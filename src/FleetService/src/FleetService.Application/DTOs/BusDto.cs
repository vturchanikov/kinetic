using FleetService.Domain.Enums;

namespace FleetService.Application.DTOs;

public class BusDto
{
    public int Id { get; set; }
    public required string Code { get; set; }
    public required string Model { get; set; }
    public int Capacity { get; set; }
    public BusStatus Status { get; set; }
}
