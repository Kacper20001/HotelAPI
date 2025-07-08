using FluentValidation.TestHelper;
using ReservationService.Application.Commands.CreateReservation;
using Xunit;

namespace ReservationService.Tests.Validators
{
    public class CreateReservationValidatorTests
    {
        private readonly CreateReservationValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_CustomerId_Is_Empty()
        {
            var model = new CreateReservationCommand
            {
                CustomerId = Guid.Empty,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(1),
                NumberOfGuests = 2,
                Price = 300,
                RoomNumber = 101
            };

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.CustomerId);
        }

        [Fact]
        public void Should_Pass_Validation_When_Model_Is_Valid()
        {
            var model = new CreateReservationCommand
            {
                CustomerId = Guid.NewGuid(),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(3),
                NumberOfGuests = 2,
                Price = 500,
                RoomNumber = 10
            };

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
