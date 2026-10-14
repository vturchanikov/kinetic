using FleetService.Application.Interfaces;
using FleetService.Domain.Entities;

namespace FleetService.Application.Services;

public class BusesService(IBusesRepository busesRepository) : IBusesService
{
    public async Task<Bus?> GetBusByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var bus = await GetBusAsync(code, cancellationToken);

        return bus;
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

    public async Task Retire(string code, CancellationToken cancellationToken)
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

    private async Task<Bus?> GetBusAsync(string code, CancellationToken cancellationToken)
    {
        var bus = await busesRepository.GetBusByCodeAsync(code, cancellationToken);

        return bus;
    }
}
