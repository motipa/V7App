using AutoMapper;
using ClubApp.Data.Entities;
using ClubApp.Models.User;
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
        }
    }
}
