using AutoMapper;
using ReservationService.Application.Queries.GetReservationById;
using ReservationService.Domain.Entities;
using ReservationService.Infrastructure.Data;
using ReservationService.Application.Mappings;
using ReservationService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ReservationService.Tests.Queries
{
    public class GetReservationByIdQueryHandlerTests
    {
        private readonly ReservationDbContext _context;
        private readonly IMapper _mapper;

        public GetReservationByIdQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ReservationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _context = new ReservationDbContext(options);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task GetById_ShouldReturnReservation()
        {
            var id = Guid.NewGuid();
            _context.Reservations.Add(new Reservation
            {
                Id = id,
                CustomerId = Guid.NewGuid(),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(3),
                NumberOfGuests = 2,
                Price = 500,
                RoomNumber = 101,
                Status = Domain.Enums.ReservationStatus.Confirmed,
                CreatedAt = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();

            var repo = new ReservationRepository(_context);
            var handler = new GetReservationByIdHandler(repo, _mapper);

            var result = await handler.Handle(new GetReservationByIdQuery(id), default);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }
    }
}
