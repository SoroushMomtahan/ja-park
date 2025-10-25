using JaPark.Services.Subscriptions.Domain.AppSubscriptions.Enums;
using JaPark.Services.Subscriptions.Domain.AppSubscriptions.ValueObjects;

namespace JaPark.Services.Subscriptions.Domain.AppSubscriptions.Models;

public sealed class AppSubscription : Aggregate<AppSubscriptionId>
{
    public AppSubscriptionType Type { get; private set; }
    public ParkingCapacity ParkingCapacity { get; private set; }
    public SpaceCapacity SpaceCapacity { get; private set; }
    public AppSubscriptionPrice Price { get; private set; }
    
    private AppSubscription() { }

    public static AppSubscription Create(
        AppSubscriptionType type, 
        ParkingCapacity parkingCapacity,
        SpaceCapacity spaceCapacity,
        AppSubscriptionPrice price)
    {
        return new AppSubscription
        {
            Type = type,
            ParkingCapacity = parkingCapacity,
            SpaceCapacity = spaceCapacity,
            Price = price
        };
    }
}
