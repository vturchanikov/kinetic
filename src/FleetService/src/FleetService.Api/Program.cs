using FleetService.Infrastructure.Persistence;
using FleetService.Infrastructure.Persistence.Seeding;
using FleetService.Infrastructure.DependencyInjection;
using FleetService.Application.DependencyInjection;
using FleetService.Api.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddFleetInfrastructure(builder.Configuration);
builder.Services.AddFleetApplication();
builder.Services.AddFleetApi();

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
