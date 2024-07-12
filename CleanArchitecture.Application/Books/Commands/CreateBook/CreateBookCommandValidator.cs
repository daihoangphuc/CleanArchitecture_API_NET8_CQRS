using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(v => v.BookTitle)
                .MaximumLength(200).WithMessage("Tieu de sach toi da 200 ki tu!")
                .NotEmpty();
            RuleFor(v => v.BookDescription)
                .MaximumLength(2000).WithMessage("Mo ta sach toi da 2000 ki tu!")
                .NotEmpty();
            RuleFor(v => v.BookAuthor)
                .MaximumLength(200).WithMessage("Tac gia sach toi da 200 ki tu!")
                .NotEmpty();
            RuleFor(x => x.BookPrice).GreaterThanOrEqualTo(0).WithMessage("So tien phai lon hon 0");

        }   
    }
}
