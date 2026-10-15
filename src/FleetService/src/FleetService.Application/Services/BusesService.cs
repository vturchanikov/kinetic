using FleetService.Application.DTOs;
using FleetService.Application.Interfaces;
using FleetService.Domain.Entities;
using Mapster;

namespace FleetService.Application.Services;

public class BusesService(IBusesRepository busesRepository) : IBusesService
{
    public async Task<BusDto?> GetBusByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var bus = await GetBusAsync(code, cancellationToken);

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

    public async Task ActivateAsync(string code, CancellationToken cancellationToken)
    {
        var bus = await GetBusAsync(code, cancellationToken);

        bus.ReturnToService();

        await busesRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeactivateAsync(string code, CancellationToken cancellationToken)
    {
        var bus = await GetBusAsync(code, cancellationToken);

        bus.Deactivate();

        await busesRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task RetireAsync(string code, CancellationToken cancellationToken)
    {
        var bus = await GetBusAsync(code, cancellationToken);

        bus.Retire();

        await busesRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task SendToRepairAsync(string code, CancellationToken cancellationToken)
    {
        var bus = await GetBusAsync(code, cancellationToken);

        bus.SendToRepair();

        await busesRepository.SaveChangesAsync(cancellationToken);
    }

    public Task DeactivateSeatAsync(string busCode, int seatNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task ActivateSeatAsync(string busCode, int seatNumber, CancellationToken cancelToken)
    {
        throw new NotImplementedException();
    }

    public Task CreateBus(Bus bus, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBus(string code, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private async Task<Bus?> GetBusAsync(string code, CancellationToken cancellationToken)
    {
        return await busesRepository.GetBusByCodeAsync(code, cancellationToken);        
    }
}
