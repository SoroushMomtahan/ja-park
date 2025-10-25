using JaPark.Services.Promotions.Domain.CouponPolicies.Errors;
using JaPark.Services.Promotions.Domain.CouponPolicies.ValueObjects;
using CouponPolicyId = JaPark.Services.Promotions.Domain.Coupons.ValueObjects.CouponPolicyId;

namespace JaPark.Services.Promotions.Domain.CouponPolicies.Models;

public sealed class CouponPolicy : Aggregate<CouponPolicyId>
{
    public CouponId CouponId { get; init; }
    public CouponPolicyStatus Status { get; init; }
    private readonly List<PlateNumber> _eligiblePlates = [];
    public IReadOnlyList<PlateNumber> EligiblePlates => [.._eligiblePlates];
    private CouponPolicy(CouponId couponId, CouponPolicyStatus status) => 
        (CouponId, Status) = (couponId, status);
    
    public static CouponPolicy CreateUniversal(CouponId couponId)
    {
        return new CouponPolicy(couponId, CouponPolicyStatus.Universal);
    }
    
    public static Result<CouponPolicy> CreateWithPlateList(
        CouponId couponId,
        List<PlateNumber> plates)
    {
        if (plates.Count == 0)
        {
            return Result.Failure<CouponPolicy>(CouponPolicyErrors.EmptyPlateList);
        }

        var policy = new CouponPolicy(couponId, PolicyType.PlateListSpecific);
        policy._eligiblePlates.AddRange(plates);
        
        return policy;
    }
    
    public bool IsSatisfiedBy(PlateNumber plate)
    {
        return Status.Type switch
        {
            PolicyType.Universal => true,
            PolicyType.PlateListSpecific => _eligiblePlates.Contains(plate),
            _ => false
        };
    }
    
    public Result AddPlate(PlateNumber plate)
    {
        if (Status.Type == PolicyType.Universal)
        {
            Result.Failure(CouponPolicyErrors.NotAcceptablePlateNumber);
        }
        
        if (!_eligiblePlates.Contains(plate))
        {
            _eligiblePlates.Add(plate);
        }
        return Result.Success();
    }
    
    public void RemovePlate(PlateNumber plate)
    {
        if (Status.Type == PolicyType.Universal)
        {
            return; 
        }
        _eligiblePlates.Remove(plate);
    }
}
