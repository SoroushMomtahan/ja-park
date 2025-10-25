using JaPark.Shared.Api.ConfigureOptions.ApiInfoOptions;
using JaPark.Shared.Api.ConfigureOptions.SwaggerOptions;
using JaPark.Shared.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceDefaults;

namespace JaPark.Shared.Api;

public static class ApiConfiguration
{
    public static IHostApplicationBuilder AddApiConfiguration(
        this IHostApplicationBuilder builder)
    {
        builder.AddServiceDefaults();
        
        IServiceCollection services = builder.Services;
        
        services.AddSwaggerServices();
        services.AddProblemHandlingServices();
        
        return builder;
    }

    public static IApplicationBuilder UseApiConfiguration(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseExceptionHandler();
        app.UseStatusCodePages();
        app.UseHttpsRedirection();
        return app;
    }

    private static void AddSwaggerServices(this IServiceCollection services)
    {
        
        services.ConfigureOptions<ApiInfoOptionsSetup>();
        services.ConfigureOptions<SwaggerGenOptionsSetup>();
        services.ConfigureOptions<SwaggerUiOptionsSetup>();
        
        // for finding api's by swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    private static void AddProblemHandlingServices(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
    }
}
