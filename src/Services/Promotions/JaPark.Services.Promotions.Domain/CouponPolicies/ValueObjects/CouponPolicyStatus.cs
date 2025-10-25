namespace JaPark.Services.Promotions.Domain.CouponPolicies.ValueObjects;
public enum PolicyType
{
    Universal,
    PlateListSpecific
}
public record CouponPolicyStatus
{
    public PolicyType Type { get; init; }
    private CouponPolicyStatus(PolicyType type) => Type = type;
    public static readonly  CouponPolicyStatus Universal = new(PolicyType.Universal);
    public static readonly  CouponPolicyStatus PlateListSpecific = new(PolicyType.PlateListSpecific);
    
    public static implicit operator PolicyType(CouponPolicyStatus status) => status.Type;
    public static implicit operator CouponPolicyStatus(PolicyType policyType) => new(policyType);
}
