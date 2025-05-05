using CommuniQueueV2.Models.Enums;

namespace CommuniQueueV2.Models.Domain;

public record TrackingRecipient
{
    public Guid Id { get; set; }
    public Guid NotificationTrackingId { get; set; }
    public RecipientType Type { get; set; }
    public string Value { get; set; }

    // Navigation properties
    public NotificationTracking NotificationTracking { get; set; } = null!;
}
