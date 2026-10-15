using FleetService.Application.DTOs;
using FleetService.Domain.Entities;

namespace FleetService.Application.Interfaces;

public interface IBusesService
{
    Task SendToRepairAsync(string code, CancellationToken cancellationToken);
    Task ActivateAsync(string code, CancellationToken cancellationToken);
    Task DeactivateAsync(string code, CancellationToken cancellationToken);
    Task RetireAsync(string code, CancellationToken cancellationToken);

    Task<BusDto?> GetBusByCodeAsync(string code, CancellationToken cancellationToken);
    Task<BusWithSeatsDto?> GetBusWithSeatsByCodeAsync(string code, CancellationToken cancellationToken);
    Task<List<BusDto>> GetBusesAsync(CancellationToken cancellationToken);
    Task<List<BusDto>> GetActiveBusesAsync(CancellationToken cancellationToken);
    

    Task DeactivateSeatAsync(string busCode, int seatNumber, CancellationToken cancellationToken);
    Task ActivateSeatAsync(string busCode, int seatNumber, CancellationToken cancelToken);

    Task CreateBus(Bus bus,  CancellationToken cancellationToken);
    Task DeleteBus(string code, CancellationToken cancellationToken);
}
