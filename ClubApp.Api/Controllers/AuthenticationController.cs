using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClubApp.Logic.Auth;
using ClubApp.Logic.Common;
using ClubApp.Models.Auth;

namespace ClubApp.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthLogic _authLogic;
     //   private readonly IEmailClient _emailClient;

        public AuthenticationController(IAuthLogic authLogic)
        {
            _authLogic = authLogic;
           
        }

        [AllowAnonymous]
        [HttpPost("authorize")]
        [ProducesResponseType(typeof(AuthorizationResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<IActionResult> Authorize([FromBody] AuthorizationModel model)
        {
            var resonse = await _authLogic.AuthorizeAsync(model);
            return Ok(resonse);
        }

    }
}
