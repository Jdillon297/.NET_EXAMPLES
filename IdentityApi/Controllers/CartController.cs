using IdentityApi.Data;
using IdentityApi.Dtos;
using IdentityApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly UserManager<User> userManager;
    private readonly DataContext dataContext;

    public CartController(DataContext dataContext, UserManager<User> userManager)
    {
        this.dataContext = dataContext;
        this.userManager = userManager;
    }

    [Authorize(Roles = RoleDealer.UserRole)]
    [HttpGet]
    public async Task<ActionResult<List<BookDto>>> GetAllBooksInCart()
    {
        var user = await userManager.GetUserAsync(User);
        if (user == null)
        {
            return BadRequest();
        }

        var cart = dataContext.Carts.Include(x => x.Books)
                                    .FirstOrDefault(x => x.UserId == user.Id);
        var Books = cart.Books;


        if(Books == null)
        {
            return BadRequest();
        }           

        return Ok(Mapper.MapBooksToDtos(Books));
    }


    [Authorize(Roles = RoleDealer.UserRole)]
    [HttpPost]
    public async Task<ActionResult<BookDto>> AddBookToCart(int bookId)
    {
        var user = await userManager.GetUserAsync(User);
        if (user == null)
        {
            return BadRequest("No User Logged in.");
        }
        var userCart = await dataContext.Carts.FirstOrDefaultAsync(x => x.UserId == user.Id);

        var bookToAdd = await dataContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);

        if(bookToAdd == null)
        {
            return BadRequest("Could not find a book.");
        }

        userCart?.Books?.Add(bookToAdd);

        await dataContext.SaveChangesAsync();

        return Ok();
    }
}
