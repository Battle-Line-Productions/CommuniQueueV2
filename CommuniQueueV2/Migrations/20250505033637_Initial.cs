using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommuniQueueV2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coupons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    flat_amount_off = table.Column<decimal>(type: "numeric", nullable: true),
                    percentage_off = table.Column<decimal>(type: "numeric", nullable: true),
                    expire_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    benefit_until = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_coupons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subscription_plans",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    tier = table.Column<int>(type: "integer", nullable: false),
                    price_per_month = table.Column<decimal>(type: "numeric", nullable: false),
                    price_per_year = table.Column<decimal>(type: "numeric", nullable: false),
                    allowed_tenants = table.Column<int>(type: "integer", nullable: false),
                    allowed_projects = table.Column<int>(type: "integer", nullable: false),
                    allowed_templates = table.Column<int>(type: "integer", nullable: false),
                    allowed_template_versions = table.Column<int>(type: "integer", nullable: false),
                    email_send_limit_per_month = table.Column<int>(type: "integer", nullable: false),
                    api_rate_limit_per_minute = table.Column<int>(type: "integer", nullable: false),
                    api_throttling_burst = table.Column<int>(type: "integer", nullable: false),
                    retention_days = table.Column<int>(type: "integer", nullable: false),
                    effective_from = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    effective_to = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subscription_plans", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    sso_id = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_super_admin = table.Column<bool>(type: "boolean", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "access_control_entries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    entity_type = table.Column<int>(type: "integer", nullable: false),
                    entity_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_access_control_entries", x => x.id);
                    table.ForeignKey(
                        name: "fk_access_control_entries_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_access_control_entries_users_user_id1",
                        column: x => x.user_id1,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tenants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    owner_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    owner_user_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenants", x => x.id);
                    table.ForeignKey(
                        name: "fk_tenants_users_owner_user_id",
                        column: x => x.owner_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_tenants_users_owner_user_id1",
                        column: x => x.owner_user_id1,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enterprise_plan_overrides",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    allowed_tenants_override = table.Column<int>(type: "integer", nullable: true),
                    allowed_projects_override = table.Column<int>(type: "integer", nullable: true),
                    allowed_templates_override = table.Column<int>(type: "integer", nullable: true),
                    allowed_template_versions_override = table.Column<int>(type: "integer", nullable: true),
                    email_send_limit_per_month_override = table.Column<int>(type: "integer", nullable: true),
                    api_rate_limit_per_minute_override = table.Column<int>(type: "integer", nullable: true),
                    api_throttling_burst_override = table.Column<int>(type: "integer", nullable: true),
                    retention_days_override = table.Column<int>(type: "integer", nullable: true),
                    sms_send_limit_per_month_override = table.Column<int>(type: "integer", nullable: true),
                    webhook_limit_per_month_override = table.Column<int>(type: "integer", nullable: true),
                    extra_charge_per_unit = table.Column<decimal>(type: "numeric", nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enterprise_plan_overrides", x => x.id);
                    table.ForeignKey(
                        name: "fk_enterprise_plan_overrides_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    tenant_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projects", x => x.id);
                    table.ForeignKey(
                        name: "fk_projects_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projects_tenants_tenant_id1",
                        column: x => x.tenant_id1,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tenant_api_keys",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    key_hash = table.Column<string>(type: "text", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_expired = table.Column<bool>(type: "boolean", nullable: false),
                    scopes = table.Column<string>(type: "jsonb", nullable: false),
                    tenant_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant_api_keys", x => x.id);
                    table.ForeignKey(
                        name: "fk_tenant_api_keys_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tenant_api_keys_tenants_tenant_id1",
                        column: x => x.tenant_id1,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tenant_coupons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    coupon_id = table.Column<Guid>(type: "uuid", nullable: false),
                    date_applied = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    benefit_until = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    tenant_id1 = table.Column<Guid>(type: "uuid", nullable: false),
                    coupon_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant_coupons", x => x.id);
                    table.ForeignKey(
                        name: "fk_tenant_coupons_coupons_coupon_id",
                        column: x => x.coupon_id,
                        principalTable: "coupons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tenant_coupons_coupons_coupon_id1",
                        column: x => x.coupon_id1,
                        principalTable: "coupons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tenant_coupons_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tenant_coupons_tenants_tenant_id1",
                        column: x => x.tenant_id1,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tenant_user_maps",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id1 = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant_user_maps", x => x.id);
                    table.ForeignKey(
                        name: "fk_tenant_user_maps_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tenant_user_maps_tenants_tenant_id1",
                        column: x => x.tenant_id1,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tenant_user_maps_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tenant_user_maps_users_user_id1",
                        column: x => x.user_id1,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tenant_subscriptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    subscription_plan_id = table.Column<Guid>(type: "uuid", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    final_price_per_month = table.Column<decimal>(type: "numeric", nullable: false),
                    coupon_code = table.Column<string>(type: "text", nullable: true),
                    enterprise_overrides_id = table.Column<Guid>(type: "uuid", nullable: true),
                    tenant_id1 = table.Column<Guid>(type: "uuid", nullable: false),
                    subscription_plan_id1 = table.Column<Guid>(type: "uuid", nullable: false),
                    enterprise_overrides_id1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant_subscriptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_tenant_subscriptions_enterprise_plan_overrides_enterprise_o",
                        column: x => x.enterprise_overrides_id,
                        principalTable: "enterprise_plan_overrides",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_tenant_subscriptions_enterprise_plan_overrides_enterprise_o1",
                        column: x => x.enterprise_overrides_id1,
                        principalTable: "enterprise_plan_overrides",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_tenant_subscriptions_subscription_plans_subscription_plan_i",
                        column: x => x.subscription_plan_id1,
                        principalTable: "subscription_plans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tenant_subscriptions_subscription_plans_subscription_plan_id",
                        column: x => x.subscription_plan_id,
                        principalTable: "subscription_plans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_tenant_subscriptions_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tenant_subscriptions_tenants_tenant_id1",
                        column: x => x.tenant_id1,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "containers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    parent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    project_id = table.Column<Guid>(type: "uuid", nullable: false),
                    depth = table.Column<int>(type: "integer", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    project_id1 = table.Column<Guid>(type: "uuid", nullable: false),
                    parent_id1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_containers", x => x.id);
                    table.ForeignKey(
                        name: "fk_containers_containers_parent_id",
                        column: x => x.parent_id,
                        principalTable: "containers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_containers_containers_parent_id1",
                        column: x => x.parent_id1,
                        principalTable: "containers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_containers_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_containers_projects_project_id1",
                        column: x => x.project_id1,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "templates",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    project_id = table.Column<Guid>(type: "uuid", nullable: false),
                    container_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false),
                    usage_type = table.Column<int>(type: "integer", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    project_id1 = table.Column<Guid>(type: "uuid", nullable: false),
                    container_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_templates", x => x.id);
                    table.ForeignKey(
                        name: "fk_templates_containers_container_id",
                        column: x => x.container_id,
                        principalTable: "containers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_templates_containers_container_id1",
                        column: x => x.container_id1,
                        principalTable: "containers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_templates_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_templates_projects_project_id1",
                        column: x => x.project_id1,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "template_versions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    template_id = table.Column<Guid>(type: "uuid", nullable: false),
                    version_number = table.Column<int>(type: "integer", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: false),
                    body = table.Column<string>(type: "text", nullable: false),
                    from = table.Column<string>(type: "text", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    template_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_template_versions", x => x.id);
                    table.ForeignKey(
                        name: "fk_template_versions_templates_template_id",
                        column: x => x.template_id,
                        principalTable: "templates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_template_versions_templates_template_id1",
                        column: x => x.template_id1,
                        principalTable: "templates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notification_trackings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    template_id = table.Column<Guid>(type: "uuid", nullable: false),
                    template_version_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false),
                    usage_type = table.Column<int>(type: "integer", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_test = table.Column<bool>(type: "boolean", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: false),
                    body = table.Column<string>(type: "text", nullable: false),
                    from = table.Column<string>(type: "text", nullable: false),
                    tenant_id1 = table.Column<Guid>(type: "uuid", nullable: false),
                    template_id1 = table.Column<Guid>(type: "uuid", nullable: false),
                    template_version_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notification_trackings", x => x.id);
                    table.ForeignKey(
                        name: "fk_notification_trackings_template_versions_template_version_i",
                        column: x => x.template_version_id1,
                        principalTable: "template_versions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notification_trackings_template_versions_template_version_id",
                        column: x => x.template_version_id,
                        principalTable: "template_versions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notification_trackings_templates_template_id",
                        column: x => x.template_id,
                        principalTable: "templates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notification_trackings_templates_template_id1",
                        column: x => x.template_id1,
                        principalTable: "templates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notification_trackings_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notification_trackings_tenants_tenant_id1",
                        column: x => x.tenant_id1,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "template_recipients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    template_version_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    template_version_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_template_recipients", x => x.id);
                    table.ForeignKey(
                        name: "fk_template_recipients_template_versions_template_version_id",
                        column: x => x.template_version_id,
                        principalTable: "template_versions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_template_recipients_template_versions_template_version_id1",
                        column: x => x.template_version_id1,
                        principalTable: "template_versions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tracking_recipients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    notification_tracking_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    notification_tracking_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tracking_recipients", x => x.id);
                    table.ForeignKey(
                        name: "fk_tracking_recipients_notification_trackings_notification_tra",
                        column: x => x.notification_tracking_id,
                        principalTable: "notification_trackings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tracking_recipients_notification_trackings_notification_tra1",
                        column: x => x.notification_tracking_id1,
                        principalTable: "notification_trackings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_access_control_entries_entity_type_entity_id",
                table: "access_control_entries",
                columns: new[] { "entity_type", "entity_id" });

            migrationBuilder.CreateIndex(
                name: "ix_access_control_entries_user_id",
                table: "access_control_entries",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_access_control_entries_user_id1",
                table: "access_control_entries",
                column: "user_id1");

            migrationBuilder.CreateIndex(
                name: "ix_containers_parent_id",
                table: "containers",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "ix_containers_parent_id1",
                table: "containers",
                column: "parent_id1");

            migrationBuilder.CreateIndex(
                name: "ix_containers_project_id",
                table: "containers",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "ix_containers_project_id1",
                table: "containers",
                column: "project_id1");

            migrationBuilder.CreateIndex(
                name: "ix_coupons_code",
                table: "coupons",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_enterprise_plan_overrides_tenant_id",
                table: "enterprise_plan_overrides",
                column: "tenant_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_notification_trackings_template_id_template_version_id",
                table: "notification_trackings",
                columns: new[] { "template_id", "template_version_id" });

            migrationBuilder.CreateIndex(
                name: "ix_notification_trackings_template_id1",
                table: "notification_trackings",
                column: "template_id1");

            migrationBuilder.CreateIndex(
                name: "ix_notification_trackings_template_version_id",
                table: "notification_trackings",
                column: "template_version_id");

            migrationBuilder.CreateIndex(
                name: "ix_notification_trackings_template_version_id1",
                table: "notification_trackings",
                column: "template_version_id1");

            migrationBuilder.CreateIndex(
                name: "ix_notification_trackings_tenant_id",
                table: "notification_trackings",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_notification_trackings_tenant_id1",
                table: "notification_trackings",
                column: "tenant_id1");

            migrationBuilder.CreateIndex(
                name: "ix_projects_tenant_id",
                table: "projects",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_projects_tenant_id1",
                table: "projects",
                column: "tenant_id1");

            migrationBuilder.CreateIndex(
                name: "ix_subscription_plans_tier",
                table: "subscription_plans",
                column: "tier");

            migrationBuilder.CreateIndex(
                name: "ix_template_recipients_template_version_id",
                table: "template_recipients",
                column: "template_version_id");

            migrationBuilder.CreateIndex(
                name: "ix_template_recipients_template_version_id1",
                table: "template_recipients",
                column: "template_version_id1");

            migrationBuilder.CreateIndex(
                name: "ix_template_versions_template_id",
                table: "template_versions",
                column: "template_id");

            migrationBuilder.CreateIndex(
                name: "ix_template_versions_template_id_version_number",
                table: "template_versions",
                columns: new[] { "template_id", "version_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_template_versions_template_id1",
                table: "template_versions",
                column: "template_id1");

            migrationBuilder.CreateIndex(
                name: "ix_templates_container_id",
                table: "templates",
                column: "container_id");

            migrationBuilder.CreateIndex(
                name: "ix_templates_container_id1",
                table: "templates",
                column: "container_id1");

            migrationBuilder.CreateIndex(
                name: "ix_templates_project_id",
                table: "templates",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "ix_templates_project_id1",
                table: "templates",
                column: "project_id1");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_api_keys_key_hash",
                table: "tenant_api_keys",
                column: "key_hash");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_api_keys_tenant_id",
                table: "tenant_api_keys",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_api_keys_tenant_id1",
                table: "tenant_api_keys",
                column: "tenant_id1");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_coupons_coupon_id",
                table: "tenant_coupons",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_coupons_coupon_id1",
                table: "tenant_coupons",
                column: "coupon_id1");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_coupons_tenant_id_coupon_id",
                table: "tenant_coupons",
                columns: new[] { "tenant_id", "coupon_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tenant_coupons_tenant_id1",
                table: "tenant_coupons",
                column: "tenant_id1");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_subscriptions_enterprise_overrides_id",
                table: "tenant_subscriptions",
                column: "enterprise_overrides_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_subscriptions_enterprise_overrides_id1",
                table: "tenant_subscriptions",
                column: "enterprise_overrides_id1");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_subscriptions_is_active",
                table: "tenant_subscriptions",
                column: "is_active");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_subscriptions_subscription_plan_id",
                table: "tenant_subscriptions",
                column: "subscription_plan_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_subscriptions_subscription_plan_id1",
                table: "tenant_subscriptions",
                column: "subscription_plan_id1");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_subscriptions_tenant_id",
                table: "tenant_subscriptions",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_subscriptions_tenant_id1",
                table: "tenant_subscriptions",
                column: "tenant_id1");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_user_maps_tenant_id_user_id",
                table: "tenant_user_maps",
                columns: new[] { "tenant_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "ix_tenant_user_maps_tenant_id1",
                table: "tenant_user_maps",
                column: "tenant_id1");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_user_maps_user_id",
                table: "tenant_user_maps",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_user_maps_user_id1",
                table: "tenant_user_maps",
                column: "user_id1");

            migrationBuilder.CreateIndex(
                name: "ix_tenants_owner_user_id",
                table: "tenants",
                column: "owner_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenants_owner_user_id1",
                table: "tenants",
                column: "owner_user_id1");

            migrationBuilder.CreateIndex(
                name: "ix_tracking_recipients_notification_tracking_id",
                table: "tracking_recipients",
                column: "notification_tracking_id");

            migrationBuilder.CreateIndex(
                name: "ix_tracking_recipients_notification_tracking_id1",
                table: "tracking_recipients",
                column: "notification_tracking_id1");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_sso_id",
                table: "users",
                column: "sso_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "access_control_entries");

            migrationBuilder.DropTable(
                name: "template_recipients");

            migrationBuilder.DropTable(
                name: "tenant_api_keys");

            migrationBuilder.DropTable(
                name: "tenant_coupons");

            migrationBuilder.DropTable(
                name: "tenant_subscriptions");

            migrationBuilder.DropTable(
                name: "tenant_user_maps");

            migrationBuilder.DropTable(
                name: "tracking_recipients");

            migrationBuilder.DropTable(
                name: "coupons");

            migrationBuilder.DropTable(
                name: "enterprise_plan_overrides");

            migrationBuilder.DropTable(
                name: "subscription_plans");

            migrationBuilder.DropTable(
                name: "notification_trackings");

            migrationBuilder.DropTable(
                name: "template_versions");

            migrationBuilder.DropTable(
                name: "templates");

            migrationBuilder.DropTable(
                name: "containers");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "tenants");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
