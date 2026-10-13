using FleetService.Domain.Enums;

namespace FleetService.Infrastructure.Persistence.Seeding;

public class SeedBusDto
{
    public required string Code { get; init; }
    public required string Model { get; init; }
    public required int Capacity { get; init; }
    public BusStatus Status { get; init; }
}
