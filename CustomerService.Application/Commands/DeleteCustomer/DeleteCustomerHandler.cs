using CustomerService.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Application.Commands.DeleteCustomer
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _repository;

        public DeleteCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id);
            if (customer == null)
                throw new KeyNotFoundException($"Customer with ID '{request.Id}' not found.");

            await _repository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
