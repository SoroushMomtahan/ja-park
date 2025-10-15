namespace JaPark.Services.Booking.Domain.Spaces.ValueObjects;

[Prefix("space")]
public record SpaceId(string Value) : PrefixedGuidV3(Value);
