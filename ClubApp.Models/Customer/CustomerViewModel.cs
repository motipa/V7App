using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Models.Customer
{
    public class CustomerViewModel
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool VIP { get; set; }
    }
}
