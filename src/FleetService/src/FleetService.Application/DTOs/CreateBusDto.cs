namespace FleetService.Application.DTOs;

public class CreateBusDto
{
    public required string Code { get; init; }
    public required string Model { get; init; }
    public required int Capacity { get; init; }
}
