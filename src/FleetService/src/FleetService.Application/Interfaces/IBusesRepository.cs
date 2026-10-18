using FleetService.Domain.Entities;

namespace FleetService.Application.Interfaces;

public interface IBusesRepository
{
    Task<Bus?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<Bus?> GetByCodeWithSeatsAsync(string code, CancellationToken canelationToken);
    Task<List<Bus>> GetAllAsync(CancellationToken cancellationToken);
    Task<List<Bus>> GetActiveAsync(CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellation);
    Task AddAsync(Bus bus, CancellationToken cancellationToken);
}
