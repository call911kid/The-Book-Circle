using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The_Book_Circle._02.Business_Logic_Layer.DTOs;
using The_Book_Circle._02.Business_Logic_Layer.Interfaces;
using The_Book_Circle.DTOs;

namespace The_Book_Circle._03.Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {

            var result = await _accountService.RegisterAsync(registerDto);

            return StatusCode(result.StatusCode, result.IsSuccess ? result.Data : result.Error);

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _accountService.LoginAsync(loginDto);

            return StatusCode(result.StatusCode, result.IsSuccess ? result.Data : result.Error);
        }
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAsync([FromBody] LogoutDto logoutDto)
        {
            var result = await _accountService.LogoutAsync(logoutDto.RefreshToken);
            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.Error);
            }
            return Ok();
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] string token)
        {
            var result = await _accountService.RefreshTokenAsync(token);

            return StatusCode(result.StatusCode, result.IsSuccess ? result.Data : result.Error);
        }

    }
}
