using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Application.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; } 
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string IDCardNumber { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public AddressDto Address { get; set; } = null!;
    }

}
