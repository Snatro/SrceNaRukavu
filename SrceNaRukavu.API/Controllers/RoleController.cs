using Microsoft.AspNetCore.Mvc;
using SrceNaRukavu.Application.Roles;
using SrceNaRukavu.Application.Roles.Models;

namespace SrceNaRukavu.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet(Name = nameof(GetRoles))]
        public async Task<IReadOnlyList<RoleDTO>> GetRoles(CancellationToken token)
        {
            return await roleService.GetRoles(token);
        }

        [HttpGet("{id}",Name =nameof(GetRolesById))]
        public async Task<IActionResult> GetRolesById([FromRoute] int id, CancellationToken token)
        {
            RoleDTO role =  await roleService.GetRoleByID(id, token);
            return role != null ? Ok(role) : NotFound(); 
        }

    }
}
