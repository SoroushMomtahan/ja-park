using System.Reflection;
using FluentValidation;
using JaPark.Shared.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JaPark.Shared.Application;

public static class ApplicationConfiguration
{
    public static IHostApplicationBuilder AddApplicationConfiguration(
        this IHostApplicationBuilder builder, params Assembly[] assemblies)
    {
        IServiceCollection services = builder.Services;
        
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(assemblies);
            config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            config.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
            config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
        });
        services.AddValidatorsFromAssemblies(assemblies, includeInternalTypes: true);
        return builder;
    }
}
