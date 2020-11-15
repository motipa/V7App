using System;

namespace ClubApp.Common
{
    public class ApiPrincipal
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public Guid TenantId { get; set; }

        public string TenantName { get; set; }

        public string TenantDatabaseName { get; set; }

        public Guid ApplicationId { get; set; }

        public string ApplicationName { get; set; }

        public string RawAccessToken { get; set; }
    }
}
