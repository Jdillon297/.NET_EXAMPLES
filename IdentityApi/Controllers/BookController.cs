using IdentityApi.Data;
using IdentityApi.Dtos;
using IdentityApi.Entities;
using IdentityApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DataContext context;

        public BookController(DataContext context)
        {
            this.context = context;
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet] 
        public ActionResult<List<Book>> GetAllBooks()
        {
            var books =  context.Books.ToList();
            var bookdtos = MapBooksToDtos(books);
            return Ok(bookdtos);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreateBook(BookModel book) 
        {

            if (book == null)
            {
                return BadRequest();
            }

            var entity = new Book
            {
                Author = book.Author,
                Description = book.Description,
                Price = book.Price,
                Title = book.Title,
            };

            await context.Books.AddAsync(entity);

            await context.SaveChangesAsync();

            var bookdto = MapBookDto(entity);
            
            

            return CreatedAtAction(nameof(CreateBook), book);
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
}
