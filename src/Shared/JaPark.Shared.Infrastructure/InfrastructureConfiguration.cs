using LearnTop.Shared.Application.Caching;
using LearnTop.Shared.Application.EventBus;
using LearnTop.Shared.Infrastructure.Authentication;
using LearnTop.Shared.Infrastructure.Authorization;
using LearnTop.Shared.Infrastructure.Caching;
using LearnTop.Shared.Infrastructure.Outbox;
using LearnTop.Shared.ServiceDefaults;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Quartz;

namespace LearnTop.Shared.Infrastructure;

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
