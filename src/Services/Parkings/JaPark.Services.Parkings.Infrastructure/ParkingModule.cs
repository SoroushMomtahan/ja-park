using JaPark.Services.Parkings.Domain.CarParts.Repository;
using JaPark.Services.Parkings.Infrastructure.CarParts.Repository;
using JaPark.Services.Parkings.Infrastructure.Data.WriteDb;
using JaPark.Services.Parkings.Presentation;
using JaPark.Shared.Presentation.Endpoints;

namespace JaPark.Services.Parkings.Infrastructure;

public static class ParkingModule
{
    public static IServiceCollection AddParkingModule(
        this IHostApplicationBuilder builder, 
        string connectionString)
    {
        IServiceCollection services = builder.Services;
        builder.AddWriteDb(connectionString);
        services.AddEndpoints(EndpointAssemblyReference.Assembly);
        return services;
    }

    private static void AddWriteDb(this IHostApplicationBuilder builder, string connectionString)
    {
        builder.AddNpgsqlDbContext<ParkingsDbContext>(connectionString);
        builder.Services.AddScoped<IParkingRepository, ParkingRepository>();
        builder.Services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ParkingsDbContext>());
    }
}
