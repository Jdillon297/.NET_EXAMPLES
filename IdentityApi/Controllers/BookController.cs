using IdentityApi.Dtos;
using IdentityApi.Entities;
using IdentityApi.Models;
using IdentityApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService bookService;

        public BookController(BookService service)
        {
            this.bookService = service;
        }

        [Authorize(Roles = RoleDealer.ComboRole)]
        [HttpGet] 
        public ActionResult<List<Book>> GetAllBooks()
        {
            var bookdtos = bookService.GetAllBooks();
            return Ok(bookdtos);
        }

        [Authorize(Roles = RoleDealer.AdminRole)]
        [HttpPost]
        public async Task<ActionResult> CreateBook(BookModel book) 
        {

           var bookDto = await bookService.CreateBookAsync(book);   
            if(bookDto == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(CreateBook), bookDto);
        }

        [Authorize(Roles = RoleDealer.AdminRole)]
        [HttpPut]
        public async Task<ActionResult<BookDto>> UpdateBook(int bookId,  BookModel book)
        {
            var bookDto = await bookService.UpdateBookAsync(bookId, book);

            return Ok(bookDto);
        }

        [Authorize(Roles = RoleDealer.AdminRole)]
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int Bookid)
        {
            await bookService.DeleteBookAsync(Bookid);
            return Ok();
        }
    }
}
