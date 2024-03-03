using IdentityApi.Data;
using IdentityApi.Dtos;
using IdentityApi.Entities;
using Microsoft.AspNetCore.Authorization;
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
        private readonly RoleManager<Role> roleManager;
        private readonly DataContext dataContext;

        public AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager, DataContext datacontext, RoleManager<Role> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dataContext = datacontext;
            this.roleManager = roleManager;
        }

        [Authorize(Roles = RoleDealer.UserRole)]
        [HttpGet("whoami")]
        public async Task<ActionResult<UserDto>> WhoAmI()
        {
          var user =   await this.userManager.GetUserAsync(User);
          if (user == null)
            {
                return BadRequest();
            }



            return Ok(Mapper.MapToUserDto(user));
        }



        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(string Username, string Password)
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

            return Ok(Mapper.MapToUserDto(user));
        }


        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(string userName, string password)
        {
            if (userName == null || password == null)
            {
                return BadRequest("UserName or Password was null please enter one.");
            }
            var user = new User();           
            user.UserName = userName;

            await userManager.CreateAsync(user, password);
            await userManager.AddToRoleAsync(user,RoleDealer.UserRole);

            var cart = new Cart();

            cart.UserId = user.Id;

            this.dataContext.Carts.Add(cart);

            await this.dataContext.SaveChangesAsync();

            var userdto = Mapper.MapToUserDto(user);

            return CreatedAtAction(nameof(Register), userdto);
        }

        [Authorize(Roles = RoleDealer.ComboRole)]
        [HttpPost("removeUser")]
        public async Task<ActionResult> RemoveUser(int userId)
        {
            await this.Logout();
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound();
            }
            await userManager.DeleteAsync(user);
            return Ok();
        }



        [Authorize(Roles = RoleDealer.ComboRole)]
        [HttpPost("logout")]

        public async Task<ActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return Ok();
        }
    }
}
