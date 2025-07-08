using DiscountService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiscountService.Infrastructure.Data
{
    public class DiscountDbContext : DbContext
    {
        public DiscountDbContext(DbContextOptions<DiscountDbContext> options)
            : base(options) { }

        public DbSet<Discount> Discounts => Set<Discount>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("discount");
            modelBuilder.ApplyConfiguration(new Configuration.DiscountConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
