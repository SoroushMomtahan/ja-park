namespace JaPark.Services.Subscriptions.Domain.AppSubscribers.ValueObjects;
[Prefix("user")]
public record UserId(string Value) : PrefixedGuidV3(Value);
