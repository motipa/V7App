﻿using System;

namespace ClubApp.Models.User
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsVerified { get; set; }

        public Guid RoleId { get; set; }
    }
}
