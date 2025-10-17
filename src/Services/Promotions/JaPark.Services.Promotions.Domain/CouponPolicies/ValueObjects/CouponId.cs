namespace JaPark.Services.Promotions.Domain.CouponPolicies.ValueObjects;

[Prefix("coupon")]
public record CouponId : PrefixedGuidV3
{
    private CouponId(string value) : base(value)
    {}

    public static Result<CouponId> From(string couponId)
    {
        Result<CouponId> couponIdOrError = From<CouponId>(couponId);
        return couponIdOrError.IsFailure ? 
            Result.Failure<CouponId>(couponIdOrError.Error) : 
            couponIdOrError;
    }
}
