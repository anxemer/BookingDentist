using BookingDentist.Business.BusinessLogic;
using BookingDentist.Business.Common.Payload.Request;
using BookingDentist.DataAccess;
using BookingDentist.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookingDentist.API.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly LoginBusiness _login;

        public LoginController(LoginBusiness login) {
            _login = login;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var loginResult = await _login.Login(login);
            if(loginResult == null)
            {
                return NotFound();
            }
            return Ok(loginResult);
        }
    }
}
