using IdentityApi.Data;
using IdentityApi.Dtos;
using IdentityApi.Entities;
using IdentityApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Services;

public class BookService
{
    private readonly DataContext datacontext;
    public BookService(DataContext context) 
    {
        this.datacontext = context;
    }


    public IEnumerable<BookDto> GetAllBooks()
    {
        var books = datacontext.Books.ToList();
        var bookDtos = MapBooksToDtos(books);
        return bookDtos;
    }


    public async Task<BookDto> CreateBookAsync(BookModel book)
    {
        if (book == null)
        {
            return null;
        }

        var entity = new Book
        {
            Author = book.Author,
            Description = book.Description,
            Price = book.Price,
            Title = book.Title,
        };

        await datacontext.Books.AddAsync(entity);

        await datacontext.SaveChangesAsync();

        var bookdto = MapBookDto(entity);


        return bookdto;

    }

    public async Task<BookDto> UpdateBookAsync(int bookId, BookModel book)
    {
        var bookToUpdate = await datacontext.Books.SingleOrDefaultAsync(x => x.Id == bookId);
             
        
        bookToUpdate.Author = book.Author;
        bookToUpdate.Description = book.Description;
        bookToUpdate.Price = book.Price;
        bookToUpdate.Title = book.Title;

        await datacontext.SaveChangesAsync();

        return MapBookDto(bookToUpdate);

    }



    private static BookDto MapBookDto(Book book)
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

    private static IEnumerable<BookDto> MapBooksToDtos(IEnumerable<Book> books)
    {
        return books.Select(book => MapBookDto(book));
    }

}
