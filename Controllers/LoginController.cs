using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RememberTask.Models;
using RememberTask.Service;

namespace RememberTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginServce;
        public LoginController(LoginService loginService)
        {
            _loginServce = loginService;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Get(string login, string password)
        {
            return Ok(await _loginServce.Login(login, password));
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            return Ok(await _loginServce.Register(user));
        }

        [Route("Verify")]
        [HttpPost]
        public async Task<IActionResult> PostVerify( int id)
        {
            return Ok(await _loginServce.Verify( id));
        }
    }
}
