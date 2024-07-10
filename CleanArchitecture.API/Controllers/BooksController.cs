using CleanArchitecture.Application.Books.Commands.CreateBook;
using CleanArchitecture.Application.Books.Commands.DeleteBook;
using CleanArchitecture.Application.Books.Commands.UpdateBook;
using CleanArchitecture.Application.Books.Queries.GetAllBook;
using CleanArchitecture.Application.Books.Queries.GetBookById;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAllBook()
        {
            var books = await Mediator().Send(new GetAllBookQuery());
            if (books == null)
            {
                return NotFound(new {message = "Khong ton tai sach nao!"});
            }
            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetBookById(int id)
        {
            var book = await Mediator().Send(new GetBookByIdQuery { BookId = id });
            if (book == null)
            {
                return NotFound(new { message = "Khong tim thay sach nay!" });
            }
            return Ok(new { message = $"Thong tin sach co Id la {id}" , data = book});
        }
        [HttpPost]
        public async Task<ActionResult> CreateBookAsync(CreateBookCommand book)
        {
            var createbook = await Mediator().Send(book);
            return CreatedAtAction(nameof(GetBookById), new { id = createbook.BookId }, createbook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookCommand updateBookDto)
        {
            if (id != updateBookDto.BookId)
            {
                return BadRequest();
            }

            await Mediator().Send(updateBookDto);

            return Ok(new { message = "Cap nhat thanh cong!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await Mediator().Send(new DeleteBookCommand { BookId = id });

            return Ok(new {message = "Xoa thanh cong!"});
        }
    }
}
