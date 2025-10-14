namespace JaPark.Services.Parking.Domain.CarParts.ValueObjects;

public record SectionName
{
    public string Prefix { get; init; }
    public int Number { get; init; }

    private SectionName(string prefix, int number)
    {
        Prefix = prefix;
        Number = number;
    }

    public static Result<SectionName> From(string prefix, int number)
    {
        prefix = prefix.Trim().ToUpperInvariant();
        
        if (string.IsNullOrWhiteSpace(prefix) || 
            prefix.Length > 3 || 
            !prefix.All(char.IsAsciiLetter))
        {
            return Result.Failure<SectionName>(ParkingErrors.PrefixNotAcceptable);
        }
        return new SectionName(prefix, number);
    }
}
