using CustomerService.Application.DTOs;
using MediatR;

namespace CustomerService.Application.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
    {
    }
}
