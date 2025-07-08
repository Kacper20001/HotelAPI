using AutoMapper;
using DiscountService.Application.Commands.UpdateDiscount;
using DiscountService.Application.DTOs;
using DiscountService.Infrastructure.Data;
using DiscountService.Application.Mappings;
using DiscountService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DiscountService.Tests.Commands
{
    public class UpdateDiscountCommandHandlerTests
    {
        private readonly DiscountDbContext _context;
        private readonly IMapper _mapper;

        public UpdateDiscountCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<DiscountDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _context = new DiscountDbContext(options);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task Handle_ShouldUpdateDiscount()
        {
            var discount = new Domain.Entities.Discount
            {
                Id = Guid.NewGuid(),
                Code = "SUMMER",
                Percentage = 10,
                IsActive = true,
                ValidFrom = DateTime.UtcNow,
                ValidTo = DateTime.UtcNow.AddDays(10),
                Description = "Old"
            };

            _context.Discounts.Add(discount);
            await _context.SaveChangesAsync();

            var command = new UpdateDiscountCommand
            {
                Id = discount.Id,
                Code = "WINTER",
                Percentage = 15,
                IsActive = false,
                ValidFrom = discount.ValidFrom,
                ValidTo = discount.ValidTo.AddDays(5),
                Description = "New"
            };

            var handler = new UpdateDiscountHandler(new DiscountRepository(_context), _mapper);

            var result = await handler.Handle(command, default);

            Assert.Equal(command.Code, result.Code);
            Assert.Equal(command.Percentage, result.Percentage);
            Assert.Equal(command.Description, result.Description);
            Assert.False(result.IsActive);
        }
    }
}
