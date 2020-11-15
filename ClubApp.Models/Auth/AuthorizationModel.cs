using System;
namespace ClubApp.Models.Auth
{
    public class AuthorizationModel
    {
        public string AuthorizationType { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Client { get; set; }

        public string ClientSecret { get; set; }

        public string RefreshToken { get; set; }

        public Guid? ApplicationId { get; set; }

        public Guid? TenantId { get; set; }

        public string ListenerServiceName { get; set; }

        public string IntegrationPartnerName { get; set; }

        public string IntegrationPartnerSecret { get; set; }
    }
}
