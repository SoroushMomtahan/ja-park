namespace JaPark.Services.Billing.Domain.Billing.ValueObjects;

public enum BillingType
{
    Pending,
    Paid,
    Unpaid,
    Cancelled
}

public record BillingStatus
{
    public BillingType Type { get; }
    private BillingStatus(BillingType type) => Type = type;
    public static readonly BillingStatus Pending = new(BillingType.Pending);
    public static readonly BillingStatus Paid = new(BillingType.Paid);
    public static readonly BillingStatus Unpaid = new(BillingType.Unpaid);
    public static readonly BillingStatus Cancelled = new(BillingType.Cancelled);
    public static readonly BillingStatus Default = new(BillingType.Unpaid);
    
    public static implicit operator BillingStatus(BillingType type) => new(type);
    public static implicit operator BillingType(BillingStatus billingStatus) => billingStatus.Type;
}
