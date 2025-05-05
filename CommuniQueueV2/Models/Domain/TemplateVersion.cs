namespace CommuniQueueV2.Models.Domain;

public record TemplateVersion
{
    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public int VersionNumber { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string From { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }

    // Navigation properties
    public Template Template { get; set; } = null!;
    public ICollection<TemplateRecipient> Recipients { get; set; } = new List<TemplateRecipient>();
}
