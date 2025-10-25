using JaPark.Services.Parkings.Infrastructure;
using JaPark.Shared.Api;
using JaPark.Shared.Application;
using JaPark.Shared.Infrastructure;
using JaPark.Shared.Presentation.Endpoints;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder
    .AddApiConfiguration()
    .AddInfrastructureConfiguration() 
    .AddApplicationConfiguration(JaPark.Services.Parkings.Application.AssemblyReference.Assembly)
    .AddParkingModule("parkings-db");



WebApplication app = builder.Build();

app.UseApiConfiguration();

app.MapEndpoints();

await app.RunAsync();
