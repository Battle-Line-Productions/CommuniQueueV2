using CommuniQueueV2.Models.Enums;

namespace CommuniQueueV2.Models.Domain;

public record TenantUserMap
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TenantId { get; set; }
    public RoleType Role { get; set; }
    public TenantMembershipStatusType Status { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }

    // Navigation properties
    public User User { get; set; } = null!;
    public Tenant Tenant { get; set; } = null!;
}
