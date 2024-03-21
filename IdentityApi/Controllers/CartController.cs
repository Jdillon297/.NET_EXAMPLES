using IdentityApi.Dtos;
using IdentityApi.Entities;
using IdentityApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly UserManager<User> userManager;
    private readonly CartService cartService;

    public CartController(UserManager<User> userManager, CartService cartService)
    {
        this.userManager = userManager;
        this.cartService = cartService;
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
        var Books = cartService.GetAllBooksInCart(user);
        if (Books == null)
        {
            return BadRequest();
        }

        return Ok(Books);
    }


    [Authorize(Roles = RoleDealer.UserRole)]
    [HttpPost]
    public async Task<ActionResult<BookDto>> AddBookToCart(int bookId)
    {
        var user = await userManager.GetUserAsync(User);
        if(user == null)
        {
            return BadRequest("user is null.");
        }
        try
        {
            await this.cartService.AddBookToCart(user, bookId);
        }
        catch (Exception ex)
        {

            return BadRequest($"This is what happened: {ex} ");
        }

        return Ok();
    }
    [Authorize(Roles = RoleDealer.UserRole)]
    [HttpPut]
    public async Task<ActionResult> RemoveBookFromCart(int bookId)
    {
        var user = await userManager.GetUserAsync(User);

        if(user == null)
        {
            return BadRequest("User is Null");
        }
        try
        {
            await cartService.RemoveBookFromCart(user, bookId);
        }
        catch (Exception ex)
        {

            return BadRequest($"This is what happened: {ex}");
        }

        return Ok();
    }
}
