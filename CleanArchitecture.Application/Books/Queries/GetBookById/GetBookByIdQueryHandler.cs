using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDTO>
    {
        public IBookRepository _bookrepository;
        public IMapper _mapper;
        public GetBookByIdQueryHandler(IBookRepository bookrepository, IMapper mapper)
        {
            _bookrepository = bookrepository;
            _mapper = mapper;
        }

        public async Task<BookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookrepository.GetBookByIdAsync(request.BookId);
            return _mapper.Map<BookDTO>(book);
        }
    }
}
