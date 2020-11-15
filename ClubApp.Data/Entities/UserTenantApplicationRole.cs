using System;
using System.Collections.Generic;
using ClubApp.Data.Common;

namespace ClubApp.Data.Entities
{
    public  class UserTenantApplicationRole : EntityBase
    {     
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid TenantId { get; set; }

       
        public Guid ApplicationId { get; set; }

       

        public Guid ApplicationRoleId { get; set; }

        

        public bool IsEnabled { get; set; }

        public ICollection<ApiRefreshToken> ApiRefreshTokens { get; set; } = new HashSet<ApiRefreshToken>();
    }
}
