namespace JaPark.Services.Billing.Domain.Billing.ValueObjects;

public record FinePrice
{
    public long Value { get; init; }
    private FinePrice(long value) => Value = value;

    public static FinePrice From(int minusScore, long basePrice)
    {
        long totalFees = basePrice * minusScore;
        return new FinePrice(totalFees);
    }
}
