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
        return await UpdateBusAsync(code, bus => bus.ReturnToService(), cancellationToken);
    }

    public async Task<bool> DeactivateAsync(string code, CancellationToken cancellationToken)
    {
        return await UpdateBusAsync(code, bus => bus.Deactivate(), cancellationToken);
    }

    public async Task<bool> RetireAsync(string code, CancellationToken cancellationToken)
    {
        return await UpdateBusAsync(code, bus => bus.Retire(), cancellationToken);
    }

    public async Task<bool> SendToRepairAsync(string code, CancellationToken cancellationToken)
    {
        return await UpdateBusAsync(code, bus => bus.SendToRepair(), cancellationToken);
    }

    public async Task<BusDto> CreateBusAsync(CreateBusDto busDto, CancellationToken cancellationToken)
    {
        var bus = Bus.Create(busDto.Code, busDto.Model, busDto.Capacity, Domain.Enums.BusStatus.Inactive);

        await busesRepository.AddAsync(bus, cancellationToken);
        await busesRepository.SaveChangesAsync(cancellationToken);

        return bus.Adapt<BusDto>();
    }

    private async Task<bool> UpdateBusAsync(string code, Action<Bus> action, CancellationToken cancellationToken)
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
