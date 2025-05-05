using CommuniQueueV2.Models.Enums;

namespace CommuniQueueV2.Models.Domain;

public record AccessControlEntry
{
    public Guid Id { get; set; }
    public AccessControlledEntityType EntityType { get; set; }
    public Guid EntityId { get; set; }
    public Guid UserId { get; set; }
    public RoleType Role { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }

    // Navigation properties
    public User User { get; set; } = null!;
}
