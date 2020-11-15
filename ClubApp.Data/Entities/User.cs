using System.Collections.Generic;
using ClubApp.Data.Common;

namespace ClubApp.Data.Entities
{
    public  class User : EntityBase
    {
        public string Email { get; set; }

        public bool IsVerified { get; set; }

        public UserAttribute UserAttribute { get; set; }

        public UserInvitation UserInvitation { get; set; }

        public ICollection<UserTenantApplicationRole> UserTenantApplicationRoles { get; set; } = new HashSet<UserTenantApplicationRole>();

        public ICollection<UserPasswordReset> UserPasswordResets { get; set; } = new HashSet<UserPasswordReset>();
    }
}
