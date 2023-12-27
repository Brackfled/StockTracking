using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.Update
{
    public class UpdateProductCommandValidator:AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Name).MinimumLength(6).MaximumLength(30);
            RuleFor(p => p.ProductDetail).MinimumLength(6).MaximumLength(30);
        }
    }
}
