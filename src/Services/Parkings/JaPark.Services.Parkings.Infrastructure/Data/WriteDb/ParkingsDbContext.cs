using JaPark.Services.Parkings.Domain.CarParts.Models;
using JaPark.Services.Parkings.Infrastructure.CarParts.Configurations;
using Microsoft.EntityFrameworkCore.Design;

namespace JaPark.Services.Parkings.Infrastructure.Data.WriteDb;

public class ParkingsDbContext(
    DbContextOptions<ParkingsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Parking> Parkings => Set<Parking>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ParkingConfiguration());
    }
}

public class MyApiDbContextFactory : IDesignTimeDbContextFactory<ParkingsDbContext>
{
    public ParkingsDbContext CreateDbContext(string[] args)
    {
        // Here you provide the connection string that the 'dotnet ef' tools will use.
        // This is ONLY for design-time tools, not for your running application.
        // Get this connection string from your local database instance (e.g., from Aspire dashboard when it's running).
        string connectionString = "Server=localhost;Port=10138;Database=parkings-db;User Id=postgres;Password=vzN4}CE7Y7a{q*8-_Y8-j6;";

        var optionsBuilder = new DbContextOptionsBuilder<ParkingsDbContext>();
        
        // Configure the DbContext to use your chosen database provider.
        optionsBuilder.UseNpgsql(connectionString);

        return new ParkingsDbContext(optionsBuilder.Options);
    }
}
