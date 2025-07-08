using CustomerService.API.Middleware;
using CustomerService.Application.Commands.CreateCustomer;
using CustomerService.Application.Interfaces;
using CustomerService.Application.Mappings;
using CustomerService.Application.Queries.GetAllCustomers;
using CustomerService.Infrastructure.Data;
using CustomerService.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CustomerDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection") ??
        "Server=HP_KACPER;Database=CustomerServiceDb;Trusted_Connection=True;Encrypt=False;"
    )
);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetAllCustomersHandler).Assembly);
});


builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Customer API", Version = "v1" });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseMiddleware<ErrorHandlingMiddleware>(); 

app.UseAuthorization();
app.MapControllers();

app.Run();
