using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidatior : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidatior()
        {
            RuleFor(x => x.BookId).NotEmpty().GreaterThan(0).WithMessage("BookId khong duoc bo trong va phai lon hon 0");
            RuleFor(x => x.BookTitle).MaximumLength(200).WithMessage("Tieu de sach toi da 200 ki tu!");
            RuleFor(x => x.BookDescription).MaximumLength(2000).WithMessage("Mo ta sach toi da 2000 ki tu!");
            RuleFor(x => x.BookAuthor).MaximumLength(200).WithMessage("Tac gia sach toi da 200 ki tu!");
            RuleFor(x => x.BookPrice).GreaterThanOrEqualTo(0).WithMessage("So tien phai lon hon 0");
        }

    }
}
