namespace JaPark.Services.Parking.Domain.CarParts.ValueObjects;

public record ParkingType
{
    public string Value { get; init; }
    private ParkingType(string value)
    {
        Value = value;
    }
    public static readonly ParkingType Surface = new("Surface");
    public static readonly ParkingType MultiLevel = new("MultiLevel");
}
