using FleetService.Application.DTOs;
using FleetService.Application.Exceptions;
using FleetService.Application.Interfaces;
using FleetService.Domain.Entities;
using Mapster;

namespace FleetService.Application.Services;

public class BusesService(IBusesRepository busesRepository) : IBusesService
{
    public async Task<BusDto?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var bus = await busesRepository.GetByCodeAsync(code, cancellationToken);

        return bus.Adapt<BusDto>() ?? throw new BusNotFoundException(code);
    }

    public async Task<BusWithSeatsDto?> GetByCodeWithSeatsAsync(string code, CancellationToken cancellationToken)
    {
        var bus = await busesRepository.GetByCodeWithSeatsAsync(code, cancellationToken);

        return bus.Adapt<BusWithSeatsDto>() ?? throw new BusNotFoundException(code);
    }

    public async Task<List<BusDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var buses = await busesRepository.GetAllAsync(cancellationToken);

        return buses.Adapt<List<BusDto>>();
    }

    public async Task<List<BusDto>> GetActiveAsync(CancellationToken cancellationToken)
    {
        var buses = await busesRepository.GetActiveAsync(cancellationToken);

        return buses.Adapt<List<BusDto>>();
    }

    public async Task ActivateAsync(string code, CancellationToken cancellationToken)
    {
        await UpdateAsync(code, bus => bus.ReturnToService(), cancellationToken);
    }

    public async Task DeactivateAsync(string code, CancellationToken cancellationToken)
    {
        await UpdateAsync(code, bus => bus.Deactivate(), cancellationToken);
    }

    public async Task RetireAsync(string code, CancellationToken cancellationToken)
    {
        await UpdateAsync(code, bus => bus.Retire(), cancellationToken);
    }

    public async Task SendToRepairAsync(string code, CancellationToken cancellationToken)
    {
        await UpdateAsync(code, bus => bus.SendToRepair(), cancellationToken);
    }

    public async Task<BusDto> CreateAsync(CreateBusDto busDto, CancellationToken cancellationToken)
    {
        var bus = Bus.Create(busDto.Code, busDto.Model, busDto.Capacity, Domain.Enums.BusStatus.Inactive);

        await busesRepository.AddAsync(bus, cancellationToken);
        await busesRepository.SaveChangesAsync(cancellationToken);

        return bus.Adapt<BusDto>();
    }

    private async Task UpdateAsync(string code, Action<Bus> action, CancellationToken cancellationToken)
    {
        var bus = await busesRepository.GetByCodeAsync(code, cancellationToken);

        if(bus is null)
        {
            throw new BusNotFoundException(code);
        }

        action(bus);

        await busesRepository.SaveChangesAsync(cancellationToken);
    }
}
