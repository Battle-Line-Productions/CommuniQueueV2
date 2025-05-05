namespace CommuniQueueV2.Models.Domain;

public record EnterprisePlanOverride
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public int? AllowedTenantsOverride { get; set; }
    public int? AllowedProjectsOverride { get; set; }
    public int? AllowedTemplatesOverride { get; set; }
    public int? AllowedTemplateVersionsOverride { get; set; }
    public int? EmailSendLimitPerMonthOverride { get; set; }
    public int? ApiRateLimitPerMinuteOverride { get; set; }
    public int? ApiThrottlingBurstOverride { get; set; }
    public int? RetentionDaysOverride { get; set; }
    public int? SmsSendLimitPerMonthOverride { get; set; }
    public int? WebhookLimitPerMonthOverride { get; set; }
    public decimal? ExtraChargePerUnit { get; set; }
    public string? Notes { get; set; }

    // Navigation properties
    public Tenant Tenant { get; set; } = null!;
    public ICollection<TenantSubscription> TenantSubscriptions { get; set; } = new List<TenantSubscription>();
}
