using ReservationService.Application.Commands.DeleteReservation;
using ReservationService.Domain.Entities;
using ReservationService.Infrastructure.Data;
using ReservationService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ReservationService.Tests.Commands
{
    public class DeleteReservationCommandHandlerTests
    {
        [Fact]
        public async Task DeleteReservation_ShouldRemoveFromDb()
        {
            var options = new DbContextOptionsBuilder<ReservationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using var context = new ReservationDbContext(options);
            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(2),
                NumberOfGuests = 1,
                Price = 100,
                RoomNumber = 1,
                Status = Domain.Enums.ReservationStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };
            context.Reservations.Add(reservation);
            await context.SaveChangesAsync();

            var repo = new ReservationRepository(context);
            var handler = new DeleteReservationHandler(repo);

            await handler.Handle(new DeleteReservationCommand(reservation.Id), default);

            Assert.Empty(context.Reservations.ToList());
        }
    }
}
