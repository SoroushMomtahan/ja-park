using JaPark.Services.Billing.Domain.Billing.Errors;

namespace JaPark.Services.Billing.Domain.Billing.ValueObjects;

public enum DiscountType
{
    Loyalty,
    Lucky,
    Universal,
    PlateListSpecific
}
public record Discount
{
    public decimal Value { get; init; }
    public string Id { get; init; }
    public DiscountType Type { get; init; }
    private Discount(decimal value, string id, DiscountType type) => 
        (Value, Id, Type) = (value, id, type);

    public static Result<Discount> From(
        decimal discountPercent, 
        string discountId,
        DiscountType type)
    {
        return discountPercent switch
        {
            > 100 or < 1 => Result.Failure<Discount>(BillingErrors.InvalidPercent),
            _ => new Discount(discountPercent, discountId, type)
        };
    }
}
