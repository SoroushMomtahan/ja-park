using JaPark.Services.Promotions.Domain.LoyaltyPolicies.Errors;

namespace JaPark.Services.Promotions.Domain.LoyaltyPolicies.ValueObjects;

public record LoyaltyDiscountPercent
{
    public decimal Value { get; init; }
    private LoyaltyDiscountPercent(decimal value) => Value = value;

    public static Result<LoyaltyDiscountPercent> From(decimal percent)
    {
        return percent switch
        {
            > 100 or < 1 => Result.Failure<LoyaltyDiscountPercent>(
                LoyaltyPolicyErrors.InvalidLoyaltyDiscountPercent),
            _ => new LoyaltyDiscountPercent(percent)
        };
    }
}
