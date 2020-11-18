using AutoMapper;
using ClubApp.Common.Exceptions;
using ClubApp.Data;
using ClubApp.Data.Entities;
using ClubApp.Logic.Common;
using ClubApp.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.Login
{
    public class RegAndLogin : LogicBase, IRegAndLogin
    {
        private readonly IHasher _hasher;
        //private readonly IRandomizer _randomizer;

        public RegAndLogin(DatabaseContext db, IMapper mapper, IHasher hasher, IConfiguration config) :base(db,mapper,config)
        {
            _hasher = hasher;
           // _randomizer = randomizer;
        }

        public async Task<UserViewModel> UserRegistration(UserRegModel Reg)
        {
            if(Reg!=null)
            {
                string Password= await _hasher.HashAsync(Reg.Password);
                var UserDetails = new User
                {
                    Email = Reg.Email,                   
                    IsVerified = true
                };
                User UserSave = _mapper.Map <User>(UserDetails);                
                await _db.Users.AddAsync(UserDetails);
                await _db.SaveChangesAsync();                
                Reg.Id= UserSave.Id;
                UserAttribute UserAttr = _mapper.Map<UserAttribute>(Reg);
                UserAttr.UserId = UserSave.Id;
                UserAttr.PasswordHash= Password;
                await _db.UserAttributes.AddAsync(UserAttr);
                await _db.SaveChangesAsync();
                return new UserViewModel { Email = UserSave.Email };
            }
            else
            {
                throw new ConsoleCommonException("Registration Failed");
            }
        }
        public async Task<UserViewModel> UpdateUserDetails(UserRegModel Reg)
        {
            if (Reg.Id != null)
            {
                UserAttribute objModel = new UserAttribute();
                objModel = _db.UserAttributes.Find(Reg.Id);
                objModel.Id = Reg.Id;
                objModel.FirstName = Reg.FirstName;
                objModel.LastName = Reg.LastName;                
                _db.Entry(objModel).State = EntityState.Modified;               
                _db.SaveChanges();
                return new UserViewModel { FirstName = objModel.FirstName };
            }
            else
            {
                throw new ConsoleCommonException("Update Failed");
            }
        }
    }
}
