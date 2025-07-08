using AutoMapper;
using ReservationService.Application.Commands.CancelReservation;
using ReservationService.Domain.Entities;
using ReservationService.Domain.Enums;
using ReservationService.Infrastructure.Data;
using ReservationService.Application.Mappings;
using ReservationService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ReservationService.Tests.Commands
{
    public class CancelReservationCommandHandlerTests
    {
        [Fact]
        public async Task CancelReservation_ShouldUpdateStatus()
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
                NumberOfGuests = 2,
                Price = 200,
                RoomNumber = 7,
                Status = ReservationStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            context.Reservations.Add(reservation);
            await context.SaveChangesAsync();

            var repo = new ReservationRepository(context);
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();

            var handler = new CancelReservationHandler(repo, mapper);

            var result = await handler.Handle(new CancelReservationCommand(reservation.Id), default);

            Assert.Equal(ReservationStatus.Cancelled, result.Status);
        }
    }
}
