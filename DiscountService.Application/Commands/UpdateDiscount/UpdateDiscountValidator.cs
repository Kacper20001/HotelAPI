using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountService.Application.Commands.UpdateDiscount
{
    public class UpdateDiscountValidator : AbstractValidator<UpdateDiscountCommand>
    {
        public UpdateDiscountValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Code).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Percentage).GreaterThan(0).LessThanOrEqualTo(100);
            RuleFor(x => x.ValidFrom).LessThan(x => x.ValidTo);
        }
    }
}
