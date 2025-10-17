using JaPark.Services.Billing.Domain.Billing.Errors;

namespace JaPark.Services.Billing.Domain.Billing.ValueObjects;

public record ReservationPrice
{
    public long Value { get; init; }
    private ReservationPrice(long value) => 
        Value = value;

    public static Result<ReservationPrice> From(
        DateTime startTime, 
        DateTime endTime,
        int minBlock,
        long feePerBlock)
    {
        if (endTime <= startTime)
        {
            return Result.Failure<ReservationPrice>(
                BillingErrors.InvalidReservationInfo);
        }
        TimeSpan duration = endTime - startTime;
        double totalMinutes = duration.TotalMinutes;
        double totalBlocks = totalMinutes / minBlock;
        long roundedTotalBlocks = (long)Math.Ceiling(totalBlocks);
        long totalFees = roundedTotalBlocks * feePerBlock;
        return new ReservationPrice(totalFees);
    }
}
