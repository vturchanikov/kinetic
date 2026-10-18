namespace FleetService.Domain.Exceptions;

public class InvalidBusStateException(string message) : Exception(message)
{
}