using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RememberTask.Models;
using RememberTask.Service;

namespace RememberTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;
        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [Route("Get all roles")]
        [HttpGet]
        public async Task<ActionResult<User>> GetAllRoles()
        {
            return Ok(await _roleService.GetAll());
        }
        [Route("By id")]
        [HttpGet]
        public async Task<IActionResult> GetByID(int id)
        {
            return Ok(await _roleService.GetByID(id));
        }

        [Route("Add user")]
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddRoles(Role role)
        {
            return Ok(await _roleService.Create(role));
        }

        [Route("Update user")]
        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateRoles(Role role, int id)
        {
            return Ok(await _roleService.Update(id, role));
        }

        [Route("Delete user")]
        [HttpDelete]
        public async Task<ActionResult<List<User>>> DeleteRoles(int id)
        {
            return Ok(await _roleService.Delete(id));
        }

    }
}