using ClubApp.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Data.Entities
{
    public class TableBookingDetails : EntityBase
    {        
        public DateTime BookingDateTimeFrom { get; set; }
        public DateTime BookingDateTimeTo { get; set; }
        public int NumberOfBookedTable { get; set; }
        public string TableNum { get; set; }
        public string PaymentStatus { get; set; }
        public string Shisha { get; set; }
        public string Venue { get; set; }
        public Guid CustId { get; set; }
        public Guid PaymentId { get; set; }
        public Guid VenueId { get; set; }
        public string SpecialNote { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
