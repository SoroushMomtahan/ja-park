namespace JaPark.Services.Promotions.Domain.CouponPolicies.Errors;

public static class CouponPolicyErrors
{
    public static readonly Error InvalidPlate = new(
        "CouponPolicyErrors.InvalidPlate",
        "شماره پلاک وارد شده صحیح نمی باشد.",
        ErrorType.Validation);

    public static readonly Error EmptyPlateList = new(
        "CouponPolicyErrors.EmptyPlateList",
        "لیست پلاک ها نمی تواند خالی باشد.",
        ErrorType.Validation);

    public static readonly Error NotAcceptablePlateNumber = new(
        "CouponPolicyErrors.NotAcceptablePlateNumber",
        "کوپن عمومی نمی تواند شامل شماره پلاک باشد.",
        ErrorType.Validation);
}
