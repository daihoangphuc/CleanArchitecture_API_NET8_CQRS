using CleanArchitecture.Application.Books.Commands.CreateBook;
using CleanArchitecture.Application.Books.Commands.DeleteBook;
using CleanArchitecture.Application.Books.Commands.UpdateBook;
using CleanArchitecture.Application.Books.Queries.GetAllBook;
using CleanArchitecture.Application.Books.Queries.GetBookById;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
using FluentValidation;
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
            try
            {
                var books = await Mediator().Send(new GetAllBookQuery());
                if (books == null)
                {
                    return NotFound(new { message = "Khong ton tai san pham nao!" });
                }
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetBookById(int id)
        {
            try
            {
                var book = await Mediator().Send(new GetBookByIdQuery { BookId = id });
                if (book == null)
                {
                    return NotFound(new { message = "Khong tim thay sach!" });
                }
                return Ok(new { message = $"Thong tin sach co Id la {id}", data = book });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateBookAsync(CreateBookCommand book)
        {
            try
            {
                // Nếu dữ liệu không hợp lệ, FluentValidation sẽ trả về lỗi
                var result = await Mediator().Send(book);
                return CreatedAtAction(nameof(GetBookById), new { id = result.BookId }, result);
            }
            catch (ValidationException ex)
            {
                // Xử lý lỗi xác thực từ FluentValidation
                return BadRequest(new { message = ex.Message, errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookCommand updateBookDto)
        {
            try
            {
                if (id != updateBookDto.BookId)
                {
                    return BadRequest(new { message = "BookId không khớp." });
                }

                await Mediator().Send(updateBookDto);

                return Ok(new { message = $"Cập nhật sách {id} thành công!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                await Mediator().Send(new DeleteBookCommand { BookId = id });

                return Ok(new { message = $"Xoa thanh cong sach {id}" });
            }catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
