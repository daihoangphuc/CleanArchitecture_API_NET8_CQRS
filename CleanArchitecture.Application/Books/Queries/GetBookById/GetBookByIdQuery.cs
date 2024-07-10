using CleanArchitecture.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookDTO>
    {
        public int BookId { get; set; }
    }

}
