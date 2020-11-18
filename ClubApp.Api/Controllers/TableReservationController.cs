﻿using ClubApp.Logic.Booking;
using ClubApp.Logic.Customer;
using ClubApp.Logic.CustomerDetails;
using ClubApp.Logic.Payment;
using ClubApp.Logic.Venue;
using ClubApp.Models.Booking;
using ClubApp.Models.Customer;
using ClubApp.Models.Payment;
using ClubApp.Models.Venue;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubApp.Api.Controllers
{
    [Route("api/reserve")]
    [ApiController]
    public class TableReservationController : ControllerBase
    {
        private readonly ICustomerReg _customerReg;
        private readonly IGuestReg _guestReg;
        private readonly IBookingTable _bookingTable;
        private readonly IVenueModel _venueDetails;
        private readonly IPaymentMode _paymentMode;

        public TableReservationController(ICustomerReg icustomerReg,IGuestReg iguestReg,IBookingTable ibookingTable,IVenueModel ivenue,IPaymentMode ipayment)
        {
            _customerReg = icustomerReg;
            _guestReg = iguestReg;
            _bookingTable = ibookingTable;
            _venueDetails = ivenue;
            _paymentMode = ipayment;
        }
        [AllowAnonymous]
        [HttpPost("regcustomer")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerModel cust)
        {
            var resonse = await _customerReg.AddCustomer(cust);
            return Ok(resonse);
        }
        [AllowAnonymous]
        [HttpPost("guestreg")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<IActionResult> UpdateUserDetails([FromBody] GuestModel guest)
        {
            var resonse = await _guestReg.AddGuest(guest);
            return Ok(resonse);
        }
        [AllowAnonymous]
        [HttpPost("tablebooking")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<IActionResult> BookingTable([FromBody] TableBookingModel bookTable)
        {
            var resonse = await _bookingTable.TableBooking(bookTable);
            return Ok(resonse);
        }
        [AllowAnonymous]
        [HttpPost("addvenue")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<IActionResult> AddVenue([FromBody] VenueDetailsModel bookTable)
        {
            var response = await _venueDetails.AddVenueDetails(bookTable);
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost("savepaymentdetails")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<IActionResult> SavePayment([FromBody] PaymentModel payment)
        {
            var response = await _paymentMode.SavePayementDetails(payment);
            return Ok(response);
        }
        
    }
}
