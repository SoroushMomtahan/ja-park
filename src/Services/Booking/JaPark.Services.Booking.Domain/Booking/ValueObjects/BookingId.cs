namespace JaPark.Services.Booking.Domain.Booking.ValueObjects;

[Prefix("booking")]
public record BookingId(string Value) : PrefixedGuidV3(Value);
