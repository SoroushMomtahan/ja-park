namespace JaPark.Services.Parking.Domain.CarParts.Repository;

public interface IParkingRepository
{
    Task AddParkingAsync(Models.Parking parking, CancellationToken cancellationToken);
    Task RemoveParkingAsync(Models.Parking parking, CancellationToken cancellationToken);
}
