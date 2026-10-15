using FleetService.Application.Interfaces;
using FleetService.Domain.Entities;
using FleetService.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace FleetService.Infrastructure.Persistence.Repositories;

public class BusesRepository(FleetDbContext context) : IBusesRepository
{
    public async Task<Bus?> GetBusByCodeAsync(string code, CancellationToken cancellationToken)
    {
        return await context.Buses.FirstOrDefaultAsync(b => b.Code == code, cancellationToken);
    }
    public async Task<Bus?> GetBusWithSeatsAsync(string code, CancellationToken cancellationToken)
    {
        return await context.Buses.Include(b => b.Seats).FirstOrDefaultAsync(b => b.Code == code);
    }
    public async Task<List<Bus>> GetBusesAsync(CancellationToken cancellationToken)
    {
        return await context.Buses.ToListAsync();
    }
    public async Task<List<Bus>> GetActiveBusesAsync(CancellationToken cancellationToken)
    {
        return await context.Buses.Where(b => b.Status == BusStatus.Active).ToListAsync();
    }

    public Task<List<Bus>> GetBusesInRepair()
    {
        throw new NotImplementedException();
    }    

    public Task<List<Bus>> GetInactiveBuses()
    {
        throw new NotImplementedException();
    }

    public Task<List<Bus>> GetRetiredBuses()
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(); 
    }
}
