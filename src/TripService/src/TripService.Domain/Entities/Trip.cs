namespace TripService.Domain.Entities;

public class Trip
{
    public int Id { get; set; }
    public int TrainId { get; set; }
    public required DateTime ScheduledDeparture { get; set; }
    //public Train Train { get; set; } = null!;
    public ICollection<TripStop> Stops { get; set; } = [];
}
