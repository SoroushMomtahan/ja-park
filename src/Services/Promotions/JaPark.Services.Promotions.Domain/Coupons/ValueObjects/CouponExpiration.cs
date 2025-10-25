using JaPark.Services.Promotions.Domain.Coupons.Errors;

namespace JaPark.Services.Promotions.Domain.Coupons.ValueObjects;

public record CouponExpiration
{
    public DateTime Value { get; init; }
    private CouponExpiration() {}

    public static Result<CouponExpiration> From(DateTime expireIn)
    {
        if (expireIn <= DateTime.Now)
        {
            return Result.Failure<CouponExpiration>(CouponErrors.InvalidExpiration);
        }
        return new CouponExpiration
        {
            Value = expireIn
        };
    }
}
