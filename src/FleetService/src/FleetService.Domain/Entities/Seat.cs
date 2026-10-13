using FleetService.Domain.Enums;

namespace FleetService.Domain.Entities;

public class Seat
{
    private Seat() { }
    private Seat(int number)
    {
        Number = number;
        Status = SeatStatus.Active;
    }
    public int Id { get; private set; }
    public int Number { get; private set; }
    public SeatStatus Status { get; private set; }
    public int BusId { get; private set; }
    public Bus Bus { get; private set; } = null!;

    internal static Seat Create(int number)
    {
        return new Seat(number);
    }
}
