using ECommerce.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpPost("createRole")]
        public async Task<IActionResult> Create(UserRoleDTO userRoleDTO)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole(userRoleDTO.Name);
                var result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Role");
                }

            }
            return BadRequest();
        }
    }
}
