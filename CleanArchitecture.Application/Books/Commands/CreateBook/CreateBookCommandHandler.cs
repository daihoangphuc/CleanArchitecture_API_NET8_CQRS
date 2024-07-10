using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookDTO>
    {
        public IBookRepository _bookrepository;
        public IMapper _mapper;
        public CreateBookCommandHandler(IBookRepository bookrepository, IMapper mapper)
        {
            _bookrepository = bookrepository;
            _mapper = mapper;
        }
        public async Task<BookDTO> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var newbook = new Book()
            {
                BookTitle = request.BookTitle,
                BookDescription = request.BookDescription,
                BookAuthor = request.BookAuthor
            };
            await _bookrepository.AddBookAsync(newbook);
            return _mapper.Map<BookDTO>(newbook);
        }
    }
}
