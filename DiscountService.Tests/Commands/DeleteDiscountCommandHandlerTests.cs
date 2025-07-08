using DiscountService.Application.Commands.DeleteDiscount;
using DiscountService.Infrastructure.Data;
using DiscountService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DiscountService.Tests.Commands
{
    public class DeleteDiscountCommandHandlerTests
    {
        private readonly DiscountDbContext _context;

        public DeleteDiscountCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<DiscountDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _context = new DiscountDbContext(options);
        }

        [Fact]
        public async Task Handle_ShouldDeleteDiscount()
        {
            var discount = new Domain.Entities.Discount
            {
                Id = Guid.NewGuid(),
                Code = "DEL",
                Percentage = 5,
                IsActive = true,
                ValidFrom = DateTime.UtcNow,
                ValidTo = DateTime.UtcNow.AddDays(3),
            };

            _context.Discounts.Add(discount);
            await _context.SaveChangesAsync();

            var handler = new DeleteDiscountHandler(new DiscountRepository(_context));
            await handler.Handle(new DeleteDiscountCommand(discount.Id), default);

            Assert.Empty(_context.Discounts);
        }
    }
}
