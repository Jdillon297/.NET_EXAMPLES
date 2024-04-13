using IdentityApi.Data;
using IdentityApi.Dtos;
using IdentityApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Services;

public class CartService
{
    private readonly DataContext dataContext;

    public CartService(DataContext dataContext)
    {

        this.dataContext = dataContext;

    }
    public IEnumerable<BookDto> GetAllBooksInCart(User user)
    {
        if (user == null)
        {
            return null;
        }

        var cart = dataContext.Carts.Include(x => x.CartBooks)
                                    .ThenInclude(x => x.Book)
                                    .FirstOrDefault(x => x.UserId == user.Id);

        var Books = cart?.CartBooks.Select(x => x.Book)
                                  .ToList();


        if (Books == null)
        {
            return null;
        }

        return Mapper.MapBooksToDtos(Books);
    }

    public async Task AddBookToCart(User user, int bookId)
    {
        if (user == null)
        {
            return;
        }
        var userCart = await dataContext.Carts.FirstOrDefaultAsync(x => x.UserId == user.Id);

        var bookToAdd = await dataContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);

        if (bookToAdd == null)
        {
            return;
        }

        userCart?.CartBooks?.Add(new CartBook { Book = bookToAdd });

        userCart.Price += bookToAdd.Price;

        await dataContext.SaveChangesAsync();
    }

    public async Task RemoveBookFromCart(User user, int bookId)
    {
        var userCart = await dataContext.Carts.Include(x => x.CartBooks)
                                            .FirstOrDefaultAsync(x => x.UserId == user.Id);

        if (userCart == null)
        {
            return;
        }

        var bookToRemove = userCart.CartBooks.FirstOrDefault(x => x.BookId == bookId);


        if (bookToRemove == null)
        {
            return;
        }

        userCart.CartBooks.Remove(bookToRemove);

        await dataContext.SaveChangesAsync();
    }
}
