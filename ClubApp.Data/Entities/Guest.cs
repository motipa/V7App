using ClubApp.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Data.Entities
{
    public class Guest : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }        
        public Guid CustomerId { get; set; }
    }
}
