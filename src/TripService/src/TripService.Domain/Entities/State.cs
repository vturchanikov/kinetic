namespace TripService.Domain.Entities;

public class State
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }

    public ICollection<Locality> Localities { get; set; } = [];
}
