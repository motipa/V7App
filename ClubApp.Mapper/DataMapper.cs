using AutoMapper;
using ClubApp.Data.Entities;
using ClubApp.Models.Booking;
using ClubApp.Models.Common;
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
            CreateMap<VenueViewModel, VenueDetails>();
            CreateMap<VenueDetails, VenueViewModel>();
           // CreateMap<UserViewModel, User>();
            CreateMap<UserViewModel, UserAttribute>();

            CreateMap<VenueDetails, LookupModel<Guid>>()
              .ForMember(model => model.ValueMember, opt => opt.MapFrom(category => category.Id))
              .ForMember(model => model.DisplayMember, opt => opt.MapFrom(category => category.VenueName));

            CreateMap<VenueDetails, PickModel>()
              .ForMember(model => model.ValueMember, opt => opt.MapFrom(category => category.Id))
              .ForMember(model => model.DisplayMember, opt => opt.MapFrom(category => category.VenueName));

            CreateMap<User, UserViewModel > ()
                .ForMember(model => model.Email, opt => opt.MapFrom(inventory => inventory.Email))
               .ForMember(model => model.FirstName, opt => opt.MapFrom(inventory => inventory.UserAttribute.FirstName))
                .ForMember(model => model.PhoneNumber, opt => opt.MapFrom(inventory => inventory.UserAttribute.PhoneNumber));
                
        }
    }
}
