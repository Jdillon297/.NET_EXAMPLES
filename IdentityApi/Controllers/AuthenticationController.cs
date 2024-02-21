using IdentityApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpGet("whoami")]
        public async Task<IActionResult> WhoAmI()
        {
          var user =   await this.userManager.GetUserAsync(User);

            return Ok(user);
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(string Username, string Password)
        {
            var user = await this.userManager.FindByNameAsync(Username);

            if (user == null)
            {
                return BadRequest();
            }

            var result = await this.signInManager.CheckPasswordSignInAsync(user, Password, false);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            await signInManager.SignInAsync(user, false);

            return Ok();
        }


        [HttpPost("logout")]

        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return Ok();
        }
    }
}
