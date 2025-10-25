namespace JaPark.Services.Penalize.Domain.Penalize.ValueObjects;

public record FineDescription
{
    public int MinusScore { get; init; }
    public string Description { get; init; }
    private FineDescription(int minusScore, string description) => 
        (MinusScore, Description) = (minusScore, description);

    public static readonly FineDescription BadParking = new(
        1,
        "بد پارک کردن خودرو");
}
