using System.Text.Json;
using CommuniQueueV2.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CommuniQueueV2;

public class CommuniQueueDbContext(DbContextOptions<CommuniQueueDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantUserMap> TenantUserMaps { get; set; }
    public DbSet<AccessControlEntry> AccessControlEntries { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Container> Containers { get; set; }
    public DbSet<Template> Templates { get; set; }
    public DbSet<TemplateVersion> TemplateVersions { get; set; }
    public DbSet<TemplateRecipient> TemplateRecipients { get; set; }
    public DbSet<NotificationTracking> NotificationTrackings { get; set; }
    public DbSet<TrackingRecipient> TrackingRecipients { get; set; }
    public DbSet<TenantApiKey> TenantApiKeys { get; set; }
    public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
    public DbSet<TenantSubscription> TenantSubscriptions { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<TenantCoupon> TenantCoupons { get; set; }
    public DbSet<EnterprisePlanOverride> EnterprisePlanOverrides { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ─── User ────────────────────────────────────────────────────────────────
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Email).IsRequired();
            entity.Property(u => u.SsoId).IsRequired();
            entity.HasIndex(u => u.Email).IsUnique();
            entity.HasIndex(u => u.SsoId).IsUnique();
        });

        // ─── Tenant ───────────────────────────────────────────────────────────────
        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.HasOne<User>()
                  .WithMany()
                  .HasForeignKey(t => t.OwnerUserId)
                  .OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(t => t.OwnerUserId);
        });

        // ─── TenantUserMap ───────────────────────────────────────────────────────
        modelBuilder.Entity<TenantUserMap>(entity =>
        {
            entity.HasKey(tum => tum.Id);
            entity.HasOne<User>()
                  .WithMany()
                  .HasForeignKey(tum => tum.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne<Tenant>()
                  .WithMany()
                  .HasForeignKey(tum => tum.TenantId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(tum => new { tum.TenantId, tum.UserId });
        });

        // ─── AccessControlEntry ──────────────────────────────────────────────────
        modelBuilder.Entity<AccessControlEntry>(entity =>
        {
            entity.HasKey(ace => ace.Id);
            entity.HasOne<User>()
                  .WithMany()
                  .HasForeignKey(ace => ace.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(ace => ace.UserId);
            entity.HasIndex(ace => new { ace.EntityType, ace.EntityId });
        });

        // ─── Project ─────────────────────────────────────────────────────────────
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.HasOne<Tenant>()
                  .WithMany()
                  .HasForeignKey(p => p.TenantId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(p => p.TenantId);
        });

        // ─── Container ───────────────────────────────────────────────────────────
        modelBuilder.Entity<Container>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasOne<Project>()
                  .WithMany()
                  .HasForeignKey(c => c.ProjectId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne<Container>()
                  .WithMany()
                  .HasForeignKey(c => c.ParentId)
                  .OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(c => c.ProjectId);
            entity.HasIndex(c => c.ParentId);
        });

        // ─── Template ────────────────────────────────────────────────────────────
        modelBuilder.Entity<Template>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.HasOne<Project>()
                  .WithMany()
                  .HasForeignKey(t => t.ProjectId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne<Container>()
                  .WithMany()
                  .HasForeignKey(t => t.ContainerId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(t => t.ProjectId);
            entity.HasIndex(t => t.ContainerId);
        });

        // ─── TemplateVersion ─────────────────────────────────────────────────────
        modelBuilder.Entity<TemplateVersion>(entity =>
        {
            entity.HasKey(tv => tv.Id);
            entity.HasOne<Template>()
                  .WithMany()
                  .HasForeignKey(tv => tv.TemplateId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(tv => tv.TemplateId);
            entity.HasIndex(tv => new { tv.TemplateId, tv.VersionNumber }).IsUnique();
        });

        // ─── TemplateRecipient ───────────────────────────────────────────────────
        modelBuilder.Entity<TemplateRecipient>(entity =>
        {
            entity.HasKey(tr => tr.Id);
            entity.HasOne<TemplateVersion>()
                  .WithMany()
                  .HasForeignKey(tr => tr.TemplateVersionId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(tr => tr.TemplateVersionId);
        });

        // ─── NotificationTracking ────────────────────────────────────────────────
        modelBuilder.Entity<NotificationTracking>(entity =>
        {
            entity.HasKey(nt => nt.Id);
            entity.HasOne<Tenant>()
                  .WithMany()
                  .HasForeignKey(nt => nt.TenantId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne<Template>()
                  .WithMany()
                  .HasForeignKey(nt => nt.TemplateId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne<TemplateVersion>()
                  .WithMany()
                  .HasForeignKey(nt => nt.TemplateVersionId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(nt => nt.TenantId);
            entity.HasIndex(nt => new { nt.TemplateId, nt.TemplateVersionId });
        });

        // ─── TrackingRecipient ───────────────────────────────────────────────────
        modelBuilder.Entity<TrackingRecipient>(entity =>
        {
            entity.HasKey(tr => tr.Id);
            entity.HasOne<NotificationTracking>()
                  .WithMany()
                  .HasForeignKey(tr => tr.NotificationTrackingId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(tr => tr.NotificationTrackingId);
        });

        // ─── TenantApiKey ─────────────────────────────────────────────────────────
        modelBuilder.Entity<TenantApiKey>(entity =>
        {
            entity.HasKey(k => k.Id);
            entity.HasOne<Tenant>()
                  .WithMany()
                  .HasForeignKey(k => k.TenantId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(k => k.KeyHash); // TODO: Should this be unique?
            entity.HasIndex(k => k.TenantId);
            entity.Property(k => k.Scopes)
                  .HasConversion(
                      v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null)!,
                      v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)!)
                  .HasColumnType("jsonb");
        });

        // ─── SubscriptionPlan ────────────────────────────────────────────────────
        modelBuilder.Entity<SubscriptionPlan>(entity =>
        {
            entity.HasKey(sp => sp.Id);
            entity.HasIndex(sp => sp.Tier);
        });

        // ─── TenantSubscription ──────────────────────────────────────────────────
        modelBuilder.Entity<TenantSubscription>(entity =>
        {
            entity.HasKey(ts => ts.Id);
            entity.HasOne<Tenant>()
                  .WithMany()
                  .HasForeignKey(ts => ts.TenantId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne<SubscriptionPlan>()
                  .WithMany()
                  .HasForeignKey(ts => ts.SubscriptionPlanId)
                  .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne<EnterprisePlanOverride>()
                  .WithMany()
                  .HasForeignKey(ts => ts.EnterpriseOverridesId)
                  .OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(ts => ts.TenantId);
            entity.HasIndex(ts => ts.SubscriptionPlanId);
            entity.HasIndex(ts => ts.IsActive);
        });

        // ─── Coupon ──────────────────────────────────────────────────────────────
        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasIndex(c => c.Code).IsUnique();
        });

        // ─── TenantCoupon ─────────────────────────────────────────────────────────
        modelBuilder.Entity<TenantCoupon>(entity =>
        {
            entity.HasKey(tc => tc.Id);
            entity.HasOne<Tenant>()
                  .WithMany()
                  .HasForeignKey(tc => tc.TenantId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne<Coupon>()
                  .WithMany()
                  .HasForeignKey(tc => tc.CouponId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(tc => new { tc.TenantId, tc.CouponId }).IsUnique();
        });

        // ─── EnterprisePlanOverride ──────────────────────────────────────────────
        modelBuilder.Entity<EnterprisePlanOverride>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Tenant)
                .WithOne(t => t.EnterprisePlanOverride)
                .HasForeignKey<EnterprisePlanOverride>(e => e.TenantId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => e.TenantId).IsUnique();
        });
    }
}
