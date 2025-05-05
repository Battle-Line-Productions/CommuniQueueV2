namespace CommuniQueueV2.Models.Domain;

public record Container
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid? ParentId { get; set; }
    public Guid ProjectId { get; set; }
    public int Depth { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }

    // Navigation properties
    public Project Project { get; set; } = null!;
    public Container? Parent { get; set; }
    public ICollection<Container> Children { get; set; } = new List<Container>();
    public ICollection<Template> Templates { get; set; } = new List<Template>();
}
