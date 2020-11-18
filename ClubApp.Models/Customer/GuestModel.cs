using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Models.Customer
{
    public class GuestModel
    {
        public Guid GuestId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public Guid CustomerId { get; set; }
    }
}
