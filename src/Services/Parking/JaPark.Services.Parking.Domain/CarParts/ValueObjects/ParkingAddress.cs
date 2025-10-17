namespace JaPark.Services.Parking.Domain.CarParts.ValueObjects;

public record ParkingAddress
{
    public string Map { get; init; }
    public string Text { get; init; }

    private ParkingAddress(string map, string text) => (Map, Text) = (map, text);

    public static ParkingAddress From(string map, string text)
    {
        return new ParkingAddress(map, text);
    }
}
