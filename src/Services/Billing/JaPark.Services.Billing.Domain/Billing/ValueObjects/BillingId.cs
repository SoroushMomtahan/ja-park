namespace JaPark.Services.Billing.Domain.Billing.ValueObjects;

[Prefix("billing")]
public record BillingId(string Value) : PrefixedGuidV3(Value);
