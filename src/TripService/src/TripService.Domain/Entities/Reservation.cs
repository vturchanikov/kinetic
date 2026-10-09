using TripService.Domain.Enums;

namespace TripService.Domain.Entities;

public class Reservation
{
    public int Id { get; set; }
    public int TripId { get; set; }
    public int SeatId { get; set; }
    public int FromStopId { get; set; }
    public int ToStopId { get; set; }

    public ReservationStatus Status { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public Trip Trip { get; set; } = null!;
    public Seat Seat { get; set; } = null!;

    public TripStop FromStop { get; set; } = null!;
    public TripStop ToStop { get; set; } = null!;
}
