using CommuniQueueV2.Models.Enums;

namespace CommuniQueueV2.Models.Domain;

public record NotificationTracking
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid TemplateId { get; set; }
    public Guid TemplateVersionId { get; set; }
    public NotificationType Type { get; set; }
    public StateType State { get; set; }
    public UsageType UsageType { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
    public bool IsTest { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string From { get; set; }

    // Navigation properties
    public Tenant Tenant { get; set; } = null!;
    public Template Template { get; set; } = null!;
    public TemplateVersion TemplateVersion { get; set; } = null!;
    public ICollection<TrackingRecipient> Recipients { get; set; } = new List<TrackingRecipient>();
}
