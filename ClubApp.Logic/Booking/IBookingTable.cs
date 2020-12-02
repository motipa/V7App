using ClubApp.Models.Booking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.Booking
{
    public interface IBookingTable
    {
        Task<BookingViewModel> TableBooking(TableBookingModel table);
       
    }
}
