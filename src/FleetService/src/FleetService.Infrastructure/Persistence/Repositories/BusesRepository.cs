using FleetService.Application.DTOs;
using FleetService.Application.Interfaces;
using FleetService.Domain.Entities;
using FleetService.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace FleetService.Infrastructure.Persistence.Repositories;

public class BusesRepository(FleetDbContext context) : IBusesRepository
{
    public async Task<Bus?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        return await context.Buses.FirstOrDefaultAsync(b => b.Code == code, cancellationToken);
    }
    public async Task<Bus?> GetByCodeWithSeatsAsync(string code, CancellationToken cancellationToken)
    {
        return await context.Buses.Include(b => b.Seats).FirstOrDefaultAsync(b => b.Code == code);
    }
    public async Task<List<Bus>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Buses.ToListAsync();
    }
    public async Task<List<Bus>> GetActiveAsync(CancellationToken cancellationToken)
    {
        return await context.Buses.Where(b => b.Status == BusStatus.Active).ToListAsync();
    }

    public async Task AddAsync(Bus bus, CancellationToken cancellationToken)
    {
        await context.Buses.AddAsync(bus);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(); 
    }
}
