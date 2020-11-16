using ClubApp.Logic.Auth;
using ClubApp.Logic.Login;
using ClubApp.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubApp.Api.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRegAndLogin _regandLogin;

        public LoginController(IRegAndLogin iregAndLogin)
        {
            _regandLogin = iregAndLogin;
        }
        [AllowAnonymous]
        [HttpPost("userregistration")]        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<IActionResult> Registration([FromBody] UserRegModel reg)
        {
            var resonse = await _regandLogin.UserRegistration(reg);
            return Ok(resonse);
        }
        [AllowAnonymous]
        [HttpPost("updateuser")]        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<IActionResult> UpdateUserDetails([FromBody] UserRegModel reg)
        {
            var resonse = await _regandLogin.UpdateUserDetails(reg);
            return Ok(resonse);
        }
    }
}
