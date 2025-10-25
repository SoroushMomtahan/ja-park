namespace JaPark.Services.Billing.Domain.Billing.ValueObjects;

public record TotalPrice
{
    public long Value { get; init; }
    private TotalPrice(long value) => Value = value;

    public static TotalPrice From(long totalPrice)
    {
        return new TotalPrice(totalPrice);
    }
}
