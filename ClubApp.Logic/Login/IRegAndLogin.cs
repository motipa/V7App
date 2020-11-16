using ClubApp.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.Login
{
    public interface IRegAndLogin
    {
        Task<UserViewModel> UserRegistration(UserRegModel Reg);
        Task<UserViewModel> UpdateUserDetails(UserRegModel Reg);
    }
}
