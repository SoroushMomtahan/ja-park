namespace JaPark.Services.Parking.Domain.CarParts.Repository;

public interface IParkingRepository
{
    Task AddParking(Models.Parking parking, CancellationToken cancellationToken);
    Task RemoveParking(Models.Parking parking, CancellationToken cancellationToken);
}
