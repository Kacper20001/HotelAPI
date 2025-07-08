using CustomerService.Application.Commands.CreateCustomer;
using CustomerService.Application.DTOs;
using FluentValidation.TestHelper;
using Xunit;

namespace CustomerService.Tests.Validators
{
    public class CreateCustomerValidatorTests
    {
        private readonly CreateCustomerValidator _validator = new();

        [Fact]
        public void Validator_Should_Pass_For_Valid_Data()
        {
            var command = new CreateCustomerCommand
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "jan.kowalski@example.com",
                PhoneNumber = "123456789",
                IDCardNumber = "ABC123456",
                DateOfBirth = DateTime.UtcNow.AddYears(-30),
                Address = new AddressDto
                {
                    Street = "ul. Kwiatowa 1",
                    City = "Rzeszów",
                    PostalCode = "35-001",
                    Country = "Polska"
                }
            };

            var result = _validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validator_Should_Fail_When_Too_Young()
        {
            var command = new CreateCustomerCommand
            {
                FirstName = "Adam",
                LastName = "Nowak",
                Email = "adam@example.com",
                IDCardNumber = "ABC123456",
                DateOfBirth = DateTime.UtcNow.AddYears(-15), // za młody
                Address = new AddressDto
                {
                    Street = "ul. Rzeszowska",
                    City = "Rzeszów",
                    PostalCode = "35-002",
                    Country = "Polska"
                }
            };

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.DateOfBirth);
        }
    }
}
