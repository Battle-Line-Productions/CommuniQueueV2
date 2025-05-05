using CommuniQueueV2.Models.Enums;

namespace CommuniQueueV2.Models.Domain;

public record Tenant
{
    public Guid Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid OwnerUserId { get; set; }
    public StatusType Status { get; set; }

    // Navigation properties
    public User OwnerUser { get; set; } = null!;
    public ICollection<TenantUserMap> TenantUserMaps { get; set; } = new List<TenantUserMap>();
    public ICollection<Project> Projects { get; set; } = new List<Project>();
    public ICollection<NotificationTracking> NotificationTrackings { get; set; } = new List<NotificationTracking>();
    public ICollection<TenantApiKey> TenantApiKeys { get; set; } = new List<TenantApiKey>();
    public ICollection<TenantSubscription> TenantSubscriptions { get; set; } = new List<TenantSubscription>();
    public ICollection<TenantCoupon> TenantCoupons { get; set; } = new List<TenantCoupon>();
    public EnterprisePlanOverride? EnterprisePlanOverride { get; set; }
}
