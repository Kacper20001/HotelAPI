using AutoMapper;
using CustomerService.Application.Commands.CreateCustomer;
using CustomerService.Application.DTOs;
using CustomerService.Infrastructure.Data;
using CustomerService.Application.Mappings;
using CustomerService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CustomerService.Tests.Commands
{
    public class CreateCustomerCommandHandlerTests
    {
        private readonly CustomerDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new CustomerDbContext(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Application.Mappings.MappingProfile>();
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCommand_ShouldCreateCustomer()
        {
            // Arrange
            var command = new CreateCustomerCommand
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "jan.kowalski@example.com",
                IDCardNumber = "AB123456",
                DateOfBirth = DateTime.UtcNow.AddYears(-30),
                PhoneNumber = "123456789",
                Address = new AddressDto
                {
                    Street = "ul. Testowa 1",
                    City = "Rzeszów",
                    PostalCode = "35-001",
                    Country = "Polska"
                }
            };

            var repository = new CustomerRepository(_context);
            var handler = new CreateCustomerHandler(repository, _mapper);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            var created = await _context.Customers.FindAsync(result);
            Assert.NotNull(created);
            Assert.Equal("Jan", created.FirstName);
        }
    }
}
