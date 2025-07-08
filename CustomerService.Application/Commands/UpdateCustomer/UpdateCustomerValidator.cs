using FluentValidation;

namespace CustomerService.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(200);
            RuleFor(x => x.PhoneNumber).MaximumLength(20);
            RuleFor(x => x.IDCardNumber).NotEmpty().MaximumLength(20);
            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.UtcNow)
                .Must(date => date <= DateTime.UtcNow.AddYears(-18))
                .WithMessage("Client must be at least 18 years old");

            RuleFor(x => x.Address).NotNull();
            RuleFor(x => x.Address.Street).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Address.City).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Address.PostalCode).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Address.Country).NotEmpty().MaximumLength(100);
        }
    }
}
