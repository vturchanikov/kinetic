using FleetService.Domain.Entities;

namespace FleetService.Application.Interfaces;

public interface IBusesRepository
{
    Task<Bus?> GetBusByCodeAsync(string code, CancellationToken cancellation);
    Task<Bus> GetBusWithSeats(string code);
    Task<List<Bus>> GetActiveBuses();
    Task<List<Bus>> GetBusesInRepair();
    Task<List<Bus>> GetInactiveBuses();
    Task<List<Bus>> GetRetiredBuses();
    Task<List<Bus>> GetBuses();
    Task SaveChangesAsync(CancellationToken cancellation);
}
