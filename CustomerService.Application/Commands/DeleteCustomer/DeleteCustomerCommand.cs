using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Application.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
        }
    }
}
