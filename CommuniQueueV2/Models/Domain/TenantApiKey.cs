namespace CommuniQueueV2.Models.Domain;

public record TenantApiKey
{
    public Guid Id { get; set; }
    public string KeyHash { get; set; }
    public Guid TenantId { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsExpired { get; set; }
    public List<string> Scopes { get; set; } = new();

    // Navigation properties
    public Tenant Tenant { get; set; } = null!;
}
