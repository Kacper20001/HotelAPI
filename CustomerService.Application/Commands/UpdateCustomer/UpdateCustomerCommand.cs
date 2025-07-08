using CustomerService.Application.DTOs;
using MediatR;

namespace CustomerService.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string IDCardNumber { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public AddressDto Address { get; set; } = null!;
    }
}
