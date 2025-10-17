namespace JaPark.Services.Billing.Domain.Billing.ValueObjects;

[Prefix("booking")]
public record BookingId(string Value) : PrefixedGuidV3(Value);
