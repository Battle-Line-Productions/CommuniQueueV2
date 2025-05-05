using CommuniQueueV2.Models.Enums;

namespace CommuniQueueV2.Models.Domain;

public record SubscriptionPlan
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public SubscriptionTier Tier { get; set; }
    public decimal PricePerMonth { get; set; }
    public decimal PricePerYear { get; set; }
    public int AllowedTenants { get; set; }
    public int AllowedProjects { get; set; }
    public int AllowedTemplates { get; set; }
    public int AllowedTemplateVersions { get; set; }
    public int EmailSendLimitPerMonth { get; set; }
    public int ApiRateLimitPerMinute { get; set; }
    public int ApiThrottlingBurst { get; set; }
    public int RetentionDays { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime? EffectiveTo { get; set; }

    // Navigation properties
    public ICollection<TenantSubscription> TenantSubscriptions { get; set; } = new List<TenantSubscription>();
}
