using AutoMapper;
using ClubApp.Common.Exceptions;
using ClubApp.Data;
using ClubApp.Data.Entities;
using ClubApp.Logic.Common;
using ClubApp.Logic.Email;
using ClubApp.Models.Booking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Mail;
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
                try
                {
                    SendEmail sendEmail = new SendEmail();
                    TableBookingDetails _tableBookingDetails = _mapper.Map<TableBookingDetails>(table);
                   await _db.TableBookigDetails.AddAsync(_tableBookingDetails);               
                   int a= await _db.SaveChangesAsync();
                    ///////////////////////////////
                    if (a > 0)
                    {
                        string body = "<table border='1' style='border-collapse: collapse;background-color:#85c4f3; margin: 25px 0; font-size: 0.9em; font-family:sans-serif; min-width: 500px; min-height:260px'>" +
                          "<tr><td colspan='2'  style='color:#6c2550; text-align:center;font-weight:bold'>Table Reservation Request</td></tr>" +
                        "<tr><td style='text-align:center'>Name</td><td style='text-align:center'>" + table.Customer.Name + "</td></tr>" +
                        "<tr><td style='text-align:center'>Email</td><td style='text-align:center'>" + table.Customer.Email + "</td></tr>" +
                        "<tr><td style='text-align:center'>Phone</td><td style='text-align:center'>" + table.Customer.Phone + "</td></tr>" +
                        "<tr><td style='text-align:center'>Venue</td><td style='text-align:center'>" + table.Venue + "</td></tr>" +
                        "<tr><td style='text-align:center'>From Date & Time</td><td style='text-align:center'>" + table.BookingDateTimeFrom + "</td></tr>" +
                        "<tr><td style='text-align:center'>To Date & Time</td><td style='text-align:center'>" + table.BookingDateTimeTo + "</td></tr>" +
                        "<tr><td style='text-align:center'>Shisha</td><td style='text-align:center'>" + table.shisha + "</td></tr>" +
                        "<tr><td style='text-align:center'>Preffered Table</td><td>" + table.TableNum + "</td></tr>" +
                        "<tr><td style='text-align:center'>Request Note</td><td style='text-align:center'>" + table.SpecialNote + "</td></tr>" +
                        "</table>";
                       await sendEmail.EmailSend(table.sendEmail.toEmail, table.sendEmail.subject, body);
                        
                    }
                }
                catch(Exception ex)
                {
                    return new BookingViewModel { Exception =ex.Message };

                }
                return new BookingViewModel { Exception = "Success" };
                
            }
            else
            {
                return new BookingViewModel { Exception = "Failed" };

            }
        }
        
    }
}
