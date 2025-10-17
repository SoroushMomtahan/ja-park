using JaPark.Services.Billing.Domain.Billing.ValueObjects;

namespace JaPark.Services.Billing.Domain.Billing.Models;

public sealed class Billing : Aggregate<BillingId>
{
    public ParkingId ParkingId { get; init; }
    public BookingId BookingId { get; init; }
    public FineId FineId { get; init; }
    public ReservationPrice ReservationPrice { get; init; }
    public FinePrice FinePrice { get; init; }
    public TotalPrice TotalPrice { get; set; }
    public Discount Discount { get; init; }
    public BillingStatus Status { get; private set; } = BillingStatus.Default;
    
    private Billing() { }

    public static Billing Create(
        ParkingId parkingId,
        BookingId bookingId,
        FineId fineId,
        ReservationPrice reservationPrice,
        FinePrice finePrice,
        Discount discount)
    {
        var billing = new Billing()
        {
            ParkingId = parkingId,
            BookingId = bookingId,
            FineId = fineId,
            ReservationPrice = reservationPrice,
            FinePrice = finePrice,
            Discount = discount,
        };
        billing.CalculateTotalPrice();
        return billing;
    }

    private void CalculateTotalPrice()
    {
        long totalPrice = ReservationPrice.Value + FinePrice.Value * (long)(100 - Discount.Value);
        TotalPrice = TotalPrice.From(totalPrice);
    }

    public void UpdateStatus(BillingStatus status)
    {
        Status = status;
    }
}
