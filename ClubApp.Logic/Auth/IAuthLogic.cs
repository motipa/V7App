using ClubApp.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.Auth
{
    public interface IAuthLogic
    {
        Task<AuthorizationResponseModel> AuthorizeAsync(AuthorizationModel model);
    }
}
