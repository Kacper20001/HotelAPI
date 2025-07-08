using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReservationService.Application.Commands.ConfirmReservation;
using ReservationService.Domain.Entities;
using ReservationService.Domain.Enums;
using ReservationService.Infrastructure.Data;
using ReservationService.Application.Mappings;
using ReservationService.Infrastructure.Repositories;
using Xunit;

namespace ReservationService.Tests.Commands
{
    public class ConfirmReservationCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldConfirmReservation()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ReservationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new ReservationDbContext(options);

            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(3),
                NumberOfGuests = 1,
                Price = 300,
                RoomNumber = 2,
                Status = ReservationStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await context.Reservations.AddAsync(reservation);
            await context.SaveChangesAsync();

            var repository = new ReservationRepository(context);
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();
            var handler = new ConfirmReservationHandler(repository, mapper);

            // Act
            var result = await handler.Handle(new ConfirmReservationCommand(reservation.Id), CancellationToken.None);

            // Assert
            Assert.Equal(ReservationStatus.Confirmed, result.Status);
        }
    }
}
