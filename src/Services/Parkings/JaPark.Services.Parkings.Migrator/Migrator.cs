using System.Diagnostics;
using JaPark.Services.Parkings.Infrastructure.Data.WriteDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace JaPark.Services.Parkings.Migrator;

internal sealed class Migrator(
    IServiceProvider serviceProvider,  
    IHostApplicationLifetime hostApplicationLifetime) : BackgroundService
{
    public const string ActivitySourceName = "Migrations";  
    private static readonly ActivitySource ActivitySource = new(ActivitySourceName); 

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using Activity? activity = ActivitySource.StartActivity("Migrating database", ActivityKind.Client);  
  
        try  
        {  
            using IServiceScope scope = serviceProvider.CreateScope();  
            ParkingsDbContext dbContext = scope.ServiceProvider.GetRequiredService<ParkingsDbContext>();  
            
            await EnsureDatabaseAsync(dbContext, stoppingToken);  
            await RunMigrationAsync(dbContext, stoppingToken);
        }        
        catch (Exception ex)  
        {            
            activity?.AddException(ex);  
            throw;  
        }  
        hostApplicationLifetime.StopApplication(); 
    }
    private static async Task EnsureDatabaseAsync(ParkingsDbContext dbContext, CancellationToken cancellationToken)  
    {        
        IRelationalDatabaseCreator dbCreator = dbContext.GetService<IRelationalDatabaseCreator>();  
  
        IExecutionStrategy strategy = dbContext.Database.CreateExecutionStrategy();  
        await strategy.ExecuteAsync(async () =>  
        {  
            // Create the database if it does not exist.  
            // Do this first so there is then a database to start a transaction against.            
            if (!await dbCreator.ExistsAsync(cancellationToken))  
            {                
                await dbCreator.CreateAsync(cancellationToken);  
            }        
        });    
    } 
    private static async Task RunMigrationAsync(ParkingsDbContext dbContext, CancellationToken cancellationToken)  
    {        
        IExecutionStrategy strategy = dbContext.Database.CreateExecutionStrategy();  
        await strategy.ExecuteAsync(async () =>  
        {  
            // Run migration in a transaction to avoid partial migration if it fails.  
            await dbContext.Database.MigrateAsync(cancellationToken);
        });    
    }
}
