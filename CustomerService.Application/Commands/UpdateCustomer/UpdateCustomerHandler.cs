using AutoMapper;
using CustomerService.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCustomerHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var existingCustomer = await _repository.GetByIdAsync(request.Id);
            if (existingCustomer is null)
                throw new KeyNotFoundException($"Customer with ID '{request.Id}' not found.");

            existingCustomer.FirstName = request.FirstName;
            existingCustomer.LastName = request.LastName;
            existingCustomer.Email = request.Email;
            existingCustomer.PhoneNumber = request.PhoneNumber;
            existingCustomer.IDCardNumber = request.IDCardNumber;
            existingCustomer.DateOfBirth = request.DateOfBirth;

            existingCustomer.Address.Street = request.Address.Street;
            existingCustomer.Address.City = request.Address.City;
            existingCustomer.Address.PostalCode = request.Address.PostalCode;
            existingCustomer.Address.Country = request.Address.Country;

            await _repository.UpdateAsync(existingCustomer);

            return Unit.Value;
        }
    }
}
