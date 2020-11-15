
using ClubApp.Models.Common;
using System;
using System.Collections.Generic;


namespace ClubApp.Models.Auth
{
    public class AuthorizationResponseModel
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public bool MultiTenant { get; set; } = false;

        public IEnumerable<LookupModel<Guid>> AvailableTenants { get; set; } = new HashSet<LookupModel<Guid>>();
    }
}
