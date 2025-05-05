namespace CommuniQueueV2.Models.Domain;

public record Project
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid TenantId { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }

    // Navigation properties
    public Tenant Tenant { get; set; } = null!;
    public ICollection<Container> Containers { get; set; } = new List<Container>();
    public ICollection<Template> Templates { get; set; } = new List<Template>();
}
