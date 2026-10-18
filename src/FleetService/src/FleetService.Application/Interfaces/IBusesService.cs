using FleetService.Application.DTOs;
using FleetService.Domain.Entities;

namespace FleetService.Application.Interfaces;

public interface IBusesService
{
    Task<bool> SendToRepairAsync(string code, CancellationToken cancellationToken);
    Task<bool> ActivateAsync(string code, CancellationToken cancellationToken);
    Task<bool> DeactivateAsync(string code, CancellationToken cancellationToken);
    Task<bool> RetireAsync(string code, CancellationToken cancellationToken);

    Task<BusDto?> GetBusByCodeAsync(string code, CancellationToken cancellationToken);
    Task<BusWithSeatsDto?> GetBusWithSeatsByCodeAsync(string code, CancellationToken cancellationToken);
    Task<List<BusDto>> GetBusesAsync(CancellationToken cancellationToken);
    Task<List<BusDto>> GetActiveBusesAsync(CancellationToken cancellationToken);

    Task<BusDto> CreateBusAsync(CreateBusDto bus,  CancellationToken cancellationToken);
}
