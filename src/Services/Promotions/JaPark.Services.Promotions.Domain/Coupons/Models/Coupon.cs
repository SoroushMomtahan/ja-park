using JaPark.Services.Promotions.Domain.Coupons.ValueObjects;

namespace JaPark.Services.Promotions.Domain.Coupons.Models;

public sealed class Coupon : Aggregate<CouponId>
{
    public ParkingId ParkingId { get; init; }
    public CouponName Name { get; init; }
    public CouponDescription Description { get; init; }
    public CouponExpiration Expiration { get; init; }
    public CouponPercent CouponPercent { get; init; }
    
    private Coupon() {}

    public bool IsActive() => Expiration.Value > DateTime.Now;

    public static Coupon Create(
        ParkingId parkingId,
        CouponName name, 
        CouponDescription description, 
        CouponExpiration expiration,
        CouponPercent couponPercent)
    {
        return new Coupon
        {
            ParkingId = parkingId,
            Name = name,
            Description = description,
            Expiration = expiration,
            CouponPercent = couponPercent
        };
    }
}
