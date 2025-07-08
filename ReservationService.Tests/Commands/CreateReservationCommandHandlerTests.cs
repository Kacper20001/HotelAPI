using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReservationService.Application.Commands.CreateReservation;
using ReservationService.Application.DTOs;
using ReservationService.Application.Interfaces;
using ReservationService.Infrastructure.Data;
using ReservationService.Application.Mappings;
using ReservationService.Infrastructure.Repositories;
using Shared.DTOs;
using Xunit;

namespace ReservationService.Tests.Commands
{
    public class CreateReservationCommandHandlerTests
    {
        private readonly ReservationDbContext _context;
        private readonly IMapper _mapper;

        public CreateReservationCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ReservationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new ReservationDbContext(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task Handle_ShouldCreateReservation()
        {
            // Arrange
            var repository = new ReservationRepository(_context);
            var command = new CreateReservationCommand
            {
                CustomerId = Guid.NewGuid(),
                StartDate = DateTime.UtcNow.AddDays(1),
                EndDate = DateTime.UtcNow.AddDays(5),
                NumberOfGuests = 2,
                Price = 500,
                RoomNumber = 101,
                DiscountId = null
            };

            var customerApi = new FakeCustomerApiClient(); 
            var discountApi = new FakeDiscountApiClient();

            var handler = new CreateReservationHandler(repository, _mapper, customerApi, discountApi);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(command.CustomerId, result.CustomerId);
        }

        private class FakeCustomerApiClient : ICustomerApiClient
        {
            public Task<CustomerDto?> GetByIdAsync(Guid id) => Task.FromResult<CustomerDto?>(new CustomerDto { Id = id });
        }

        private class FakeDiscountApiClient : IDiscountApiClient
        {
            public Task<DiscountDto?> GetByIdAsync(Guid id) => Task.FromResult<DiscountDto?>(new DiscountDto
            {
                Id = id,
                IsActive = true,
                ValidFrom = DateTime.UtcNow.AddDays(-1),
                ValidTo = DateTime.UtcNow.AddDays(2)
            });
        }
    }
}
