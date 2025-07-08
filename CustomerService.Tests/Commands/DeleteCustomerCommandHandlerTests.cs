using CustomerService.Application.Commands.DeleteCustomer;
using CustomerService.Application.Interfaces;
using CustomerService.Domain.Entities;
using CustomerService.Infrastructure.Data;
using CustomerService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CustomerService.Tests.Commands
{
    public class DeleteCustomerCommandHandlerTests
    {
        private readonly CustomerDbContext _context;
        private readonly ICustomerRepository _repository;

        public DeleteCustomerCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new CustomerDbContext(options);
            _repository = new CustomerRepository(_context);
        }

        [Fact]
        public async Task DeleteCustomer_ShouldRemoveCustomer()
        {
            // Arrange
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "jan.kowalski@example.com",
                IDCardNumber = "ABC123456",
                DateOfBirth = DateTime.UtcNow.AddYears(-30),
                Address = new Address
                {
                    Street = "ul. Testowa 1",
                    City = "Rzeszów",
                    PostalCode = "35-001",
                    Country = "Polska"
                }
            };

            await _repository.AddAsync(customer);

            var handler = new DeleteCustomerHandler(_repository);
            var command = new DeleteCustomerCommand(customer.Id);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            var deleted = await _repository.GetByIdAsync(customer.Id);
            Assert.Null(deleted);
        }
    }
}
