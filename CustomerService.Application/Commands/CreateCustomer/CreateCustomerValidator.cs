using FluentValidation;

namespace CustomerService.Application.Commands.CreateCustomer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(200);
            RuleFor(x => x.PhoneNumber).MaximumLength(20);
            RuleFor(x => x.IDCardNumber).NotEmpty().MaximumLength(20);
            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.UtcNow).WithMessage("Date of birth must be in the past")
                .Must(date => date <= DateTime.UtcNow.AddYears(-18)).WithMessage("Client must be at least 18 years old");

            RuleFor(x => x.Address).NotNull();
            RuleFor(x => x.Address.Street).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Address.City).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Address.PostalCode).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Address.Country).NotEmpty().MaximumLength(100);
        }
    }
}
