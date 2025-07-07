using AutoMapper;
using CustomerService.Application.Commands.CreateCustomer;
using CustomerService.Application.Commands.UpdateCustomer;
using CustomerService.Application.DTOs;
using CustomerService.Domain.Entities;

namespace CustomerService.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

            CreateMap<UpdateCustomerCommand, Customer>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

            CreateMap<AddressDto, Address>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap();

            CreateMap<Customer, CustomerDto>();
            CreateMap<Address, AddressDto>();
        }
    }
}
