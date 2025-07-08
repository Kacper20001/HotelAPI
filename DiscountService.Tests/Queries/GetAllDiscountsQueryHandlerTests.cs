using AutoMapper;
using DiscountService.Application.DTOs;
using DiscountService.Application.Queries.GetAllDiscounts;
using DiscountService.Domain.Entities;
using DiscountService.Infrastructure.Data;
using DiscountService.Application.Mappings;
using DiscountService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DiscountService.Tests.Queries
{
    public class GetAllDiscountsQueryHandlerTests
    {
        private readonly DiscountDbContext _context;
        private readonly IMapper _mapper;

        public GetAllDiscountsQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<DiscountDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new DiscountDbContext(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task Handle_ShouldReturnAllDiscounts()
        {
            // Arrange
            _context.Discounts.Add(new Discount
            {
                Id = Guid.NewGuid(),
                Code = "XMAS",
                Percentage = 20,
                IsActive = true,
                ValidFrom = DateTime.UtcNow.AddDays(-10),
                ValidTo = DateTime.UtcNow.AddDays(10)
            });

            await _context.SaveChangesAsync();

            var repository = new DiscountRepository(_context);
            var handler = new GetAllDiscountsHandler(repository, _mapper);

            // Act
            var result = await handler.Handle(new GetAllDiscountsQuery(), CancellationToken.None);

            // Assert
            Assert.NotEmpty(result);
            Assert.IsType<List<DiscountDto>>(result);
        }
    }
}
