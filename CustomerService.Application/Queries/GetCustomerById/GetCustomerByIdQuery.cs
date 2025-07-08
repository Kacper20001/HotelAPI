using CustomerService.Application.DTOs;
using MediatR;

namespace CustomerService.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public Guid Id { get; set; }

        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
