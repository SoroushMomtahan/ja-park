using JaPark.Services.Parkings.Domain.CarParts.Models;

namespace JaPark.Services.Parkings.Domain.CarParts.Repository;

public interface IParkingRepository
{
    Task AddParkingAsync(Parking parking, CancellationToken cancellationToken);
    void RemoveParking(Parking parking);
}
