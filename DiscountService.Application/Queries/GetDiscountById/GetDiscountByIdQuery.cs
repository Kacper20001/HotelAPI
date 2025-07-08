using DiscountService.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountService.Application.Queries.GetDiscountById
{
    public class GetDiscountByIdQuery : IRequest<DiscountDto>
    {
        public Guid Id { get; set; }

        public GetDiscountByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
