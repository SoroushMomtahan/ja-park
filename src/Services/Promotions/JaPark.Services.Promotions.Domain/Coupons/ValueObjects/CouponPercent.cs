using JaPark.Services.Promotions.Domain.Coupons.Errors;

namespace JaPark.Services.Promotions.Domain.Coupons.ValueObjects;

public record CouponPercent
{
    public decimal Value { get; init; }
    private CouponPercent() {}

    public static Result<CouponPercent> From(decimal value)
    {
        return value switch
        {
            > 100 or < 1 => Result.Failure<CouponPercent>(CouponErrors.InvalidCouponPercent),
            _ => new CouponPercent()
            {
                Value = value
            }
        };
    }
}
