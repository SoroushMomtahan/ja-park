namespace JaPark.Services.Subscriptions.Domain.AppSubscribers.ValueObjects;

[Prefix("app-subscriber")]
public record AppSubscriberId(string Value) : PrefixedGuidV3(Value);
