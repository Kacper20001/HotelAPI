using CustomerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Infrastructure.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Address> Addresses => Set<Address>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("customer");

            modelBuilder.ApplyConfiguration(new Configuration.CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.AddressConfiguration());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
