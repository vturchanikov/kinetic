using FleetService.Application.DTOs;
using FleetService.Domain.Entities;

namespace FleetService.Application.Interfaces;

public interface IBusesService
{
    Task SendToRepairAsync(string code, CancellationToken cancellationToken);
    Task ActivateAsync(string code, CancellationToken cancellationToken);
    Task DeactivateAsync(string code, CancellationToken cancellationToken);
    Task RetireAsync(string code, CancellationToken cancellationToken);

    Task<BusDto?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<BusWithSeatsDto?> GetByCodeWithSeatsAsync(string code, CancellationToken cancellationToken);
    Task<List<BusDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<List<BusDto>> GetActiveAsync(CancellationToken cancellationToken);

    Task<BusDto> CreateAsync(CreateBusDto bus,  CancellationToken cancellationToken);
}
