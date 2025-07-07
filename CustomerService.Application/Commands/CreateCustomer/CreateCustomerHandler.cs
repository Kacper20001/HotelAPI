using AutoMapper;
using CustomerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerService.Application.Interfaces;

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
