namespace TripService.Domain.Entities;

public class Locality
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int StateId { get; set; }

    public State State { get; set; } = null!;
    public ICollection<Stop> Stops { get; set; } = [];
}