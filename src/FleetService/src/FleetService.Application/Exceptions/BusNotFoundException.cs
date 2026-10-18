namespace FleetService.Application.Exceptions;

public class BusNotFoundException(string code) : Exception($"No bus with code '{code}' was found")
{
}
