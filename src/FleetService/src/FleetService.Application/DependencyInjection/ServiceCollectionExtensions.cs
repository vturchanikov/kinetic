using FleetService.Application.Interfaces;
using FleetService.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FleetService.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFleetApplication(this IServiceCollection services)
    {
        services.AddScoped<IBusesService, BusesService>();

        return services;
    } 
}
