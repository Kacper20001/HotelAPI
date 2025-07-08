using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ReservationService.API.Middleware;
using ReservationService.Application.Commands.CancelReservation;
using ReservationService.Application.Commands.ConfirmReservation;
using ReservationService.Application.Commands.CreateReservation;
using ReservationService.Application.Commands.DeleteReservation;
using ReservationService.Application.Interfaces;
using ReservationService.Application.Mappings;
using ReservationService.Infrastructure.Data;
using ReservationService.Infrastructure.HttpClients;
using ReservationService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// DB context
builder.Services.AddDbContext<ReservationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReservationConnection")));

// MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateReservationHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(ConfirmReservationHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CancelReservationHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(DeleteReservationHandler).Assembly);
});

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateReservationValidator>();
builder.Services.AddFluentValidationAutoValidation();

// Repositories
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

// Rejestracja HttpClienta do CustomerService
builder.Services.AddHttpClient<ICustomerApiClient, CustomerApiClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5216");
});
builder.Services.AddHttpClient<IDiscountApiClient, DiscountApiClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5249/"); 
});

// MVC i Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("FATAL ERROR przy starcie aplikacji: " + ex);
    throw;
}
