using ClubApp.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Data.Entities
{
    public class PaymentDetails : EntityBase
    {        
        public string PaymentReferenceId { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public Guid CustId { get; set; }
        public Guid BookingId { get; set; }
    }
}
