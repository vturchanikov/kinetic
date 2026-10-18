using FleetService.Domain.Enums;
using FleetService.Domain.Exceptions;
using System.Reflection.PortableExecutable;

namespace FleetService.Domain.Entities;

public class Bus
{
    private readonly List<Seat> _seats = [];
    private Bus() { }
    public int Id { get; private set; }
    public string Code { get; set; } = null!;
    public string Model { get; set; } = null!;
    public int Capacity { get; private set; }
    public BusStatus Status { get; set; }

    public IReadOnlyCollection<Seat> Seats => _seats;

    public static Bus Create(string code, string model, int capacity, BusStatus status)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException("Code is Required", nameof(code));
        }
        if (string.IsNullOrWhiteSpace(model))
        {
            throw new ArgumentException("Model is Required", nameof(model));
        }
        if (!Enum.IsDefined(status))
        {
            throw new ArgumentOutOfRangeException(nameof(status), "Invalid bus status");
        }
        if(capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity));
        }

        var bus = new Bus()
        {
            Code = code,
            Model = model,
            Capacity = capacity,
            Status = status
        };

        for(int number = 1; number <= capacity; number++)
        {
            bus._seats.Add(Seat.Create(number));
        }

        return bus;
    }

    public void Deactivate()
    {
        if (Status == BusStatus.Retired)
        {
            throw new InvalidBusStateException("A retired bus cannot be deactivated.");
        }

        Status = BusStatus.Inactive;
    }

    public void SendToRepair()
    {
        if (Status == BusStatus.Retired)
        {
            throw new InvalidBusStateException("A retired bus cannot be send to repair");
        }

        Status = BusStatus.InRepair;
    }

    public void ReturnToService()
    {
        if(Status == BusStatus.Retired)
        {
            throw new InvalidBusStateException("A retired bus cannot return to service");
        }

        Status = BusStatus.Active;
    }

    public void Retire()
    {
        Status = BusStatus.Retired;
    }
}
