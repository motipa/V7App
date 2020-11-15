using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClubApp.Api.Extensions;
using ClubApp.Data;
using ClubApp.Logic.Common;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ClubApp.Api
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(opt =>
                {
                    opt.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    opt.RegisterValidatorsFromAssembly(Assembly.Load(_config["ModelValidationAssembly"]));
                })
                .AddNewtonsoftJson();

            services.AddDbContext<DatabaseContext>(opt =>
            {
                opt.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
            });

            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt => {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _config["Jwt:JwtIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:JwtSecret"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddHttpClient<ApplicationHttpClient>();

            services.AddAuthorization(opt =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                opt.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();

                opt.AddPolicy("ListenerServicePolicy", policyConfig =>
                {
                    policyConfig.RequireAuthenticatedUser();
                    policyConfig.RequireRole("LSClient");
                });
            });

            services.TryAddScoped<IHasher, Hasher>();
            services.TryAddScoped<IRandomizer, Randomizer>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           
        

            services.AddAutoMapper(Assembly.Load(_config["MapperAssembly"]));
            services.RegisterLogicAssembly(_config["LogicAssembly"]);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policyBuilder =>
                {
                    policyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithExposedHeaders("Content-Disposition")
                    .AllowAnyMethod();

                });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsEnvironment("Local"))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseReadableRequestBody();

                app.UseApiExceptionHandler();
            }

            app.UseSwagger();

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "eP360 Web Api");
            });

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
