using FleetService.Domain.Entities;

namespace FleetService.Application.Interfaces;

public interface IBusesRepository
{
    Task<Bus?> GetBusByCodeAsync(string code, CancellationToken cancellationToken);
    Task<Bus?> GetBusWithSeatsAsync(string code, CancellationToken canelationToken);
    Task<List<Bus>> GetBusesAsync(CancellationToken cancellationToken);
    Task<List<Bus>> GetActiveBusesAsync(CancellationToken cancellationToken);
    Task<List<Bus>> GetBusesInRepair();
    Task<List<Bus>> GetInactiveBuses();
    Task<List<Bus>> GetRetiredBuses();
    Task SaveChangesAsync(CancellationToken cancellation);
}
