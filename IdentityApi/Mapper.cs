using IdentityApi.Dtos;
using IdentityApi.Entities;
using Microsoft.SqlServer.Server;

namespace IdentityApi;

public class Mapper
{


    public static UserDto MapToUserDto(User user)
    {
        var userDto = new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            FirstName = user.FirstName,
            PhoneNumber = user.PhoneNumber,

        };

        return userDto; 
    }

    public static BookDto MapBookDto(Book book)
    {
        var bookdto = new BookDto
        {
            Id = book.Id,
            Author = book.Author,
            Description = book.Description,
            Price = book.Price,
            Title = book.Title,

        };
        return bookdto;
    }

    public static IEnumerable<BookDto> MapBooksToDtos(IEnumerable<Book> books)
    {
        return books.Select(book => MapBookDto(book));
    }

}
