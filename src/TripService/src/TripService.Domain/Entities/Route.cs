using TripService.Domain.Enums;

namespace TripService.Domain.Entities;

public class Route
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public RouteStatus Status { get; set; }

    public ICollection<RouteStop> RouteStops { get; set; } = null!;
}
