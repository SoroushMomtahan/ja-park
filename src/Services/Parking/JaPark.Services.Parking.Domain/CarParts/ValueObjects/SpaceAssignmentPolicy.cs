namespace JaPark.Services.Parking.Domain.CarParts.ValueObjects;

public record SpaceAssignmentPolicy
{
    public string Value { get; init; }
    private SpaceAssignmentPolicy(string value) => Value = value;
    public static readonly SpaceAssignmentPolicy Ascending = new("Ascending");
    public static readonly SpaceAssignmentPolicy Descending = new("Descending");
}
