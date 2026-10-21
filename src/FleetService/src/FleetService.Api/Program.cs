using FleetService.Api.ExceptionHandling;
using FleetService.Application.Interfaces;
using FleetService.Application.Services;
using FleetService.Application.Validators;
using FleetService.Infrastructure.Persistence;
using FleetService.Infrastructure.Persistence.Repositories;
using FleetService.Infrastructure.Persistence.Seeding;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<FleetDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IBusesService, BusesService>();
builder.Services.AddTransient<IBusesRepository, BusesRepository>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddValidatorsFromAssemblyContaining<CreateBusDtoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    await using var scope = app.Services.CreateAsyncScope();

    var context = scope.ServiceProvider.GetRequiredService<FleetDbContext>();

    await SeedFleetDb.SeedAsync(context, app.Lifetime.ApplicationStopping);
}

app.Run();
