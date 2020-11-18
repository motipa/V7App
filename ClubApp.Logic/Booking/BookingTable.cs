using AutoMapper;
using ClubApp.Common.Exceptions;
using ClubApp.Data;
using ClubApp.Data.Entities;
using ClubApp.Logic.Common;
using ClubApp.Models.Booking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.Booking
{
    public class BookingTable : LogicBase, IBookingTable
    {
        public BookingTable(DatabaseContext db, IMapper mapper, IConfiguration config) : base(db, mapper, config)
        {

        }
       
        public async Task<BookingViewModel> TableBooking(TableBookingModel table)
        {
            if(table.TableNum!=null)
            {
                TableBookingDetails _tableBookingDetails = _mapper.Map<TableBookingDetails>(table);
                await _db.TableBookigDetails.AddAsync(_tableBookingDetails);               
                await _db.SaveChangesAsync();
                return new BookingViewModel { BookingId = _tableBookingDetails.Id };
            }
            else
            {
                throw new ConsoleCommonException("Booking Failed");
            }
        }
    }
}
