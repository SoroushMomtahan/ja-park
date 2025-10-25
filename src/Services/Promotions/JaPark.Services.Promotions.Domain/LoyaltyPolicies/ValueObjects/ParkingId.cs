namespace JaPark.Services.Promotions.Domain.LoyaltyPolicies.ValueObjects;

[Prefix("parking")]
public record ParkingId : PrefixedGuidV3
{
    private ParkingId(string value) : base(value)
    { }

    public static Result<ParkingId> From(string parkingId)
    {
        return From<ParkingId>(parkingId);
        
    }
}
