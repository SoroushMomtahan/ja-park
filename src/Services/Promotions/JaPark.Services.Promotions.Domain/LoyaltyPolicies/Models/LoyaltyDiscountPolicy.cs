using JaPark.Services.Promotions.Domain.LoyaltyPolicies.ValueObjects;

namespace JaPark.Services.Promotions.Domain.LoyaltyPolicies.Models;

public sealed class LoyaltyDiscountPolicy : Aggregate<LoyaltyPolicyId>
{
    public ParkingId ParkingId { get; init; }
    public LoyaltyDiscountInterval DiscountInterval { get; private set; }
    public LoyaltyDiscountPercent DiscountPercent { get; private set; }
    private readonly List<PlateNumber> _eligiblePlates = [];
    public IReadOnlyList<PlateNumber> EligiblePlates => [.._eligiblePlates];
    
    private LoyaltyDiscountPolicy() {}

    public static LoyaltyDiscountPolicy Create(
        ParkingId parkingId, 
        LoyaltyDiscountPercent percent, 
        LoyaltyDiscountInterval interval)
    {
        return new LoyaltyDiscountPolicy
        {
            ParkingId = parkingId,
            DiscountInterval = interval,
            DiscountPercent = percent
        };
    }
    public bool IsSatisfiedBy(PlateNumber plate)
    {
        return _eligiblePlates.Contains(plate);
    }

    public void AddEligiblePlate(PlateNumber plate)
    {
        _eligiblePlates.Add(plate);
    }

    public void RemoveEligiblePlate(PlateNumber plate)
    {
        _eligiblePlates.Remove(plate);
    }
}
