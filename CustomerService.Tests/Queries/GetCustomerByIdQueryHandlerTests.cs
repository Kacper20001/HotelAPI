using AutoMapper;
using CustomerService.Application.Queries.GetCustomerById;
using CustomerService.Infrastructure.Data;
using CustomerService.Application.Mappings;
using CustomerService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CustomerService.Tests.Queries
{
    public class GetCustomerByIdQueryHandlerTests
    {
        private readonly CustomerDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandlerTests()
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
        public async Task Handle_ShouldReturnCorrectCustomer()
        {
            // Arrange
            var customer = new CustomerService.Domain.Entities.Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Maria",
                LastName = "Nowak",
                Email = "maria.nowak@example.com",
                DateOfBirth = DateTime.UtcNow.AddYears(-40),
                IDCardNumber = "CD654321",
                Address = new CustomerService.Domain.Entities.Address
                {
                    Street = "ul. Kwiatowa 1",
                    City = "Lublin",
                    PostalCode = "20-001",
                    Country = "Polska"
                }
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            var repository = new CustomerRepository(_context);
            var handler = new GetCustomerByIdHandler(repository, _mapper);

            // Act
            var result = await handler.Handle(new GetCustomerByIdQuery(customer.Id), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Maria", result.FirstName);
        }
    }
}
