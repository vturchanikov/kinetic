namespace FleetService.Application.DTOs;

public class BusWithSeatsDto : BusDto
{
    public IReadOnlyCollection<SeatDto> Seats { get; init; } = [];
}
