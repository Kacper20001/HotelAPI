using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace ReservationService.Application.Interfaces
{
    public interface ICustomerApiClient
    {
        Task<CustomerDto?> GetCustomerByIdAsync(Guid customerId);
    }
}
