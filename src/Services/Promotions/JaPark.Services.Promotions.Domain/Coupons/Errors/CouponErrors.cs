using JaPark.Services.Promotions.Domain.Coupons.ValueObjects;

namespace JaPark.Services.Promotions.Domain.Coupons.Errors;

public static class CouponErrors
{
    public static readonly Error MoreThan20Character = new(
        "CouponErrors.MoreThan20Character",
        $"نام کوپن نمی تواند بیشتر از {CouponName.MaxNameLength} کاراکتر باشد",
        ErrorType.Validation);
    public static readonly Error LessThan3Character = new(
        "CouponErrors.MoreThan20Character",
        $"نام کوپن نمی تواند کمتر از {CouponName.MinNameLength} کاراکتر باشد",
        ErrorType.Validation);

    public static readonly Error InvalidExpiration = new(
        "CouponErrors.InvalidCouponExpiration",
        "تاریخ انقضای کوپن اشتباه هست",
        ErrorType.Validation);
    public static readonly Error InvalidCouponPercent = new(
        "CouponErrors.InvalidCouponPercent",
        "درصد وارد شده برای کوپن صحیح نمی باشد.",
        ErrorType.Validation);
    
}
