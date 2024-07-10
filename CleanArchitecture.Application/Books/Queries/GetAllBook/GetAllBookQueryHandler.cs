using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Books.Queries.GetAllBook
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, List<BookDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public GetAllBookQueryHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<List<BookDTO>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllBookAsync();
            return _mapper.Map<List<BookDTO>>(books);
        }

    }
}
