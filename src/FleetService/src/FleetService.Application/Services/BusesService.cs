using FleetService.Application.DTOs;
using FleetService.Application.Interfaces;
using FleetService.Domain.Entities;
using Mapster;

namespace FleetService.Application.Services;

public class BusesService(IBusesRepository busesRepository) : IBusesService
{
    public async Task<BusDto?> GetBusByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var bus = await busesRepository.GetBusByCodeAsync(code, cancellationToken);

        return bus.Adapt<BusDto>();
    }

    public async Task<BusWithSeatsDto?> GetBusWithSeatsByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var bus = await busesRepository.GetBusWithSeatsAsync(code, cancellationToken);

        return bus.Adapt<BusWithSeatsDto>();
    }

    public async Task<List<BusDto>> GetBusesAsync(CancellationToken cancellationToken)
    {
        var buses = await busesRepository.GetBusesAsync(cancellationToken);

        return buses.Adapt<List<BusDto>>();
    }

    public async Task<List<BusDto>> GetActiveBusesAsync(CancellationToken cancellationToken)
    {
        var buses = await busesRepository.GetActiveBusesAsync(cancellationToken);

        return buses.Adapt<List<BusDto>>();
    }

    public async Task<bool> ActivateAsync(string code, CancellationToken cancellationToken)
    {
        return await UpdateBusAsync(code, cancellationToken, bus => bus.ReturnToService());
    }

    public async Task<bool> DeactivateAsync(string code, CancellationToken cancellationToken)
    {
        return await UpdateBusAsync(code, cancellationToken, bus => bus.Deactivate());
    }

    public async Task<bool> RetireAsync(string code, CancellationToken cancellationToken)
    {
        return await UpdateBusAsync(code, cancellationToken, bus => bus.Retire());
    }

    public async Task<bool> SendToRepairAsync(string code, CancellationToken cancellationToken)
    {
        return await UpdateBusAsync(code, cancellationToken, bus => bus.SendToRepair());
    }

    public Task CreateBus(Bus bus, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBus(string code, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private async Task<bool> UpdateBusAsync(string code, CancellationToken cancellationToken, Action<Bus> action)
    {
        var bus = await busesRepository.GetBusByCodeAsync(code, cancellationToken);

        if(bus is null)
        {
            return false;
        }

        action(bus);

        await busesRepository.SaveChangesAsync(cancellationToken);
        return true;
    }
}
