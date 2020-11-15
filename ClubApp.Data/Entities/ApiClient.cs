using System.Collections.Generic;
using ClubApp.Data.Common;

namespace ClubApp.Data.Entities
{
    public partial class ApiClient : EntityBase
    { 
        public string Name { get; set; }

        public string Secret { get; set; }

        public bool IsSecured { get; set; }

        public bool IsActive { get; set; }

        public int AccessTokenLifeTimeMin { get; set; }

        public int RefreshTokenLifeTimeMin { get; set; }

        public ICollection<ApiRefreshToken> ApiRefreshTokens { get; set; } = new HashSet<ApiRefreshToken>();
    }
}
