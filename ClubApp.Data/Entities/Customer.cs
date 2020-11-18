using ClubApp.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Data.Entities
{
   public class Customer : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool VIP { get; set; }
    }
}
