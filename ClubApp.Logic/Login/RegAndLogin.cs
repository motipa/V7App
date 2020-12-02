using AutoMapper;
using ClubApp.Common.Exceptions;
using ClubApp.Data;
using ClubApp.Data.Entities;
using ClubApp.Logic.Common;
using ClubApp.Logic.Email;
using ClubApp.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.Login
{
    public class RegAndLogin : LogicBase, IRegAndLogin
    {
        private readonly IHasher _hasher;
        //private readonly IRandomizer _randomizer;
       public UserListModel objuserList { get; set; }
        public RegAndLogin(DatabaseContext db, IMapper mapper, IHasher hasher, IConfiguration config) :base(db,mapper,config)
        {
            _hasher = hasher;
           // _randomizer = randomizer;
        }

        public async Task<UserViewModel> UserRegistration(UserRegModel Reg)
        {
            try
            {
                if (Reg != null)
                {
                    string Password = await _hasher.HashAsync(Reg.Password);
                    var UserDetails = new User
                    {
                        Email = Reg.Email,
                        IsVerified = true
                    };
                    User UserSave = _mapper.Map<User>(UserDetails);
                    await _db.Users.AddAsync(UserDetails);
                    await _db.SaveChangesAsync();
                    Reg.Id = UserSave.Id;
                    UserAttribute UserAttr = _mapper.Map<UserAttribute>(Reg);
                    UserAttr.UserId = UserSave.Id;
                    UserAttr.PasswordHash = Password;
                    await _db.UserAttributes.AddAsync(UserAttr);
                    await _db.SaveChangesAsync();
                    return new UserViewModel { Email = UserSave.Email };
                }
                else
                {
                    return new UserViewModel { Exception = "Failed" };
                }
            }
            catch(Exception ex)
            {
                return new UserViewModel { Exception = ex.Message };
            }
        }
        public async Task<UserViewModel> UpdateUserDetails(UserRegModel Reg)
        {
            try
            {
                if (Reg.Id != null)
                {
                    UserAttribute objModel = new UserAttribute();
                    objModel = _db.UserAttributes.Find(Reg.Id);
                    objModel.Id = Reg.Id;
                    objModel.FirstName = Reg.FirstName;
                    objModel.LastName = Reg.LastName;
                    objModel.PhoneNumber = Reg.PhoneNumber;
                    _db.Entry(objModel).State = EntityState.Modified;
                    _db.SaveChanges();
                    return new UserViewModel { FirstName = objModel.FirstName };
                }
                else
                {
                    return new UserViewModel { Exception = "Failed" };
                }
            }
            catch(Exception ex)
            {
                return new UserViewModel { Exception = ex.Message };
            }
        }
        public async Task<UserViewModel> GetCustomerDetails(string Email)
        {
            try
            {
                var user = await _db.Users
                    .Include(u => u.UserAttribute)
                    .SingleOrDefaultAsync(u => u.Email == Email);

                if (user == null)
                {

                }
               
                return _mapper.Map<UserViewModel>(user);
            }
            catch(Exception ex)
            {
                return new UserViewModel { Exception = ex.Message };
            }
        }
        public async Task SendActivationCode(string Email)
        {
            try
            {
                SendEmail sendEmail = new SendEmail();
                var random = new Random();
                int randomnumber = random.Next();

                var user = await _db.Users
                    .Include(u => u.UserAttribute)
                    .SingleOrDefaultAsync(u => u.Email == Email);

                
                UserAttribute objModel = new UserAttribute();
                objModel = _db.UserAttributes.Find(user.Id);
                objModel.Id = objModel.Id;
                objModel.FirstName = objModel.FirstName;
                objModel.LastName = objModel.LastName;
                objModel.PhoneNumber = objModel.PhoneNumber;
                objModel.ActivationCode = randomnumber.ToString();
                _db.Entry(objModel).State = EntityState.Modified;
                _db.SaveChanges();
                //send Email Code                
                string body= "<div style='border:double;border-color:#854e4e;width:400px'>"+
                 "<span style='font-family:Arial; font-size: 10pt;' > Hello,<br /><br />" +
                 "Your Password Change Request On Process <br /><br />" +
                 "Your Activation Code : <b>"+ randomnumber + " </b ><br /> <br />Thanks <br /> " +
                 "SupportTeam </span></div >";
                await sendEmail.EmailSend(Email, "Password Change Request", body);
               
            }
            catch(Exception ex)
            {

            }
        }
        public async Task<UserViewModel> UpdatePassword(UserRegModel Reg)
        {
            try
            {
                if (Reg.ActivationCode != null)
                {
                    var user = await _db.Users
                    .Include(u => u.UserAttribute)
                    .SingleOrDefaultAsync(u => u.Email == Reg.Email);


                    UserAttribute objModel = new UserAttribute();
                    objModel = _db.UserAttributes.Find(user.Id);

                    if (objModel.ActivationCode == Reg.ActivationCode)
                    {
                    string password = await _hasher.HashAsync(Reg.Password);
                    
                    
                    objModel.Id = objModel.Id;
                    objModel.FirstName = objModel.FirstName;
                    objModel.LastName = objModel.LastName;
                    objModel.PasswordHash = password;
                    _db.Entry(objModel).State = EntityState.Modified;
                    _db.SaveChanges();
                       
                    return new UserViewModel { Exception="Success" };
                    }
                    else
                    {
                        return new UserViewModel { Exception = "failed" };
                    }
                }
                else
                {
                    return new UserViewModel { Exception = "Failed" };
                }
            }
            catch(Exception ex)
            {
                return new UserViewModel { Exception = ex.Message };
            }
        }
    }
}
