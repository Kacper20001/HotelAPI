using AutoMapper;
using DiscountService.Application.Commands.CreateDiscount;
using DiscountService.Application.DTOs;
using DiscountService.Infrastructure.Data;
using DiscountService.Application.Mappings;
using DiscountService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DiscountService.Tests.Commands
{
    public class CreateDiscountCommandHandlerTests
    {
        private readonly DiscountDbContext _context;
        private readonly IMapper _mapper;

        public CreateDiscountCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<DiscountDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new DiscountDbContext(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task Handle_ShouldCreateDiscount()
        {
            // Arrange
            var command = new CreateDiscountCommand
            {
                Code = "TEST10",
                Percentage = 10,
                IsActive = true,
                ValidFrom = DateTime.UtcNow.AddDays(-1),
                ValidTo = DateTime.UtcNow.AddDays(10),
                Description = "Test description"
            };

            var repository = new DiscountRepository(_context);
            var handler = new CreateDiscountHandler(repository, _mapper);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<DiscountDto>(result);
            Assert.Equal("TEST10", result.Code);
        }
    }
}
