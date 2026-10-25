namespace TripService.Domain.Entities;

public class Stop
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int LocalityId { get; set; }
    public required string Address { get; set; }

    public Locality Locality { get; set; } = null!;
    public ICollection<TripStop> TripStops { get; set; } = null!;
}
