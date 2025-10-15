namespace JaPark.Services.Booking.Domain.Booking.ValueObjects;

[Prefix("booking")]
public record SpaceId(string Value) : PrefixedGuidV3(Value);
