using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ClubApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, configBuilder) =>
            {
                var env = hostContext.HostingEnvironment;

                if (env.IsEnvironment("Local"))
                {
                    configBuilder.AddUserSecrets(Assembly.GetExecutingAssembly());
                }
            })
            .UseSerilog((hostContext, logging) => {
                logging.ReadFrom.Configuration(hostContext.Configuration);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
