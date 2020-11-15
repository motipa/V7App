using ClubApp.Data.Entities;
using System;
using System.Linq;

namespace ClubApp.Data.Extensions
{
    public static class EntitiesExtensions
    {
        public static bool HasAnyTenantForApplication(this User user, Guid applicationId)
        {
            return user.UserTenantApplicationRoles != null
                && user.UserTenantApplicationRoles.Count(join => join.IsEnabled && join.ApplicationId == applicationId) != 0;
        }

        public static bool HasSingleTenantForApplication(this User user, Guid applicationId)
        {
            return user.UserTenantApplicationRoles.Count(join => join.IsEnabled && join.ApplicationId == applicationId) == 1;
        }
    }
}
