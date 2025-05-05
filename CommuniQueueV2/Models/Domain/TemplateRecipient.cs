using CommuniQueueV2.Models.Enums;

namespace CommuniQueueV2.Models.Domain;

public record TemplateRecipient
{
    public Guid Id { get; set; }
    public Guid TemplateVersionId { get; set; }
    public RecipientType Type { get; set; }
    public string Value { get; set; }

    // Navigation properties
    public TemplateVersion TemplateVersion { get; set; } = null!;
}
