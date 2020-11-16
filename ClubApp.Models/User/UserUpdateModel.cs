using System;

namespace Rti.eP360.Console.Models.User
{
    public class UserUpdateModel
    {
        public Guid RoleId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
