using CustomerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerService.Infrastructure.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(200);
            builder.Property(c => c.PhoneNumber).HasMaxLength(20);
            builder.Property(c => c.IDCardNumber).IsRequired().HasMaxLength(20);
            builder.Property(c => c.DateOfBirth).IsRequired();

            builder.HasOne(c => c.Address)
                   .WithOne(a => a.Customer)
                   .HasForeignKey<Address>(a => a.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
