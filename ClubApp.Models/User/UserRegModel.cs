using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Models.User
{
    public class UserRegModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public bool IsVerified { get; set; }
        public bool IsEnabled { get; set; }
        public string Password { get; set; }
    }
}
