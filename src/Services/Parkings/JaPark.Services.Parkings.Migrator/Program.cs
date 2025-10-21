using JaPark.Services.Parkings.Infrastructure;
using JaPark.Services.Parkings.Migrator;
using JaPark.Shared.Application;
using JaPark.Shared.Infrastructure;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Migrator>();

builder
    .AddInfrastructureConfiguration() 
    .AddApplicationConfiguration(JaPark.Services.Parkings.Application.AssemblyReference.Assembly)
    .AddParkingModule("parkings-db");

IHost host = builder.Build();
await host.RunAsync();
