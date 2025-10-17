namespace JaPark.Services.Promotions.Domain.Coupons.ValueObjects;

public record CouponDescription
{
    public string Value { get; init; }
    private CouponDescription(string value) => Value = value;

    public static CouponDescription From(string description)
    {
        return new CouponDescription(description);
    }
    public static implicit operator string(CouponDescription couponDescription) => couponDescription.Value;
    public static implicit operator CouponDescription(string description) => From(description);
}
