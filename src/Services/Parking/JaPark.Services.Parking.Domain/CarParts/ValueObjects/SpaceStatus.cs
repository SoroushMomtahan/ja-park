namespace JaPark.Services.Parking.Domain.CarParts.ValueObjects;

public record SpaceStatus
{
    public string Value { get; }

    private SpaceStatus(string value)
    {
        Value = value;
    }
    public static readonly SpaceStatus Reserved = new("Reserved");
    public static readonly SpaceStatus Available = new("Available");
    public static readonly SpaceStatus Occupied = new("Occupied");
}
