using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(AdminForLoginDto adminForLoginDto)
        {
            var adminToLogin = _authService.Login(adminForLoginDto);
            if (!adminToLogin.Success)
            {
                return BadRequest(adminToLogin.Message);
            }

            var result = _authService.CreateAccessToken(adminToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(AdminForRegisterDto adminForRegisterDto)
        {
            var adminExists = _authService.AdminExists(adminForRegisterDto.Email);
            if (!adminExists.Success)
            {
                return BadRequest(adminExists.Message);
            }

            var registerResult = _authService.Register(adminForRegisterDto, adminForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
