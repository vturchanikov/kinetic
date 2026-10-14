using FleetService.Application.Interfaces;
using FleetService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FleetService.Infrastructure.Persistence.Repositories;

public class BusesRepository(FleetDbContext context) : IBusesRepository
{
    public Task<List<Bus>> GetActiveBuses()
    {
        throw new NotImplementedException();
    }

    public async Task<Bus?> GetBusByCodeAsync(string code, CancellationToken cancellationToken)
    {
        return await context.Buses.FirstOrDefaultAsync(b => b.Code == code, cancellationToken);        
    }

    public Task<List<Bus>> GetBuses()
    {
        throw new NotImplementedException();
    }

    public Task<List<Bus>> GetBusesInRepair()
    {
        throw new NotImplementedException();
    }

    public Task<Bus> GetBusWithSeats(string code)
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
