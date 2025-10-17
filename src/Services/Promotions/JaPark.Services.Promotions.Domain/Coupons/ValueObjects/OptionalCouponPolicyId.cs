namespace JaPark.Services.Promotions.Domain.Coupons.ValueObjects;

[Prefix("coupon-policy")]
public record CouponPolicyId(string Value) : PrefixedGuidV3(Value);

public record OptionalCouponPolicyId
{
    public Option<CouponPolicyId> Option { get; init; }
    
    private OptionalCouponPolicyId(Option<CouponPolicyId> option) => Option = option;
    
    public static readonly OptionalCouponPolicyId WithoutPolicy = new(Option<CouponPolicyId>.None);
    public static OptionalCouponPolicyId WithPolicy(string policyId) => 
        new(Option<CouponPolicyId>.Some(new CouponPolicyId(policyId)));

    public static Result<OptionalCouponPolicyId> From(string? policyId)
    {
        if (string.IsNullOrWhiteSpace(policyId))
        {
            return WithoutPolicy;
        }

        Result<CouponPolicyId> couponPolicyIdOrError = PrefixedGuidV3.From<CouponPolicyId>(policyId);
        return couponPolicyIdOrError.IsFailure ? 
            Result.Failure<OptionalCouponPolicyId>(couponPolicyIdOrError.Error) : 
            WithPolicy(policyId);
    }

    public bool TryGetPolicyId(out CouponPolicyId? policyId)
    {
        return Option.TryGetValue(out policyId);
    }
}
