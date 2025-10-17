namespace JaPark.Services.Parking.Domain.CarParts.ValueObjects;

public record Subscription
{
    public int MaxAcceptableSection { get; init; }
    public int MaxAcceptableSpace { get; init; }

    private Subscription(int maxAcceptableSection, int maxAcceptableSpace) => 
        (MaxAcceptableSection, MaxAcceptableSpace) =  (maxAcceptableSection, maxAcceptableSpace);
    public static readonly Subscription Default = new(1, 100);
}
