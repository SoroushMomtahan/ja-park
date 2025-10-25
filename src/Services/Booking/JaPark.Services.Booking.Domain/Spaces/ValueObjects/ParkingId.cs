namespace JaPark.Services.Booking.Domain.Spaces.ValueObjects;

[Prefix("parking")]
public record ParkingId(string Value) : PrefixedGuidV3(Value);
