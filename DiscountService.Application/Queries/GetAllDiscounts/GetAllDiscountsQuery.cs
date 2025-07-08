using DiscountService.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountService.Application.Queries.GetAllDiscounts
{
    public class GetAllDiscountsQuery : IRequest<IEnumerable<DiscountDto>> { }
 
}
