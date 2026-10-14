using FleetService.Domain.Entities;

namespace FleetService.Application.Interfaces;

public interface IBusesService
{
    Task SendToRepairAsync(string code, CancellationToken cancellationToken);
    Task ActivateAsync(string code, CancellationToken cancellationToken);
    Task DeactivateAsync(string code, CancellationToken cancellationToken);
    Task Retire(string code, CancellationToken cancellationToken);

    Task<Bus?> GetBusByCodeAsync(string code, CancellationToken cancellationToken);
}
