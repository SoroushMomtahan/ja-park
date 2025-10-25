using JaPark.Services.Parkings.Infrastructure;
using JaPark.Services.Parkings.Migrator;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Migrator>();

builder.AddDbForMigration("parkings-db");

IHost host = builder.Build();
await host.RunAsync();
