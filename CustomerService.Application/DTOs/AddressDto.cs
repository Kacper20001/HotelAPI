﻿namespace CustomerService.Application.DTOs
{
    public class AddressDto
    {
        public Guid Id { get; set; } 
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
