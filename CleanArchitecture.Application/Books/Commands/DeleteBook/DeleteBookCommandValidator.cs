using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(v => v.BookId)
                .NotEmpty().GreaterThan(0).WithMessage("BookId khong duoc bo trong va phai lon hon 0");
        }
    }
}
