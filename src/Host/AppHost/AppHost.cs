using AppHost.Extensions;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<PostgresServerResource> sharedPostgresServer =
    builder
        .AddPostgres("postgres")
        .WithLifetime(ContainerLifetime.Persistent)
        .WithPgAdmin();

IResourceBuilder<PostgresDatabaseResource> parkingsDb =
    sharedPostgresServer
        .AddDatabase("parkings-db");

builder.AddParkingServices(parkingsDb);

await builder.Build().RunAsync();
