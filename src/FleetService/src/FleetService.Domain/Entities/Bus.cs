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

    public IReadOnlyCollection<Seat> Seats => _seats;

    public static Bus Create(string code, string model, int capacity)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException("Code is Required", nameof(code));
        }
        if (string.IsNullOrWhiteSpace(model))
        {
            throw new ArgumentException("Model is Required", nameof(model));
        }
        if(capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity));
        }

        var bus = new Bus()
        {
            Code = code,
            Model = model,
            Capacity = capacity
        };

        for(int number = 1; number <= capacity; number++)
        {
            bus._seats.Add(Seat.Create(number));
        }

        return bus;
    }
}
