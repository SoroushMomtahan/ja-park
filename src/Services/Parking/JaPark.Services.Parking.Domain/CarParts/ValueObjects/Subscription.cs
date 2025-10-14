namespace JaPark.Services.Parking.Domain.CarParts.ValueObjects;

public record Subscription
{
    public int MaxAcceptableSection { get; set; }
    public int MaxAcceptableSpace { get; set; }

    public Subscription(int maxAcceptableSection, int maxAcceptableSpace)
    {
        MaxAcceptableSection = maxAcceptableSection;
        MaxAcceptableSpace = maxAcceptableSpace;
    }

    public static readonly Subscription Default = new(1, 50);
}
