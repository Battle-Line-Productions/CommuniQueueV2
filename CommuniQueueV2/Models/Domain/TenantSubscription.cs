namespace CommuniQueueV2.Models.Domain;

public record TenantSubscription
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid SubscriptionPlanId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public decimal FinalPricePerMonth { get; set; }
    public string? CouponCode { get; set; }
    public Guid? EnterpriseOverridesId { get; set; }

    // Navigation properties
    public Tenant Tenant { get; set; } = null!;
    public SubscriptionPlan SubscriptionPlan { get; set; } = null!;
    public EnterprisePlanOverride? EnterpriseOverrides { get; set; }
}
