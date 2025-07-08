using DiscountService.Application.Commands.CreateDiscount;
using DiscountService.Application.Interfaces;
using DiscountService.Infrastructure.Data;
using DiscountService.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DiscountService.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DiscountDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DiscountConnection")));

builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateDiscountHandler).Assembly);
});

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddValidatorsFromAssemblyContaining<CreateDiscountValidator>();
builder.Services.AddFluentValidationAutoValidation();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
