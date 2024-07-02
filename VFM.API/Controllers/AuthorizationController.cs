using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VFM.Core.Interfaces;

namespace VFM.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorizationController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService authService = authService;
        [HttpPost("Register")]
        public async Task<ActionResult> Register(string Email, string Password)
        {
            return await authService.Register(Email, Password) ? Ok() : BadRequest();
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(string Email, string Password)
        {
           string token = await authService.Authorization(Email, Password);

            return string.IsNullOrEmpty(token) ? BadRequest("Не верный логин или пароль") : Ok(token);
        }

    }
}
