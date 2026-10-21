using FleetService.Application.Interfaces;
using FleetService.Application.Mapping;
using FleetService.Application.Services;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FleetService.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFleetApplication(this IServiceCollection services)
    {
        BusMappingConfig.Regitster(TypeAdapterConfig.GlobalSettings);

        services.AddScoped<IBusesService, BusesService>();

        return services;
    } 
}
