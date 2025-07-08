using AutoMapper;
using CustomerService.Application.DTOs;
using CustomerService.Application.Queries.GetAllCustomers;
using CustomerService.Infrastructure.Data;
using CustomerService.Application.Mappings;
using CustomerService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CustomerService.Tests.Queries
{
    public class GetAllCustomersQueryHandlerTests
    {
        private readonly CustomerDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new CustomerDbContext(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task GetAllCustomers_ShouldReturnList()
        {
            // Arrange
            _context.Customers.Add(new CustomerService.Domain.Entities.Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Anna",
                LastName = "Nowak",
                Email = "anna@example.com",
                IDCardNumber = "XYZ123456",
                DateOfBirth = DateTime.UtcNow.AddYears(-25),
                Address = new CustomerService.Domain.Entities.Address
                {
                    Street = "ul. Testowa 5",
                    City = "Rzeszów",
                    PostalCode = "35-003",
                    Country = "Polska"
                }
            });

            await _context.SaveChangesAsync();

            var repository = new CustomerRepository(_context);
            var handler = new GetAllCustomersHandler(repository, _mapper);

            // Act
            var result = await handler.Handle(new GetAllCustomersQuery(), CancellationToken.None);

            // Assert
            Assert.Single(result);
            Assert.IsType<List<CustomerDto>>(result);
        }
    }
}
