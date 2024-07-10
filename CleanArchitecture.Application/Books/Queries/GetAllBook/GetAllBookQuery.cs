using CleanArchitecture.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Books.Queries.GetAllBook
{
    public class GetAllBookQuery : IRequest<List<BookDTO>>
    {

    }
}
