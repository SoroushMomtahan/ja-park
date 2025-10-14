namespace JaPark.Services.Parking.Domain.CarParts.ValueObjects;

public record ParkingAddress
{
    public string Location { get; init; }
    public string Description { get; init; }

    private ParkingAddress(string location, string description)
    {
        Location = location;
        Description = description;
    }

    public static Result<ParkingAddress> From(string location, string description)
    {
        return new ParkingAddress(location, description);
    }
}
