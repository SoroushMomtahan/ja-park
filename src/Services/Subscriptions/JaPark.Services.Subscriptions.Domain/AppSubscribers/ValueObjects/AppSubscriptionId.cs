namespace JaPark.Services.Subscriptions.Domain.AppSubscribers.ValueObjects;

[Prefix("app-subscription")]
public record AppSubscriptionId(string Value) : PrefixedGuidV3(Value);
