using Microsoft.EntityFrameworkCore;
using ReservationService.Domain.Entities;

namespace ReservationService.Infrastructure.Data
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options)
            : base(options) { }

        public DbSet<Reservation> Reservations => Set<Reservation>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("reservation");
            modelBuilder.ApplyConfiguration(new Configuration.ReservationConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
