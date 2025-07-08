using DiscountService.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountService.Application.Commands.CreateDiscount
{
    public class CreateDiscountCommand : IRequest<DiscountDto>
    {
        public string Code { get; set; } = null!;
        public decimal Percentage { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string? Description { get; set; }
    }
}
