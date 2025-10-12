using JaPark.Shared.Application.Caching;
using JaPark.Shared.Application.EventBus;
using JaPark.Shared.Infrastructure.Authentication;
using JaPark.Shared.Infrastructure.Authorization;
using JaPark.Shared.Infrastructure.Caching;
using JaPark.Shared.Infrastructure.Outbox;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Quartz;
using ServiceDefaults;

namespace JaPark.Shared.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructureConfiguration(
        this IHostApplicationBuilder builder,
        Action<IRegistrationConfigurator>[] moduleConfigureConsumers)
    {

        builder.AddServiceDefaults();
        
        IServiceCollection services = builder.Services;
        
        services.AddAuthenticationInternal();
        services.AddAuthorizationInternal();

        services.AddRedisCache(builder);
        services.AddMessagingServices(moduleConfigureConsumers);
        services.AddQuartzService();
        
        return services;
    }
    
    private static void AddRedisCache(this IServiceCollection services, IHostApplicationBuilder builder)
    {
        services.TryAddSingleton<ICacheService, CacheService>();

        builder.AddKeyedRedisDistributedCache("cache");
    }
    private static void AddMessagingServices(
        this IServiceCollection services,
        Action<IRegistrationConfigurator>[] moduleConfigureConsumers)
    {
        services.TryAddSingleton<InsertOutboxMessageInterceptor>();
        
        services.AddSingleton<IEventBus, EventBus.EventBus>();
        
        services.AddMassTransit(config =>
        {
            foreach (Action<IRegistrationConfigurator> moduleConfigureConsumer in moduleConfigureConsumers)
            {
                moduleConfigureConsumer(config);
            }
            config.UsingInMemory((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });
    }
    private static void AddQuartzService(this IServiceCollection services)
    {
        services.AddQuartz();
        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);
    }
}
