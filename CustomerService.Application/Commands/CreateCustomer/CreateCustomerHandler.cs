using AutoMapper;
using CustomerService.Application.Interfaces;
using CustomerService.Domain.Entities;
using MediatR;

namespace CustomerService.Application.Commands.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);
            customer.Address.CustomerId = customer.Id;
            await _repository.AddAsync(customer);
            return customer.Id;
        }
    }
}
