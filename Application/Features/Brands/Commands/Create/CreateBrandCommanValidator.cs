using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommanValidator:AbstractValidator<CreateBrandCommand>
    {

        public CreateBrandCommanValidator()
        {
            RuleFor(b => b.Name).NotEmpty().MinimumLength(2) ;
        }

    }
}
