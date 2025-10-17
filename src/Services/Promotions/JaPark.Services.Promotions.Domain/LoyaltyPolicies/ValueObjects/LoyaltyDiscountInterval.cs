namespace JaPark.Services.Promotions.Domain.LoyaltyPolicies.ValueObjects;

public record LoyaltyDiscountInterval
{
    public int Value { get; init; }
    private LoyaltyDiscountInterval(int value) => Value = value;

    public static LoyaltyDiscountInterval From(int interval)
    {
        return new LoyaltyDiscountInterval(interval);
    }
}
