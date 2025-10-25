namespace JaPark.Services.Billing.Domain.Billing.ValueObjects;

[Prefix("parking")]
public record ParkingId(string Value) : PrefixedGuidV3(Value);
