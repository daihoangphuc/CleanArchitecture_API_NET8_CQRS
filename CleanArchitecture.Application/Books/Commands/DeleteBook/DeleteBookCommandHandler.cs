using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, int>
    {
        public IBookRepository _bookrepository;
        public IMapper _mapper;
        public DeleteBookCommandHandler(IBookRepository bookrepository, IMapper mapper)
        {
            _bookrepository = bookrepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookrepository.GetBookByIdAsync(request.BookId);
            if (book == null)
            {
                return 0;
            }
            await _bookrepository.DeleteBookAsync(book.BookId);
            return book.BookId;

        }
    }
}
