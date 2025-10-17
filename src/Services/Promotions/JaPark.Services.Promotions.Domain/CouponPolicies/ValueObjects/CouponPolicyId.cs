namespace JaPark.Services.Promotions.Domain.CouponPolicies.ValueObjects;

[Prefix("coupon-policy")]
public record CouponPolicyId(string Value) : PrefixedGuidV3(Value);
