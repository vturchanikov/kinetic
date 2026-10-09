using System.Reflection.PortableExecutable;

namespace TripService.Domain.Entities;

public class Station
{
    public int Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
}
