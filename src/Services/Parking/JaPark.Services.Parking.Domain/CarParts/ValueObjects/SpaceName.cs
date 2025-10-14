namespace JaPark.Services.Parking.Domain.CarParts.ValueObjects;

public record SpaceName
{
    public string Prefix { get; init; }
    public int Number { get; init; }
    
    private SpaceName(string prefix, int number) => (Prefix, Number) = (prefix, number);

    public static SpaceName From(string prefix, int number)
    {
        return new SpaceName(prefix, number);
    }
}
