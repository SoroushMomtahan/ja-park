using JaPark.Services.Parkings.Domain.CarParts.Models;
using JaPark.Services.Parkings.Domain.CarParts.Repository;
using JaPark.Services.Parkings.Infrastructure.Data.WriteDb;

namespace JaPark.Services.Parkings.Infrastructure.CarParts.Repository;

internal sealed class ParkingRepository(
    ParkingsDbContext dbContext) : IParkingRepository
{
    public async Task AddParkingAsync(
        Parking parking, 
        CancellationToken cancellationToken)
    {
        await dbContext.Parkings.AddAsync(parking, cancellationToken);
    }

    public void RemoveParking(Parking parking)
    {
        dbContext.Parkings.Remove(parking);
    }
}
