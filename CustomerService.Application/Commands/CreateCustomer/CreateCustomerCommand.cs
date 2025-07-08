using CustomerService.Application.DTOs;
using MediatR;

namespace CustomerService.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string IDCardNumber { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public AddressDto Address { get; set; } = null!;
    }
}
