using AutoMapper;
using DiscountService.Application.DTOs;
using DiscountService.Application.Queries.GetDiscountById;
using DiscountService.Domain.Entities;
using DiscountService.Infrastructure.Data;
using DiscountService.Application.Mappings;
using DiscountService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DiscountService.Tests.Queries
{
    public class GetDiscountByIdQueryHandlerTests
    {
        private readonly DiscountDbContext _context;
        private readonly IMapper _mapper;

        public GetDiscountByIdQueryHandlerTests()
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
        public async Task Handle_ShouldReturnCorrectDiscount()
        {
            // Arrange
            var discount = new Discount
            {
                Id = Guid.NewGuid(),
                Code = "VIP99",
                Percentage = 99,
                IsActive = true,
                ValidFrom = DateTime.UtcNow.AddDays(-5),
                ValidTo = DateTime.UtcNow.AddDays(5),
                Description = "Premium"
            };

            _context.Discounts.Add(discount);
            await _context.SaveChangesAsync();

            var repository = new DiscountRepository(_context);
            var handler = new GetDiscountByIdHandler(repository, _mapper);

            var query = new GetDiscountByIdQuery(discount.Id);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("VIP99", result.Code);
        }
    }
}
