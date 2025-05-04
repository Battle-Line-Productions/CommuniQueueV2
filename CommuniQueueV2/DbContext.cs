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
        });

        // ─── Tenant ───────────────────────────────────────────────────────────────
        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.HasOne<User>()
                  .WithMany()
                  .HasForeignKey(t => t.OwnerUserId)
                  .OnDelete(DeleteBehavior.Restrict);
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
        });

        // ─── AccessControlEntry ──────────────────────────────────────────────────
        modelBuilder.Entity<AccessControlEntry>(entity =>
        {
            entity.HasKey(ace => ace.Id);
            entity.HasOne<User>()
                  .WithMany()
                  .HasForeignKey(ace => ace.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ─── Project ─────────────────────────────────────────────────────────────
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.HasOne<Tenant>()
                  .WithMany()
                  .HasForeignKey(p => p.TenantId)
                  .OnDelete(DeleteBehavior.Cascade);
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
        });

        // ─── TemplateVersion ─────────────────────────────────────────────────────
        modelBuilder.Entity<TemplateVersion>(entity =>
        {
            entity.HasKey(tv => tv.Id);
            entity.HasOne<Template>()
                  .WithMany()
                  .HasForeignKey(tv => tv.TemplateId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ─── TemplateRecipient ───────────────────────────────────────────────────
        modelBuilder.Entity<TemplateRecipient>(entity =>
        {
            entity.HasKey(tr => tr.Id);
            entity.HasOne<TemplateVersion>()
                  .WithMany()
                  .HasForeignKey(tr => tr.TemplateVersionId)
                  .OnDelete(DeleteBehavior.Cascade);
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
        });

        // ─── TrackingRecipient ───────────────────────────────────────────────────
        modelBuilder.Entity<TrackingRecipient>(entity =>
        {
            entity.HasKey(tr => tr.Id);
            entity.HasOne<NotificationTracking>()
                  .WithMany()
                  .HasForeignKey(tr => tr.NotificationTrackingId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ─── TenantApiKey ─────────────────────────────────────────────────────────
        modelBuilder.Entity<TenantApiKey>(entity =>
        {
            entity.HasKey(k => k.Id);
            entity.HasOne<Tenant>()
                  .WithMany()
                  .HasForeignKey(k => k.TenantId)
                  .OnDelete(DeleteBehavior.Cascade);

            // Store the List<string> as a JSONB column in Postgres:
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
        });

        // ─── Coupon ──────────────────────────────────────────────────────────────
        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(c => c.Id);
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
        });

        // ─── EnterprisePlanOverride ──────────────────────────────────────────────
        modelBuilder.Entity<EnterprisePlanOverride>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne<Tenant>()
                  .WithMany()
                  .HasForeignKey(e => e.TenantId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
