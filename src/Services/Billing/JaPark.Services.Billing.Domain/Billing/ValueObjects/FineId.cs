namespace JaPark.Services.Billing.Domain.Billing.ValueObjects;

[Prefix("fine")]
public record FineId(string Value) : PrefixedGuidV3(Value);
