using DiscountService.Application.Interfaces;
using DiscountService.Domain.Entities;
using DiscountService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DiscountService.Infrastructure.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DiscountDbContext _context;

        public DiscountRepository(DiscountDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Discount>> GetAllAsync()
        {
            return await _context.Discounts.ToListAsync();
        }

        public async Task<Discount?> GetByIdAsync(Guid id)
        {
            return await _context.Discounts.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(Discount discount)
        {
            await _context.Discounts.AddAsync(discount);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Discount discount)
        {
            _context.Discounts.Update(discount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Discount discount)
        {
            _context.Discounts.Remove(discount);
            await _context.SaveChangesAsync();
        }
    }
}
