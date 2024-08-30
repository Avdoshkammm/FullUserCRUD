using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RememberTask.Models;
using RememberTask.Service;

namespace RememberTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        public UserController(UserService _userService)
        {
            userService = _userService;
        }

        [HttpGet("Get all users")]
        public async Task<ActionResult<User>> AllUsers()
        {
            return Ok(await userService.GetAllUsers());
        }

        [HttpGet("Get by id")]
        public async Task<IActionResult> UserByID(int id)
        {
            return Ok(await userService.GetUser(id));
        }

        [HttpPost("Add user")]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            return Ok(await userService.CreateUser(user));
        }

        [HttpPut("Edit user")]
        public async Task<ActionResult<List<User>>> UpdateUser(User user, int id)
        {
            return Ok(await userService.UpdateUser(id, user));
        }

        [HttpDelete("Delete user")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            return Ok(await userService.DeleteUser(id));
        }
    }
}
