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
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public record Tenant
{
    public Guid Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid OwnerUserId { get; set; }
    public StatusType Status { get; set; }
}

public enum StatusType
{
    Active,
    Suspended,  // TODO: Don't know if these are the status types I want yet or not
    Deleted
}

public record TenantUserMap
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TenantId { get; set; }
    public RoleType Role { get; set; }
    public TenantMembershipStatusType Status { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}

public enum TenantMembershipStatusType
{
    Active,
    Pending,
    Invited,
    Rejected,
    Left
}

public enum RoleType
{
    Owner,
    Admin,
    Member,
    Readonly,
    Deny
}

public record AccessControlEntry
{
    public Guid Id { get; set; }
    public AccessControlledEntityType EntityType { get; set; } // Tenant, Project, Container, Template
    public Guid EntityId { get; set; }
    public Guid UserId { get; set; }
    public RoleType Role { get; set; } // Owner, Admin, Member, Readonly, Deny
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
    // Expanding for group/role-based access may be future
}

public enum AccessControlledEntityType
{
    Tenant,
    Project,
    Container,
    Template
}

public record Project
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid TenantId { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}

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
}

public record Template
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ProjectId { get; set; }
    public Guid ContainerId { get; set; }
    public NotificationType Type { get; set; } // Email/SMS/Webhook/...
    public StateType State { get; set; } // Building/Testing/Ready
    public UsageType UsageType { get; set; } // Transactional/Marketing
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}

public enum NotificationType
{
    Email,
    SMS,
    Webhook,
    PushNotification,
    InAppNotification
}

public enum StateType
{
    Building,
    Testing,
    Ready
}

public enum UsageType
{
    Transactional,
    Marketing
}

public enum RecipientType
{
    User,
    Group,
    Email
}

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
}

public record TemplateRecipient
{
    public Guid Id { get; set; }
    public Guid TemplateVersionId { get; set; }
    public RecipientType Type { get; set; }
    public string Value { get; set; }
}

public record NotificationTracking
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid TemplateId { get; set; }
    public Guid TemplateVersionId { get; set; }
    public NotificationType Type { get; set; }
    public StateType State { get; set; }
    public UsageType UsageType { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
    public bool IsTest { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string From { get; set; }
    // Tracking/analytics fields kept as long as needed for metrics
}

public record TrackingRecipient
{
    public Guid Id { get; set; }
    public Guid NotificationTrackingId { get; set; }
    public RecipientType Type { get; set; }
    public string Value { get; set; }
}

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
    public List<string> Scopes { get; set; }
}

public enum SubscriptionTier
{
    Free,
    Standard,
    Plus,
    Premium,
    Enterprise
}

public record SubscriptionPlan
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public SubscriptionTier Tier { get; set; }
    public decimal PricePerMonth { get; set; }
    public decimal PricePerYear { get; set; }
    public int AllowedTenants { get; set; }
    public int AllowedProjects { get; set; }
    public int AllowedTemplates { get; set; }
    public int AllowedTemplateVersions { get; set; }
    public int EmailSendLimitPerMonth { get; set; }
    public int ApiRateLimitPerMinute { get; set; }
    public int ApiThrottlingBurst { get; set; }
    public int RetentionDays { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime? EffectiveTo { get; set; }
    // Add common plan fields as needed
}

public record TenantSubscription
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid SubscriptionPlanId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public decimal FinalPricePerMonth { get; set; }
    public string? CouponCode { get; set; }
    // For enterprise plans: link to complex limit overrides
    public Guid? EnterpriseOverridesId { get; set; }
}

public record Coupon
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public decimal? FlatAmountOff { get; set; }
    public decimal? PercentageOff { get; set; }
    public DateTime ExpireDate { get; set; }
    public DateTime? BenefitUntil { get; set; }
}

public record TenantCoupon
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid CouponId { get; set; }
    public DateTime DateApplied { get; set; }
    public DateTime? BenefitUntil { get; set; }
}

public record EnterprisePlanOverride
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    // All settings are nullable; if set, they override base plan for this tenant
    public int? AllowedTenantsOverride { get; set; }
    public int? AllowedProjectsOverride { get; set; }
    public int? AllowedTemplatesOverride { get; set; }
    public int? AllowedTemplateVersionsOverride { get; set; }
    public int? EmailSendLimitPerMonthOverride { get; set; }
    public int? ApiRateLimitPerMinuteOverride { get; set; }
    public int? ApiThrottlingBurstOverride { get; set; }
    public int? RetentionDaysOverride { get; set; }
    public int? SmsSendLimitPerMonthOverride { get; set; }
    public int? WebhookLimitPerMonthOverride { get; set; }
    public decimal? ExtraChargePerUnit { get; set; }
    // ... Extend with any new features/limits as needed
    public string? Notes { get; set; }
}
