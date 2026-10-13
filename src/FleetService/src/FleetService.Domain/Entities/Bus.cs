using System.Reflection.PortableExecutable;

namespace FleetService.Domain.Entities;

public class Bus
{
    public int Id { get; set; }
    public required string Code { get; set; }
    public required string Model { get; set; }
    public int Capacity { get; set; }

    public ICollection<Seat> Seats { get; set; } = null!;
}
