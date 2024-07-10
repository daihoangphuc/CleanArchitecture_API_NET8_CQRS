using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<int>
    {
        public int BookId { get; set; }
    }
}
