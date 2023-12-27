using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {

            RuleFor(p => p.Name).NotEmpty().MaximumLength(6).MaximumLength(16);
            RuleFor(p => p.ProductDetail).NotEmpty().MaximumLength(6).MaximumLength(16);
            RuleFor(p => p.StockAmount).NotEmpty();

        }
    }
}
