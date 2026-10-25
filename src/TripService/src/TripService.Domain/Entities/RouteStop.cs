namespace TripService.Domain.Entities;

public class RouteStop
{
    public int Id { get; set; }
    public int RouteId { get; set; }
    public int StopId { get; set; }
    public int SequeceNumber { get; set; }

    public Route Route { get; set; } = null!;
    public Stop Stop { get; set; } = null!;
}
