using Shared.DTOs;

namespace ReservationService.Application.Interfaces
{
    public interface ICustomerApiClient
    {
        Task<CustomerDto?> GetByIdAsync(Guid id);
    }
}
