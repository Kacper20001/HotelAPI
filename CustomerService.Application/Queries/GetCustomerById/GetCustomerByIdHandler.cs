using AutoMapper;
using CustomerService.Application.DTOs;
using CustomerService.Application.Interfaces;
using MediatR;

namespace CustomerService.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id);
            if (customer is null)
                throw new KeyNotFoundException($"Customer with ID '{request.Id}' not found.");

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
