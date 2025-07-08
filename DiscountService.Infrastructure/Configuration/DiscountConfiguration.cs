using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DiscountService.Domain.Entities;


namespace DiscountService.Infrastructure.Configuration
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.Percentage)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(d => d.IsActive)
                .IsRequired();

            builder.Property(d => d.ValidFrom)
                .IsRequired();

            builder.Property(d => d.ValidTo)
                .IsRequired();

            builder.Property(d => d.Description)
                .HasMaxLength(500);

            builder.Property(d => d.CreatedAt).IsRequired();
            builder.Property(d => d.ModifiedAt);
        }
    }
}
