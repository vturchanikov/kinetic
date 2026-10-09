namespace TripService.Domain.Entities;

public class TripStop
{
    public int Id { get; set; }
    public int TripId { get; set; }
    public int StationId { get; set; }
    public required int Sequence { get; set; }
    public DateTime? ScheduledArrival { get; set; }
    public DateTime? ScheduledDeparture { get; set; }
    public Trip Trip { get; set; } = null!;
    public Station Station { get; set; } = null!;
}