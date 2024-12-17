using ECommerce.DTO;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Registration(ApplicationUserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    
                    UserName = userDTO.Name,
                    Email = userDTO.Email,
                    

                };

                var result = await userManager.CreateAsync(user, userDTO.Password);
                await userManager.AddToRoleAsync(user, "User");
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, true);
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            return Unauthorized();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(userLoginDTO.UserName);
                if (user != null)
                {
                    var check = await userManager.CheckPasswordAsync(user, userLoginDTO.Password);
                    if (check)
                    {
                        await signInManager.SignInAsync(user, userLoginDTO.RememberMe);
                        return Ok("Login successful");
                    }
                    ModelState.AddModelError("invalidPass", "invalid Password");
                }
                else
                {
                    ModelState.AddModelError("invalidName", "invalid Name");
                }
            }
            return BadRequest();
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout() { 
            await signInManager.SignOutAsync();
            return Ok("Logout successful");
        }
    }
}
