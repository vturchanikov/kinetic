using FleetService.Domain.Enums;

namespace FleetService.Domain.Entities;

public class Seat
{
    public int Id { get; set; }
    public int Number { get; set; }
    public SeatStatus Status { get; set; }
    public int BusId { get; set; }
    public Bus Bus { get; set; } = null!;
}
