using FleetService.Application.Interfaces;
using FleetService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FleetService.Infrastructure.Persistence;

public class FleetDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
    public DbSet<Bus> Buses { get; set; } = null!;
    public DbSet<Seat> Seats { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(FleetDbContext).Assembly);
    }
}
