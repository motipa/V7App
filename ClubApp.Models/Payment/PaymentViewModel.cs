using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Models.Payment
{
   public class PaymentViewModel
    {
        public Guid CustId { get; set; }
        public Guid BookingId { get; set; }
        public string PaymentReferenceId { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
