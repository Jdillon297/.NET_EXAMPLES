using IdentityApi.Data;
using IdentityApi.Dtos;
using IdentityApi.Entities;
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

        [Authorize]
        [HttpGet] 
        public ActionResult<List<Book>> GetAllBooks()
        {
            var books =  context.Books.ToList();
            var bookdtos = MapBooksToDtos(books);
            return Ok(bookdtos);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateBook(BookDto book) 
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
