using CleanArchitecture.Application.DTOs;
using MediatR;

namespace CleanArchitecture.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public int BookId { get; set; }
        public string? BookTitle { get; set; }
        public string? BookDescription { get; set; }
        public string? BookAuthor { get; set; }
        public decimal BookPrice { get; set; }

    }
}
