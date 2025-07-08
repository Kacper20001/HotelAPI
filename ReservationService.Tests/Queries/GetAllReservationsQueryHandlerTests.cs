using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReservationService.Application.DTOs;
using ReservationService.Application.Queries.GetAllReservations;
using ReservationService.Infrastructure.Data;
using ReservationService.Application.Mappings;
using ReservationService.Infrastructure.Repositories;
using Xunit;

namespace ReservationService.Tests.Queries
{
    public class GetAllReservationsQueryHandlerTests
    {
        private readonly ReservationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllReservationsQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ReservationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _context = new ReservationDbContext(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task GetAllReservations_ShouldReturnList()
        {
            // Arrange
            _context.Reservations.Add(new ReservationService.Domain.Entities.Reservation
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(3),
                NumberOfGuests = 2,
                Price = 500,
                RoomNumber = 5,
                Status = ReservationService.Domain.Enums.ReservationStatus.Pending,
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();

            var repo = new ReservationRepository(_context);
            var handler = new GetAllReservationsHandler(repo, _mapper);

            // Act
            var result = await handler.Handle(new GetAllReservationsQuery(), CancellationToken.None);

            // Assert
            Assert.Single(result);
            Assert.IsType<List<ReservationDto>>(result);
        }
    }
}
