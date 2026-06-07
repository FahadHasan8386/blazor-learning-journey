using argosync.Api.Models;
using argosync.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace argosync.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegisterRequest request)
        {
            await _auth.RegisterAsync(request);

            return Ok("Registration Successful");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginRequest request)
        {
            var token = await _auth.LoginAsync(request);

            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
    }
}
