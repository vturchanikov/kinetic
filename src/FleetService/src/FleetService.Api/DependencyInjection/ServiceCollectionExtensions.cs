using FleetService.Api.ExceptionHandling;
using FleetService.Application.Validators;
using FluentValidation;

namespace FleetService.Api.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFleetApi(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        services.AddValidatorsFromAssemblyContaining<CreateBusDtoValidator>();

        return services;
    }
}
