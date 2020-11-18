using AutoMapper;
using ClubApp.Data.Entities;
using ClubApp.Models.Booking;
using ClubApp.Models.Customer;
using ClubApp.Models.User;
using ClubApp.Models.Venue;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Mapper
{
    public class DataMapper:Profile
    {
        public DataMapper()
        {
            CreateMap<UserRegModel, User>();
            CreateMap<UserRegModel, UserAttribute>();
            CreateMap<CustomerModel, Customer>();
            CreateMap<GuestModel, Guest>();
            CreateMap<TableBookingModel, TableBookingDetails>();
            CreateMap<VenueDetailsModel, VenueDetails>();
        }
    }
}
