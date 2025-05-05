using CommuniQueueV2.Models.Enums;

namespace CommuniQueueV2.Models.Domain;

public record Template
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ProjectId { get; set; }
    public Guid ContainerId { get; set; }
    public NotificationType Type { get; set; }
    public StateType State { get; set; }
    public UsageType UsageType { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }

    // Navigation properties
    public Project Project { get; set; } = null!;
    public Container Container { get; set; } = null!;
    public ICollection<TemplateVersion> Versions { get; set; } = new List<TemplateVersion>();
}
