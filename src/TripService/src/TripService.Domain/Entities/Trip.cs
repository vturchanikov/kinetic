namespace TripService.Domain.Entities;

public class Trip
{
    public int Id { get; set; }
    public int BusId { get; set; }
    public int RouteId { get; set; }

    public Route Route { get; set; } = null!;
    public ICollection<TripStop> Stops { get; set; } = [];
}
