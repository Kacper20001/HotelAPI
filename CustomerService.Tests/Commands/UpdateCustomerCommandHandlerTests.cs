using AutoMapper;
using CustomerService.Application.Commands.UpdateCustomer;
using CustomerService.Application.DTOs;
using CustomerService.Infrastructure.Data;
using CustomerService.Application.Mappings;
using CustomerService.Infrastructure.Repositories;
using CustomerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CustomerService.Tests.Commands
{
    public class UpdateCustomerCommandHandlerTests
    {
        private readonly CustomerDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new CustomerDbContext(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task UpdateCustomer_ShouldUpdateFields()
        {
            // Arrange
            var customerId = Guid.NewGuid();

            _context.Customers.Add(new Customer
            {
                Id = customerId,
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "jan@example.com",
                IDCardNumber = "ABC123",
                DateOfBirth = new DateTime(1995, 1, 1),
                Address = new Address
                {
                    Street = "ul. Stara",
                    City = "Kraków",
                    PostalCode = "30-001",
                    Country = "Polska"
                }
            });
            await _context.SaveChangesAsync();

            var repository = new CustomerRepository(_context);
            var handler = new UpdateCustomerHandler(repository, _mapper);

            var command = new UpdateCustomerCommand
            {
                Id = customerId,
                FirstName = "Janek",
                LastName = "Nowak",
                Email = "janek@example.com",
                PhoneNumber = "123456789",
                IDCardNumber = "XYZ987",
                DateOfBirth = new DateTime(1990, 5, 15),
                Address = new AddressDto
                {
                    Street = "ul. Nowa",
                    City = "Warszawa",
                    PostalCode = "00-001",
                    Country = "Polska"
                }
            };

            // Act
            await handler.Handle(command, CancellationToken.None);

            var updated = await _context.Customers.Include(c => c.Address).FirstOrDefaultAsync(c => c.Id == customerId);

            // Assert
            Assert.NotNull(updated);
            Assert.Equal("Janek", updated!.FirstName);
            Assert.Equal("Nowak", updated.LastName);
            Assert.Equal("janek@example.com", updated.Email);
            Assert.Equal("ul. Nowa", updated.Address.Street);
        }
    }
}
