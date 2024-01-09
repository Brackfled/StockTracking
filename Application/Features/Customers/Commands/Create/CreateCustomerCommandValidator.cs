using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.Create
{
    public class CreateCustomerCommandValidator: AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(6).MaximumLength(30);
            RuleFor(c => c.CompanyName).NotEmpty().MinimumLength(6).MaximumLength(30);
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.Adress).NotEmpty().MaximumLength(50);
            RuleFor(c => c.PhoneNumber).NotEmpty();
        }
    }
}
