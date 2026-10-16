using FleetService.Domain.Entities;

namespace FleetService.Application.Interfaces;

public interface IBusesRepository
{
    Task<Bus?> GetBusByCodeAsync(string code, CancellationToken cancellationToken);
    Task<Bus?> GetBusWithSeatsAsync(string code, CancellationToken canelationToken);
    Task<List<Bus>> GetBusesAsync(CancellationToken cancellationToken);
    Task<List<Bus>> GetActiveBusesAsync(CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellation);
}
