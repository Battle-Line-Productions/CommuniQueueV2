# CommuniQueue: Platform Architecture & Specification

**Version:** 1.8
**Last Updated:** 2025-04-27  
**Author:** Michael Cavanaugh

---

## Table of Contents

- [1. Overview](#1-overview)
- [2. Technology Stack and Deployment](#2-technology-stack-and-deployment)
  - [Application Code and Organization](#application-code-and-organization)
  - [Third-Party Integrations](#third-party-integrations)
  - [Hosting, Cloud, and DevOps](#hosting-cloud-and-devops)
  - [CI/CD Pipeline](#cicd-pipeline)
  - [Infrastructure Diagram (textual)](#infrastructure-diagram-textual)
- [3. UI/UX Design and Accessibility](#3-uiux-design-and-accessibility)
  - [General Principles](#general-principles)
  - [Design Framework & Styling](#design-framework--styling)
- [4. Feature Matrix](#4-feature-matrix)
  - [Multi-Tenancy & Limits](#multi-tenancy--limits)
  - [Roles (RBAC)](#roles-rbac)
  - [Access Inheritance](#access-inheritance)
  - [Templates and Versioning](#templates-and-versioning)
  - [API Auth](#api-auth)
  - [Notification Delivery & Tracking](#notification-delivery--tracking)
  - [Subscription and Coupons](#subscription-and-coupons)
  - [Data Retention](#data-retention)
- [5. Entity Data Model](#5-entity-data-model)
  - [Users/Tenants/Access](#userstenantsaccess)
  - [TenantUserMap & RBAC Matrix](#tenantusermap--rbac-matrix)
  - [Project/Container/Template (with Versioning)](#projectcontainertemplate-with-versioning)
  - [Notification Sending & Tracking](#notification-sending--tracking)
  - [API Keys](#api-keys)
  - [Enhanced Subscription Plan Models](#enhanced-subscription-plan-models)
- [6. RBAC Matrix](#6-rbac-matrix)
- [7. API Specification (Outline)](#7-api-specification-outline)
  - [Auth](#auth)
  - [RBAC/Access](#rbacaccess)
  - [Example Endpoints](#example-endpoints)
- [8. ERD (Pseudo-Graphviz Style, Key Relations)](#8-erd-pseudo-graphviz-style-key-relations)
- [9. Core Workflows](#9-core-workflows)
  - [9.1 Onboarding](#91-onboarding)
  - [9.2 RBAC & Access Changes](#92-rbac--access-changes)
  - [9.3 Template Management](#93-template-management)
  - [9.4 Sending/Tracking](#94-sendingtracking)
  - [9.5 Subscription/Billing](#95-subscriptionbilling)
  - [9.6 Retention/Purging](#96-retentionpurging)
- [10. Logging and Observability](#10-logging-and-observability)
  - [Logging Design and Practice](#logging-design-and-practice)
- [11. Metric Reporting and Analytics (Roadmap/Post-MVP)](#11-metric-reporting-and-analytics-roadmappost-mvp)
- [12. Open Issues/Future Decisions](#12-open-issuesfuture-decisions)
- [13. Roadmap & Future Feature Ideas](#13-roadmap--future-feature-ideas)
- [14. CHANGELOG](#14-changelog)

---

## 1. Overview

CommuniQueue is a secure, multi-tenant notification SaaS for templated message management, dispatch, and tracking over email, SMS, and webhooks. Designed for organizational flexibility, it features RBAC, rich template/version control, pluggable subscription models, robust metrics, extensible logging, and seamless developer operations—all backed by a modern, scalable .NET/Blazor + Postgres stack.

---

## 2. Technology Stack and Deployment

### Application Code and Organization

- **Language/Runtime:** .NET 9 (C#)
- **UI:** Blazor Server App  
  - Hosted as the primary user interface (interactive, real-time updates).
  - Blazor Server provides both frontend and can serve as the backend for UI logic.
- **API Services:**  
  - Separate .NET 9 API project for client-exposed endpoints (RESTful).
  - This API serves 3rd-party integrations, public documentation, and workload queries.
- **Background Processing:**
  - AWS Lambda function handles background/queue processing (consumes messages from SQS for sending, retries, status handling, etc.).
  - Implemented as a .NET 9 Lambda function that is triggered by SQS events.
  - Each Lambda invocation processes one or more messages from the SQS queue depending on batch configuration.
- **Shared Libraries:**  
  - Common business logic, data models, and utility code are structured in shared libraries, referenced by all projects.
- **Containerization:**  
  - UI and API services are containerized using Docker for deployment, scaling, and local development parity.
  - Lambda function is deployed directly as a .NET Assembly.
- **Solution/Orchestration:**
  - All deployable projects (UI, API, Lambda, shared libraries) are organized within a single .NET Aspire solution file at the root of the monorepo. 
  - dotnet Aspire is used for orchestration; offers unified local setup, discovery, health checking, common configuration, and is the foundation for integrating service dependencies (e.g., local queue, database, test environment coordination).
  - Each deployable is a project in the single solution, and Aspire orchestrates their inter-dependencies.

### Third-Party Integrations

- **Email Provider:**  
  - [SendGrid](https://sendgrid.com/) is the primary transactional/marketing email provider.
    - Integration supports templated emails, open/click tracking, sender verification, basic and advanced email address validation (with pass-through billing for premium checks where applicable).
    - Email type classification (transactional vs marketing) managed in the app and respected at the SendGrid level.
- **SMS Provider:**  
  - [Twilio](https://twilio.com/) designated for SMS/MMS delivery.
    - Pluggable logic can expand to other SMS APIs later or support tenant-supplied credentials ("bring your own provider").
    - Future support: SMS link tracking via redirect/shortener service.
- **Auth Provider:**  
  - [Auth0](https://auth0.com/) is used for UI and API authentication and SSO.
    - All user management, JWT issuance, and federated login handled by Auth0.
    - Users never handle passwords or local credentials.
    - API authentication with API key support for machine-to-machine scenarios.

### Hosting, Cloud, and DevOps

- **Cloud:**  
  - AWS is the primary cloud provider for all core infrastructure.
  - Regions, backup, and storage settings TBA (default: US regional).
- **Compute/Hosting:**  
  - **AWS App Runner** used for hosting containerized Blazor Server app and API.
    - App Runner handles scaling, health checks, networking, domain SSL, and rolling deploys.
    - Services deployed via Docker images.
    - Backend services may be split for scale/performance or hosted together for simplicity.
  - **AWS Lambda** for background processing of SQS messages.
    - Serverless execution model with automatic scaling based on queue depth.
    - Configured with appropriate memory, timeout, and concurrency settings.
  - **Static/Asset Storage:**  
    - AWS S3 for logs/files/assets (if needed).
    - CloudFront used for CDN/caching if necessary.
- **Database:**  
  - PostgreSQL (AWS RDS or Aurora Serverless as default managed option).
  - All entities use GUID v7 as PKs for scalability and global uniqueness.
- **Container Management:**  
  - Docker for local dev and CI/CD (for UI and API services).
    - Multi-stage Dockerfiles for each service (UI, API) for minimal images.
    - Default docker-compose for developer bootstrapping.
    - Registry: AWS ECR for publishing images.
- **Queueing/Background Processing:**  
  - AWS SQS for decoupling the message "Send" API from the actual background message delivery.
  - AWS Lambda function triggered by SQS events processes messages for sending, retry, webhooks, status polling, and updates the main application DB.

### CI/CD Pipeline

- Source is in git (flow and branching model TBA).
- Docker images built and tested for UI/API services.
- Lambda function built and packaged as .NET assembly.
- Deployment to AWS via GitHub Actions, AWS CodePipeline, or other modern CI/CD runner.
- Environment-specific configs/secrets managed by AWS SSM or Secrets Manager.

### Infrastructure Diagram (textual)
```
[Client Browser] 
   | 
   v
[Blazor Server Container: UI logic] <-----> [API Service Container: REST, exposed endpoints]
   |                                              |
   v                                              v
[Postgres RDS/Aurora]                      [AWS SQS/Queue] 
                                                  | 
                                                  v
                                   [AWS Lambda: processes SQS events,
                                    integrates with SendGrid, Twilio, webhooks, and 
                                    updates NotificationTracking/entities]

[Auth0 cloud service] handles all signin and token issuance for UI & API.
[AWS App Runner] deploys and manages containers for UI and API.
[AWS Lambda] handles background processing from SQS queue.
[S3] and [CloudFront] used for any exported data, logs, or large asset hosting.
```

---

## 3. UI/UX Design and Accessibility

### General Principles

- **Unified Experience:**  
  The UI is designed as a single-page app using Blazor Server to provide fast, real-time user interactions, with robust state management and responsive routing.

- **Componentized Architecture:**  
  Most UI features (dashboards, project/container trees, template editors, modals, invite flows, RBAC management, send/test forms, tracking, subscription management) are built using reusable Blazor components to maximize development efficiency and UX consistency.

- **Accessibility (a11y):**
  - All interface components are designed to be fully keyboard navigable.
  - All UI elements support proper ARIA roles/labels, dynamic announcements, and contrast ratios compliant with WCAG 2.1 AA or higher (target: AAA where feasible).
  - All interactive controls, especially forms, role assignment dialogs, and table/grid elements, are tested for screen reader compatibility (using NVDA/JAWS/VoiceOver during QA).
  - Focus management and skip links are included for efficient navigation.
  - Modal dialogs and dropdown components are fully accessible and dismissible.

- **Internationalization & Theming (future support):**
  - All text is presented via string resource files and is ready for future localization efforts.
  - High-contrast and dark/light themes supported via TailwindCSS utility classes and toggle in-site preferences.

### Design Framework & Styling

- **TailwindCSS:**
  - All UI styling is developed using [TailwindCSS](https://tailwindcss.com/), integrated into Blazor via third-party interop and build tooling.
  - Atomic utility classes ensure maintainable, scalable UI with minimal global CSS.
  - Layout uses responsive grid/flexbox for dashboards and navigation elements.
  - Custom theme palettes defined for branding and accessibility.

- **Design Language:**
  - Clean, modern "dashboard SaaS" visual style.
  - Primary navigation is via a sidebar (tree of tenants/projects/containers) and top bar (user/account/settings).
  - Consistent iconography and microcopy for frictionless onboarding.

- **User Feedback/Interactions:**
  - All major actions (save, send, test, promote version, invite, role change) provide clear feedback (toast/alert, visual inline validation).
  - Undo/redo or confirmation for destructive actions (delete, mass revoke).
  - RBAC modifications provide immediate, in-context feedback and access change notification.

---

## 4. Feature Matrix

### Multi-Tenancy & Limits
- Each user gets 1 tenant at signup. Can create up to 6; requests for more manually justified.
- All core entities scoped by TenantId.
- Subscription, quotas, and upgrades are per-tenant (not user-global).

### Roles (RBAC)
- **Tenant/User level:** Owner, Admin, Member, Readonly
- **Entity (Project/Container/Template) level:** Same roles, default-inherited down unless explicitly denied/overridden. Deny is strict (Deny > Allow).
- **SuperAdmin:** Only system-level staff; always full access. All access changes by SuperAdmin logged.
- **Impersonation:** SuperAdmin can impersonate any user via the UI, acting on the user's behalf. Impersonation state is displayed in the UI and logged in the audit trail for accountability.

### Access Inheritance
- Grant at a higher level allows access to lower unless denied.
- Deny at project/container/template level hides that tree from user, even if inherited.
- All access changes (grant, deny, revoke) trigger user notifications.

### Templates and Versioning
- Templates are versioned; every save (out of "building" stage) produces a version.
- 5 most recent versions are kept by default; older versions pruned FIFO unless user pays for more capacity.
- Unlimited versions can be created (with warning upon cap); oldest pruned as needed.

### API Auth
- API Keys per-tenant, multiple allowed, full expiry/rotation support, explicit allowed scopes (send, preview, fetch status, etc.)

### Notification Delivery & Tracking
- "Send" calls validate, enqueue in background (AWS SQS); status available via API.
- Tracking/metrics on sent/failed/test status, exportable prior to retention expiry. Some metadata retained for long-term metrics even after detailed purge for compliance.

### Subscription and Coupons
- All plan/entitlement logic versioned/configured in DB
- **Subscription Tiers:**  
  - Free  
  - Standard (e.g., Basic)  
  - Plus  
  - Premium  
  - **Enterprise:** Fully customizable per-tenant plan (see Subscription Models below)
- Per-tenant subscription; upgrades, feature add-ons, coupon support (percentage, flat, expiry vs. benefit window)
- All changes auditable.

### Data Retention
- Notification and recipient data kept for 3 days by default, longer via plan.
- On purge: Success/failure counts/analytics maintained; PII deleted/obscured except where needed for audit/billing.

---

## 5. Entity Data Model

### Users/Tenants/Access

```csharp
public class User {
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

public class Tenant {
    public Guid Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid OwnerUserId { get; set; }
    public StatusType Status { get; set; }
}
```

### TenantUserMap & RBAC Matrix

```csharp
public class TenantUserMap {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TenantId { get; set; }
    public RoleType Role { get; set; } // Owner/Admin/Member/Readonly
    public TenantMembershipStatusType Status { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}

// Universal RBAC table for entity-level overrides
public class AccessControlEntry {
    public Guid Id { get; set; }
    public AccessControlledEntityType EntityType { get; set; } // Tenant, Project, Container, Template
    public Guid EntityId { get; set; }
    public Guid UserId { get; set; }
    public RoleType Role { get; set; } // Owner, Admin, Member, Readonly, Deny
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
    // Expanding for group/role-based access may be future
}
```

### Project/Container/Template (with Versioning)

```csharp
public class Project {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid TenantId { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}

public class Container {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid? ParentId { get; set; }
    public Guid ProjectId { get; set; }
    public int Depth { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}

public class Template {
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

public class TemplateVersion {
    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public int VersionNumber { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string From { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}

public class TemplateRecipient {
    public Guid Id { get; set; }
    public Guid TemplateVersionId { get; set; }
    public RecipientType Type { get; set; }
    public string Value { get; set; }
}
```

### Notification Sending & Tracking

```csharp
public class NotificationTracking {
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

public class TrackingRecipient {
    public Guid Id { get; set; }
    public Guid NotificationTrackingId { get; set; }
    public RecipientType Type { get; set; }
    public string Value { get; set; }
}

public class NotificationTrackingDebug {
    public Guid Id { get; set; }
    public Guid NotificationTrackingId { get; set; }
    public JSONB DebugInfo { get; set; }
    public ProviderType DebugSource { get; set; } // sendgrid, twilio, etc
    public DeliveryStatus Status { get; set; } // Sent/Delivered/Failed/Retrying
    public int AttemptCount { get; set; }
}
```

### API Keys

```csharp
public class TenantApiKey {
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
```

### Enhanced Subscription Plan Models

```csharp
public enum SubscriptionTier {
    Free,
    Standard,
    Plus,
    Premium,
    Enterprise
}

public class SubscriptionPlan {
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

public class TenantSubscription {
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

public class Coupon {
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public decimal? FlatAmountOff { get; set; }
    public decimal? PercentageOff { get; set; }
    public DateTime ExpireDate { get; set; }
    public DateTime? BenefitUntil { get; set; }
}

public class TenantCoupon {
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid CouponId { get; set; }
    public DateTime DateApplied { get; set; }
    public DateTime? BenefitUntil { get; set; }
}

// For highly granular Enterprise plan limits (per-tenant customization):
public class EnterprisePlanOverride {
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
```

- All normal plans use default SubscriptionPlan fields in tiers.
- If TenantSubscription.EnterpriseOverridesId is set, referenced overrides will supersede plan values for the tenant (for only those values not null).
- This allows an enterprise customer to upgrade, buy, or negotiate any feature/cap on a per-tenant basis.

---

## 6. RBAC Matrix

| Scope/Entity      | Owner | Admin | Member | Readonly | Deny      |
|-------------------|-------|-------|--------|----------|-----------|
| Tenant            | Full  | CRUD* | View+  | View     | Block all |
| Project           | Full  | CRUD  | View+  | View     | Hide all  |
| Container         | Full  | CRUD  | View+  | View     | Hide all  |
| Template          | Full  | CRUD  | View+  | View     | Hide all  |

- Full: everything, including membership/keys.
- CRUD*: Can't delete tenant if not owner. Can invite members.
- View+: includes view/test/send but not edit/delete.
- Access is inherited from parent unless denied at any tier.
- Deny: Blocks user and all subordinate children, even if higher level permits.

---

## 7. API Specification (Outline)

Base API prefix: /api/v1

### Auth
- All API (except public docs/health) requires Auth0 JWT or a valid API key.

### RBAC/Access
- Endpoints validate scope per user AND per API key.
- "Deny" hides the resource and children in all listings.

### Example Endpoints

#### Tenant/Org

```
http
POST   /api/v1/tenants                 // create new tenant
GET    /api/v1/tenants                 // list available to user
GET    /api/v1/tenants/{id}            // view tenant dashboard/info
POST   /api/v1/tenants/{id}/invite     // invite user, assign role
POST   /api/v1/tenants/{id}/api-keys   // create/manage key
PUT    /api/v1/tenants/{id}/role       // assign/override tenant roles
GET    /api/v1/tenants/{id}/rback      // query effective access matrix
```

#### Projects

```
http
POST   /api/v1/projects                // create
GET    /api/v1/projects/{id}           // details
PUT    /api/v1/projects/{id}/role      // assign/override project roles
DELETE /api/v1/projects/{id}
```

#### Containers

```
http
POST   /api/v1/containers
GET    /api/v1/containers/{id}
PUT    /api/v1/containers/{id}/role
DELETE /api/v1/containers/{id}
```

#### Templates
```
http
POST   /api/v1/templates
GET    /api/v1/templates/{id}
PUT    /api/v1/templates/{id}
DELETE /api/v1/templates/{id}
POST   /api/v1/templates/{id}/clone
POST   /api/v1/templates/{id}/promote  // promote version to active
GET    /api/v1/templates/{id}/versions // history/list
```

#### Sending/Preview/Tracking

```
http
POST   /api/v1/send                    // enqueue send
POST   /api/v1/preview                 // render template/variables, no send
GET    /api/v1/notifications/{id}/status
GET    /api/v1/notifications/{id}/debug
GET    /api/v1/notifications/export    // per plan; only non-PII fields
```

#### Subscription and Billing

```
http
GET    /api/v1/subscription
POST   /api/v1/subscription/change     // upgrade/downgrade
POST   /api/v1/subscription/enterprise-overrides // set enterprise per-tenant
POST   /api/v1/coupons
POST   /api/v1/coupons/apply
POST   /api/v1/coupons/remove
```

#### Admin/SuperAdmin

```
http
GET    /api/v1/admin/audit-trail
POST   /api/v1/admin/impersonate
```

---

## 8. ERD (Pseudo-Graphviz Style, Key Relations)

```
mermaid
erDiagram
    USER ||--o{ TENANTUSERMAP : maps
    TENANT ||--o{ TENANTUSERMAP : contains
    TENANT ||--o{ PROJECT : has
    PROJECT ||--o{ CONTAINER : has
    CONTAINER ||--o{ TEMPLATE : contains
    TEMPLATE ||--o{ TEMPLATEVERSION : has
    TEMPLATEVERSION ||--o{ TEMPLATERECIPIENT : to
    TENANT ||--o{ TENANTAPIKEY : owns
    TENANT ||--o{ TENANTSUBSCRIPTION : subscribes
    TENANTSUBSCRIPTION ||--|| SUBSCRIPTIONPLAN : is
    TENANTSUBSCRIPTION ||--|| ENTERPRISEPLANOVERRIDE : can_have
    TENANT ||--o{ TENANTCOUPON : applies
    TENANTCOUPON ||--|| COUPON : uses
    USER ||--o{ ACCESSCONTROLENTRY : overrides
    TENANT ||--o{ NOTIFICATIONTRACKING : tracks
    NOTIFICATIONTRACKING ||--o{ TRACKINGRECIPIENT : to
    NOTIFICATIONTRACKING ||--o{ NOTIFICATIONTRACKINGDEBUG : logs
```

---

## 9. Core Workflows

#### 9.1 Onboarding
- User registers (Auth0), auto-provision default tenant, assign as Owner.
- User can create/join up to 6 tenants; each participation is tracked in TenantUserMap.
- Tenant invites trigger email and, upon acceptance, new TenantUserMap.

#### 9.2 RBAC & Access Changes
- Access granted/denied cascades via RBAC table.
- Deny trumps inherited grants.
- All access changes notify affected users and log action.

#### 9.3 Template Management
- Users create templates in containers.
- Each save (when state != "building") produces version.
- On version cap, warn; upon new version, prune oldest.
- Templates can be edited, promoted, or cloned.

#### 9.4 Sending/Tracking
- Send endpoint validates permissions, enqueues message in SQS, returns tracking ID.
- AWS Lambda function processes SQS messages and updates NotificationTracking.
- Debug audit (delivery detail, provider info, response, status, retry count) stored by Lambda.

#### 9.5 Subscription/Billing
- All allowances stored per-tenant.
- User can apply coupon codes for discounts/time-limited benefits.
- **Enterprise/Bespoke Plans:**   
    - Admin/sales can assign fine-tuned limits for any tenant, affecting max tenants, projects, templates, API/email limits, and more.

#### 9.6 Retention/Purging
- Data available for 3 days by default (plan controls window).
- Non-metric fields purged at expiry; analytics persist (count/success/fail, no PII).

---

## 10. Logging and Observability

### Logging Design and Practice

- **Logging Approach:**
  - All application code uses .NET's built-in ILogger abstraction.
  - Enrich logs with: timestamp, log level, message, correlationId (created per incoming request and propagated), userId (if authenticated), tenantId (where applicable), operation or feature context, and service name.
  - Middleware at API boundaries ensures a correlationId is created or propagated for each request (incoming HTTP, outgoing HTTP requests, queue messages).
  - For multi-service workflows (ex: message send -> Lambda processing), the correlationId is passed as metadata in SQS messages, headers, and anywhere actions span boundaries.
- **Logging Configuration:**
  - Local/dev: logs written to console and optionally file sink.
  - Production: logs exported to AWS CloudWatch Logs.
  - Aspire orchestrates, standardizes, and synchronizes service-level logging configuration.
  - Lambda logs automatically sent to CloudWatch Logs with additional context from the Lambda execution environment.
  - Potential use of [Serilog](https://serilog.net/) (with enrichers) or [OpenTelemetry](https://opentelemetry.io/) for enhanced structured logging and traces, especially for cross-service correlation.
- **Log Retention:**
  - Local/staging logs retained 7-30 days.
  - Production logs kept at least 90 days (configurable per legal/compliance/audit needs).
- **Example Log Format (JSON):**

 ```json   
{
  "timestamp": "2025-04-18T13:14:29Z",
  "level": "Information",
  "message": "Email sent successfully.",
  "correlationId": "a5d4d1ad-ac12-432c-b78c-eacd4a2c4758",
  "userId": "180a45b7-8889-4851-93a7-998d64a92129",
  "tenantId": "4e26a80a-7e5d-4e79-bba4-e12143f63365",
  "operation": "SendNotification",
  "service": "LambdaFunction",
  "provider": "SendGrid"
}
```

- **Traceability:**
  - Each event/action log can be tied to a specific request or operation across any number of services.
  - All log-backed events/actions must reference the originating correlationId for easy diagnostics, debugging, and auditing. 
  - Lambda receives correlationId from SQS message attributes and propagates it to all logs and downstream service calls.
  - Down the road, pursue distributed tracing and OpenTelemetry collector support to enable deep tracing, performance monitoring, and easier debug of cross-service issues.

---

## 11. Metric Reporting and Analytics (Roadmap/Post-MVP)

**Not part of MVP, but captured now for future planning.**

- **Goal:** Provide users and tenants with dashboards and APIs for:
    - Total/periodic number of messages sent, by time (hour/day/week/month)
    - Success vs failure rates, and trends over any interval
    - Filter/search/reporting by message status (success, failure, bounced, test), message type (email, SMS, webhook, etc.), template, project, tenant, and user
    - Exporting to CSV, JSON, or similar (with filters)
    - Alerting/notifications for usage/billing if desired in the future
- **Widget Dashboard:** 
    - Blazor UI to include summary tiles, bar/line charts for trends, filter bars
- **Data Aggregation:**
    - Use NotificationTracking for raw records; nightly/rolling jobs performed by Lambda aggregate into summary tables (e.g., per-tenant, per-project/day/month, per-message-type).
- **API Design:**
    - /api/v1/metrics/summary?range=last30days&type=email
    - /api/v1/metrics/widget?tenantId=123&filter=success&period=last24h
- **Proposed Metric Model Example:**
    
```csharp
    public class MetricAggregate {
        public Guid TenantId { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public int SentCount { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
        public NotificationType Type { get; set; }
        public string? ProjectName { get; set; }
        public string? User { get; set; }
    }
```

- **Frontend:**
    - Dashboard with widgets and trend visualizations. Likely will use Blazor-compatible charting library (ChartJS, ApexCharts).
    - Filter widgets for status, type, time window, and more.

---

## 12. Open Issues/Future Decisions

- UI/UX approach for SuperAdmin (impersonation, UI visibility - now locked as a supported feature).
- Audit log retention, visibility, and privacy for failed/purged messages.
- Webhook signing and retry patterns (JWT/HMAC, user config).
- Billing reconciliation/model (support for future usage metering, tiered pricing).
- Bulk export/reporting: data, format, scope.

---

## 13. Roadmap & Future Feature Ideas

**After MVP, immediate post-launch, and long-term features for CommuniQueue:**

### Metrics & Reporting Enhancements (Post-MVP)
- Real-time, filterable dashboard widgets for sent/failed message volume (by type/recipient/project/tenant).
- Advanced trend analytics: time-series charts for volume, delivery success/failure, bounce rates.
- API for exporting aggregated or raw message data for BI and compliance.
- Scheduled/email metric reports to tenant admins.
- In-app alerts and push/email/SMS notifications for quota exhaustion, failures, or traffic anomalies.

### Channels & Integrations
- **Inbound Webhooks:** Allow tenants to ingest data/events and trigger outgoing notifications or workflows.
- **Slack, Teams, Discord Integration:** Send notifications directly into chat/workspace tools.
- **WhatsApp, Facebook Messenger, or Push Notifications** as new destination types.
- **Event-Driven Integrations:** Native support for Zapier/IFTTT, webhook chaining, or custom event sources.

### Organization & Collaboration
- **Org/Group Management:** Allow grouping multiple tenants into an organization, with central billing and roster/RBAC management.
- **Audit Log UI:** Full searchable/auditable activity log with fine-grained filtering and export.
- **Admin "Inbox":** Centralized place for all RBAC requests, access change notifications, and org-level alerts.
- **Self-service Role Delegation:** Allow project/container/template owners to delegate management without tenant admin access.

### Advanced Templating & Delivery Features
- **Template Variables UI:** Visual editor and variable testing (live validation/preview), variable history and suggestions.
- **Template Approval Flows:** Add stage gating for "Needs Review," "Approval," and "Locked" states.
- **A/B Testing:** Support for testing notification variants and tracking open/click/conversion lift.
- **Scheduling/Future Sends:** Specify message jobs for future time windows, recurring sends or drip campaigns.
- **Dynamic Attachment Support:** File asset storage and securely attach (link or inline) documents/images to outgoing messages.

### Security & Compliance
- **Custom Domain & DKIM/SPF Management:** Let paid tenants provide their own sender domains, manage DNS records, and validate with SendGrid.
- **End-to-end Encryption for Sensitive Payloads/PII:** Encrypt message contents and attachments at rest and optionally in transit.
- **Granular Data Retention/Legal Hold Policies:** Let tenants customize retention windows and request "freeze" for audit/legal.

### Administrative Capabilities
- **Usage Billing Portal:** Full usage-based billing, downloadable invoices, and payment integration (Stripe/ACH/Credit Card).
- **SSO/SAML/SCIM Support for Large Tenants.**
- **Bulk User Management:** CSV import/export for contacts, access, and template data.
- **Custom Branding:** White label UI with tenant-specific logo/colors, email footers, and "from" domains.

### Developer & API Experience
- **OpenAPI/Swagger-powered developer portal:** Self-serve API key management, live docs, and test calls.
- **API Rate Limiting Controls:** Tenant admins can configure bursts and set alerts for nearing quota.
- **Webhook Event Delivery Receipts/Dead-letter Queues:** Retry/backoff/callback management and monitoring.

### Reliability / Scaling
- **Multi-region failover with automated disaster recovery.**
- **Capacity auto-scaling (per-tenant or per-channel).**
- **Advanced queue and delivery analytics (e.g., latency, retries, provider SLA trends).**
- **Predictive scaling insights using past usage for large tenants.**

### AI/ML & Smart Automation (Vision)
- **Smart Variable Discovery:** Automatic detection and recommendation of template variables using message body analysis.
- **Anomaly Detection:** Alert on unusual bounce/failure/spam rates using ML.
- **AI-Based Message Optimization:** Suggest best times to send, optimize for open/click based on historical data.
- **Language Tone/Sentiment Checks for Marketing Messages.**

### Marketplace & Extensibility
- **Marketplace for Verified Templates:** Community or partner-submitted notification templates, free or for sale.
- **Plugin API for In-app Extensions:** Let tenants (or vendors) build custom logic, validation, or reporting widgets.

---

## 14. CHANGELOG

- 2025-04-18: Full tech stack, RBAC/design, retention, API, and ERD formalized.
- 2025-04-18: Infrastructure/cloud/hosting, Docker, and deployment workflow updated.
- 2025-04-18: Added UI/UX, accessibility, TailwindCSS section, and design guidance.
- 2025-04-18: Enterprise-grade plan/override model described.
- 2025-04-18: Logging (ILogger, CloudWatch, correlation, distributed tracing) fully defined.
- 2025-04-18: Aspire orchestration, monorepo/solution pattern added.
- 2025-04-18: Metric reporting, dashboard widgets, and analytic aggregation described for future effort.
- 2025-04-18: SuperAdmin impersonation supported and described.
- 2025-04-27: Updated background processing to use AWS Lambda function that reads from SQS queue via Lambda events instead of a containerized worker service.
