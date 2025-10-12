using System.Reflection;
using FluentValidation;
using LearnTop.Shared.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace LearnTop.Shared.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplicationConfiguration(
        this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(assemblies);
            config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            config.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
            config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
        });
        services.AddValidatorsFromAssemblies(assemblies, includeInternalTypes: true);
        return services;
    }
}
