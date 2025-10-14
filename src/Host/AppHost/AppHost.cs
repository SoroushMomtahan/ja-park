using Projects;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<JaPark_Services_Parking_Api>("parking-service");

await builder.Build().RunAsync();
