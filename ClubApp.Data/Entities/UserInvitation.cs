using System;
using ClubApp.Data.Common;

namespace ClubApp.Data.Entities
{
    public  class UserInvitation : EntityBase
    {
        public string Value { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
