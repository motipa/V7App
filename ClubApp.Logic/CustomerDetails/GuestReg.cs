using AutoMapper;
using ClubApp.Common.Exceptions;
using ClubApp.Data;
using ClubApp.Data.Entities;
using ClubApp.Logic.Common;
using ClubApp.Models.Customer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.Customer
{
    public class GuestReg: LogicBase, IGuestReg
    {
        public GuestReg(DatabaseContext db,IMapper mapper, IConfiguration config) : base(db, mapper, config)
        {

        }

        public async Task<GuestViewModel> AddGuest(GuestModel model)
        {
            if (model.CustomerId != null)
            {
                Guest SaveGuest = _mapper.Map<Guest>(model);
                await _db.Guests.AddAsync(SaveGuest);
                await _db.SaveChangesAsync();               
                return new GuestViewModel { Name = SaveGuest.Name };
            }
            else
            {
                throw new ConsoleCommonException("Registration Failed");
            }
        }
    }
}
