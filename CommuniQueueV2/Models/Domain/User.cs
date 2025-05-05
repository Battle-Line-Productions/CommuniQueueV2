namespace CommuniQueueV2.Models.Domain;

public record User
{
    public Guid Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
    public required string Email { get; set; }
    public required string SsoId { get; set; }
    public bool IsActive { get; set; }
    public bool IsSuperAdmin { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    // Navigation properties
    public ICollection<Tenant> OwnedTenants { get; set; } = new List<Tenant>();
    public ICollection<TenantUserMap> TenantUserMaps { get; set; } = new List<TenantUserMap>();
    public ICollection<AccessControlEntry> AccessControlEntries { get; set; } = new List<AccessControlEntry>();
}
