using System;
using ClubApp.Data.Common;

namespace ClubApp.Data.Entities
{
    public  class UserPasswordReset : EntityBase
    {
        public DateTime RequestedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public string Value { get; set; }

        public bool IsActive { get; set; }

        public bool IsCompleted { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
