namespace TripService.Domain.Entities;

public class TripStop
{
    public int Id { get; set; }
    public int TripId { get; set; }
    public int StopId { get; set; }
    public int SequenceNumber { get; set; }

    public DateTimeOffset? ArrivalTime { get; set; }
    public DateTimeOffset? DepartureTime { get; set; }

    public Trip Trip { get; set; } = null!;
    public Stop Stop { get; set; } = null!;
}