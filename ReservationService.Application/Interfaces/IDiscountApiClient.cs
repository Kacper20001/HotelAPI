using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Application.Interfaces
{
    public interface IDiscountApiClient
    {
        Task<DiscountDto?> GetByIdAsync(Guid id);
    }
}
