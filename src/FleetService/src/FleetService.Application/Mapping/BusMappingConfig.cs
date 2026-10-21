using FleetService.Application.DTOs;
using FleetService.Domain.Entities;
using Mapster;

namespace FleetService.Application.Mapping;

public static class BusMappingConfig
{
    public static void Regitster(TypeAdapterConfig config)
    {
        config.NewConfig<Bus, BusDto>();
        config.NewConfig<Seat, SeatDto>();
    }
}
