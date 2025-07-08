using CustomerService.Application.Commands.UpdateCustomer;
using CustomerService.Application.DTOs;
using FluentValidation.TestHelper;
using Xunit;

namespace CustomerService.Tests.Validators
{
    public class UpdateCustomerValidatorTests
    {
        private readonly UpdateCustomerValidator _validator = new();

        [Fact]
        public void Validator_Should_Pass_For_Valid_Data()
        {
            var command = new UpdateCustomerCommand
            {
                Id = Guid.NewGuid(),
                FirstName = "Anna",
                LastName = "Zielińska",
                Email = "anna.z@example.com",
                PhoneNumber = "987654321",
                IDCardNumber = "XYZ789456",
                DateOfBirth = DateTime.UtcNow.AddYears(-22),
                Address = new AddressDto
                {
                    Street = "ul. Miodowa 10",
                    City = "Kraków",
                    PostalCode = "30-001",
                    Country = "Polska"
                }
            };

            var result = _validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validator_Should_Fail_When_Id_Empty()
        {
            var command = new UpdateCustomerCommand
            {
                Id = Guid.Empty, // błąd
                FirstName = "Anna",
                LastName = "Zielińska",
                Email = "anna.z@example.com",
                IDCardNumber = "XYZ789456",
                DateOfBirth = DateTime.UtcNow.AddYears(-22),
                Address = new AddressDto
                {
                    Street = "ul. Miodowa 10",
                    City = "Kraków",
                    PostalCode = "30-001",
                    Country = "Polska"
                }
            };

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
