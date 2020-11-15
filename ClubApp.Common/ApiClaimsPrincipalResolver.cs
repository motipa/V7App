using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using ClubApp.Common.Extensions;

namespace ClubApp.Common
{
    public class ApiClaimsPrincipalResolver : IApiPrincipalResolver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiClaimsPrincipalResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ApiPrincipal Resolve()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            var claimsPrincipal = httpContext.User;

            if (claimsPrincipal == null)
            {
                return null;
            }

            return new ApiPrincipal
            {
                Id = claimsPrincipal.GetId(),
                Name = claimsPrincipal.GetName(),
                Role = claimsPrincipal.GetRole(),
                TenantId = claimsPrincipal.GetTenantId(),
                TenantName = claimsPrincipal.GetTenantName(),
                TenantDatabaseName = claimsPrincipal.GetTenantDatabaseName(),
                ApplicationId = claimsPrincipal.GetApplicationId(),
                ApplicationName = claimsPrincipal.GetApplicationName(),
                RawAccessToken = httpContext.GetTokenAsync("access_token").Result
            };
        }
    }
}
