namespace JaPark.Services.Subscriptions.Domain.AppSubscriptions.ValueObjects;

[Prefix("app-subscription")]
public record AppSubscriptionId(string Value) : PrefixedGuidV3(Value);
