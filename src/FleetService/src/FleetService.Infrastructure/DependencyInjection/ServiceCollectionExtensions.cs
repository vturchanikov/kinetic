using FleetService.Application.Interfaces;
using FleetService.Infrastructure.Persistence;
using FleetService.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FleetService.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFleetInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FleetDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<FleetDbContext>());
        services.AddScoped<IBusesRepository, BusesRepository>();

        return services;
    }
}
