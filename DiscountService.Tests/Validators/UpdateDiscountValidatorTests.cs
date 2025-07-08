using DiscountService.Application.Commands.UpdateDiscount;
using FluentValidation.TestHelper;
using Xunit;

namespace DiscountService.Tests.Validators
{
    public class UpdateDiscountValidatorTests
    {
        private readonly UpdateDiscountValidator _validator;

        public UpdateDiscountValidatorTests()
        {
            _validator = new UpdateDiscountValidator();
        }

        [Fact]
        public void Validator_ShouldPass_ValidModel()
        {
            var command = new UpdateDiscountCommand
            {
                Id = Guid.NewGuid(),
                Code = "PROMO",
                Percentage = 25,
                IsActive = true,
                ValidFrom = DateTime.UtcNow,
                ValidTo = DateTime.UtcNow.AddDays(10),
                Description = "Updated discount"
            };

            var result = _validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validator_ShouldFail_InvalidPercentage()
        {
            var command = new UpdateDiscountCommand
            {
                Id = Guid.NewGuid(),
                Code = "FAIL",
                Percentage = 0,
                ValidFrom = DateTime.UtcNow,
                ValidTo = DateTime.UtcNow.AddDays(1)
            };

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Percentage);
        }
    }
}
