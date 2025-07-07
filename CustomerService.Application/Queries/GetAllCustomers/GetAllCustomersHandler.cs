using AutoMapper;
using CustomerService.Application.DTOs;
using CustomerService.Application.Interfaces;
using CustomerService.Domain.Entities;
using MediatR;

namespace CustomerService.Application.Queries.GetAllCustomers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCustomersHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repository.GetAllAsync();

            if (!customers.Any())
            {
                return new List<CustomerDto>();
            }

            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }
    }
}
