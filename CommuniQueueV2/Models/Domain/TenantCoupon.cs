namespace CommuniQueueV2.Models.Domain;

public record TenantCoupon
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid CouponId { get; set; }
    public DateTime DateApplied { get; set; }
    public DateTime? BenefitUntil { get; set; }

    // Navigation properties
    public Tenant Tenant { get; set; } = null!;
    public Coupon Coupon { get; set; } = null!;
}
