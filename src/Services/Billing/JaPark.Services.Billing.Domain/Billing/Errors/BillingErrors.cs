namespace JaPark.Services.Billing.Domain.Billing.Errors;

public static class BillingErrors
{
    public static readonly Error InvalidPercent = new(
        "BillingErrors.InvalidPercent",
        "درصد وارد شده صحیح نمی باشد.",
        ErrorType.Validation);

    public static readonly Error InvalidReservationInfo = new(
        "BillingErrors.InvalidDuration",
        "پایان زمان رزرو نمی تواند کمتر یا مساوی زمان شروع باشد.",
        ErrorType.Validation);
}
