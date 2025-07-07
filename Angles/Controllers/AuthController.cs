using Angles.BL.DTOs;
using Angles.BL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Angles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.SignUpAsync(signUpDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto signInDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.SignInAsync(signInDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpGet("Profile")]
        public async Task<IActionResult> Profile(string userId)
        {


            var result = await _authService.GetProfileDataAsync(userId);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}