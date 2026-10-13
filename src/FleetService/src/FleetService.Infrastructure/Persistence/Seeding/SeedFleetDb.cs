using FleetService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FleetService.Infrastructure.Persistence.Seeding;

public class SeedFleetDb
{
    public static async Task SeedAsync(FleetDbContext context, CancellationToken cancellationToken)
    {
        // TODO: move this to a separate method
        await context.Database.MigrateAsync(cancellationToken);

        if (await context.Buses.AnyAsync(cancellationToken)) return;

        var filePath = Path.Combine(AppContext.BaseDirectory, "Seeding", "Data", "BusSeedData.json");
        var busData = await File.ReadAllTextAsync(filePath, cancellationToken);
        var buses = JsonSerializer.Deserialize<List<SeedBusDto>>(busData);

        if(buses == null || buses.Count == 0)
        {
            throw new InvalidOperationException("No buses in seed data.");
        }

        foreach(var bus in buses)
        {
            var item = Bus.Create(bus.Code, bus.Model, bus.Capacity);
            context.Buses.Add(item);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}
