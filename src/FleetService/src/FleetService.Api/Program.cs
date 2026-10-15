using FleetService.Application.Interfaces;
using FleetService.Application.Services;
using FleetService.Infrastructure.Persistence;
using FleetService.Infrastructure.Persistence.Repositories;
using FleetService.Infrastructure.Persistence.Seeding;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<FleetDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IBusesService, BusesService>();
builder.Services.AddTransient<IBusesRepository, BusesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    await using var scope = app.Services.CreateAsyncScope();

    var context = scope.ServiceProvider.GetRequiredService<FleetDbContext>();

    await SeedFleetDb.SeedAsync(context, app.Lifetime.ApplicationStopping);
}

app.Run();
