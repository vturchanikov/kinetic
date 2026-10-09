namespace TripService.Domain.Entities;

public class Seat
{
    public int Id { get; set; }
    public int CarriageId { get; set; }
    public int Number { get; set; }
    public Carriage Carriage { get; set; } = null!;
}
