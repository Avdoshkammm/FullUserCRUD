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
        [Route("Get all users")]
        [HttpGet]
        public async Task<ActionResult<User>> AllUsers()
        {
            return Ok(await userService.GetAll());
        }

        [Route("Get user by id")]
        [HttpGet]
        public async Task<IActionResult> UserByID(int id)
        {
            return Ok(await userService.GetByID(id));
        }

        [Route("Add new user")]
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            return Ok(await userService.Create(user));
        }

        [Route("Edit user")]
        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User user, int id)
        {
            return Ok(await userService.Update(id, user));
        }

        [Route("Delete user by id")]
        [HttpDelete]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            return Ok(await userService.Delete(id));
        }
    }
}