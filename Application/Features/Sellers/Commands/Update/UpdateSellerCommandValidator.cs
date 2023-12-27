using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sellers.Commands.Update
{
    public class UpdateSellerCommandValidator: AbstractValidator<UpdateSellerCommand>
    {
        public UpdateSellerCommandValidator()
        {
            RuleFor(c => c.Name).MinimumLength(6).MaximumLength(30);
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Adress).MaximumLength(50);
        }
    }
}
