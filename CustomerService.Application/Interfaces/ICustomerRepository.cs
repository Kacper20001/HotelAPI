using CustomerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(Guid id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(string email);
    }
}
