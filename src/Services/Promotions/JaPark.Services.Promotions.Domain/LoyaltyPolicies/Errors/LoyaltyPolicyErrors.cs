namespace JaPark.Services.Promotions.Domain.LoyaltyPolicies.Errors;

public static class LoyaltyPolicyErrors
{
    public static readonly Error InvalidLoyaltyDiscountPercent = new(
        "LoyaltyPolicyErrors.InvalidLoyaltyDiscountPercent",
        "درصد وارد شده برای تخفیف وفاداری اشتباه هست",
        ErrorType.Validation);
}
