using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sellers.Commands.Create
{
    public class CreateSellerCommandValidator:AbstractValidator<CreateSellerCommand>
    {
        public CreateSellerCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(6).MaximumLength(16);
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.Adress).NotEmpty().MaximumLength(50);
            RuleFor(c => c.PhoneNumber).NotEmpty();
        }
    }
}
