using JaPark.Services.Subscriptions.Domain.AppSubscribers.ValueObjects;

namespace JaPark.Services.Subscriptions.Domain.AppSubscribers.Models;

public sealed class AppSubscriber : Aggregate<AppSubscriberId>
{
    public UserId UserId { get; init; }
    public AppSubscriptionId SubscriptionId { get; private set; }
    
    private AppSubscriber() {}

    public static AppSubscriber Create(UserId userId, AppSubscriptionId subscriptionId)
    {
        return new AppSubscriber
        {
            UserId = userId,
            SubscriptionId = subscriptionId
        };
    }

    public void ChangeSubscription(AppSubscriptionId subscriptionId)
    {
        SubscriptionId = subscriptionId;
    }
}
