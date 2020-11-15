using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ClubApp.Common.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetRole(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst(ClaimTypes.Role);

            return claim?.Value;
        }

        public static string GetName(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst(ClaimTypes.Name);

            return claim?.Value;
        }

        public static string GetTenantName(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst(Consts.TENANT_NAME_CLAIMTYPE);

            return claim?.Value;
        }

        public static string GetTenantDatabaseName(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst(Consts.TENANT_DB_CLAIMTYPE);

            return claim?.Value;
        }

        public static string GetApplicationName(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst(Consts.APPLICATION_NAME_CLAIMTYPE);

            return claim?.Value;
        }

        public static Guid GetId(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
            {
                return Guid.Empty;
            }

            Guid.TryParse(claim.Value, out var id);

            return id;
        }

        public static Guid GetTenantId(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst(Consts.TENANT_ID_CLAIMTYPE);

            if (claim == null)
            {
                return Guid.Empty;
            }

            Guid.TryParse(claim.Value, out var id);

            return id;
        }

        public static Guid GetApplicationId(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst(Consts.APPLICATION_ID_CLAIMTYPE);

            if (claim == null)
            {
                return Guid.Empty;
            }

            Guid.TryParse(claim.Value, out var id);

            return id;
        }
    }
}
