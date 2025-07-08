using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountService.Application.Commands.DeleteDiscount
{
    public class DeleteDiscountCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteDiscountCommand(Guid id)
        {
            Id = id;
        }
    }
}
