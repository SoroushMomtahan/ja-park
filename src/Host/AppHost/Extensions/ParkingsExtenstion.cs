using Projects;

namespace AppHost.Extensions;

internal static class ParkingsExtenstion
{
    public static IDistributedApplicationBuilder AddParkingServices(
        this IDistributedApplicationBuilder builder,
        IResourceBuilder<PostgresDatabaseResource> parkingsDb)
    {
        IResourceBuilder<ProjectResource> parkingsApi = builder
            .AddProject<JaPark_Services_Parkings_Api>("parkings-api")
            .WithReference(parkingsDb)
            .WaitFor(parkingsDb);

        IResourceBuilder<ProjectResource> parkingsMigrator =
            builder
                .AddProject<JaPark_Services_Parkings_Migrator>("parkings-migrator")
                .WithReference(parkingsDb)
                .WithParentRelationship(parkingsApi);

        parkingsApi
            .WithReference(parkingsMigrator)
            .WaitForCompletion(parkingsMigrator);
        
        return builder;
    }
}
