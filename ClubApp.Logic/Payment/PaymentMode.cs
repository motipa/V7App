using AutoMapper;
using ClubApp.Common.Exceptions;
using ClubApp.Data;
using ClubApp.Data.Entities;
using ClubApp.Logic.Booking;
using ClubApp.Logic.Common;
using ClubApp.Models.Booking;
using ClubApp.Models.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.Payment
{
    public class PaymentMode : LogicBase,IPaymentMode
    {
        private IBookingTable _bookingTable;

        public PaymentMode(DatabaseContext db, IMapper mapper, IConfiguration config,IBookingTable ibooking) : base(db, mapper, config)
        {
            _bookingTable = ibooking;
        }

        public async Task<PaymentViewModel> SavePayementDetails(PaymentModel payment)
        {
            try
            {
                if (payment.PaymentReferenceId != null)
                {
                    PaymentDetails saveDetails = _mapper.Map<PaymentDetails>(payment);
                    await _db.paymentDetails.AddAsync(saveDetails);
                    await _db.SaveChangesAsync();
                    if (saveDetails.Status == "success")
                    {
                        TableBookingDetails objModel = new TableBookingDetails();
                        objModel = _db.TableBookigDetails.Find(saveDetails.BookingId);
                        objModel.Id = saveDetails.BookingId;
                        objModel.PaymentStatus = "SUCCESS";
                        _db.Entry(objModel).State = EntityState.Modified;
                        _db.SaveChanges();
                    }
                    return new PaymentViewModel { PaymentReferenceId = saveDetails.PaymentReferenceId };
                }
                else
                {
                    return new PaymentViewModel { Exception = "Registration Failed" };
                }
            }
            catch(Exception ex)
            {
                return new PaymentViewModel { Exception = ex.Message };
            }
        }
    }
}
