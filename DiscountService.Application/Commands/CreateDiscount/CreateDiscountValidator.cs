using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountService.Application.Commands.CreateDiscount
{
    public class CreateDiscountValidator : AbstractValidator<CreateDiscountCommand>
    {
        public CreateDiscountValidator()
        {
            RuleFor(x => x.Code).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Percentage).GreaterThan(0).LessThanOrEqualTo(100);
            RuleFor(x => x.ValidFrom).LessThan(x => x.ValidTo);
        }
    }
}
