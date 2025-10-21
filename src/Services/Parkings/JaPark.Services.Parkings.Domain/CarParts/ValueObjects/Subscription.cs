namespace JaPark.Services.Parkings.Domain.CarParts.ValueObjects;

public record Subscription
{
    public int MaxAcceptableSection { get; }
    public int MaxAcceptableSpace { get; }
    
    private Subscription() { }

    private Subscription(int maxAcceptableSection, int maxAcceptableSpace) => 
        (MaxAcceptableSection, MaxAcceptableSpace) =  (maxAcceptableSection, maxAcceptableSpace);
    public static readonly Subscription Default = new(1, 100);
}
