using FleetService.Domain.Enums;

namespace FleetService.Application.DTOs;

public class SeatDto
{
    public int Number { get; init; }
    public SeatStatus Status { get; init; }
}
