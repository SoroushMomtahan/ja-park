namespace JaPark.Services.Promotions.Domain.Coupons.ValueObjects;

[Prefix("parking")]
public record ParkingId(string Value) : PrefixedGuidV3(Value);
