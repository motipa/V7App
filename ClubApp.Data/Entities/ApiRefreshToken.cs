using System;
using ClubApp.Data.Common;

namespace ClubApp.Data.Entities
{
    public  class ApiRefreshToken : EntityBase
    {
        public DateTime IssuedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public string Value { get; set; }

        public Guid ApiClientId { get; set; }

        public ApiClient ApiClient { get; set; }

    

       
    }
}
