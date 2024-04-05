using BlusukYogya.BLL.DTO;
using BlusukYogya.BLL.Interface;
using BlusukYogya.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlusukYogya.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleBLL _role;
        public RolesController(IRoleBLL roleBLL)
        {
            _role = roleBLL;
        }

        [HttpPost("InsertNew")]
        public async Task<IActionResult> InsertNewRole(RoleCreateDTO roleCreateDTO)
        {
            {
                var result = await _role.AddRole(roleCreateDTO);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPost("AddRoleToUser")]
        public async Task<IActionResult> AddRoleToUser(int userId, int roleId)
        {
            {
                var result = await _role.AddUserToRole(userId, roleId);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            {
                var result = await _role.GetAllRoles();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
