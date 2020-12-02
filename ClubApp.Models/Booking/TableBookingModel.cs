using ClubApp.Models.Customer;
using ClubApp.Models.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Models.Booking
{
    public class TableBookingModel
    {
        public Guid BookingId { get; set; }
        public DateTime BookingDateTimeFrom { get; set; }
        public DateTime BookingDateTimeTo { get; set; }
        public int NumberOfBookedTable { get; set; }
        public string TableNum { get; set; }
        public Guid CustId { get; set; }
        public Guid PaymentId { get; set; }
        public Guid VenueId { get; set; }
        public string PaymentStatus { get; set; }
        public string SpecialNote { get; set; }
        public string shisha { get; set; }
        public string Venue { get; set; }
        public SendEmail sendEmail { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
