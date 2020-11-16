using AutoMapper;
using Microsoft.Extensions.Configuration;
using ClubApp.Common;
using ClubApp.Common.Exceptions;
using ClubApp.Data;
using ClubApp.Data.Entities;
using ClubApp.Logic.Common;
using ClubApp.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.Auth
{
    public class AuthLogic : LogicBase, IAuthLogic
    {
        private readonly IHasher _hasher;
        private readonly IRandomizer _randomizer;
        

        public AuthLogic(DatabaseContext db, IMapper mapper, IHasher hasher, IRandomizer randomizer, IConfiguration config) : base(db, mapper,config)
        {
            _hasher = hasher;
            _randomizer = randomizer;           
          
        }

        public async Task<AuthorizationResponseModel> AuthorizeAsync(AuthorizationModel model)
        {
            if (model.AuthorizationType == _config["AuthorizationType:CredentialsType"])
            {
                //string res = await _hasher.HashAsync(model.Password);
                return await AuthorizeBasedOnCredentialsAsync(model.Login, model.Password, model.ApplicationId.Value, model.TenantId, model.Client, model.ClientSecret);
            }
            else if (model.AuthorizationType == _config["AuthorizationType:RefreshTokenType"])
            {
                //  return await AuthorizeBasedOnRefreshTokenAsync(model.RefreshToken);
                return null;
            }
           
            else
            {
                throw new ConsoleCommonException("Invalid authorization type");
            }
        }

        private async Task<AuthorizationResponseModel> AuthorizeBasedOnCredentialsAsync(string login, string password, Guid applicationId, Guid? tenantId, string client, string clientSecret)
        {
            var user = await _db.Users
                .Include(u => u.UserAttribute)
               
                .SingleOrDefaultAsync(u => u.Email == login);

            if (user == null)
            {
                throw new ConsoleNotFoundException("Account with the specified email address was not found");
            }

            if (!user.IsVerified)
            {
                throw new ConsoleNotAllowedException("Account was not verified");
            }

            if (!await _hasher.VerifyAsync(password, user.UserAttribute.PasswordHash))
            {
                throw new ConsoleNotFoundException("Account with the specified password was not found");
            }


            var apiClient = await _db.ApiClients
                .SingleOrDefaultAsync(c => c.Name == client);

            if (apiClient == null)
            {
                throw new ConsoleNotFoundException("Api client with provided name was not found");
            }

            if (apiClient.IsSecured)
            {
                if (apiClient.Secret != clientSecret)
                {
                    throw new ConsoleNotFoundException("Api client with provided secret was not found");
                }
            }

            if (!apiClient.IsActive)
            {
                throw new ConsoleNotAllowedException("Api client is inactive");
            }


            return new AuthorizationResponseModel
            {
                AccessToken = await GenerateAccesTokenAsync(user, apiClient),
                RefreshToken = await GenerateRefreshTokenAsync(user, apiClient)
            };
        }
        private Task<string> GenerateAccesTokenAsync(User join, ApiClient apiClient)
        {
            return Task.Factory.StartNew(() =>
            {
                var now = DateTime.UtcNow;
                var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:JwtSecret"]));

                var jwtToken = new JwtSecurityToken(
                    issuer: _config["Jwt:JwtIssuer"],
                    claims: CreateUserClaims(join),
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(apiClient.AccessTokenLifeTimeMin)),
                    signingCredentials: new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256));

                return new JwtSecurityTokenHandler().WriteToken(jwtToken);
            });
        }
        private Claim[] CreateUserClaims(User join)
        {
            return new Claim[] {
                new Claim(JwtRegisteredClaimNames.Sub, join.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{join.UserAttribute.FirstName} {join.UserAttribute.LastName}"),
              
            };
        }
        private async Task<string> GenerateRefreshTokenAsync(User join, ApiClient apiClient)
        {
            var refreshToken = await _db.ApiRefreshTokens
                .SingleOrDefaultAsync(token =>  token.ApiClientId == apiClient.Id);

            if (refreshToken == null)
            {
                refreshToken = new ApiRefreshToken()
                {
                  
                    ApiClientId = apiClient.Id,
                    IssuedAt = DateTime.UtcNow,
                    ExpiresAt = DateTime.UtcNow.AddMinutes(apiClient.RefreshTokenLifeTimeMin),
                    Value = (await _randomizer.GetRandomStringAsync())
                };

                _db.ApiRefreshTokens.Add(refreshToken);
            }
            else
            {
                refreshToken.IssuedAt = DateTime.UtcNow;
                refreshToken.ExpiresAt = DateTime.UtcNow.AddMinutes(apiClient.RefreshTokenLifeTimeMin);
                refreshToken.Value = (await _randomizer.GetRandomStringAsync());

                _db.ApiRefreshTokens.Update(refreshToken);
            }

            await _db.SaveChangesAsync();

            return refreshToken.Value;
        }

    }
}
