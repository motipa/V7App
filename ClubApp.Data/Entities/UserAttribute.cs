using System;
using ClubApp.Data.Common;

namespace ClubApp.Data.Entities
{
    public  class UserAttribute : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string PasswordHash { get; set; }

        public Guid UserId { get; set; }
        public string ActivationCode { get; set; }

        public User User { get; set; }
    }
}
