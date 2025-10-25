namespace JaPark.Services.Promotions.Domain.Coupons.ValueObjects;

[Prefix("coupon")]
public record CouponId(string Value) : PrefixedGuidV3(Value);
