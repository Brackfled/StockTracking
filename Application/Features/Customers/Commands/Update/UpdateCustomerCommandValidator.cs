using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommandValidator:AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(c => c.Name).MinimumLength(6).MaximumLength(30);
            RuleFor(c => c.CompanyName).MinimumLength(6).MaximumLength(16);
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Adress).MaximumLength(50);
            
        }
    }
}
