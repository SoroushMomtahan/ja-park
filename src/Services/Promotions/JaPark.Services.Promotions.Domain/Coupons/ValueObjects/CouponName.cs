

using JaPark.Services.Promotions.Domain.Coupons.Errors;

namespace JaPark.Services.Promotions.Domain.Coupons.ValueObjects;

public record CouponName
{
    public const int MaxNameLength = 20;
    public const int MinNameLength = 3;
    public string Value { get; init; }
    private CouponName() { }

    public static Result<CouponName> From(string code)
    {
        code = code.Trim();
        return code.Length switch
        {
            < MinNameLength => Result.Failure<CouponName>(CouponErrors.LessThan3Character),
            > MaxNameLength => Result.Failure<CouponName>(CouponErrors.MoreThan20Character),
            _ => new CouponName { Value = code }
        };
    }
}
