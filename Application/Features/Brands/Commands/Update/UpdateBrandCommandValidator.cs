using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommandValidator:AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {

            RuleFor(b => b.Name).NotEmpty().MinimumLength(6).MaximumLength(16);

        }
    }
}
