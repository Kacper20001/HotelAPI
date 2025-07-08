using DiscountService.Application.Commands.CreateDiscount;
using FluentValidation.TestHelper;
using Xunit;

namespace DiscountService.Tests.Validators
{
    public class CreateDiscountValidatorTests
    {
        private readonly CreateDiscountValidator _validator = new();

        [Fact]
        public void Should_HaveValidationError_When_CodeIsEmpty()
        {
            var command = new CreateDiscountCommand { Code = "" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.Code);
        }

        [Fact]
        public void Should_PassValidation_ForValidData()
        {
            var command = new CreateDiscountCommand
            {
                Code = "CODE",
                Percentage = 15,
                ValidFrom = DateTime.UtcNow.AddDays(-1),
                ValidTo = DateTime.UtcNow.AddDays(1),
                IsActive = true
            };

            var result = _validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
