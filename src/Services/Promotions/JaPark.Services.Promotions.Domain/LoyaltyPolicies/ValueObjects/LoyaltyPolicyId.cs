namespace JaPark.Services.Promotions.Domain.LoyaltyPolicies.ValueObjects;

[Prefix("loyalty-policy")]
public record LoyaltyPolicyId(string Value) : PrefixedGuidV3(Value);
