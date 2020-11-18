using ClubApp.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Data.Entities
{
    public class TableBookingDetails : EntityBase
    {
        public Guid BookingId { get; set; }
        public DateTime BookingDateTimeFrom { get; set; }
        public DateTime BookingDateTimeTo { get; set; }
        public int NumberOfBookedTable { get; set; }
        public string TableNum { get; set; }
        public string PaymentStatus { get; set; }
        public Guid CustId { get; set; }
        public Guid PaymentId { get; set; }
        public Guid VenueId { get; set; }
    }
}
