namespace CommuniQueueV2.Models.Domain;

public record Coupon
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public decimal? FlatAmountOff { get; set; }
    public decimal? PercentageOff { get; set; }
    public DateTime ExpireDate { get; set; }
    public DateTime? BenefitUntil { get; set; }

    // Navigation properties
    public ICollection<TenantCoupon> TenantCoupons { get; set; } = new List<TenantCoupon>();
}
