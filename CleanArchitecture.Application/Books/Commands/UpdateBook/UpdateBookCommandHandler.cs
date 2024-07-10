using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Books.Commands.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(request.BookId);

            if (existingBook != null)
            {
                var updatebook = _mapper.Map(request, existingBook);

                await _bookRepository.UpdateBook(updatebook);
                await _bookRepository.SaveChangesAsync();

                return Unit.Value;
            }
            return Unit.Value;
        }
    }
}
