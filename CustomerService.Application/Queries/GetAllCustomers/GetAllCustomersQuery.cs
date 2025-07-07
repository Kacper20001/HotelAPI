using CustomerService.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Application.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
    {
    }
}
