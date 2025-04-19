# CommuniQueue Features and Stories Breakdown

## Table of Contents

- [Epic 1: Core Infrastructure & Setup](#epic-1-core-infrastructure--setup)
  - [Feature 1.1: .NET Solution Architecture](#feature-11-net-solution-architecture)
  - [Feature 1.2: Database Implementation](#feature-12-database-implementation)
  - [Feature 1.3: Containerization](#feature-13-containerization)
  - [Feature 1.4: AWS Infrastructure Setup](#feature-14-aws-infrastructure-setup)
  - [Feature 1.5: CI/CD Pipeline](#feature-15-cicd-pipeline)
  - [Feature 1.6: Development Environment](#feature-16-development-environment)
- [Epic 2: Authentication & Authorization](#epic-2-authentication--authorization)
  - [Feature 2.1: Auth0 Integration](#feature-21-auth0-integration)
  - [Feature 2.2: User Management](#feature-22-user-management)
  - [Feature 2.3: RBAC Framework](#feature-23-rbac-framework)
  - [Feature 2.4: Access Inheritance](#feature-24-access-inheritance)
  - [Feature 2.5: API Authentication](#feature-25-api-authentication)
  - [Feature 2.6: SuperAdmin Capabilities](#feature-26-superadmin-capabilities)
  - [Feature 2.7: Authentication Audit & Security](#feature-27-authentication-audit--security)
- [Epic 3: Multi-tenancy Framework](#epic-3-multi-tenancy-framework)
  - [Feature 3.1: Tenant Provisioning](#feature-31-tenant-provisioning)
  - [Feature 3.2: Tenant User Management](#feature-32-tenant-user-management)
  - [Feature 3.3: Tenant Invitation System](#feature-33-tenant-invitation-system)
  - [Feature 3.4: Tenant Administration](#feature-34-tenant-administration)
- [Epic 4: Project & Container Management](#epic-4-project--container-management)
  - [Feature 4.1: Project Structure](#feature-41-project-structure)
  - [Feature 4.2: Container Hierarchy](#feature-42-container-hierarchy)
  - [Feature 4.3: Project Navigation](#feature-43-project-navigation)
  - [Feature 4.4: Project & Container Access Control](#feature-44-project--container-access-control)
- [Epic 5: Template System](#epic-5-template-system)
  - [Feature 5.1: Template Management](#feature-51-template-management)
  - [Feature 5.2: Template Versioning](#feature-52-template-versioning)
  - [Feature 5.3: Template Editor](#feature-53-template-editor)
  - [Feature 5.4: Template Testing](#feature-54-template-testing)
  - [Feature 5.5: Template Recipients](#feature-55-template-recipients)
- [Epic 6: Notification Services](#epic-6-notification-services)
  - [Feature 6.1: SendGrid Integration](#feature-61-sendgrid-integration)
  - [Feature 6.2: Twilio Integration](#feature-62-twilio-integration)
  - [Feature 6.3: Webhook Delivery](#feature-63-webhook-delivery)
  - [Feature 6.4: Message Queue Integration](#feature-64-message-queue-integration)
  - [Feature 6.5: Background Processing](#feature-65-background-processing)
- [Epic 7: Notification Tracking](#epic-7-notification-tracking)
  - [Feature 7.1: Notification Status Tracking](#feature-71-notification-status-tracking)
  - [Feature 7.2: Recipient Tracking](#feature-72-recipient-tracking)
  - [Feature 7.3: Debug Information](#feature-73-debug-information)
  - [Feature 7.4: Data Retention](#feature-74-data-retention)
  - [Feature 7.5: Notification Analytics](#feature-75-notification-analytics)
- [Epic 8: Subscription & Billing](#epic-8-subscription--billing)
  - [Feature 8.1: Subscription Plans](#feature-81-subscription-plans)
  - [Feature 8.2: Tenant Subscriptions](#feature-82-tenant-subscriptions)
  - [Feature 8.3: Enterprise Plan Customization](#feature-83-enterprise-plan-customization)
  - [Feature 8.4: Coupon System](#feature-84-coupon-system)
  - [Feature 8.5: Usage Limits & Enforcement](#feature-85-usage-limits--enforcement)
- [Epic 9: External API & Developer Experience](#epic-9-external-api--developer-experience)
  - [Feature 9.1: API Infrastructure](#feature-91-api-infrastructure)
  - [Feature 9.2: API Documentation & Developer Portal](#feature-92-api-documentation--developer-portal)
  - [Feature 9.3: SDK Generation & Code Samples](#feature-93-sdk-generation--code-samples)
  - [Feature 9.4: API Monitoring & Analytics](#feature-94-api-monitoring--analytics)
  - [Feature 9.5: API Rate Limiting & Throttling](#feature-95-api-rate-limiting--throttling)
- [Epic 10: Post-MVP Reporting & Analytics](#epic-10-post-mvp-reporting--analytics)
  - [Feature 10.1: Analytics Dashboard](#feature-101-analytics-dashboard)
  - [Feature 10.2: Notification Metrics](#feature-102-notification-metrics)
  - [Feature 10.3: Usage Reporting](#feature-103-usage-reporting)
  - [Feature 10.4: Scheduled Reports](#feature-104-scheduled-reports)
  - [Feature 10.5: Advanced Analytics](#feature-105-advanced-analytics)

## Epic 1: Core Infrastructure & Setup

**Description:**  
Core Infrastructure & Setup establishes the technological backbone for CommuniQueue. This epic includes initial architecture design, development tooling, orchestration, containerization, and deployment pipelines. The ambition is not just to build a solid foundation, but to future-proof the platform for rapid feature evolution and operational scaling. The choices here (modern .NET stack, multi-service orchestration via Aspire, strict containerization) are deliberate: they mitigate early technical debt, maximize developer productivity, guarantee maintainability, and set the stage for secure, reliable multi-environment deployments. This epic also tackles critical non-functional concerns—performance, logging, resilience, and developer experience—all crucial for supporting a cloud-native SaaS with enterprise reliability expectations. By investing here first, we ensure subsequent feature epics sit atop a robust, testable, and cost-effective infrastructure that aligns with your vision for modular, team-scalable delivery.

**Why:**  
- Removes bottlenecks and rework by getting the architecture right from the start.
- Accelerates onboarding for future hires and contributors.
- Ensures platform is cloud-native, resilient, and scalable for both MVP and long-term growth.
- Enables rapid, automated delivery of updates—critical for SaaS competitiveness and security patches.
- Supports multi-service decoupling for flexibility (move fast without fragile monolith).
- Foundation for compliance, observability, and operational excellence.

**What Success Looks Like:**  
- Developers can ship features rapidly and safely.
- Ops can scale, roll back, or redeploy any service independently.
- Outages, bottlenecks, or integration pains are rare and quickly traceable.
- New environments (dev, staging, prod) can be spun up or torn down in minutes.

### Feature 1.1: .NET Solution Architecture
This feature involves establishing the core architecture of the CommuniQueue platform using .NET 9. It includes setting up a structured solution with Aspire orchestration for service coordination, creating a Blazor Server app for the primary UI, implementing an API service for external integrations, and developing a background worker service for asynchronous processing. The solution architecture will establish shared libraries for common business logic and data models, ensuring code reuse and maintainability across services.

#### Story 1.1.1: Create initial .NET 9 solution structure with Aspire orchestration

**Description:**
Create a new .NET 9 solution structure that will serve as the foundation for the CommuniQueue platform. The solution should be organized using .NET Aspire for service orchestration and discovery, with a clear structure that supports the multi-service architecture described in the design document. This includes setting up the solution file, organizing project folders, and configuring initial Aspire orchestration components.

**Acceptance Criteria:**
- Solution file (.sln) created with appropriate naming and structure
- .NET Aspire host project configured to orchestrate all services
- Folder structure established for UI, API, worker services, and shared libraries
- Solution builds successfully with no errors
- Basic Aspire orchestration configuration includes service discovery setup
- README file includes basic information about solution structure
- All projects target .NET 9
- Git repository initialized with appropriate .gitignore for .NET projects

#### Story 1.1.2: Set up Blazor Server project with basic structure

**Description:**
Create the Blazor Server project that will serve as the primary user interface for CommuniQueue. This project should follow best practices for Blazor Server applications, including proper component organization, routing setup, and basic application shell with placeholder navigation. The project should integrate with the Aspire orchestration established in the previous story.

**Acceptance Criteria:**
- Blazor Server project created and integrated with the solution
- Project organized with appropriate folder structure (Pages, Shared, Components, etc.)
- Basic application shell implemented with navigation sidebar and header
- Routing configured for primary application sections
- Placeholder pages for key application areas (Dashboard, Templates, Projects, Settings)
- Authentication placeholder components added (login/logout buttons, user info display)
- Project successfully builds and runs independently
- Project registered with Aspire orchestration
- Basic error handling pages implemented (404, 500)
- Dependency injection container configured for service registration

#### Story 1.1.3: Create API service project with initial controllers

**Description:**
Implement the API service project that will provide external access to CommuniQueue functionality. This should be a separate ASP.NET Core project focused on RESTful API endpoints. The initial implementation should include controller scaffolding for key resources, basic request/response models, and integration with the Aspire orchestration.

**Acceptance Criteria:**
- API project created and integrated with the solution
- Project organized with appropriate folder structure (Controllers, Models, Services)
- Controller scaffolding for key resources (Tenants, Projects, Templates, Notifications)
- Basic versioning structure implemented (v1 namespace/routing)
- Health check endpoint implemented
- Basic API documentation framework set up (OpenAPI/Swagger)
- API project builds successfully and runs independently
- Project registered with Aspire orchestration
- Controller action stubs return appropriate status codes and placeholder responses
- Basic middleware pipeline configured (exception handling, logging)

#### Story 1.1.4: Implement background worker service project

**Description:**
Create the background worker service project that will handle asynchronous processing tasks for CommuniQueue, particularly message sending and delivery tracking. This should be a .NET Worker Service project that can run as a standalone service but also integrate with the Aspire orchestration.

**Acceptance Criteria:**
- Background worker project created and integrated with the solution
- Worker service configured to run as a hosted service
- Basic queue consumption pattern implemented (placeholder)
- Health check endpoint implemented
- Worker service registered with Aspire orchestration
- Project builds successfully and runs independently
- Logging and telemetry hooks established
- Basic retry policy infrastructure implemented
- Worker configured to handle graceful shutdown
- Documentation comments explain worker responsibilities and processing flow

#### Story 1.1.5: Create shared libraries for common business logic and models

**Description:**
Implement shared class libraries that will contain common business logic, data models, and utilities used across all CommuniQueue services. These libraries should promote code reuse and maintainability while enforcing a clear separation of concerns.

**Acceptance Criteria:**
- CommuniQueue.Shared project created with common utilities and helpers
- CommuniQueue.Data project created with entity models and database interfaces
- CommuniQueue.Core project created with business logic and service interfaces
- All entity models from the design document implemented as classes with proper annotations
- Interface definitions created for all major services
- Common exception types defined
- Basic validation rules implemented for entity models
- Shared configuration models implemented
- Libraries referenced appropriately from UI, API, and worker projects
- Documentation comments on all public classes and methods
- Unit test project structure established for shared libraries

#### Story 1.1.6: Configure service discovery and inter-service communication

**Description:**
Implement service discovery and inter-service communication patterns that allow the different components of CommuniQueue (UI, API, worker) to communicate with each other in a decoupled way. This should leverage the Aspire framework's capabilities while establishing patterns that will work in both development and production environments.

**Acceptance Criteria:**
- Service discovery configured in Aspire for all services
- Health check endpoints implemented across all services
- Service-to-service authentication mechanism established
- Circuit breaker patterns implemented for service calls
- Timeout and retry policies configured for service communication
- Local development proxy settings configured
- Service URLs configurable via environment variables/configuration
- Logging implemented for inter-service communication
- Documentation describes communication patterns and configuration
- Communication works in both local development and containerized environments

### Feature 1.2: Database Implementation
This feature covers the design and implementation of the PostgreSQL database schema that will support CommuniQueue's multi-tenant data model. It includes creating efficient table structures with GUID v7 primary keys for scalability, implementing entity models and data contexts, setting up migration systems for schema evolution, and establishing connection pooling patterns for performance. The database implementation will include appropriate indexing strategies and query optimization to ensure responsive performance as the system scales.

#### Story 1.2.1: Design and create initial Postgres schema with GUID v7 primary keys

**Description:**
Design and implement the initial PostgreSQL database schema based on the entity models in the design document. All tables should use GUID v7 as primary keys for optimal performance and scalability. The schema should support the multi-tenant architecture and establish proper relationships between entities.

**Acceptance Criteria:**
- Complete database schema diagram created and documented
- SQL scripts created for initial schema creation
- All tables use GUID v7 as primary keys
- Foreign key relationships established according to the design document
- Appropriate indexes created on common query fields
- Tenant isolation enforced at the database level
- Schema includes all core entities: Users, Tenants, Projects, Containers, Templates, etc.
- Data types optimized for PostgreSQL
- Security and partitioning strategy documented
- Schema scripts are idempotent and can be run multiple times safely

#### Story 1.2.2: Implement core entity models and data contexts

**Description:**
Create the C# entity models that map to the database schema and implement Entity Framework Core data contexts to interact with the database. The models should accurately reflect the database structure while providing a clean, object-oriented interface for application code.

**Acceptance Criteria:**
- Entity Framework Core models implemented for all database tables
- DbContext classes created with proper configuration
- Entity configurations use Fluent API for complex mappings
- Navigation properties established for relationships
- Shadow properties implemented where appropriate
- Soft delete pattern implemented for relevant entities
- Multi-tenancy filtering implemented at the context level
- Query filters established for common scenarios
- Entity validation implemented via data annotations and/or Fluent API
- Documentation comments on all entity models
- Unit tests verify proper model configuration

#### Story 1.2.3: Create database migration system and baseline migrations

**Description:**
Implement a database migration system using Entity Framework Core migrations to manage schema evolution over time. Create baseline migrations that establish the initial schema and can be applied to new environments.

**Acceptance Criteria:**
- EF Core migrations configured for the project
- Initial migration created that establishes baseline schema
- Migration scripts verified against PostgreSQL
- Migration can be applied to a clean database
- Migration can be rolled back if needed
- Documentation on how to run migrations
- Migration testing strategy established
- Migration included in CI/CD pipeline
- Migration scripts safe to run in production
- Seeding mechanism for essential reference data

#### Story 1.2.4: Set up connection pooling and resilience patterns

**Description:**
Implement connection pooling and database resilience patterns to ensure reliable database connectivity, especially under high load. This includes configuring connection pooling, implementing retry policies for transient failures, and establishing monitoring for database connections.

**Acceptance Criteria:**
- Connection pooling configured for optimal performance
- Transient fault handling implemented with retry policies
- Circuit breaker pattern implemented for database failures
- Timeout configurations optimized for different query types
- Connection string management secured for different environments
- Logging implemented for database operations and performance
- Health checks include database connectivity
- Documentation on connection management
- Performance testing verifies connection pool efficiency
- Monitoring hooks established for connection usage

#### Story 1.2.5: Implement query optimization and indexing strategy

**Description:**
Develop and implement a comprehensive query optimization and indexing strategy to ensure database performance scales with increasing data volumes. This includes analyzing common query patterns, establishing appropriate indexes, and implementing query optimizations in the data access layer.

**Acceptance Criteria:**
- Analysis of common query patterns documented
- Indexing strategy defined and implemented
- Index maintenance plan established
- Query performance baseline established
- Optimization for multi-tenant queries implemented
- Large table partitioning strategy defined
- EF Core query optimization techniques applied
- Compiled queries used for frequent operations
- Documentation of index usage and maintenance
- Performance testing validates optimization effectiveness

### Feature 1.3: Containerization
This feature focuses on containerizing all CommuniQueue services using Docker. It includes creating multi-stage Dockerfiles for each service (Blazor UI, API, and worker services) to ensure efficient, lightweight images for production. The containerization strategy will include a comprehensive docker-compose configuration for local development environments and integration with AWS ECR for container registry management in production.

#### Story 1.3.1: Create multi-stage Dockerfiles for Blazor UI service

**Description:**
Develop a multi-stage Dockerfile for the Blazor Server UI service that optimizes for both build efficiency and runtime performance. The Dockerfile should use appropriate base images, implement proper layer caching, and result in a minimal production image.

**Acceptance Criteria:**
- Multi-stage Dockerfile created for Blazor UI service
- Build stage uses appropriate SDK image
- Runtime stage uses minimal ASP.NET runtime image
- Only necessary files copied to production image
- Environment variable configuration supported
- Health check configuration included
- Docker build completes successfully
- Container starts and serves the UI correctly
- Image size optimized to be under 200MB
- Documentation on how to build and run the container
- Security scanning passes with no critical issues

#### Story 1.3.2: Create multi-stage Dockerfiles for API service

**Description:**
Develop a multi-stage Dockerfile for the API service that optimizes for both build efficiency and runtime performance. The Dockerfile should use appropriate base images, implement proper layer caching, and result in a minimal production image.

**Acceptance Criteria:**
- Multi-stage Dockerfile created for API service
- Build stage uses appropriate SDK image
- Runtime stage uses minimal ASP.NET runtime image
- Only necessary files copied to production image
- Environment variable configuration supported
- Health check configuration included
- Docker build completes successfully
- Container starts and serves the API correctly
- Image size optimized to be under 200MB
- Documentation on how to build and run the container
- Security scanning passes with no critical issues

#### Story 1.3.3: Create multi-stage Dockerfiles for worker service

**Description:**
Develop a multi-stage Dockerfile for the background worker service that optimizes for both build efficiency and runtime performance. The Dockerfile should use appropriate base images, implement proper layer caching, and result in a minimal production image.

**Acceptance Criteria:**
- Multi-stage Dockerfile created for worker service
- Build stage uses appropriate SDK image
- Runtime stage uses minimal .NET runtime image
- Only necessary files copied to production image
- Environment variable configuration supported
- Health check configuration included
- Docker build completes successfully
- Container starts and executes worker processes correctly
- Image size optimized to be under 200MB
- Documentation on how to build and run the container
- Security scanning passes with no critical issues

#### Story 1.3.4: Build docker-compose.yml for local development environment

**Description:**
Create a comprehensive docker-compose configuration that orchestrates all CommuniQueue services for local development. This should include the UI, API, and worker services, as well as dependencies like PostgreSQL and SQS-compatible queuing service.

**Acceptance Criteria:**
- docker-compose.yml file created with all required services
- PostgreSQL service configured with appropriate volume mapping
- Local queue service (like localstack) configured for SQS emulation
- All application services (UI, API, worker) configured to connect to dependencies
- Environment variables properly configured for local development
- Port mappings established for accessing services
- Health checks configured for all services
- Volume mappings set up for development hot reload where applicable
- docker-compose up successfully starts all services
- Documentation on how to use docker-compose for development
- Service dependencies correctly ordered with wait conditions

#### Story 1.3.5: Set up container registry strategy with AWS ECR

**Description:**
Establish a container registry strategy using AWS Elastic Container Registry (ECR) for storing and distributing CommuniQueue container images. This includes creating repositories, implementing tagging strategies, and establishing processes for pushing and pulling images.

**Acceptance Criteria:**
- AWS ECR repositories created for each service
- Image tagging strategy documented (versioning, environments)
- Authentication process for ECR documented
- Script or workflow created for pushing images to ECR
- Image lifecycle policies configured to manage image retention
- Security scanning enabled on ECR repositories
- Documentation on how to pull and use images from ECR
- IAM permissions configured for CI/CD pipeline access to ECR
- Process defined for promoting images between environments
- Storage cost optimization strategies implemented
- Testing verifies images can be pushed and pulled from ECR

### Feature 1.4: AWS Infrastructure Setup
This feature encompasses setting up the AWS cloud infrastructure to host the CommuniQueue platform. It includes configuring AWS App Runner for containerized service deployment, provisioning RDS PostgreSQL or Aurora Serverless for the database tier, setting up SQS queues for background message processing, and configuring S3 buckets for asset storage and logging. The infrastructure setup will also include CloudFront configuration for CDN capabilities if needed for asset delivery and caching.

#### Story 1.4.1: Configure AWS App Runner for Blazor Server deployment

**Description:**
Set up AWS App Runner service for hosting the Blazor Server UI component of CommuniQueue. This includes creating the App Runner service, configuring it to use the container images from ECR, and establishing the necessary networking and security settings.

**Acceptance Criteria:**
- AWS App Runner service created for Blazor UI
- Service configured to use container images from ECR
- Auto-scaling configuration established
- Memory and CPU allocations optimized for Blazor workload
- Health checks configured
- Custom domain configured with HTTPS
- Environment variables set for production environment
- IAM roles and policies configured with least privilege
- Monitoring and logging configured
- Deployment process documented
- Testing confirms UI is accessible and functioning

#### Story 1.4.2: Configure AWS App Runner for API service deployment

**Description:**
Set up AWS App Runner service for hosting the API component of CommuniQueue. This includes creating the App Runner service, configuring it to use the container images from ECR, and establishing the necessary networking and security settings.

**Acceptance Criteria:**
- AWS App Runner service created for API service
- Service configured to use container images from ECR
- Auto-scaling configuration established
- Memory and CPU allocations optimized for API workload
- Health checks configured
- Custom domain configured with HTTPS
- Environment variables set for production environment
- IAM roles and policies configured with least privilege
- Monitoring and logging configured
- Deployment process documented
- Testing confirms API is accessible and functioning

#### Story 1.4.3: Configure AWS App Runner for worker service deployment

**Description:**
Set up AWS App Runner service for hosting the background worker component of CommuniQueue. This includes creating the App Runner service, configuring it to use the container images from ECR, and establishing the necessary networking and security settings.

**Acceptance Criteria:**
- AWS App Runner service created for worker service
- Service configured to use container images from ECR
- Auto-scaling configuration established
- Memory and CPU allocations optimized for background processing
- Health checks configured
- Environment variables set for production environment
- IAM roles and policies configured with least privilege
- Monitoring and logging configured
- Deployment process documented
- Testing confirms worker service is functioning properly
- Alarm configured for worker service failures

#### Story 1.4.4: Provision RDS PostgreSQL or Aurora Serverless instance

**Description:**
Set up a managed PostgreSQL database using either Amazon RDS or Aurora Serverless to serve as the primary data store for CommuniQueue. This includes provisioning the database instance, configuring networking and security, and establishing backup and maintenance policies.

**Acceptance Criteria:**
- RDS PostgreSQL or Aurora Serverless instance provisioned
- Instance sized appropriately for initial workload
- Auto-scaling configured (if using Aurora Serverless)
- Private subnet placement with security groups
- Backup policy established with point-in-time recovery
- Maintenance window configured for minimal impact
- Parameter groups optimized for CommuniQueue workload
- Monitoring and alerting configured
- Encrypted storage configured
- Connection information securely stored in SSM Parameter Store
- Testing confirms database is accessible from application services

#### Story 1.4.5: Set up AWS SQS queues for background message processing

**Description:**
Implement AWS Simple Queue Service (SQS) queues to support asynchronous background processing in CommuniQueue. This includes creating the necessary queues, configuring dead-letter queues, and establishing appropriate access controls.

**Acceptance Criteria:**
- Main processing queue created for notification sending
- Dead-letter queue created for failed messages
- Message retention period configured appropriately
- Visibility timeout optimized for processing tasks
- IAM policies configured for application access
- Monitoring and alerting configured for queue depth and oldest message
- Queue encryption enabled
- Documentation on queue usage and error handling
- Testing confirms messages can be sent and received
- Integration with worker service verified
- Cost optimization strategy implemented

#### Story 1.4.6: Configure S3 buckets for log/file/asset storage

**Description:**
Set up Amazon S3 buckets to store logs, exported files, and other assets for CommuniQueue. This includes creating the buckets, configuring security and access policies, and establishing lifecycle rules for cost management.

**Acceptance Criteria:**
- S3 buckets created for logs, files, and assets
- Bucket policies configured with least privilege access
- Lifecycle rules implemented for log rotation and archiving
- Encryption configured for sensitive data
- CORS configuration established for web access where needed
- IAM policies created for application access
- Public access blocked where appropriate
- Versioning configured for critical assets
- Monitoring and logging configured
- Documentation on bucket usage and naming conventions
- Testing confirms files can be uploaded and retrieved

#### Story 1.4.7: Set up CloudFront for CDN if needed

**Description:**
Implement Amazon CloudFront content delivery network for serving static assets and optimizing content delivery for CommuniQueue users. This includes creating the CloudFront distribution, configuring origins, and establishing caching policies.

**Acceptance Criteria:**
- CloudFront distribution created
- S3 bucket configured as primary origin
- Cache behavior optimized for different content types
- SSL certificate configured for custom domain
- Origin access identity configured for S3 security
- Cache invalidation process documented
- Edge locations optimized for user geography
- CORS headers preserved through CloudFront
- Compression enabled for appropriate content types
- Monitoring and error tracking configured
- Testing confirms assets are correctly served through CDN

### Feature 1.5: CI/CD Pipeline
This feature covers establishing a robust continuous integration and deployment pipeline for CommuniQueue. It includes creating GitHub Actions workflows for automated building and testing, setting up Docker image build and publish processes, configuring AWS deployment automation, and implementing environment-specific configuration management. The CI/CD pipeline will utilize AWS SSM or Secrets Manager for secure configuration and include automated deployment strategies with rollback capabilities.

#### Story 1.5.1: Create GitHub Actions workflow for building and testing

**Description:**
Implement a GitHub Actions workflow that automates the build and testing process for the CommuniQueue codebase. The workflow should trigger on pull requests and commits to main branches, run unit and integration tests, and report test results.

**Acceptance Criteria:**
- GitHub Actions workflow created for CI process
- Workflow triggers on pull requests and main branch commits
- .NET build process configured for all projects
- Unit tests executed as part of the workflow
- Test results reported in GitHub interface
- Code coverage calculated and reported
- Static code analysis integrated (e.g., SonarQube or similar)
- Workflow fails if tests or quality gates fail
- Caching implemented for dependencies to speed up builds
- Documentation on CI process and failure remediation
- Average workflow completion time under 10 minutes

#### Story 1.5.2: Set up Docker image build and publish pipeline

**Description:**
Expand the CI/CD pipeline to include building Docker images for all CommuniQueue services and publishing them to AWS ECR. This should be automated as part of the deployment process for main branch changes.

**Acceptance Criteria:**
- GitHub Actions workflow created/updated for Docker build process
- Docker images built for UI, API, and worker services
- Images tagged with appropriate version information
- Images scanned for vulnerabilities before publishing
- Images published to AWS ECR repositories
- Authentication to ECR handled securely
- Build caching implemented for faster builds
- Multi-platform builds supported if needed
- Build process fails if image scanning finds critical issues
- Documentation on image versioning and tagging strategy
- Testing confirms published images can be pulled and run

#### Story 1.5.3: Configure AWS deployment automation

**Description:**
Implement automated deployment to AWS environments as part of the CI/CD pipeline. This includes updating App Runner services with new images, applying database migrations, and coordinating the rollout process.

**Acceptance Criteria:**
- GitHub Actions workflow created/updated for deployment
- Workflow deploys new images to App Runner services
- Database migrations applied as part of deployment
- Deployment process handles multiple environments (staging, production)
- Environment promotion strategy documented
- IAM roles created with least privilege for deployment
- Deployment logs captured and stored
- Notification system for deployment status
- Manual approval step for production deployments
- Documentation on deployment process and troubleshooting
- Testing confirms end-to-end deployment works correctly

#### Story 1.5.4: Implement environment-specific configuration management

**Description:**
Establish a system for managing environment-specific configuration settings throughout the CI/CD pipeline. This should support different configurations for development, staging, and production environments while keeping sensitive information secure.

**Acceptance Criteria:**
- Configuration management strategy documented
- Environment-specific configuration files established
- Sensitive configuration handling process defined
- Configuration variables integrated with CI/CD pipeline
- Configuration validation as part of deployment
- Configuration accessible to applications at runtime
- Configuration changes tracked and auditable
- Rollback process for configuration changes
- Documentation on adding new configuration settings
- Testing confirms configuration is correctly applied per environment
- Security review passes with no critical issues

#### Story 1.5.5: Set up AWS SSM or Secrets Manager for configuration

**Description:**
Implement AWS Systems Manager Parameter Store or Secrets Manager to securely store and manage sensitive configuration values such as connection strings, API keys, and credentials. These should be accessible to the application services while maintaining security.

**Acceptance Criteria:**
- AWS SSM Parameter Store or Secrets Manager configured
- Parameters organized with clear naming convention
- Sensitive values stored with encryption
- IAM policies configured for least privilege access
- Application services configured to retrieve parameters at startup
- Parameter change process documented
- Monitoring and audit logging enabled
- Rotation strategy for secrets documented
- Documentation on adding new parameters
- Testing confirms application can retrieve parameters
- Security review passes with no critical issues

#### Story 1.5.6: Create automated deployment strategy with rollback capability

**Description:**
Design and implement an automated deployment strategy that includes the capability to quickly roll back to previous versions if issues are detected. This should include monitoring for deployment health and automated or one-click rollback procedures.

**Acceptance Criteria:**
- Deployment strategy documented with rollback procedures
- Previous versions retained for rollback purposes
- Health checks integrated into deployment process
- Automated failure detection during deployment
- Rollback process automated or simplified to one click
- Database changes considered in rollback strategy
- Testing environment for verifying rollbacks
- Notification system for deployment failures
- Documentation on handling failed deployments
- End-to-end testing of rollback process
- Average rollback time under 10 minutes

### Feature 1.6: Development Environment
This feature focuses on creating a streamlined development environment for CommuniQueue contributors. It includes comprehensive developer onboarding documentation, local development tool configurations, debugging tools setup, implementation of service mocks for third-party dependencies during development, and sample data seeding mechanisms. The development environment will ensure parity between local and production environments through containerization.

#### Story 1.6.1: Create developer onboarding documentation

**Description:**
Develop comprehensive documentation to help new developers onboard to the CommuniQueue project. This should include environment setup instructions, architecture overview, coding standards, and development workflows.

**Acceptance Criteria:**
- Developer onboarding guide created in repository
- Environment setup instructions for all supported platforms (Windows, macOS, Linux)
- Required tools and dependencies documented
- Architecture overview with diagrams
- Coding standards and best practices documented
- Git workflow and branch strategy explained
- Pull request and code review process documented
- Documentation on running and debugging the application
- Common issues and troubleshooting guide
- Documentation reviewed by team members for clarity
- New developer can set up environment in under 2 hours using guide

#### Story 1.6.2: Set up local development tools and configurations

**Description:**
Create standardized configuration files and tooling to ensure consistent development environments across the team. This includes editor configurations, code formatting rules, and development tool settings.

**Acceptance Criteria:**
- Visual Studio/VS Code configuration files in repository
- EditorConfig file established for code formatting
- Code analysis rulesets configured
- Git hooks for pre-commit validation (optional)
- Development certificate setup process documented
- Local development environment variables template
- Recommended extensions for VS Code documented
- Debugger configurations for different services
- Documentation on tool usage and configuration
- Testing confirms configuration works across development environments
- Developer productivity tools configured and documented

#### Story 1.6.3: Configure debugging tools and environment

**Description:**
Set up debugging tools and configurations that allow developers to efficiently troubleshoot issues across the different CommuniQueue services. This should support debugging the UI, API, and worker services both individually and as an integrated system.

**Acceptance Criteria:**
- Debugging configurations for all services
- Launch settings for debugging multiple services together
- Remote debugging configuration for containerized services
- Browser debugging tools configured for Blazor
- Logging configuration optimized for development
- Environment variable templates for debugging
- Documentation on attaching debuggers to services
- Troubleshooting guide for common debugging scenarios
- Performance profiling tools configured
- Memory profiling tools configured
- Testing confirms debugger attaches and functions correctly

#### Story 1.6.4: Implement local service mocking for third-party dependencies

**Description:**
Create mock implementations or local alternatives for third-party services used by CommuniQueue (such as SendGrid, Twilio, Auth0) to enable development without depending on external services. These should provide a similar interface while being entirely local.

**Acceptance Criteria:**
- Mock services implemented for SendGrid (email)
- Mock services implemented for Twilio (SMS)
- Mock services implemented for Auth0 (authentication)
- Local alternatives configured in development environment
- Mock services accessible through docker-compose
- Mock services maintain compatibility with real service APIs
- Test data configured for mock services
- Documentation on using and extending mock services
- Interface for viewing mock service activity (sent emails, SMS, etc.)
- Testing confirms application works with mock services
- Easy switching between mock and real services

#### Story 1.6.5: Create sample data seeding for development environments

**Description:**
Implement a data seeding mechanism that populates the development database with realistic sample data for testing and development. This should include sample tenants, users, projects, templates, and other entities required for comprehensive testing.

**Acceptance Criteria:**
- Data seeding mechanism implemented
- Sample data covers all major entities
- Realistic relationships between seeded entities
- Seeding process documented
- Seeding integrated with development environment setup
- Different data sets available for different testing scenarios
- Option to reset to clean state with fresh seed data
- Performance considerations for large data sets
- Documentation on extending sample data
- Testing confirms seeded data allows full application testing
- Seed data respects entity relationships and constraints


## Epic 2: Authentication & Authorization

**Description:**  
Authentication & Authorization is the entry point of trust for CommuniQueue. This epic orchestrates the identity plane—ensuring the right users (and systems) access the right resources, at the right time, with the right permissions. It weaves together secure authentication (Auth0 SSO/JWT), extensible user management, granular RBAC, and advanced capabilities like hierarchical, cross-entity permission inheritance and superadmin impersonation. Importantly, it bakes in modern security hygiene—auditing, rate limiting, session control, and continuous monitoring—anticipating real-world abuse and compliance needs from day one. By implementing a robust, fine-grained access model, CommuniQueue can confidently serve organizations of all maturity levels, enforce need-to-know privileges, and adapt to future requirements (such as external integrations, SSO partners, or regulatory mandates).

**Why:**  
- Protects sensitive notification channels from unauthorized use.
- Provides enterprise-grade access modeling (RBAC + inheritance + deny logic).
- Supports organizational structures of any complexity (cross-tenant, nested projects).
- Enables SaaS-friendly features: SSO, scalable APIs, audit trail for compliance.
- Prevents account takeover, data leaks, or lateral privilege escalation.

**What Success Looks Like:**  
- Administrators and users only see and do what they’re entitled to—by entity, project, or tenant.
- Security incidents are rare, quickly detected, and easy to audit.
- External audits can be passed with confidence on access controls and event histories.
- Authorization logic is flexible enough to handle future expansion (e.g., SAML, delegated auth, new RBAC dimensions).

### Feature 2.1: Auth0 Integration
This feature implements secure authentication for CommuniQueue using Auth0. It includes setting up the Auth0 tenant, implementing user authentication flows in the Blazor Server application, configuring JWT validation for secure token handling, and establishing SSO capabilities for enterprise clients. The Auth0 integration will synchronize user profiles between Auth0 and the application database and implement comprehensive session management.

#### Story 2.1.1: Set up Auth0 tenant and configure application settings

**Description:**
Create and configure an Auth0 tenant specifically for CommuniQueue. Set up the necessary application registrations within Auth0, configure callback URLs, token settings, and establish the basic authentication configuration needed for secure user authentication.

**Acceptance Criteria:**
- Auth0 tenant created with appropriate naming
- Application registered in Auth0 for CommuniQueue
- Authentication callback URLs configured for all environments
- Token lifetime and refresh settings configured according to security requirements
- CORS origins configured for application domains
- Default application permissions/scopes established
- Auth0 Dashboard access restricted to authorized administrators
- Required Auth0 Rule created for adding custom claims to tokens
- Environment variables documented for Auth0 integration
- Security settings reviewed and locked down according to best practices

#### Story 2.1.2: Implement user authentication flow with Auth0 in Blazor Server

**Description:**
Implement the user authentication flow in the Blazor Server application using Auth0. This includes redirecting users to Auth0 for authentication, handling the callback, establishing authenticated sessions, and managing token storage.

**Acceptance Criteria:**
- Auth0 authentication integrated into Blazor Server application
- Login button/link implements redirect to Auth0 login page
- Callback handler properly processes Auth0 authentication response
- Authentication state persisted in Blazor Server session
- User principal and claims correctly extracted from tokens
- Route authorization attributes implemented and functional
- Authentication errors handled gracefully with user feedback
- Authentication state accessible throughout the application
- Silent token refresh implemented for session continuity
- Testing confirms end-to-end authentication flow works correctly

#### Story 2.1.3: Configure JWT validation and token handling

**Description:**
Implement secure JWT validation for tokens issued by Auth0. This includes validating token signatures, checking expiration and audience claims, and extracting user information from validated tokens for authorization purposes.

**Acceptance Criteria:**
- JWT validation middleware configured in API and Blazor services
- Token signature validation implemented using Auth0 JWKS endpoint
- Audience and issuer validation configured correctly
- Token expiration checked on each request
- Required claims validated according to application needs
- JWT validation errors logged with appropriate detail
- Performance optimization for token validation (e.g., caching JWKS)
- Token extraction from Authorization header implemented correctly
- Documentation on token structure and required claims
- Security review confirms token validation is robust

#### Story 2.1.4: Set up SSO capabilities and identity providers

**Description:**
Configure single sign-on capabilities in Auth0 to allow enterprise customers to use their existing identity providers. This includes setting up social connections and enterprise connections in Auth0 and ensuring the application handles various authentication sources correctly.

**Acceptance Criteria:**
- Google authentication connection configured in Auth0
- Microsoft authentication connection configured in Auth0
- SAML connection template configured for enterprise customers
- Auth0 Universal Login customized with CommuniQueue branding
- Connection selection screen configured appropriately
- User profile mapping configured for each identity provider
- Testing confirms SSO works with each configured provider
- Documentation created for adding new enterprise identity providers
- User experience consistent regardless of authentication method
- Process documented for enterprise customer SSO onboarding

#### Story 2.1.5: Create user profile synchronization between Auth0 and application database

**Description:**
Implement a system to synchronize user profile information between Auth0 and the CommuniQueue database. This includes creating or updating user records in the application database when users authenticate, and handling profile updates.

**Acceptance Criteria:**
- User profile synchronization triggered after successful authentication
- New users in Auth0 automatically provisioned in application database
- Critical user attributes (email, name) synchronized from Auth0
- Profile picture/avatar synchronized when available
- Email verification status synchronized from Auth0
- Synchronization occurs on login and token refresh
- Error handling for failed synchronization with retry mechanism
- Logging of synchronization activities for audit purposes
- Profile update from application reflected in local database only
- Testing confirms user data consistency between Auth0 and application

#### Story 2.1.6: Implement logout and session management

**Description:**
Implement comprehensive logout and session management functionality. This includes both local session termination and Auth0 session logout, as well as session timeout handling and explicit user-initiated logout.

**Acceptance Criteria:**
- Logout button/link implemented in UI
- Local application session terminated on logout
- Redirect to Auth0 logout endpoint with correct return URL
- Auth0 session terminated on logout
- Session timeout detection and handling
- Automatic redirect to login page after session expiration
- User notified of impending session expiration with option to extend
- Secure removal of all authentication tokens on logout
- Protection against CSRF in logout process
- Testing confirms all authentication states are properly cleared on logout

### Feature 2.2: User Management
This feature establishes the core user management capabilities of CommuniQueue. It includes implementing the User entity model and database schema, creating user provisioning logic that triggers on first login via Auth0, building profile management interfaces, and implementing user activation/deactivation functionality. User management will also include SuperAdmin designation for system administrators with global access permissions.

#### Story 2.2.1: Create User entity model and database implementation

**Description:**
Design and implement the User entity model and corresponding database schema. This should include all necessary user attributes, relationships to other entities, and database indexes for efficient queries.

**Acceptance Criteria:**
- User entity class implemented according to design document
- Database migration created for User table with appropriate schema
- GUID v7 primary key implemented for User entities
- External ID field included to map to Auth0 user ID
- Email, FirstName, LastName, and other profile fields included
- Created/Updated timestamp fields implemented
- IsActive flag implemented for account status
- IsSuperAdmin flag implemented for system administrators
- Appropriate indexes created for common query fields
- User entity validated with database integration tests

#### Story 2.2.2: Implement user creation upon first login (Auth0 hook)

**Description:**
Implement the logic to automatically create a new user record in the CommuniQueue database when a user first logs in via Auth0. This should ensure that user records are created on demand without requiring manual provisioning.

**Acceptance Criteria:**
- Authentication handler checks for existing user record
- New user record created when authenticated user doesn't exist in database
- User attributes populated from Auth0 claims
- Default user preferences/settings established for new users
- Error handling for failed user creation with appropriate feedback
- Logging of new user creation for audit purposes
- Race condition handling for concurrent first-time logins
- Transaction management for atomic user creation
- Testing confirms new users are properly created on first login
- Performance testing confirms minimal impact on login flow

#### Story 2.2.3: Build user profile management UI

**Description:**
Create the user interface components for users to view and edit their profile information. This should include forms for updating personal information, viewing account status, and managing preferences.

**Acceptance Criteria:**
- User profile page implemented in Blazor UI
- Form for editing name, display preferences, and other profile fields
- Read-only display of email (managed by Auth0)
- Profile picture upload or change functionality
- Form validation with appropriate error messages
- Submit button with loading indicator during updates
- Success/failure notifications for profile updates
- Changes immediately reflected in UI after successful update
- Profile data loaded with efficient queries
- Mobile-responsive design for profile management
- Accessibility compliance for all profile management components

#### Story 2.2.4: Create user activation/deactivation functionality

**Description:**
Implement the ability for administrators to activate or deactivate user accounts. Deactivated users should be prevented from accessing the system while preserving their data and relationships.

**Acceptance Criteria:**
- User list view with activation status for administrators
- Toggle control for activating/deactivating users
- Confirmation dialog before status changes
- Backend API endpoint for changing user activation status
- Authentication middleware checks for deactivated status
- Deactivated users denied access with appropriate message
- Logging of activation/deactivation events
- Notification to user when their account is deactivated
- Testing confirms deactivated users cannot authenticate
- User data and relationships preserved when deactivated
- Reactivation restores full access to previous data

#### Story 2.2.5: Implement SuperAdmin designation and management

**Description:**
Implement the SuperAdmin role, which provides unrestricted access to all system functionality. This includes the ability to designate and manage SuperAdmins and implementing the special access privileges associated with this role.

**Acceptance Criteria:**
- SuperAdmin flag in User entity utilized for access control
- UI for existing SuperAdmins to designate new SuperAdmins
- Confirmation and security measures for SuperAdmin designation
- SuperAdmin status check in authorization middleware
- SuperAdmin access override implemented for all protected resources
- SuperAdmin management restricted to existing SuperAdmins
- Logging of all SuperAdmin designation changes
- Initial SuperAdmin established during system provisioning
- Cannot remove last SuperAdmin from system
- Notification/audit when SuperAdmin access is used
- Testing confirms SuperAdmins can access all system functionality

### Feature 2.3: RBAC Framework
This feature implements the role-based access control framework that governs permissions throughout CommuniQueue. It includes creating role models for the predefined roles (Owner, Admin, Member, Readonly), implementing the TenantUserMap entity for associating users with tenants, and building the AccessControlEntry entity for entity-level permission overrides. The RBAC framework will include UI components for role management and middleware for permission validation on API requests.

#### Story 2.3.1: Implement role models (Owner, Admin, Member, Readonly)

**Description:**
Implement the role model system that defines the predefined roles (Owner, Admin, Member, Readonly) and their associated permissions. This includes creating the necessary enumerations, constants, and permission definitions.

**Acceptance Criteria:**
- RoleType enumeration implemented with all required roles
- Permission constants defined for all system actions
- Role-permission mapping defined to specify which roles have which permissions
- Role hierarchy established (Owner > Admin > Member > Readonly)
- Default role established for new users (Readonly)
- Documentation of each role's capabilities and restrictions
- Unit tests verify correct permission mapping
- Extension mechanism for future role/permission additions
- System prevents deletion of Owner role if it's the last one
- Default permissions automatically assigned based on role

#### Story 2.3.2: Create TenantUserMap entity and relationships

**Description:**
Implement the TenantUserMap entity that associates users with tenants and defines their role within each tenant. This entity is the core of the multi-tenant RBAC system and establishes which users have access to which tenants.

**Acceptance Criteria:**
- TenantUserMap entity class implemented according to design document
- Database migration created for TenantUserMap table
- Foreign key relationships established to User and Tenant entities
- RoleType field implemented to store user's role within tenant
- Status field implemented to track membership status
- Created/Updated timestamp fields implemented
- Composite uniqueness constraint on UserId+TenantId
- Appropriate indexes created for common query patterns
- Database integration tests verify relationships
- Repository methods implemented for common access patterns
- Cascade delete behavior configured appropriately

#### Story 2.3.3: Build AccessControlEntry entity for entity-level permissions

**Description:**
Implement the AccessControlEntry entity that allows for fine-grained permission overrides at the project, container, and template levels. This entity stores exceptions to the normal role-based permissions that are inherited through the hierarchy.

**Acceptance Criteria:**
- AccessControlEntry entity class implemented according to design document
- Database migration created for AccessControlEntry table
- EntityType enumeration implemented (Tenant, Project, Container, Template)
- Foreign key relationship to User entity
- EntityId field to reference the target entity
- RoleType field to store the overridden role/permission
- Created/Updated timestamp fields implemented
- Appropriate indexes for efficient permission lookups
- Uniqueness constraint on UserId+EntityType+EntityId
- Repository methods for querying user's permissions
- Database integration tests verify functionality

#### Story 2.3.4: Implement role assignment and management UI

**Description:**
Create the user interface components for tenant owners and administrators to manage user roles within their tenants. This includes assigning roles, removing users, and viewing current role assignments.

**Acceptance Criteria:**
- User management page implemented for tenant administrators
- List view of users with their roles within the tenant
- Role selection dropdown for changing user roles
- Add user interface with email input and role selection
- Remove user functionality with confirmation
- Error handling for invalid email addresses or users not found
- Success/error notifications for role management actions
- Search and filtering capabilities for user list
- Pagination for tenants with many users
- Permission checks to ensure only authorized users can manage roles
- Mobile-responsive design for all role management components

#### Story 2.3.5: Create permission validation middleware for APIs

**Description:**
Implement middleware for API requests that validates the current user has the necessary permissions to perform the requested action. This middleware should check role-based permissions as well as explicit AccessControlEntry overrides.

**Acceptance Criteria:**
- Permission validation middleware implemented for API controllers
- Role-based permission checks implemented
- Entity-level permission override checks implemented
- Tenant ownership/membership validation
- SuperAdmin bypass for permission checks
- Permission attributes for decorating controller actions
- Efficient caching of permission results to minimize database queries
- Detailed access denied error responses
- Logging of permission denied events
- Unit tests for permission validation logic
- Integration tests with different user roles and scenarios

#### Story 2.3.6: Build UI permission controls and conditional rendering

**Description:**
Implement UI components and directives that conditionally render elements based on the current user's permissions. This ensures users only see UI elements for actions they are authorized to perform.

**Acceptance Criteria:**
- Permission service implemented for UI authorization checks
- Blazor authorization components created for conditional rendering
- Button/link visibility controlled by permission checks
- Navigation items filtered based on user permissions
- Page access restricted based on user permissions
- Edit/delete controls only shown to authorized users
- Permission caching implemented for UI performance
- Permission refreshing on role/access changes
- Graceful handling of permission denied scenarios
- Consistent user experience across all permission-controlled areas
- Accessibility maintained for conditionally rendered elements

### Feature 2.4: Access Inheritance
This feature implements the hierarchical permission inheritance model that flows from tenants down through projects, containers, and templates. It includes logic for permission propagation from parent to child entities, mechanisms for overriding permissions at specific levels, implementing "Deny" logic that blocks access regardless of inherited permissions, and building efficient permission caching. The access inheritance system will include UI components for visualizing effective permissions across the hierarchy.

#### Story 2.4.1: Implement inheritance logic from tenant to nested entities

**Description:**
Implement the core logic for permission inheritance from tenants down through the hierarchy to projects, containers, and templates. This establishes the default behavior where permissions granted at a higher level flow down to child entities.

**Acceptance Criteria:**
- Inheritance algorithm implemented for permission propagation
- Tenant permissions flow down to all projects within tenant
- Project permissions flow down to all containers within project
- Container permissions flow down to all templates within container
- Role hierarchy respected in permission inheritance
- Efficient querying to determine inherited permissions
- Unit tests verify correct permission inheritance
- Performance considerations for deep hierarchies
- Documentation of inheritance rules and edge cases
- Integration tests across multiple entity levels
- Logging for troubleshooting permission inheritance issues

#### Story 2.4.2: Create override system for entity-specific permissions

**Description:**
Implement the system that allows permissions to be explicitly set at specific levels in the hierarchy, overriding the inherited permissions. This gives administrators fine-grained control over access to specific projects, containers, or templates.

**Acceptance Criteria:**
- Override system using AccessControlEntry entities
- API endpoints for setting entity-specific permissions
- Override permissions take precedence over inherited permissions
- Permission query system checks for overrides first
- Transaction support for permission changes
- Validation to prevent invalid permission combinations
- Logging of permission override changes
- Unit tests for permission override logic
- Database queries optimized for permission lookup
- Documentation of override behavior and best practices
- Testing confirms overrides work at all entity levels

#### Story 2.4.3: Implement "Deny" logic to block access regardless of inheritance

**Description:**
Implement the "Deny" permission type that explicitly blocks access to an entity and its children, regardless of permissions inherited from higher levels. This provides a way to specifically exclude users from accessing certain branches of the hierarchy.

**Acceptance Criteria:**
- Deny permission type implemented in RoleType enum
- Deny permissions override any inherited "Allow" permissions
- Deny permissions propagate down to all child entities
- Permission checking logic respects Deny as highest priority
- API endpoints for setting Deny permissions
- UI for applying Deny permissions with appropriate warnings
- Logging of Deny permission applications
- SuperAdmin exemption from Deny permissions
- Unit tests for Deny permission logic
- Integration tests across hierarchy with mixed permissions
- Documentation of Deny behavior and use cases

#### Story 2.4.4: Build efficient permission caching and evaluation

**Description:**
Implement an efficient caching and evaluation system for permissions to minimize database queries and improve application performance. This should cache permission results while ensuring changes to permissions are promptly reflected.

**Acceptance Criteria:**
- Permission caching strategy implemented
- Cache invalidation on permission changes
- User-specific permission cache with appropriate lifecycle
- Memory usage optimized for large user bases
- Cache hit ratio monitoring
- Performance metrics for permission checks
- Cache warm-up strategy for common permission checks
- Distributed cache support for multi-instance deployment
- Fallback to database on cache miss
- Unit tests for cache behavior
- Cache configuration options for different environments

#### Story 2.4.5: Create UI for viewing effective permissions across hierarchy

**Description:**
Implement a user interface that allows administrators to view the effective permissions for users across the entity hierarchy. This helps in understanding and troubleshooting permission issues by showing inherited, overridden, and denied permissions in a clear way.

**Acceptance Criteria:**
- Permission viewer UI component implemented
- Hierarchical display of entities and permissions
- Visual indicators for inherited vs. explicit permissions
- Visual indicators for Deny permissions
- User selector for viewing different users' permissions
- Entity selector for focusing on specific hierarchy branches
- Explanation of how effective permissions were determined
- Print/export functionality for permission reports
- Accessibility compliance for permission visualization
- Mobile-responsive design
- Testing confirms accuracy of displayed permissions

### Feature 2.5: API Authentication
This feature establishes secure authentication for the CommuniQueue API for machine-to-machine integrations. It includes implementing API key generation and management, secure storage for key hashes, authentication middleware for API requests, scoped permissions for granular API access control, and key rotation/expiration handling. The API authentication system will include UI components for API key management within the application.

#### Story 2.5.1: Implement API key generation and management

**Description:**
Implement the system for generating and managing API keys that can be used for machine-to-machine authentication with the CommuniQueue API. This includes key generation, storage, and the core management functionality.

**Acceptance Criteria:**
- Secure API key generation using cryptographically strong methods
- API key format follows best practices (length, character set)
- API key prefix/identifier for easy reference
- Service for creating, listing, and revoking API keys
- Each API key associated with a specific tenant
- Key metadata including creation date, description, last used
- Repository pattern for API key management
- Unit tests for key generation and management
- Logging of key management operations
- Rate limiting for key generation operations
- Documentation of API key management best practices

#### Story 2.5.2: Create secure storage for API key hashes

**Description:**
Implement secure storage for API keys, storing only hashed versions of the keys in the database to prevent exposure in case of a data breach. This includes implementing the TenantApiKey entity and associated database schema.

**Acceptance Criteria:**
- TenantApiKey entity class implemented according to design document
- Database migration created for TenantApiKey table
- Only key hashes stored in database (never raw keys)
- Strong hashing algorithm used (e.g., bcrypt, Argon2)
- Foreign key relationship to Tenant entity
- Key prefix stored for reference without exposing full key
- Created/Updated timestamp fields implemented
- Start/End date fields for key validity period
- IsExpired flag for quick filtering
- Appropriate indexes for efficient queries
- Integration tests verify secure storage behavior

#### Story 2.5.3: Build API key validation middleware

**Description:**
Implement middleware for the API that validates API key authentication. This middleware should extract the API key from requests, validate it against stored hashes, and establish the authenticated tenant context for the request.

**Acceptance Criteria:**
- Middleware extracts API key from Authorization header
- API key validation against stored hashes
- Check for key expiration and validity
- Tenant context established for authenticated requests
- Performance optimized with appropriate caching
- Detailed error responses for invalid or expired keys
- Update of last used timestamp on successful validation
- Logging of failed authentication attempts
- Unit tests for middleware behavior
- Integration tests with valid and invalid keys
- Documentation of API key usage for clients

#### Story 2.5.4: Implement scoped permissions for API keys

**Description:**
Implement a permission scoping system for API keys that allows keys to be restricted to specific API operations or resources. This provides granular control over what each API key can access.

**Acceptance Criteria:**
- Scope definition system for API operations
- Storage of allowed scopes with each API key
- Scope validation during API request processing
- UI for selecting scopes when generating keys
- Default scope templates for common use cases
- Documentation of available scopes
- Scope inheritance and hierarchy (if applicable)
- Validation to prevent scope escalation
- Unit tests for scope validation logic
- Integration tests with different scope combinations
- Logging of scope validation failures

#### Story 2.5.5: Create API key rotation and expiration handling

**Description:**
Implement functionality for API key rotation and expiration. This includes the ability to set expiration dates for keys, automatic expiration of unused keys, and a process for rotating keys without service disruption.

**Acceptance Criteria:**
- Expiration date setting for API keys
- Automatic expiration check during validation
- Unused key expiration based on last used date
- Key rotation workflow (create new, transition, revoke old)
- Notification system for upcoming key expirations
- Grace period option for expired keys
- Batch operations for key management
- Reporting on key usage and expiration status
- Unit tests for expiration logic
- Integration tests for key rotation process
- Documentation of key rotation best practices

#### Story 2.5.6: Build API key management UI

**Description:**
Create the user interface components for managing API keys within the CommuniQueue application. This includes views for generating, listing, and revoking keys, as well as setting permissions and expiration dates.

**Acceptance Criteria:**
- API key management page in application UI
- List view of existing API keys with metadata
- Create new key form with description and scope selection
- One-time display of newly generated keys with copy function
- Revoke key functionality with confirmation
- Filtering and searching of API keys
- Key expiration date setting and editing
- Visual indicators for key status (active, expired, etc.)
- Permission checks to ensure only authorized users can manage keys
- Mobile-responsive design
- Accessibility compliance for all components

### Feature 2.6: SuperAdmin Capabilities
This feature implements special capabilities for system administrators. It includes creating the SuperAdmin role with unrestricted global access, user impersonation functionality for troubleshooting and support, UI indicators during impersonation sessions, comprehensive audit logging of all SuperAdmin actions, and specialized administration dashboards and tools only available to SuperAdmins.

#### Story 2.6.1: Implement SuperAdmin role with global access

**Description:**
Implement the SuperAdmin role which grants unrestricted access to all system functionality regardless of normal tenant and entity permissions. This establishes the highest level of system access for platform administrators.

**Acceptance Criteria:**
- SuperAdmin flag in User entity utilized for access control
- Authorization middleware checks for SuperAdmin status
- SuperAdmin access bypasses normal permission checks
- SuperAdmin access works across all tenants
- SuperAdmin can access all projects, containers, and templates
- API endpoints honor SuperAdmin status
- UI navigation shows all entities to SuperAdmins
- SuperAdmin status cannot be self-assigned
- Unit tests for SuperAdmin authorization logic
- Integration tests verify SuperAdmin access across system
- Documentation of SuperAdmin capabilities and responsibilities

#### Story 2.6.2: Create user impersonation functionality

**Description:**
Implement functionality for SuperAdmins to impersonate other users for troubleshooting and support purposes. This allows SuperAdmins to see the application exactly as another user would see it, with their permissions and settings.

**Acceptance Criteria:**
- Impersonation service implemented for switching user context
- Impersonation restricted to SuperAdmins only
- Original SuperAdmin identity preserved during impersonation
- API endpoint for starting impersonation session
- User selector UI for choosing user to impersonate
- Validation to prevent impersonating another SuperAdmin
- Session marked as impersonation for audit purposes
- Ability to end impersonation and return to SuperAdmin identity
- Impersonation state persisted appropriately during session
- Unit tests for impersonation logic
- Integration tests for impersonation workflow

#### Story 2.6.3: Build impersonation UI indicators and controls

**Description:**
Create UI components that clearly indicate when a SuperAdmin is impersonating another user, and provide controls for ending impersonation. This ensures transparency and prevents confusion during support sessions.

**Acceptance Criteria:**
- Prominent visual indicator displayed during impersonation
- Banner showing both impersonated user and actual SuperAdmin
- Color-coded UI elements during impersonation
- End impersonation button always visible during session
- Impersonation status shown in user dropdown/profile menu
- All pages display impersonation indicator
- Impersonation indicator designed to be noticeable but not intrusive
- Mobile-responsive design for impersonation controls
- Keyboard shortcut for ending impersonation
- Accessibility compliance for impersonation indicators
- Testing confirms indicators visible across all application areas

#### Story 2.6.4: Implement comprehensive audit logging for SuperAdmin actions

**Description:**
Implement detailed audit logging for all actions performed by SuperAdmins, especially those that involve elevated privileges or impersonation. This ensures accountability and provides a trail for security review.

**Acceptance Criteria:**
- Comprehensive logging of all SuperAdmin actions
- Special flagging of actions performed during impersonation
- Logging includes both real identity and impersonated identity
- Detailed context captured for each action
- Timestamp, IP address, and session information included
- Log storage separated from regular application logs
- Log retention policy implemented for audit logs
- SuperAdmin action logs not purgeable by regular admins
- Filtering and search capabilities for audit logs
- Export functionality for audit logs
- Testing confirms all SuperAdmin actions are properly logged

#### Story 2.6.5: Create superadmin-specific dashboard and tools

**Description:**
Implement specialized dashboard and administrative tools available only to SuperAdmins. These tools provide system-wide insights and management capabilities beyond what regular tenant administrators can access.

**Acceptance Criteria:**
- SuperAdmin dashboard implemented with system-wide metrics
- Tenant listing and management across entire system
- User management across all tenants
- System health monitoring and diagnostics
- Queue monitoring for background processing
- Error and exception monitoring
- Database statistics and performance metrics
- Security event monitoring
- Configuration management interface
- System-wide search capabilities
- Documentation of SuperAdmin tools and their usage

### Feature 2.7: Authentication Audit & Security
This feature establishes comprehensive security monitoring for authentication activities. It includes implementing detailed event logging for authentication events, notification mechanisms for access changes, security monitoring tools with alerting capabilities, rate limiting to prevent brute force attacks, and session management features including forced logout capabilities for security incidents.

#### Story 2.7.1: Implement comprehensive auth event logging

**Description:**
Implement detailed logging for all authentication-related events, including login attempts, logout, password changes, and permission changes. This provides a comprehensive audit trail for security monitoring and compliance.

**Acceptance Criteria:**
- Logging implemented for all authentication events
- Login attempts (successful and failed) logged
- Logout events logged
- Permission and role changes logged
- API key usage logged
- Impersonation events logged
- Consistent log format with appropriate detail level
- User identifier included in all auth logs
- IP address and user agent information captured
- Timestamp in consistent format
- Log storage configured with appropriate retention
- Integration with central logging system

#### Story 2.7.2: Create access change notifications for users

**Description:**
Implement a notification system that alerts users when changes are made to their access permissions or account status. This ensures transparency and helps detect unauthorized permission changes quickly.

**Acceptance Criteria:**
- Notification sent when user's role changes in a tenant
- Notification sent when user is added to or removed from a tenant
- Notification sent when user's account is activated or deactivated
- Email notifications implemented as primary channel
- In-app notifications shown on next login
- Notification includes details of what changed and by whom
- Notifications for permission changes at project/container level
- Option to disable specific notification types
- Notification history viewable by user
- Notification content is clear and actionable
- Testing confirms notifications sent for all relevant changes

#### Story 2.7.3: Build security monitoring and alerting

**Description:**
Implement a security monitoring system that watches for suspicious authentication activities and alerts administrators. This includes detecting unusual login patterns, multiple failed attempts, and other security anomalies.

**Acceptance Criteria:**
- Monitoring system for authentication anomalies
- Detection of multiple failed login attempts
- Alerting for unusual login locations or times
- Notification mechanism for security alerts
- Dashboard for security monitoring
- Configurable alert thresholds
- Alert aggregation to prevent notification fatigue
- Historical view of security events
- Filtering and search capabilities for security events
- Export functionality for security reports
- Integration with external SIEM systems (if applicable)

#### Story 2.7.4: Implement rate limiting for authentication attempts

**Description:**
Implement rate limiting for authentication endpoints to prevent brute force attacks. This includes limiting the number of failed login attempts and implementing progressive backoff for repeated failures.

**Acceptance Criteria:**
- Rate limiting implemented for login endpoints
- Configurable threshold for failed attempts
- Progressive backoff for repeated failures
- IP-based rate limiting
- User-based rate limiting
- Clear error messages when rate limits are exceeded
- Logging of rate limit events
- Monitoring dashboard for rate limit events
- Whitelist capability for trusted IPs
- Manual reset option for locked accounts
- Testing confirms rate limits prevent brute force attempts

#### Story 2.7.5: Create session management and forced logout capabilities

**Description:**
Implement comprehensive session management including the ability to force logout of users for security incidents. This gives administrators the tools to immediately revoke access when security issues are detected.

**Acceptance Criteria:**
- Session tracking for all authenticated users
- Admin interface showing active user sessions
- Forced logout capability for individual sessions
- Batch logout capability for multiple sessions
- Tenant-wide logout capability for security incidents
- System-wide logout for critical security events
- Session timeout configuration
- Automatic session expiration for inactive users
- Notification to users about forced logout
- Logging of all session management actions
- Testing confirms forced logout immediately terminates access

## Epic 3: Multi-tenancy Framework

**Description:**  
Multi-Tenancy Framework is the organizational and isolation layer of CommuniQueue. This epic governs how multiple, fully partitioned organizations (tenants) safely coexist within the same SaaS infrastructure. It defines tenant provisioning, user mapping, invitation flows, and tenant-level administration—ensuring robust, data-level isolation and tailored policy enforcement (such as per-tenant limits and subscription plans). A resilient multi-tenancy design enables CommuniQueue to scale economically, serve both SMBs and large enterprises, and offer seamless “one account, many orgs” UX patterns. The framework addresses user and data isolation, onboarding automation, and policy inheritance, which are fundamental in enabling upgrades, enterprise sales, and compliance.

**Why:**  
- Allows secure scaling to hundreds (or thousands) of customer orgs on a shared platform.
- Guarantees strong separation to prevent accidental or malicious data cross-over.
- Supports multi-org users (consultants, agencies, parent orgs).
- Unlocks feature packaging and pricing flexibility (per-tenant plans, quotas, entitlements).
- Simplifies onboarding and makes user-driven growth (invite, self-service creation) possible.

**What Success Looks Like:**  
- Tenants are fully isolated—no cross-tenant data or event leakage.
- Org-level configuration (branding, access, quotas) is frictionless.
- Tenant-admin workflows (invitation, role mapping, metadata management) are smooth and scalable.
- The product’s business model (per-tenant billing/limits/support) is directly enabled by the architecture.

### Feature 3.1: Tenant Provisioning
This feature implements the tenant provisioning system for CommuniQueue's multi-tenant architecture. It includes creating the Tenant entity model and database schema, implementing automatic tenant creation during user signup, enforcing tenant limits per user (up to 6 by default), tenant activation/deactivation functionality, and tenant metadata management including name and description fields.

#### Story 3.1.1: Implement Tenant entity model and database schema

**Description:**
Design and implement the Tenant entity model and corresponding database schema according to the design document. This entity is the foundation of the multi-tenant architecture and represents an organization or workspace within CommuniQueue.

**Acceptance Criteria:**
- Tenant entity class implemented according to design document specifications
- Database migration created for Tenant table with appropriate schema
- GUID v7 primary key implemented for Tenant entities
- Name and Description fields included with appropriate validation
- OwnerUserId field implemented to track tenant ownership
- Status field implemented for tenant activation status
- Created/Updated timestamp fields implemented
- Appropriate indexes created for common query fields
- Foreign key relationship to User table for ownership
- Integration tests verify proper database schema creation
- Repository pattern implemented for Tenant entity access

#### Story 3.1.2: Create automatic tenant creation on user signup

**Description:**
Implement functionality to automatically create a default tenant for new users during the signup process. This ensures that every user has at least one tenant workspace to begin using the system immediately after registration.

**Acceptance Criteria:**
- Automatic tenant creation triggered after successful user registration
- Default tenant named according to user's name or email pattern
- New tenant ownership assigned to the registering user
- Owner role automatically assigned in TenantUserMap
- Tenant created with active status by default
- Welcome message or onboarding guidance for new tenant
- Error handling for failed tenant creation
- Logging of tenant creation for audit purposes
- Transaction management for atomic user and tenant creation
- Performance testing to ensure minimal impact on signup flow
- Testing confirms new users always have one tenant available

#### Story 3.1.3: Build tenant limits enforcement (up to 6 per user)

**Description:**
Implement the system to enforce the maximum number of tenants a user can create or own. By default, users are limited to 6 tenants, with the ability to request more through a justification process.

**Acceptance Criteria:**
- Tenant count validation before allowing new tenant creation
- UI indication of current tenant count and limit
- Prevention of tenant creation when limit reached
- Error messages explaining the limit when exceeded
- Request mechanism for increasing tenant limit
- Admin interface for reviewing and approving limit increase requests
- Configuration option for changing the default limit
- SuperAdmin exemption from tenant limits
- Logging of limit increase requests and approvals
- Testing confirms limit enforcement works correctly
- Testing confirms limit increase requests work correctly

#### Story 3.1.4: Implement tenant activation/deactivation functionality

**Description:**
Create functionality to activate or deactivate tenants, allowing administrators to temporarily disable access to a tenant without deleting its data. Deactivated tenants should be inaccessible to all users except SuperAdmins.

**Acceptance Criteria:**
- Tenant status field utilized for activation state
- API endpoint for changing tenant activation status
- Admin UI for activating/deactivating tenants
- Confirmation dialog before changing activation status
- Authorization checks to ensure only owners/admins can change status
- Middleware checks tenant activation status on all requests
- Deactivated tenants hidden from regular navigation
- Clear user feedback when attempting to access deactivated tenant
- Logging of activation status changes
- Email notification to tenant members when status changes
- Testing confirms deactivated tenants cannot be accessed
- SuperAdmin override to access deactivated tenants

#### Story 3.1.5: Create tenant metadata management (name, description)

**Description:**
Implement functionality for managing tenant metadata, such as name, description, and other properties. This allows tenants to be properly labeled and organized according to user preferences.

**Acceptance Criteria:**
- UI form for editing tenant name and description
- API endpoint for updating tenant metadata
- Validation rules for tenant name (required, max length)
- Validation rules for description (optional, max length)
- Authorization checks to ensure only owners/admins can edit metadata
- Real-time UI updates after successful metadata changes
- Tenant name displayed consistently throughout application
- Search functionality includes tenant metadata
- Audit logging of metadata changes
- Testing confirms metadata updates work correctly
- Testing confirms validation rules are properly enforced

### Feature 3.2: Tenant User Management
This feature establishes the relationship between users and tenants. It includes implementing the TenantUserMap relationships in the database, tenant ownership designation and transfer capabilities, UI components for viewing and managing tenant members, role assignment mechanisms specific to tenant membership, and tenant membership status tracking.

#### Story 3.2.1: Build TenantUserMap relationships and database schema

**Description:**
Implement the TenantUserMap entity and database schema to establish the many-to-many relationship between users and tenants. This entity stores each user's role and status within each tenant they have access to.

**Acceptance Criteria:**
- TenantUserMap entity class implemented according to design document
- Database migration created for TenantUserMap table
- Foreign key relationships to User and Tenant tables
- RoleType field implemented to store user's role within tenant
- TenantMembershipStatusType field implemented for status tracking
- Created/Updated timestamp fields implemented
- Composite uniqueness constraint on UserId+TenantId
- Appropriate indexes for efficient querying
- Cascade behavior appropriately configured
- Repository pattern implemented for TenantUserMap access
- Integration tests verify relationship integrity

#### Story 3.2.2: Implement tenant ownership and transfer capabilities

**Description:**
Create functionality for transferring tenant ownership from one user to another. This ensures continuity when organizational responsibilities change and allows for proper administration succession.

**Acceptance Criteria:**
- Ownership transfer UI for tenant owners
- API endpoint for transferring tenant ownership
- User selector for choosing new owner
- Confirmation dialog with implications explained
- Validation to ensure new owner is an existing tenant member
- Automatic role updates: previous owner to Admin, new user to Owner
- OwnerUserId field updated in Tenant entity
- Email notifications to both previous and new owners
- Transfer shown in audit log with before/after details
- Validation prevents removing last owner from tenant
- Testing confirms ownership transfer correctly updates roles
- Testing confirms tenant ownership field is properly updated

#### Story 3.2.3: Create tenant member listing and management UI

**Description:**
Implement the user interface for viewing, searching, and managing tenant members. This provides administrators with a central place to see who has access to their tenant and manage their roles.

**Acceptance Criteria:**
- Member listing page with user details and roles
- Search and filtering capabilities for member list
- Pagination for tenants with many members
- Sort options (name, role, join date, etc.)
- Visual indicators for member status
- Quick actions for common role changes
- Remove member functionality with confirmation
- Performance optimized for large member lists
- Mobile-responsive design
- Accessibility compliance for all UI elements
- Testing confirms all member management functions work correctly
- Authorization ensures only permitted users can view/manage members

#### Story 3.2.4: Build tenant-specific user role assignment

**Description:**
Implement functionality for assigning and changing user roles within specific tenants. This allows tenant administrators to control the level of access each member has within their tenant.

**Acceptance Criteria:**
- Role assignment UI within member management
- Role dropdown with available options (Owner, Admin, Member, Readonly)
- API endpoint for updating user roles
- Authorization checks to ensure only owners/admins can change roles
- Validation prevents removing last owner
- Role change confirmation dialog
- Real-time UI updates after role changes
- Audit logging of role changes
- Email notification to user when their role changes
- Testing confirms role changes are immediately effective
- Testing confirms proper authorization checks are enforced
- Integration with permission system for immediate access updates

#### Story 3.2.5: Implement tenant membership status types

**Description:**
Implement a status tracking system for tenant memberships to handle various states such as active, pending, suspended, or declined. This allows for proper lifecycle management of tenant memberships.

**Acceptance Criteria:**
- TenantMembershipStatusType enum implemented (Active, Pending, Suspended, Declined)
- Status field utilized in TenantUserMap entity
- Status transitions properly enforced
- Status changes logged for audit purposes
- UI indicators for different membership statuses
- Filtering options based on membership status
- API endpoints for changing membership status
- Authorization checks for status change operations
- Email notifications for status changes
- Testing confirms status transitions work correctly
- Testing confirms access is properly controlled based on status

### Feature 3.3: Tenant Invitation System
This feature implements the functionality for inviting users to join tenants. It includes creating invitation generation mechanisms, email notification delivery for invitations, implementing the workflow for accepting invitations, UI components for managing outstanding invitations, and handling invitation expiration to maintain security.

#### Story 3.3.1: Create invitation generation mechanism

**Description:**
Implement the system for generating and tracking invitations to join a tenant. This includes creating the necessary data models, validation rules, and services for invitation management.

**Acceptance Criteria:**
- Invitation entity model implemented with appropriate fields
- Database schema created for storing invitations
- Service for generating new invitations with security tokens
- Role selection as part of invitation creation
- Validation for invitation email addresses
- Prevention of duplicate invitations to same email
- Expiration date setting for invitations
- Repository pattern for invitation data access
- Integration with tenant membership system
- Logging of invitation creation
- Testing confirms invitations are correctly generated
- Authorization checks to ensure only owners/admins can create invitations

#### Story 3.3.2: Build email notification for invitations

**Description:**
Implement the system for sending email notifications for tenant invitations. These emails should clearly communicate the invitation details and provide an easy way for recipients to accept the invitation.

**Acceptance Criteria:**
- Email template for tenant invitations
- Integration with SendGrid for email delivery
- Personalization of email with recipient and tenant details
- Secure accept invitation link with token
- Clear explanation of what the recipient is being invited to
- Information about the inviting user
- Branding and styling consistent with application
- Email delivery tracking
- Retry mechanism for failed email delivery
- HTML and plain text versions of email
- Testing confirms emails are delivered and contain correct information
- Testing confirms accept links work correctly

#### Story 3.3.3: Implement invitation acceptance workflow

**Description:**
Create the workflow for users to accept invitations to join a tenant. This includes handling both registered and unregistered users, verifying invitation tokens, and establishing the tenant membership upon acceptance.

**Acceptance Criteria:**
- Accept invitation page with token validation
- Handling for registered vs. unregistered users
- Registration/login flow for unregistered users
- Verification of invitation token validity and expiration
- Creation of TenantUserMap entry upon acceptance
- Role assignment based on invitation settings
- Redirect to appropriate tenant page after acceptance
- Error handling for invalid or expired invitations
- Logging of invitation acceptance
- Prevention of accepting already-used invitations
- Email notification to inviter when invitation is accepted
- Testing confirms end-to-end invitation acceptance works correctly

#### Story 3.3.4: Create invitation management UI (list, revoke)

**Description:**
Implement the user interface for managing outstanding invitations. This allows administrators to see pending invitations, resend invitations, and revoke invitations that should no longer be valid.

**Acceptance Criteria:**
- Invitation management page for tenant administrators
- List view of all pending invitations
- Status indicators for invitation state
- Creation date and expiration date display
- Revoke invitation functionality with confirmation
- Resend invitation functionality
- Filtering and searching of invitations
- Pagination for large invitation lists
- Mobile-responsive design
- Accessibility compliance for all UI elements
- Testing confirms all invitation management functions work
- Authorization ensures only permitted users can manage invitations

#### Story 3.3.5: Build invitation expiration handling

**Description:**
Implement the system for handling invitation expiration, including automatic expiration of older invitations and clear user feedback when attempting to use expired invitations.

**Acceptance Criteria:**
- Automatic expiration based on configured timeframe
- Background job to clean up expired invitations
- Clear error message when using expired invitation
- Option to resend expired invitation
- Configuration setting for default expiration period
- UI indicators for soon-to-expire invitations
- Logging of invitation expiration
- Testing confirms invitations properly expire
- Testing confirms expired invitations cannot be used
- Testing confirms resending works for expired invitations
- Performance optimized expiration checking

### Feature 3.4: Tenant Administration
This feature provides the administration capabilities for tenant owners and administrators. It includes creating a comprehensive tenant dashboard with usage metrics, UI components for managing tenant settings, permission management interfaces for tenant-wide access control, tenant activity history and audit logging, and data export tools for tenant information.

#### Story 3.4.1: Create tenant dashboard with usage metrics

**Description:**
Implement a comprehensive dashboard for tenant administrators that provides key metrics and insights about tenant usage. This helps administrators understand how their tenant is being used and monitor important trends.

**Acceptance Criteria:**
- Tenant dashboard UI with key metrics
- User count metrics (total, active, by role)
- Project and container count metrics
- Template usage statistics
- Message sending volume metrics
- Resource usage versus limits display
- Activity timeline of recent important events
- Quick access to common administrative functions
- Data visualizations (charts, graphs) for key metrics
- Refresh capability for latest data
- Mobile-responsive design
- Accessibility compliance for all dashboard elements
- Testing confirms dashboard displays accurate information

#### Story 3.4.2: Build tenant settings management UI

**Description:**
Create the user interface for managing tenant-wide settings and configurations. This provides administrators with a central place to configure tenant behavior and preferences.

**Acceptance Criteria:**
- Tenant settings page with organized sections
- Form for updating tenant name and description
- Subscription plan information and upgrade options
- Default member role setting
- Branding options (if applicable)
- Notification preferences for tenant-wide events
- Integration settings management
- Save buttons with proper validation
- Real-time updates after saving changes
- Mobile-responsive design
- Accessibility compliance for all settings UI
- Testing confirms all settings can be properly updated
- Authorization ensures only permitted users can change settings

#### Story 3.4.3: Implement tenant-wide permission management

**Description:**
Create functionality for managing permissions at the tenant level, providing a centralized way to control access to tenant resources and features. This includes default permissions for new members and global permission policies.

**Acceptance Criteria:**
- Tenant permissions management UI
- Default role setting for new members
- Bulk permission management for tenant resources
- Role definition customization (if applicable)
- Permission policy templates
- Permission inheritance controls
- Save functionality with validation
- Visual representation of permission structure
- Impact analysis for permission changes
- Audit logging of permission changes
- Testing confirms tenant-wide permissions work correctly
- Authorization ensures only permitted users can manage permissions

#### Story 3.4.4: Create tenant audit log and activity history

**Description:**
Implement a comprehensive audit logging system for tenant activities, providing administrators with visibility into important actions and changes within their tenant. This supports security monitoring, compliance, and troubleshooting.

**Acceptance Criteria:**
- Audit log UI with filtering and search
- Logging of key tenant events (member changes, settings updates)
- Logging of permission changes
- Logging of resource creation/modification/deletion
- User information for each logged action
- Timestamp and action details for each entry
- Pagination for large audit logs
- Export capability for audit data
- Retention policy for audit logs
- Performance optimization for audit log queries
- Testing confirms all key actions are properly logged
- Authorization ensures only permitted users can view audit logs

#### Story 3.4.5: Build tenant data export capabilities

**Description:**
Implement functionality for exporting tenant data for backup, analysis, or migration purposes. This ensures administrators have access to their data and can use it outside the system when needed.

**Acceptance Criteria:**
- Data export UI with options for content selection
- Export formats (JSON, CSV, Excel) based on data type
- Project and container structure export
- Template content export
- User membership export
- Usage metrics export
- Background processing for large exports
- Download mechanism for completed exports
- Progress indicator for long-running exports
- Email notification when export is ready
- Security validation for exported data
- Testing confirms exports contain correct data
- Testing confirms large exports work correctly
- Authorization ensures only permitted users can export data

## Epic 4: Project & Container Management

**Description:**  
Project & Container Management provides the primary “information architecture” layer for CommuniQueue. This epic organizes messaging assets (templates, configs) into logical, hierarchical units tailored to complex business use-cases. Projects group messages by initiative or client; containers offer deep nesting, mirroring real-world orgs or campaign structures; both support fine-grained access, search, and bulk operations. This not only helps teams declutter and scale their communication assets, but also unlocks advanced features: permission overrides, flexible reporting, and workflow control. A thoughtfully designed hierarchy allows CommuniQueue to support everything from startups (few projects) to enterprises (dozens of subdivisions, campaigns, departments) without UI or admin chaos.

**Why:**  
- Enables scalable, organized management of hundreds or thousands of templates.
- Facilitates targeted permissions: e.g., Marketing can access only their campaigns.
- Supports future features such as detailed analytics breakout (by project/campaign).
- Streamlines onboarding—users can find, clone, or manage relevant assets intuitively.

**What Success Looks Like:**  
- Users quickly locate, organize, and secure their messaging templates.
- Permission assignment is flexible but never confusing.
- Orgs of any scale can map their structure naturally onto the product’s hierarchy.

### Feature 4.1: Project Structure
This feature implements the project organization system as the primary structural element within tenants. It includes creating the Project entity model and database schema, implementing CRUD operations for projects, building project listing and dashboard UI components, establishing project-specific permission controls, and implementing search and filtering capabilities for projects.

#### Story 4.1.1: Implement Project entity model and database schema

**Description:**
Design and implement the Project entity model and corresponding database schema according to the design document. Projects are the top-level organizational element within a tenant, containing containers and templates. The model should support the multi-tenant architecture with appropriate relationships.

**Acceptance Criteria:**
- Project entity class implemented according to design document specifications
- Database migration created for Project table with appropriate schema
- GUID v7 primary key implemented for Project entities
- Name and Description fields included with appropriate validation
- TenantId foreign key implemented to associate projects with tenants
- Created/Updated timestamp fields implemented
- Appropriate indexes created for common query fields including TenantId
- Foreign key relationship to Tenant table with proper cascade behavior
- Database constraints ensure project names are unique within a tenant
- Integration tests verify proper database schema creation and relationships
- Repository pattern implemented for Project entity access
- Data access methods optimized for common query patterns

#### Story 4.1.2: Create project CRUD operations

**Description:**
Implement the core Create, Read, Update, and Delete operations for projects, including API endpoints, service methods, and data access components. These operations form the foundation of project management within the system.

**Acceptance Criteria:**
- API endpoints implemented for all CRUD operations
- Create operation validates input and creates new project
- Read operation retrieves project details by ID
- Update operation validates input and updates existing project
- Delete operation validates dependencies before deletion
- Proper error handling for all operations
- Validation ensures project names are unique within tenant
- Authentication and authorization enforced for all operations
- Tenant isolation enforced in all operations
- Logging of all CRUD operations for audit purposes
- Transaction management for data consistency
- Performance testing confirms operations scale with data volume
- Error messages are clear and actionable

#### Story 4.1.3: Build project listing and dashboard UI

**Description:**
Create the user interface components for displaying projects and their details. This includes a listing view for browsing all accessible projects and a dashboard view for individual project details and management.

**Acceptance Criteria:**
- Project listing page with grid/list view options
- Search and filtering capabilities in project list
- Sort options (name, creation date, last modified)
- Project card/item displays key project information
- Create new project button with form modal
- Project dashboard view showing project details
- Project statistics and activity summary
- Quick access to containers within the project
- Edit project details functionality
- Delete project functionality with confirmation
- Mobile-responsive design for all project views
- Accessibility compliance for all UI components
- Performance optimized for tenants with many projects
- Testing confirms all UI functions work correctly

#### Story 4.1.4: Implement project-specific permissions

**Description:**
Implement the permission system for projects that allows for granular access control at the project level. This builds on the core RBAC framework to provide project-specific access controls that can override tenant-level permissions.

**Acceptance Criteria:**
- Project permissions using AccessControlEntry entity
- UI for managing project-specific permissions
- User/role selector for permission assignment
- Role options (Owner, Admin, Member, Readonly) for projects
- API endpoints for setting and retrieving project permissions
- Permission inheritance from tenant level by default
- Override capability for project-specific permissions
- Validation to prevent invalid permission combinations
- Efficiency in permission checks to minimize DB queries
- Logging of permission changes for audit
- Testing confirms permissions correctly control access
- Performance testing with many permission entries

#### Story 4.1.5: Create project search and filtering

**Description:**
Implement comprehensive search and filtering capabilities for projects to help users quickly find the projects they need, especially in tenants with many projects. This should include text search, filtering by various attributes, and sorting options.

**Acceptance Criteria:**
- Text search across project names and descriptions
- Search results highlight matching text
- Filter options for project properties (creation date, etc.)
- Filter by project owner/creator
- Sort options (alphabetical, newest, recently updated)
- Saved search/filter preferences
- Search results respect user permissions
- Empty state UI with helpful guidance
- Search performance optimized with appropriate indexes
- Client-side filtering for quick responses
- Server-side search for comprehensive results
- Results pagination for large result sets
- Mobile-responsive search and filter UI
- Accessibility compliance for search components

### Feature 4.2: Container Hierarchy
This feature implements the container hierarchy system that organizes templates within projects. It includes creating the Container entity model with parent-child relationships, implementing CRUD operations for containers, establishing depth tracking and management for nested containers, container validation rules to ensure proper hierarchy, and efficient query operations optimized for tree structures.

#### Story 4.2.1: Implement Container entity model with parent relationships

**Description:**
Design and implement the Container entity model and database schema with support for hierarchical parent-child relationships. Containers organize templates within projects and can be nested to create a flexible organizational structure.

**Acceptance Criteria:**
- Container entity class implemented according to design document
- Database migration created for Container table
- GUID v7 primary key implemented for Container entities
- Name and Description fields with appropriate validation
- ProjectId foreign key to associate containers with projects
- ParentId nullable foreign key for parent-child relationships
- Depth field to track nesting level in hierarchy
- Created/Updated timestamp fields implemented
- Appropriate indexes for efficient hierarchy traversal
- Foreign key relationships with proper cascade behavior
- Uniqueness constraint on container names within same parent
- Integration tests verify proper database schema and relationships
- Repository pattern implemented for Container entity access

#### Story 4.2.2: Create container CRUD operations

**Description:**
Implement the core Create, Read, Update, and Delete operations for containers, including API endpoints, service methods, and data access components. These operations should maintain the integrity of the container hierarchy during modifications.

**Acceptance Criteria:**
- API endpoints implemented for all CRUD operations
- Create operation validates input and creates new container
- Parent-child relationship established during creation
- Read operation retrieves container details by ID
- Update operation validates input and updates existing container
- Move operation for relocating containers in the hierarchy
- Delete operation validates dependencies before deletion
- Cascade deletion option for removing container with children
- Proper error handling for all operations
- Validation ensures container names are unique within same parent
- Authentication and authorization enforced for all operations
- Tenant and project isolation enforced in all operations
- Transaction management for data consistency
- Performance testing confirms operations scale with hierarchy depth

#### Story 4.2.3: Build container depth tracking and management

**Description:**
Implement the system for tracking and managing container nesting depth within the hierarchy. This ensures that containers can be properly organized while preventing excessively deep hierarchies that could cause performance or usability issues.

**Acceptance Criteria:**
- Depth field calculation during container creation and updates
- Maximum depth limit enforced (configurable, e.g., 5 levels)
- Validation to prevent operations that would exceed max depth
- Depth updates propagated to child containers when parent changes
- UI indication of current depth in hierarchy
- Clear error messages when depth limit is reached
- Performance optimized depth tracking to minimize DB operations
- Unit tests for depth calculation logic
- Integration tests for depth limit enforcement
- Testing confirms depth tracking works correctly during moves
- Documentation of depth limitation and best practices

#### Story 4.2.4: Implement container nesting rules and validation

**Description:**
Create a comprehensive set of rules and validation logic for container nesting to ensure the integrity and usability of the container hierarchy. This includes preventing circular references, validating parent-child relationships, and enforcing naming constraints.

**Acceptance Criteria:**
- Circular reference prevention (container can't be its own ancestor)
- Validation ensures container remains in same project
- Name uniqueness enforced among siblings
- Maximum children per container limit (if applicable)
- Validation that parent exists and is accessible
- Error messages clearly explain validation failures
- Transaction handling for validation across multiple operations
- API validation consistent with UI validation
- Unit tests for all validation rules
- Integration tests for complex scenarios
- Performance optimization for validation operations
- Documentation of nesting rules for users

#### Story 4.2.5: Create efficient container query operations

**Description:**
Implement optimized query operations for container hierarchies to support efficient navigation, searching, and manipulation of the container structure. These operations should scale well with both hierarchy depth and breadth.

**Acceptance Criteria:**
- Recursive query capability for fetching entire subtrees
- Efficient ancestor path retrieval
- Optimized descendants query
- Sibling retrieval operations
- Query caching strategy for frequently accessed structures
- Paged loading for large container collections
- Filtering capabilities within hierarchy queries
- Performance metrics for query operations
- Query optimization using appropriate indexes
- Support for common hierarchy traversal patterns
- Integration with permission system for filtered results
- Documentation of query capabilities and best practices
- Testing confirms query efficiency at scale

### Feature 4.3: Project Navigation
This feature creates the navigation components for the CommuniQueue UI. It includes building a hierarchical tree view component for navigating the project/container structure, implementing filtering and search within the navigation tree, creating breadcrumb navigation for deep hierarchies, building collapsible and expandable tree nodes, and implementing permission-aware rendering that respects user access rights.

#### Story 4.3.1: Build hierarchical tree view component for navigation

**Description:**
Create a reusable Blazor component that displays projects and containers in a hierarchical tree structure. This component will serve as the primary navigation method for users to browse and select projects, containers, and templates.

**Acceptance Criteria:**
- Tree view component with hierarchical display
- Projects as top-level nodes
- Containers as child nodes with appropriate nesting
- Visual indicators for hierarchy levels
- Selection mechanism for current node
- Visual styling consistent with application design
- Keyboard navigation support
- Screen reader accessibility
- Lazy loading for better performance
- State persistence between page navigations
- Smooth animations for expand/collapse
- Touch-friendly design for mobile devices
- Documentation for component usage
- Unit tests for component behavior

#### Story 4.3.2: Implement project/container filtering and search

**Description:**
Add filtering and search capabilities to the navigation tree to help users quickly find specific projects or containers. This should integrate with the existing search functionality while providing a focused experience for navigation.

**Acceptance Criteria:**
- Search box integrated with navigation tree
- Real-time filtering as user types
- Highlighting of matching text in results
- Options to search projects, containers, or both
- Empty state when no matches found
- Clear button to reset search
- Search history or recent searches
- Keyboard shortcuts for search focus
- Performance optimization for search operations
- Search respects user permissions
- Mobile-friendly search interface
- Accessibility compliance for search components
- Testing confirms search correctly filters tree
- Integration with global search functionality

#### Story 4.3.3: Create breadcrumb navigation for deep hierarchies

**Description:**
Implement breadcrumb navigation that shows the current location within the project/container hierarchy. This provides context for users, especially when navigating deep hierarchies, and offers quick navigation to parent elements.

**Acceptance Criteria:**
- Breadcrumb component showing hierarchy path
- Visual distinction between project and container elements
- Clickable links for each level in the path
- Truncation handling for long names
- Tooltip showing full name when truncated
- Current location highlighted
- Integration with routing system
- Consistent updating when location changes
- Mobile-responsive design
- Accessibility compliance for breadcrumb navigation
- Testing confirms breadcrumbs accurately reflect location
- Testing confirms navigation works when clicking breadcrumbs
- Style consistency with overall application design

#### Story 4.3.4: Build collapsible/expandable tree nodes

**Description:**
Enhance the tree view component with collapsible and expandable nodes to allow users to focus on relevant parts of the hierarchy. This includes implementing the expand/collapse functionality, visual indicators, and state persistence.

**Acceptance Criteria:**
- Expand/collapse functionality for tree nodes
- Visual indicators for expandable nodes
- Click and keyboard triggers for expand/collapse
- Animation for smooth transitions
- State persistence for expanded/collapsed nodes
- Expand all / collapse all functionality
- Default expansion based on context (e.g., current selection path)
- Performance optimization for large trees
- Touch-friendly expand/collapse for mobile
- Accessibility support including ARIA attributes
- Testing confirms expand/collapse works correctly
- Testing confirms state persists appropriately
- Integration with overall navigation system

#### Story 4.3.5: Implement permission-aware navigation rendering

**Description:**
Enhance the navigation components to respect user permissions, showing only the projects and containers the current user has access to. This ensures users see a personalized navigation experience based on their specific access rights.

**Acceptance Criteria:**
- Navigation tree filters items based on user permissions
- Integration with RBAC system for permission checks
- Efficient permission checking to maintain performance
- Handling for permission changes (real-time updates if possible)
- Appropriate behavior when parent is accessible but children aren't
- Visual indicators for different access levels (if applicable)
- Empty states when no accessible items exist
- SuperAdmin override to see all items
- Impersonation mode respects impersonated user's permissions
- Testing confirms correct items shown/hidden based on permissions
- Performance testing with many items and complex permissions
- Graceful handling of permission errors

### Feature 4.4: Project & Container Access Control
This feature implements granular access control for projects and containers. It includes creating project-level permission management interfaces, container-level permission override mechanisms, visualization tools for understanding permission inheritance across the hierarchy, bulk permission management capabilities, and comprehensive access audit logging.

#### Story 4.4.1: Implement project-level permission management

**Description:**
Create the functionality for managing access permissions at the project level. This allows administrators to control who can access, edit, and manage specific projects independently of tenant-wide permissions.

**Acceptance Criteria:**
- Project permissions management UI
- User/role selector for permission assignment
- Role options (Owner, Admin, Member, Readonly) for projects
- API endpoints for setting and retrieving project permissions
- Permission inheritance from tenant level by default
- Override capability for project-specific permissions
- Remove project-specific permissions functionality
- Validation to prevent removing all owner access
- Clear explanation of permission implications
- Real-time updates after permission changes
- Logging of permission changes for audit
- Testing confirms permissions correctly control project access
- Integration with existing RBAC framework

#### Story 4.4.2: Create container-level permission overrides

**Description:**
Implement the ability to set specific permissions at the container level, potentially overriding permissions from the project or tenant level. This provides fine-grained access control for organizing templates within containers.

**Acceptance Criteria:**
- Container permissions management UI
- User/role selector for permission assignment
- Role options (Owner, Admin, Member, Readonly, Deny) for containers
- API endpoints for setting and retrieving container permissions
- Permission inheritance from project level by default
- Override capability for container-specific permissions
- Remove container-specific permissions functionality
- "Deny" permission option to explicitly block access
- Inheritance visualization to show permission source
- Warning when setting permissions that conflict with parent
- Logging of permission changes for audit
- Testing confirms permissions correctly control container access
- Performance testing with deep container hierarchies

#### Story 4.4.3: Build inheritance visualization for permissions

**Description:**
Create a visual representation of permission inheritance across the project/container hierarchy. This helps administrators understand where permissions are coming from and how they flow through the system.

**Acceptance Criteria:**
- Permission visualization UI component
- Hierarchical display of permission inheritance
- Visual indicators for inherited vs. explicit permissions
- Visual indicators for "Deny" permissions
- User/group selector to view permissions for specific users
- Project/container selector to focus on specific branches
- Legend explaining visualization elements
- Interactive elements to explore permission details
- Print/export functionality for documentation
- Clear explanation of inheritance rules
- Mobile-responsive design
- Accessibility compliance for visualization
- Testing confirms visualization accurately reflects actual permissions
- Performance testing with complex permission scenarios

#### Story 4.4.4: Implement bulk permission management

**Description:**
Create functionality for managing permissions across multiple projects or containers simultaneously. This improves efficiency when making broad permission changes across the organization.

**Acceptance Criteria:**
- Bulk permission management UI
- Multi-select capability for projects/containers
- User/role selector for bulk assignment
- Preview of changes before applying
- Summary of affected items
- Progress indicator for bulk operations
- Option to propagate changes to children
- Validation to prevent accidental removal of all access
- Transaction management for atomic operations
- Error handling for partial failures
- Detailed results report after operation
- Logging of all permission changes
- Testing confirms bulk changes apply correctly
- Performance testing with large number of targets

#### Story 4.4.5: Create access audit logging for projects/containers

**Description:**
Implement comprehensive audit logging for all access-related actions on projects and containers. This provides transparency and accountability for permission changes and access attempts.

**Acceptance Criteria:**
- Detailed logging of all permission changes
- Logging of access attempts (successful and failed)
- Logging of permission inheritance changes
- User information captured for all logged events
- Timestamp and action details for each entry
- Entity information (project/container affected)
- Before/after state for permission changes
- Filtering and search capabilities for logs
- UI for viewing and exploring access logs
- Export capability for audit purposes
- Retention policy for access logs
- Performance optimization for log queries
- Testing confirms all relevant actions are logged
- Authorization ensures only appropriate users can view logs

## Epic 5: Template System

**Description:**  
Template System is the creative and operational heart of CommuniQueue. This epic encompasses everything related to authoring, editing, versioning, and managing notification templates (across email, SMS, webhook). It delivers advanced features—rich editors, type-aware validation, robust version control, permissioned publishing, and recipient management—to make messaging both dynamic and safe. By providing repeatable, reusable, and auditable templates, CommuniQueue saves organizations time, reduces errors, and aligns their messaging with compliance (marketing vs transactional distinctions, approval flows). This system is made to support both rapid testing and rock-solid production use—enabling “build, test, ready” states, version rollback, and personalizations at scale.

**Why:**  
- Eliminates message duplication and inconsistent branding/errors.
- Enables separation of responsibilities (content owners, reviewers, publishers).
- Supports compliance (retain versions for legal, manage “live” content rigorously).
- Makes powerful personalization simple and reusable across campaigns and messages.

**What Success Looks Like:**  
- Users confidently build and evolve templates without fear of breaking production.
- There’s traceability for every change—who, what, when, for every version.
- Templates are reusable, copyable, and can be tested safely before use.
- The platform makes it easy to support new message types in the future.

### Feature 5.1: Template Management
This feature implements the core template management functionality. It includes creating the Template entity model and database schema, implementing CRUD operations for templates, building template listing and dashboard UI components, implementing state management for template workflow stages (Building/Testing/Ready), and handling different template types (Email/SMS/Webhook).

#### Story 5.1.1: Implement Template entity model and database schema

**Description:**
Design and implement the Template entity model and corresponding database schema according to the design document. Templates are the core content elements that define the structure and content of notifications, and the model should support different notification types, states, and versioning.

**Acceptance Criteria:**
- Template entity class implemented according to design document specifications
- Database migration created for Template table with appropriate schema
- GUID v7 primary key implemented for Template entities
- Name field with appropriate validation
- Foreign key relationships to Project and Container entities
- NotificationType enum field (Email/SMS/Webhook)
- StateType enum field (Building/Testing/Ready)
- UsageType enum field (Transactional/Marketing)
- Created/Updated timestamp fields implemented
- Appropriate indexes for efficient querying
- Uniqueness constraint on template names within a container
- Integration tests verify proper database schema and relationships
- Repository pattern implemented for Template entity access
- Documentation of entity model and relationships
- Testing confirms model properly stores all required template data

#### Story 5.1.2: Create template CRUD operations

**Description:**
Implement the core Create, Read, Update, and Delete operations for templates, including API endpoints, service methods, and data access components. These operations should maintain template integrity and handle the relationships between templates, versions, and recipients.

**Acceptance Criteria:**
- API endpoints implemented for all CRUD operations
- Create operation validates input and creates new template
- Read operation retrieves template details by ID
- Update operation validates input and updates existing template
- Delete operation validates dependencies before deletion
- Proper error handling for all operations
- Validation ensures template names are unique within a container
- Authentication and authorization enforced for all operations
- Tenant and project isolation enforced in all operations
- Logging of all CRUD operations for audit purposes
- Transaction management for data consistency
- Performance optimized queries for template operations
- Clone template functionality implemented
- Testing confirms all operations maintain data integrity
- Documentation for API endpoints and usage

#### Story 5.1.3: Build template listing and dashboard UI

**Description:**
Create the user interface components for displaying templates and their details. This includes a listing view for browsing all accessible templates and a dashboard view for individual template details and management.

**Acceptance Criteria:**
- Template listing page with grid/list view options
- Filtering by template type, state, and usage type
- Search functionality for template names and content
- Sort options (name, creation date, last modified, type)
- Template card/item displays key template information
- Visual indicators for template type and state
- Create new template button with type selection
- Template dashboard view showing template details
- Template statistics and usage metrics
- Version history summary on dashboard
- Edit template functionality with proper navigation
- Delete template functionality with confirmation
- Mobile-responsive design for all template views
- Accessibility compliance for all UI components
- Performance optimized for containers with many templates
- Testing confirms all UI functions work correctly

#### Story 5.1.4: Implement template state management (Building/Testing/Ready)

**Description:**
Implement a state management system for templates that tracks their position in the workflow from initial creation (Building) through testing (Testing) to production readiness (Ready). The system should enforce rules about allowed operations in each state and transitions between states.

**Acceptance Criteria:**
- State field utilized in Template entity (Building/Testing/Ready)
- UI indicators for current template state
- State transition controls in template dashboard
- Validation of allowed operations per state
- Building state: full editing allowed, not available for production use
- Testing state: limited editing, test sends allowed, not for production use
- Ready state: locked for editing, available for production use
- State transition rules enforced in UI and API
- Confirmation dialogs for state changes
- Audit logging of state transitions
- State-based filtering in template listings
- Documentation of state workflow for users
- Testing confirms state transitions work correctly
- Testing confirms state restrictions are properly enforced

#### Story 5.1.5: Create template type handling (Email/SMS/Webhook)

**Description:**
Implement specialized handling for different template types (Email, SMS, Webhook) throughout the system. This includes type-specific validation, rendering, and delivery mechanisms appropriate to each notification channel.

**Acceptance Criteria:**
- Template type selection during creation
- Type-specific template editors loaded based on selection
- Email templates: subject line, HTML content, text alternative
- SMS templates: message text with character counting
- Webhook templates: JSON payload structure, endpoint configuration
- Type-specific validation rules implemented
- UI adapts based on selected template type
- Template type visible in listings and dashboard
- Type-specific testing functionality
- Type-specific preview rendering
- API validation enforces type-specific requirements
- Type conversion prevented after creation
- Documentation of template type requirements
- Testing confirms type-specific features work correctly
- Performance testing with different template types

### Feature 5.2: Template Versioning
This feature implements version control for notification templates. It includes creating the TemplateVersion entity model and establishing relationships with templates, implementing version numbering and tracking, building version history UI with comparison tools, implementing version promotion workflows for managing the active version, and creating the version pruning system that retains the 5 most recent versions.

#### Story 5.2.1: Implement TemplateVersion entity model and relationships

**Description:**
Design and implement the TemplateVersion entity model that stores versioned content of templates. This model supports the version control system, allowing templates to evolve while maintaining history and the ability to revert changes.

**Acceptance Criteria:**
- TemplateVersion entity class implemented according to design document
- Database migration created for TemplateVersion table
- GUID v7 primary key implemented for TemplateVersion entities
- Foreign key relationship to Template entity
- VersionNumber field for sequential version tracking
- Content fields appropriate to template types (Subject, Body, From, etc.)
- Created/Updated timestamp fields implemented
- Appropriate indexes for efficient version querying
- Integration tests verify proper database schema and relationships
- Repository pattern implemented for TemplateVersion entity access
- Cascade behavior appropriately configured for template deletion
- Performance optimization for version queries
- Documentation of version entity model and usage
- Testing confirms model correctly stores version history

#### Story 5.2.2: Create version numbering and tracking system

**Description:**
Implement a version numbering and tracking system that maintains sequential version numbers for each template and manages the creation of new versions. This system should handle version increments automatically when templates are updated.

**Acceptance Criteria:**
- Automatic version number incrementation on template updates
- Initial version created with number 1 on new template
- New version created when template content is modified
- API endpoint to retrieve version history for a template
- Service method to get specific version by number
- Version metadata tracking (created date, author)
- Automatic marking of latest version
- Validation to ensure version integrity
- Transaction management for version creation
- Performance optimization for version tracking
- Documentation of versioning behavior and rules
- Testing confirms version numbers increment correctly
- Testing confirms version history maintains integrity
- Integration with state management system

#### Story 5.2.3: Build version history UI and comparison tools

**Description:**
Create user interface components for viewing template version history and comparing different versions. This helps users understand how templates have evolved and identify changes between versions.

**Acceptance Criteria:**
- Version history list view in template dashboard
- Version metadata display (number, date, author)
- Version comparison view for any two versions
- Side-by-side comparison for text content
- Diff highlighting showing additions and removals
- Visual indicators for current active version
- Version filtering and searching capabilities
- Preview functionality for any version
- Restore functionality to revert to previous versions
- Mobile-responsive design for version history
- Accessibility compliance for all version UI components
- Performance optimization for large version histories
- Testing confirms version history displays correctly
- Testing confirms comparison tool accurately shows differences

#### Story 5.2.4: Implement version promotion workflow

**Description:**
Create a workflow for promoting specific template versions to "active" status, making them the current version used for sending notifications. This allows for controlled updates to templates in production use.

**Acceptance Criteria:**
- UI controls for promoting versions to active
- API endpoint for version promotion
- Validation of version state before promotion
- Confirmation dialog explaining promotion implications
- Automatic state transition to "Ready" for promoted version
- Visual indicators for active version in history view
- Audit logging of version promotion actions
- Notification to relevant users on promotion
- Version demotions tracked if version is superseded
- Documentation of promotion workflow
- Testing confirms promotion correctly updates active version
- Testing confirms only appropriate versions can be promoted
- Integration with permission system to control promotion

#### Story 5.2.5: Create version pruning system (retain 5 most recent)

**Description:**
Implement a system that automatically prunes old template versions to maintain storage efficiency while preserving recent history. By default, the system should retain the 5 most recent versions of each template while older versions are removed according to plan limits.

**Acceptance Criteria:**
- Automatic version pruning system implemented
- Configurable retention count (default: 5 most recent)
- Background job for scheduled pruning
- Protection for active version regardless of age
- Subscription plan integration for higher retention limits
- Warning UI when approaching version limit
- Pruning preview showing which versions will be removed
- Audit logging of pruned versions
- Pruning statistics and reporting
- Manual pruning option for administrators
- Documentation of pruning behavior and limits
- Testing confirms correct versions are retained/pruned
- Performance testing with many versions
- Integration with subscription management system

### Feature 5.3: Template Editor
This feature provides specialized editors for different template types. It includes building a rich text editor for email templates, a plain text editor for SMS templates, a specialized JSON/payload editor for webhook templates, implementing a variable placeholder system for template personalization, and creating template validation tools for error checking.

#### Story 5.3.1: Build rich text editor for email templates

**Description:**
Implement a rich text (WYSIWYG) editor for creating and editing email templates. The editor should provide common formatting tools, image embedding, and HTML capabilities while ensuring the output is compatible with email clients.

**Acceptance Criteria:**
- Rich text editor component integrated into template editing
- Text formatting tools (bold, italic, underline, etc.)
- Paragraph formatting (alignment, spacing, etc.)
- List creation (ordered and unordered)
- Table creation and formatting
- Image embedding with sizing and alignment
- Link creation and editing
- HTML source code editing option
- Email-compatible CSS styling options
- Responsive design preview
- Template variable insertion functionality
- Undo/redo functionality
- Autosave while editing
- Mobile-friendly editing experience
- Accessibility compliance for editor controls
- Testing confirms editor produces valid email HTML
- Performance testing with large templates

#### Story 5.3.2: Create plain text editor for SMS templates

**Description:**
Implement a specialized plain text editor for SMS templates that helps users create effective SMS messages while being aware of character limits and other SMS-specific constraints.

**Acceptance Criteria:**
- Plain text editor optimized for SMS content
- Character counter showing used and remaining characters
- SMS segment counter (160 chars per segment)
- Cost estimation based on segment count
- Warning indicators for approaching character limits
- Template variable insertion functionality
- URL shortening integration or preview
- Emoji selector with character count impact
- Preview of how message will appear on mobile devices
- Undo/redo functionality
- Autosave while editing
- Mobile-friendly editing experience
- Accessibility compliance for editor controls
- Testing confirms editor respects SMS constraints
- Performance testing with character counting

#### Story 5.3.3: Implement JSON/payload editor for webhook templates

**Description:**
Create a specialized editor for webhook templates that allows users to define JSON payloads and HTTP configurations for webhook notifications. The editor should support JSON validation, syntax highlighting, and template variables within the payload.

**Acceptance Criteria:**
- JSON editor with syntax highlighting
- JSON structure validation
- Schema validation option for common webhook formats
- Template variable insertion within JSON structure
- HTTP method selection (GET, POST, PUT, etc.)
- Header configuration options
- Endpoint URL configuration
- Request parameter configuration
- Format validation ensuring valid JSON output
- JSON formatting/beautify option
- Undo/redo functionality
- Autosave while editing
- Sample payload library for common webhook formats
- Documentation of webhook structure and best practices
- Testing confirms editor produces valid JSON with variables
- Performance testing with large JSON payloads

#### Story 5.3.4: Build template variable system with placeholders

**Description:**
Implement a system for defining and using template variables (placeholders) that can be replaced with actual values when notifications are sent. This enables personalization and dynamic content in templates.

**Acceptance Criteria:**
- Variable placeholder syntax defined and documented
- Variable insertion UI in all template editors
- Variable picker showing available variables
- Variable categorization (recipient, system, custom)
- Variable preview with sample values
- Validation of variable syntax in templates
- Documentation of available variables and their usage
- Support for conditional logic in variables (if/else)
- Support for formatting options (dates, numbers)
- Variable highlighting in editors
- Default values for variables
- Testing confirms variables work in all template types
- Testing confirms proper variable replacement at send time
- Performance testing with many variables
- Documentation for creating custom variables

#### Story 5.3.5: Create template validation tools

**Description:**
Implement comprehensive validation tools for templates to help users identify and fix potential issues before templates are used in production. This includes syntax checking, variable validation, and channel-specific validations.

**Acceptance Criteria:**
- Real-time validation during template editing
- Visual indicators for validation errors and warnings
- Validation summary showing all issues
- Email-specific validation (HTML validity, spam triggers)
- SMS-specific validation (character count, forbidden content)
- Webhook-specific validation (JSON validity, required fields)
- Variable validation ensuring all variables exist
- Link validation checking for broken URLs
- Accessibility validation for email templates
- Validation API endpoint for programmatic checking
- Clear error messages with resolution suggestions
- Validation checks during state transitions
- Documentation of validation rules
- Testing confirms validation correctly identifies issues
- Performance testing with large templates

### Feature 5.4: Template Testing
This feature implements the ability to test templates before sending. It includes creating test send functionality with validation, template preview capabilities with variable substitution, test recipient management tools, test result review and debugging interfaces, and maintaining template testing history and logs for quality assurance.

#### Story 5.4.1: Implement test send functionality with validation

**Description:**
Create functionality to send test notifications using templates, allowing users to validate how templates will appear when delivered. The test send should use real delivery channels but be clearly marked as test messages.

**Acceptance Criteria:**
- Test send button in template editor and dashboard
- Test recipient selection interface
- Test variable value input form
- Validation of template before test send
- Integration with SendGrid for email test sends
- Integration with Twilio for SMS test sends
- Integration with test webhook endpoint
- Clear marking of messages as "TEST" in subject/content
- Confirmation dialog before sending tests
- Progress indicator during test send
- Success/failure notification after test completion
- Rate limiting for test sends
- Logging of all test sends
- Testing confirms test messages are delivered
- Testing confirms test messages are properly marked
- Integration with permission system

#### Story 5.4.2: Create template preview with variable substitution

**Description:**
Implement a preview system that shows how templates will appear when variables are replaced with actual values. This allows users to verify template appearance without sending actual test messages.

**Acceptance Criteria:**
- Preview button in template editor and dashboard
- Variable value input form for preview
- Real-time preview rendering
- Preview for all template types (email, SMS, webhook)
- Email preview showing desktop and mobile rendering
- SMS preview showing message as it would appear on phone
- Webhook preview showing final payload after substitution
- Preview of all variable replacements
- Toggle between preview and edit mode
- Share preview functionality (if applicable)
- Print/export preview option
- Mobile-responsive preview interface
- Accessibility compliance for preview components
- Testing confirms preview accurately reflects final output
- Performance testing with complex templates

#### Story 5.4.3: Build test recipient management

**Description:**
Create a system for managing test recipients that can be used when testing templates. This allows users to maintain a list of test addresses without having to re-enter them for each test.

**Acceptance Criteria:**
- Test recipient management UI
- Add, edit, remove test recipient functionality
- Recipient categorization or tagging
- Recipient groups for batch testing
- Support for different recipient types (email, phone, webhook)
- Quick select of recent or favorite test recipients
- Validation of recipient addresses/numbers
- Permission controls for test recipient management
- Import/export of test recipients
- Test recipient selection in test send interface
- Documentation of test recipient best practices
- Testing confirms recipient management works correctly
- Integration with organization contact systems (if applicable)
- Privacy compliance for stored recipient information

#### Story 5.4.4: Implement test result review and debugging

**Description:**
Create functionality to review the results of template tests and provide debugging information to help identify and resolve issues. This helps users understand delivery problems and improve template quality.

**Acceptance Criteria:**
- Test result dashboard showing test history
- Detailed view of individual test results
- Status tracking (sent, delivered, failed)
- Error messages for failed tests
- Delivery metadata from providers (SendGrid, Twilio)
- Preview of exactly what was sent (after variable substitution)
- Suggestions for resolving common issues
- Link validation results
- Spam score for email templates
- Performance metrics (size, delivery time)
- Export test results functionality
- Filtering and searching of test results
- Testing confirms debugging information is accurate
- Integration with notification tracking system
- Documentation of common issues and resolutions

#### Story 5.4.5: Create template testing history and logs

**Description:**
Implement a system for maintaining a history of template tests and comprehensive logging of test activities. This supports quality assurance and troubleshooting by providing a record of template evolution and testing efforts.

**Acceptance Criteria:**
- Testing history view in template dashboard
- Log of all test sends with timestamps and users
- Test result status tracking over time
- Filtering and searching of test history
- Version information for each test
- Variable values used in each test
- Test recipient information
- Comparison of test results across versions
- Statistics and trends in test results
- Export functionality for test logs
- Retention policy for test history
- Integration with audit logging system
- Testing confirms history accurately tracks all tests
- Performance optimization for large test histories
- Authorization controls for viewing test history

### Feature 5.5: Template Recipients
This feature manages template recipient configuration. It includes implementing the TemplateRecipient entity model, handling different recipient types based on the notification method (To/CC/BCC for email, etc.), building recipient management UI components, implementing recipient validation rules, and supporting dynamic recipient handling through variable substitution.

#### Story 5.5.1: Implement TemplateRecipient entity model

**Description:**
Design and implement the TemplateRecipient entity model that defines the recipients for template notifications. This model supports different recipient types and establishes the relationship between templates and their intended recipients.

**Acceptance Criteria:**
- TemplateRecipient entity class implemented according to design document
- Database migration created for TemplateRecipient table
- GUID v7 primary key implemented for TemplateRecipient entities
- Foreign key relationship to TemplateVersion entity
- RecipientType enum field (To, CC, BCC, SMS, etc.)
- Value field for recipient address/number
- Integration tests verify proper database schema and relationships
- Repository pattern implemented for TemplateRecipient entity access
- Cascade behavior appropriately configured for version deletion
- Performance optimization for recipient queries
- Documentation of recipient entity model and usage
- Testing confirms model correctly stores recipient information
- API endpoints for managing recipients
- Validation rules for recipient values

#### Story 5.5.2: Create recipient type handling (To/CC/BCC for email, etc.)

**Description:**
Implement specialized handling for different recipient types based on the notification channel. For email, this includes To, CC, and BCC recipients, while for SMS and webhooks it includes appropriate recipient designations for those channels.

**Acceptance Criteria:**
- Email recipient types supported: To, CC, BCC
- SMS recipient type supported
- Webhook endpoint recipient configuration
- UI controls specific to each recipient type
- Validation rules appropriate to each type
- Maximum counts per recipient type (if applicable)
- Required recipient types enforced (e.g., at least one To for email)
- Type-specific formatting and validation
- Clear labeling of recipient types in UI
- Documentation of recipient type usage and best practices
- Testing confirms all recipient types work correctly
- Integration with delivery providers for type-specific handling
- Performance testing with many recipients

#### Story 5.5.3: Build recipient management UI

**Description:**
Create user interface components for managing template recipients. This includes adding, editing, and removing recipients, as well as assigning recipient types and configuring recipient-specific options.

**Acceptance Criteria:**
- Recipient management section in template editor
- Add, edit, remove recipient functionality
- Recipient type selection appropriate to template type
- Multiple recipient input for batch addition
- Validation feedback for recipient values
- Drag-and-drop reordering (if applicable)
- Clear organization of different recipient types
- Bulk operations for multiple recipients
- Import recipients from file or contacts
- Mobile-responsive recipient management UI
- Accessibility compliance for all recipient UI components
- Testing confirms recipient management functions correctly
- Performance testing with many recipients
- Integration with variable system for dynamic recipients

#### Story 5.5.4: Implement recipient validation rules

**Description:**
Create comprehensive validation rules for recipients to ensure they are properly formatted and valid for their intended notification channel. This helps prevent delivery failures due to invalid recipient information.

**Acceptance Criteria:**
- Email format validation for email recipients
- Phone number format validation for SMS recipients
- URL validation for webhook endpoints
- Domain validation and blacklist checking
- Maximum recipient count validation
- Required recipient validation
- Real-time validation during input
- Batch validation for imported recipients
- Clear error messages for validation failures
- Suggestions for fixing common validation issues
- Documentation of validation rules
- Testing confirms validation correctly identifies issues
- Integration with external validation services (if applicable)
- Performance testing with large recipient lists

#### Story 5.5.5: Create dynamic recipient handling with variables

**Description:**
Implement support for dynamic recipients using template variables. This allows recipients to be determined at send time based on data values rather than being statically defined in the template.

**Acceptance Criteria:**
- Variable placeholders in recipient fields
- UI indication of dynamic recipients
- Variable selector integrated with recipient inputs
- Preview of dynamic recipients with sample data
- Validation of variable syntax in recipient fields
- Support for recipient arrays from variables
- Support for conditional recipients based on data
- Documentation of dynamic recipient usage
- Testing confirms dynamic recipients resolve correctly
- Testing confirms validation works with variable recipients
- Preview shows potential recipient resolution
- Performance testing with complex variable recipients
- Error handling for missing or invalid recipient variables
- Integration with permission system for dynamic recipients

## Epic 6: Notification Services

**Description:**  
Notification Services brings CommuniQueue’s messages to life, integrating with external providers (SendGrid for email, Twilio for SMS, webhooks for extensibility) to enable reliable multi-channel delivery. This epic ensures robust, decoupled sending: background queue processing, provider failover, delivery tracking webhooks, and retry backoff. It incorporates pluggable architecture (supporting new channels in the future) and injects resilience and observability into every step (logging, status tracking, error capture). By focusing on async, queue-based design, the system can handle bursty loads, isolate external provider failures, and optimize for performance/cost. This also opens the door to sophisticated analytics and regulatory auditability.

**Why:**  
- Isolates business logic from external service flakiness.
- Supports high concurrency and burst scaling for large notifications.
- Enables real-time and post-hoc insights into delivery, failures, and provider health.
- Allows product growth—new channels or providers—without massive rework.

**What Success Looks Like:**  
- Messages are reliably delivered, with minimal failures—even under stress.
- Failures are quickly detected, logged, and retried (with no end-user confusion).
- It’s easy to monitor, debug, and adapt to provider-specific issues or migrations.

### Feature 6.1: SendGrid Integration
This feature implements email delivery through SendGrid. It includes creating a SendGrid API client, implementing template transformation logic for SendGrid compatibility, building email delivery and tracking mechanisms, implementing sender verification and management, and creating email validation services for ensuring deliverability.

#### Story 6.1.1: Implement SendGrid API client

**Description:**
Create a robust SendGrid API client that interfaces with the SendGrid service for sending emails. This client should handle authentication, API request formatting, response parsing, and error handling for all SendGrid interactions.

**Acceptance Criteria:**
- SendGrid API client implemented using their official .NET SDK
- Configuration system for API keys and settings
- Authentication handling with SendGrid API
- Secure storage of SendGrid credentials (not hardcoded)
- Proper exception handling for API errors
- Retry logic for transient failures
- Logging of API interactions (excluding sensitive data)
- Rate limiting awareness and handling
- Unit tests mocking SendGrid API responses
- Integration tests with SendGrid sandbox (if available)
- Documentation of client usage and configuration
- Performance testing under load
- Support for all required SendGrid API endpoints
- Metrics collection for monitoring (calls, errors, latency)
- Testability through dependency injection

#### Story 6.1.2: Create email template transformation for SendGrid

**Description:**
Implement a transformation system that converts CommuniQueue email templates into a format compatible with SendGrid's delivery API. This should handle HTML content, text alternatives, variable substitution, and other SendGrid-specific requirements.

**Acceptance Criteria:**
- Template transformation service for SendGrid format
- HTML content properly formatted for SendGrid
- Text alternative content generated when needed
- Variable placeholder conversion to SendGrid format
- Subject line handling and transformation
- From/Reply-To address handling
- Attachment processing if supported
- SendGrid categories and metadata integration
- Template validation before transformation
- Error handling for transformation failures
- Logging of transformation process
- Unit tests verifying correct transformation
- Performance optimization for large templates
- Documentation of transformation process
- Testing with various template complexities
- Validation that transformed templates render correctly

#### Story 6.1.3: Build email delivery and tracking

**Description:**
Implement the core email delivery functionality using SendGrid, including sending operations, delivery status tracking, and event handling for bounces, opens, clicks, and other email activities.

**Acceptance Criteria:**
- Email sending functionality via SendGrid API
- Delivery request creation from transformed templates
- Recipient handling (To, CC, BCC)
- Variable substitution at send time
- Tracking ID generation for each email
- SendGrid event webhook configuration
- Event handling for delivered, opened, clicked events
- Bounce and complaint handling
- Status updates in NotificationTracking records
- Error handling for failed sends
- Retry mechanism for recoverable failures
- Logging of all delivery events
- Performance testing for bulk sends
- Documentation of delivery tracking
- Testing confirms tracking accuracy
- Integration with analytics system

#### Story 6.1.4: Implement sender verification and management

**Description:**
Create functionality for verifying and managing email senders through SendGrid. This includes domain verification, sender identity management, and handling sending reputation to ensure optimal email deliverability.

**Acceptance Criteria:**
- Sender identity management interface
- Domain verification workflow using SendGrid
- Individual sender email verification
- Sender reputation monitoring
- DKIM and SPF setup guidance
- Default sender configuration
- Tenant-specific sender settings
- Sender validation before sending
- Error handling for unverified senders
- Documentation of verification process
- UI for managing verified senders
- API endpoints for sender management
- Logging of sender verification events
- Testing confirms verification works correctly
- Integration with tenant management system

#### Story 6.1.5: Create email validation services

**Description:**
Implement email validation services that help ensure email deliverability by validating recipient addresses before sending. This should include syntax validation, domain validation, and optional integration with advanced validation services.

**Acceptance Criteria:**
- Email syntax validation functionality
- Domain existence validation (MX record check)
- Integration with SendGrid email validation API
- Disposable email domain detection
- Validation caching for performance
- Configurable validation levels (syntax only, full validation)
- Validation result categorization (valid, risky, invalid)
- API endpoint for validating single emails
- Batch validation capability
- Validation during recipient entry
- Clear error messages for invalid emails
- Documentation of validation services
- Performance testing for validation operations
- Cost-control mechanisms for paid validations
- Testing confirms validation accuracy

### Feature 6.2: Twilio Integration
This feature implements SMS delivery through Twilio. It includes creating a Twilio API client, implementing template transformation for SMS formatting, building SMS delivery and tracking mechanisms, implementing phone number validation, and creating SMS quota and limit management to control costs.

#### Story 6.2.1: Implement Twilio API client

**Description:**
Create a robust Twilio API client that interfaces with the Twilio service for sending SMS and MMS messages. This client should handle authentication, API request formatting, response parsing, and error handling for all Twilio interactions.

**Acceptance Criteria:**
- Twilio API client implemented using their official .NET SDK
- Configuration system for API keys and settings
- Authentication handling with Twilio API
- Secure storage of Twilio credentials
- Proper exception handling for API errors
- Retry logic for transient failures
- Logging of API interactions (excluding sensitive data)
- Rate limiting awareness and handling
- Unit tests mocking Twilio API responses
- Integration tests with Twilio test credentials
- Documentation of client usage and configuration
- Performance testing under load
- Support for all required Twilio API endpoints
- Metrics collection for monitoring
- Testability through dependency injection

#### Story 6.2.2: Create SMS template transformation for Twilio

**Description:**
Implement a transformation system that converts CommuniQueue SMS templates into a format compatible with Twilio's messaging API. This should handle text formatting, variable substitution, and SMS-specific limitations.

**Acceptance Criteria:**
- Template transformation service for Twilio format
- Text content properly formatted for SMS
- Variable placeholder conversion to Twilio format
- Character count validation and handling
- Message segmentation for long messages
- MMS content handling if supported
- Emoji and special character handling
- Twilio-specific metadata integration
- Template validation before transformation
- Error handling for transformation failures
- Logging of transformation process
- Unit tests verifying correct transformation
- Performance optimization for template processing
- Documentation of transformation process
- Testing with various template complexities
- Handling of URL shortening if implemented

#### Story 6.2.3: Build SMS delivery and tracking

**Description:**
Implement the core SMS delivery functionality using Twilio, including sending operations, delivery status tracking, and event handling for delivery, failures, and responses.

**Acceptance Criteria:**
- SMS sending functionality via Twilio API
- Delivery request creation from transformed templates
- Recipient phone number formatting and validation
- Variable substitution at send time
- Tracking ID generation for each message
- Twilio webhook configuration for status updates
- Event handling for delivered, failed, and other events
- Status updates in NotificationTracking records
- Error handling for failed sends
- Retry mechanism for recoverable failures
- Logging of all delivery events
- Performance testing for bulk sends
- Documentation of delivery tracking
- Testing confirms tracking accuracy
- Integration with analytics system
- Cost tracking per message sent

#### Story 6.2.4: Implement phone number validation

**Description:**
Create phone number validation services to ensure SMS deliverability by validating recipient numbers before sending. This should include format validation, country code handling, and optional lookup services.

**Acceptance Criteria:**
- Phone number syntax and format validation
- Country code detection and normalization
- International number format handling (E.164)
- Integration with Twilio lookup API for validation
- Mobile number type verification
- Validation caching for performance
- Configurable validation levels
- Validation result categorization
- API endpoint for validating single numbers
- Batch validation capability
- Validation during recipient entry
- Clear error messages for invalid numbers
- Documentation of validation services
- Performance testing for validation operations
- Cost-control mechanisms for paid validations
- Testing confirms validation accuracy

#### Story 6.2.5: Create SMS quota and limit management

**Description:**
Implement a quota and limit management system for SMS messages to control costs and prevent unexpected charges. This should include tenant-specific quotas, usage tracking, and alerting for approaching limits.

**Acceptance Criteria:**
- SMS quota management system based on subscription plans
- Tenant-specific SMS limits configuration
- Real-time quota usage tracking
- Limit enforcement before sending
- Notification system for approaching limits
- Administrative override for limits
- Usage reporting and analytics
- Cost estimation based on message count and destinations
- Quota reset on billing cycle
- Quota adjustment capability for plan changes
- Documentation of quota system
- API endpoints for quota management
- UI for viewing current quota usage
- Testing confirms quota enforcement works
- Integration with billing and subscription systems

### Feature 6.3: Webhook Delivery
This feature implements webhook notification capabilities. It includes creating webhook payload construction logic, implementing an HTTP client with retry capabilities, building response handling and validation, implementing webhook security through signing and authentication, and creating webhook delivery monitoring tools.

#### Story 6.3.1: Implement webhook payload construction

**Description:**
Create a system for constructing webhook payloads based on template definitions, including variable substitution, formatting, and validation. This should generate properly structured JSON payloads ready for delivery to webhook endpoints.

**Acceptance Criteria:**
- Webhook payload construction service
- JSON payload generation from templates
- Variable substitution in payload structure
- Support for nested JSON structures
- Template validation before payload construction
- Error handling for payload construction failures
- Size limit validation for payloads
- JSON schema validation if applicable
- Default fields added to all webhooks (timestamp, event type)
- Custom HTTP headers support
- Logging of payload construction (excluding sensitive data)
- Unit tests verifying correct payload construction
- Performance optimization for large payloads
- Documentation of payload construction
- Testing with various template complexities
- Support for different content types if needed

#### Story 6.3.2: Create webhook HTTP client with retry logic

**Description:**
Implement a specialized HTTP client for webhook delivery that includes robust retry logic, timeout handling, and connection management optimized for reliable webhook delivery.

**Acceptance Criteria:**
- HTTP client for webhook delivery
- Configurable timeout settings
- Retry logic with exponential backoff
- Maximum retry attempts configuration
- Circuit breaker pattern for failing endpoints
- Connection pooling for performance
- TLS/SSL handling and validation
- Proxy support if required
- Request and response compression handling
- Logging of request/response cycles
- Performance metrics collection
- Unit tests for retry behavior
- Integration tests with mock endpoints
- Documentation of client configuration
- Testing confirms reliable delivery under various conditions
- Configurable per-tenant settings

#### Story 6.3.3: Build webhook response handling and validation

**Description:**
Implement functionality to process webhook responses, validate success, and handle various error conditions. This should include parsing response data, status code handling, and determining whether a delivery was successful.

**Acceptance Criteria:**
- Response status code interpretation
- Success criteria configuration (2xx, specific codes)
- Response body validation if required
- Response time tracking
- Error categorization (server error, client error, timeout)
- Retry decision based on error type
- Response data extraction for tracking
- Integration with NotificationTracking system
- Customizable success criteria per webhook
- Logging of response handling
- Unit tests for various response scenarios
- Documentation of response handling
- Testing with various response types
- Performance optimization for response processing
- Security validation of responses

#### Story 6.3.4: Implement webhook security (signing, auth)

**Description:**
Create security mechanisms for webhook delivery, including payload signing, authentication options, and other measures to ensure webhooks are secure both for CommuniQueue as a sender and for recipients of webhook data.

**Acceptance Criteria:**
- Webhook payload signing using HMAC
- Signature included in HTTP headers
- Signing key management per tenant/endpoint
- Basic auth support for webhook endpoints
- Bearer token support for webhook endpoints
- API key support in headers or query parameters
- IP allowlisting capabilities
- Documentation for recipients on verification
- Security settings configuration UI
- Encryption of sensitive payload data if required
- Secure storage of authentication credentials
- Validation before sending to ensure security requirements
- Logging of security-related events
- Testing confirms security mechanisms work correctly
- Documentation of security best practices

#### Story 6.3.5: Create webhook delivery monitoring

**Description:**
Implement monitoring tools for webhook deliveries to track reliability, performance, and issues with webhook endpoints. This should provide visibility into webhook delivery operations and help identify problematic endpoints.

**Acceptance Criteria:**
- Webhook delivery dashboard
- Success/failure rate metrics by endpoint
- Response time tracking and reporting
- Failure categorization and analysis
- Endpoint reliability scoring
- Alerting for problematic endpoints
- Historical delivery data with filtering
- Webhook testing tool from UI
- Payload and response inspection
- Export capability for delivery logs
- Integration with general system monitoring
- Real-time delivery tracking
- Documentation of monitoring tools
- Testing confirms monitoring accuracy
- Performance optimization for high-volume monitoring

### Feature 6.4: Message Queue Integration
This feature implements message queueing for asynchronous notification processing. It includes setting up AWS SQS integration, implementing message enqueuing for send operations, creating a worker service that consumes from the queue, handling dead letter queues for failed messages, and implementing queue monitoring and scaling capabilities.

#### Story 6.4.1: Set up AWS SQS integration

**Description:**
Implement integration with AWS Simple Queue Service (SQS) for reliable message queueing. This includes setting up queues, configuring access, and establishing the connection between the application and SQS.

**Acceptance Criteria:**
- AWS SQS client implemented using AWS SDK
- Configuration for queue URLs and credentials
- Secure storage of AWS credentials
- Main processing queue configuration
- Exception handling for SQS API errors
- Retry logic for transient failures
- Logging of queue operations
- Message serialization/deserialization
- Unit tests with mock SQS client
- Integration tests with local queue (like localstack)
- Documentation of SQS integration
- Proper IAM permissions configuration
- Queue creation automation in infrastructure
- Performance testing under load
- Metrics collection for queue operations

#### Story 6.4.2: Implement message enqueuing for send operations

**Description:**
Create the system for enqueuing notification send requests into the message queue. This should handle message formatting, prioritization, and ensuring all necessary data is included for asynchronous processing.

**Acceptance Criteria:**
- Message enqueuing service for notifications
- Message format definition with all required data
- Variable data inclusion in queued messages
- Priority setting for different message types
- Tenant isolation in message data
- Duplicate detection and handling
- Message grouping for related notifications
- Message ID generation and tracking
- Correlation ID for end-to-end tracking
- Error handling for enqueue failures
- Logging of enqueue operations
- Unit tests for enqueuing functionality
- Performance testing for high-volume enqueueing
- Documentation of message format
- Testing confirms all necessary data is included
- Size limit handling for large messages

#### Story 6.4.3: Create worker service consumer for queue

**Description:**
Implement a worker service that consumes messages from the queue and processes them. This service should handle message retrieval, processing, deletion, and managing concurrency for efficient operation.

**Acceptance Criteria:**
- Worker service implementation for SQS consumption
- Message polling with appropriate frequency
- Message deserialization and validation
- Processing pipeline for different message types
- Concurrency management for parallel processing
- Message visibility timeout handling
- Message deletion after successful processing
- Error handling during message processing
- Logging of processing operations
- Health check endpoint for monitoring
- Graceful shutdown handling
- Unit tests for worker service logic
- Integration tests with queue and processors
- Documentation of worker service
- Performance optimization for throughput
- Resource utilization monitoring

#### Story 6.4.4: Build dead letter queue handling

**Description:**
Implement a dead letter queue (DLQ) system for handling messages that fail processing repeatedly. This should include routing failed messages to a separate queue, monitoring DLQ contents, and providing mechanisms for reprocessing or analyzing failed messages.

**Acceptance Criteria:**
- Dead letter queue configuration in AWS SQS
- Failed message routing to DLQ after retry exhaustion
- Message metadata enrichment for failure analysis
- DLQ monitoring and alerting
- UI for viewing DLQ contents
- Manual reprocessing capability for DLQ messages
- Failure analysis tools for understanding issues
- Purge capability for clearing DLQ
- Logging of DLQ operations
- Regular reporting on DLQ status
- Documentation of DLQ handling procedures
- Testing confirms messages correctly route to DLQ
- Integration with notification system for DLQ alerts
- Performance considerations for DLQ operations
- Security controls for DLQ management

#### Story 6.4.5: Implement queue monitoring and scaling

**Description:**
Create a comprehensive monitoring system for message queues that tracks queue depth, processing rates, and other metrics. This should include alerting for abnormal conditions and support for scaling decisions based on queue metrics.

**Acceptance Criteria:**
- Queue depth monitoring
- Message age/delay monitoring
- Processing rate tracking
- Error rate monitoring
- Alerting for queue backlogs
- Alerting for processing delays
- Dashboard for queue health visualization
- Historical metrics for trend analysis
- Auto-scaling integration if applicable
- Manual scaling controls
- Documentation of monitoring metrics
- Integration with overall system monitoring
- Performance impact minimization of monitoring
- Testing confirms accurate metric collection
- Tenant-specific queue metrics where applicable

### Feature 6.5: Background Processing
This feature implements the background processing system for notification delivery. It includes creating the background worker service architecture, implementing message retrieval and processing logic, building retry and backoff strategies for transient failures, creating failure handling and reporting mechanisms, and implementing worker scaling and monitoring.

#### Story 6.5.1: Create background worker service architecture

**Description:**
Design and implement the overall architecture for the background worker service that will process queued notification requests. This includes the service structure, processing pipeline, and integration with other components of the system.

**Acceptance Criteria:**
- Worker service project structure established
- Processing pipeline architecture defined
- Component registration and dependency injection
- Hosted service implementation
- Configuration system for worker settings
- Startup and shutdown handling
- Health check implementation
- Logging framework integration
- Performance counters and metrics
- Documentation of architecture
- Testing infrastructure for the worker
- Local development setup
- Containerization support
- Environment-specific configuration
- Integration points with other services clearly defined

#### Story 6.5.2: Implement message retrieval and processing

**Description:**
Create the core message processing functionality that retrieves messages from the queue and processes them according to their type and content. This should include dispatching to the appropriate handlers for different notification types.

**Acceptance Criteria:**
- Message retrieval from queue
- Message type determination
- Routing to appropriate processor (email, SMS, webhook)
- Variable substitution and template rendering
- NotificationTracking record creation/update
- Payload construction for each notification type
- Provider API client invocation
- Response handling and status recording
- Message completion and deletion from queue
- Correlation ID propagation throughout processing
- Logging of processing steps
- Performance metrics for processing time
- Unit tests for processing logic
- Integration tests for end-to-end processing
- Documentation of processing flow

#### Story 6.5.3: Build retry and backoff strategies

**Description:**
Implement sophisticated retry logic with backoff strategies for handling transient failures during notification delivery. This should maximize delivery success while avoiding overwhelming external services during issues.

**Acceptance Criteria:**
- Retry strategy implementation for failed deliveries
- Exponential backoff algorithm
- Maximum retry attempts configuration
- Retry delay calculation
- Failure type categorization (retriable vs. permanent)
- Retry count tracking per message
- Different strategies for different providers/errors
- Circuit breaker pattern implementation
- Jitter addition to prevent thundering herd
- Retry state persistence across service restarts
- Logging of retry attempts and outcomes
- Documentation of retry strategies
- Unit tests for backoff algorithms
- Integration tests for retry behavior
- Performance impact analysis of retries

#### Story 6.5.4: Create failure handling and reporting

**Description:**
Implement comprehensive failure handling for notification processing, including permanent failure detection, error categorization, and reporting mechanisms to provide visibility into delivery issues.

**Acceptance Criteria:**
- Permanent failure detection logic
- Error categorization framework
- Detailed error information capture
- Error reporting dashboard
- Failure notifications for critical errors
- Error pattern detection and analysis
- Feedback to notification senders on failures
- NotificationTrackingDebug record creation
- Export capability for error reports
- Documentation of common errors and resolutions
- Testing of failure handling paths
- Performance considerations for error processing
- Integration with monitoring systems
- Security considerations for error data
- Tenant isolation in error reporting

#### Story 6.5.5: Implement worker scaling and monitoring

**Description:**
Create systems for monitoring worker performance and implementing scaling capabilities to handle varying loads. This should ensure the background processing system can efficiently handle both low and high volume periods.

**Acceptance Criteria:**
- Worker performance monitoring
- Processing rate metrics
- Resource utilization tracking (CPU, memory)
- Queue backlog monitoring
- Auto-scaling configuration (if applicable)
- Manual scaling controls
- Worker instance health monitoring
- Alerting for abnormal conditions
- Dashboard for worker status visualization
- Predictive scaling based on patterns (if applicable)
- Documentation of scaling architecture
- Testing under various load conditions
- Performance optimization recommendations
- Cost efficiency considerations
- Tenant isolation in processing resources (if applicable)

## Epic 7: Notification Tracking

**Description:**  
Notification Tracking is the visibility and assurance layer of CommuniQueue. This epic tracks every message—its journey, recipient-level delivery status, failures, and associated debug context. The system surfaces analytics, alerting, and export capabilities to enable troubleshooting, compliance, and performance optimization. Built-in data retention and anonymization supports privacy by design, while still preserving critical metrics. Notification tracking is the bridge from “send and hope” to “send and know,” empowering users to demonstrate efficacy, debug issues, and meet SLAs or legal requirements.

**Why:**  
- Transforms notification sending from a blind push to a trackable, auditable workflow.
- Enables rapid issue detection and resolution (why did this fail?).
- Fuels user trust and supports external compliance/audit needs (GDPR, SOC2).
- Supports future advanced analytics, billing, and performance tuning.

**What Success Looks Like:**  
- Users and admins can diagnose message delivery in real-time or historically.
- Regulatory or support audits can be handled quickly, with evidence.
- A/B testing, engagement tracking, and optimization are all straightforward and accurate.

### Feature 7.1: Notification Status Tracking
This feature implements tracking for notification delivery status. It includes creating the NotificationTracking entity model, generating tracking records when notifications are sent, implementing status update mechanisms based on provider callbacks, building status query and filtering capabilities, and creating notification history view components.

#### Story 7.1.1: Implement NotificationTracking entity model

**Description:**
Design and implement the NotificationTracking entity model that will store comprehensive information about notification sends and their delivery status. This model will serve as the foundation for all notification tracking capabilities in the system.

**Acceptance Criteria:**
- NotificationTracking entity class implemented according to design document
- Database migration created for NotificationTracking table
- GUID v7 primary key implemented for NotificationTracking entities
- Foreign key relationships to Tenant, Template, and TemplateVersion
- NotificationType enum field (Email, SMS, Webhook)
- StateType enum field for tracking delivery status
- UsageType enum field (Transactional, Marketing)
- IsTest flag to distinguish test sends from production
- Subject, Body, and From fields to store point-in-time content
- Created/Updated timestamp fields implemented
- Appropriate indexes for efficient querying
- Repository pattern implemented for NotificationTracking access
- Integration tests verify proper database schema and relationships
- Documentation of entity model and relationships
- Performance considerations for high-volume tracking

#### Story 7.1.2: Create tracking record generation on send

**Description:**
Implement the system for automatically generating NotificationTracking records whenever a notification is sent. This ensures that all notification activity is properly recorded for status tracking, analytics, and compliance purposes.

**Acceptance Criteria:**
- Automatic tracking record creation during send process
- Unique tracking ID generation for each notification
- Capture of all relevant metadata (template, version, type)
- Storage of point-in-time notification content
- Correlation with sending user/process
- Initial status set appropriately (Queued/Sending)
- Integration with notification sending pipeline
- Transaction management for data consistency
- Performance optimization for bulk sends
- Logging of tracking record creation
- Unit tests for tracking record generation
- Integration tests with sending process
- Documentation of tracking record creation process
- Testing confirms accurate data capture
- Handling for both API and UI-initiated sends

#### Story 7.1.3: Build status update mechanisms from providers

**Description:**
Implement the mechanisms to receive and process status updates from notification providers (SendGrid, Twilio, webhook endpoints) and update the NotificationTracking records accordingly. This ensures the tracking system has current information about the delivery status of all notifications.

**Acceptance Criteria:**
- Webhook endpoints for receiving SendGrid event callbacks
- Webhook endpoints for receiving Twilio status callbacks
- Processing logic for webhook response status updates
- Status mapping from provider-specific to system statuses
- NotificationTracking record updates with status changes
- Timestamp recording for status transitions
- Error handling for malformed callbacks
- Security validation of incoming callbacks
- Logging of all status updates
- Metrics collection for status update volume
- Unit tests for status update processing
- Integration tests with mock provider callbacks
- Documentation of status update flows
- Testing confirms accurate status updates
- Performance testing for high-volume updates

#### Story 7.1.4: Implement status query and filtering

**Description:**
Create a comprehensive query system for notification tracking records that allows searching, filtering, and sorting by various criteria. This enables users and the system to efficiently locate and analyze notification activity.

**Acceptance Criteria:**
- API endpoints for querying notification tracking records
- Filtering by status, type, date range, template
- Sorting options for query results
- Pagination for large result sets
- Performance optimization for common queries
- Support for complex filtering combinations
- Permission-based filtering (tenant isolation)
- Search capability across notification content
- Count/aggregation endpoints for analytics
- Validation of query parameters
- Error handling for invalid queries
- Documentation of query capabilities
- Unit tests for query functionality
- Integration tests for end-to-end queries
- Performance testing with large data volumes

#### Story 7.1.5: Create notification history views

**Description:**
Implement user interface components for viewing notification history, including listing views, detail views, and summary dashboards. These components should provide users with clear visibility into notification activity and delivery status.

**Acceptance Criteria:**
- Notification history listing page with filtering
- Detail view for individual notification tracking records
- Status indicators with clear visual differentiation
- Date range picker for history filtering
- Search functionality within history view
- Sorting options (date, status, type)
- Pagination for large history lists
- Performance optimization for history views
- Real-time or near-real-time updates for status changes
- Export functionality for notification history
- Mobile-responsive design
- Accessibility compliance for all components
- Integration with recipient and debug information
- Testing confirms history views display correctly
- User feedback indicates history is clear and useful

### Feature 7.2: Recipient Tracking
This feature implements detailed tracking for individual recipients. It includes creating the TrackingRecipient entity model, implementing recipient-level status tracking, building per-recipient delivery status updates, implementing recipient filtering and search, and creating recipient-level analytics for delivery performance.

#### Story 7.2.1: Implement TrackingRecipient entity model

**Description:**
Design and implement the TrackingRecipient entity model that will track delivery status for individual recipients of notifications. This model extends the notification tracking system to provide granular status information at the recipient level.

**Acceptance Criteria:**
- TrackingRecipient entity class implemented according to design document
- Database migration created for TrackingRecipient table
- GUID v7 primary key implemented for TrackingRecipient entities
- Foreign key relationship to NotificationTracking
- RecipientType enum field (To, CC, BCC, SMS, etc.)
- Value field for storing recipient address/number
- Status field for recipient-specific delivery status
- Created/Updated timestamp fields implemented
- Appropriate indexes for efficient querying
- Repository pattern implemented for TrackingRecipient access
- Integration tests verify proper database schema and relationships
- Documentation of entity model and relationships
- Performance considerations for high-volume tracking
- Testing confirms model captures all required recipient data
- Privacy considerations for PII data

#### Story 7.2.2: Create recipient status tracking

**Description:**
Implement the system for tracking delivery status at the individual recipient level. This includes status initialization, updates based on provider feedback, and maintaining an accurate record of delivery outcome for each recipient.

**Acceptance Criteria:**
- Initial status creation for each recipient during send
- Status field with appropriate states (Sent, Delivered, Failed, etc.)
- Status update logic based on provider callbacks
- Support for provider-specific status values
- Timestamp tracking for status changes
- Error code/reason capture for failed deliveries
- Correlation between NotificationTracking and recipient statuses
- Transaction management for status updates
- Performance optimization for bulk updates
- Logging of status changes for audit purposes
- Unit tests for status tracking logic
- Integration tests with provider callbacks
- Documentation of recipient status workflow
- Testing confirms accurate status tracking
- Handling of edge cases (unknown recipients, etc.)

#### Story 7.2.3: Build per-recipient delivery status updates

**Description:**
Create the mechanisms to process delivery status updates at the recipient level based on provider callbacks. This should correctly map provider-specific status information to the system's recipient tracking model and ensure timely updates.

**Acceptance Criteria:**
- Processing logic for recipient-level status callbacks
- Mapping of provider-specific statuses to system statuses
- Recipient identification in callbacks
- Handling for grouped/batch status updates
- Error handling for unmatched recipients
- TrackingRecipient record updates with status changes
- Timestamp recording for status transitions
- Metrics collection for status update volume
- Unit tests for status update processing
- Integration tests with mock provider callbacks
- Documentation of status update flows
- Testing confirms accurate status updates
- Performance testing for high-volume updates
- Handling of out-of-order status updates
- Security validation of incoming callbacks

#### Story 7.2.4: Implement recipient filtering and search

**Description:**
Create a comprehensive query system for recipient tracking records that allows searching, filtering, and sorting by various criteria. This enables users to efficiently locate and analyze delivery outcomes for specific recipients or groups of recipients.

**Acceptance Criteria:**
- API endpoints for querying recipient tracking records
- Filtering by status, type, date range, notification
- Filtering by recipient address/number
- Sorting options for query results
- Pagination for large result sets
- Performance optimization for common queries
- Support for complex filtering combinations
- Permission-based filtering (tenant isolation)
- Search capability across recipient data
- Count/aggregation endpoints for analytics
- Validation of query parameters
- Error handling for invalid queries
- Documentation of query capabilities
- Unit tests for query functionality
- Integration tests for end-to-end queries
- Performance testing with large data volumes

#### Story 7.2.5: Create recipient-level analytics

**Description:**
Implement analytics capabilities focused on recipient-level delivery performance. This provides insights into delivery success rates for different recipients, domains, or regions, helping users identify and address delivery issues.

**Acceptance Criteria:**
- Recipient success/failure rate calculations
- Domain-based delivery analytics for email
- Region-based delivery analytics for SMS
- Time-based analysis of recipient delivery trends
- Identification of problematic recipients/domains
- Comparison views across different recipient segments
- Data visualizations for recipient analytics
- Export functionality for recipient analytics
- Integration with notification analytics
- Performance optimization for analytics queries
- Documentation of analytics capabilities
- Testing confirms analytics accuracy
- Privacy considerations for recipient data
- UI components for viewing recipient analytics
- Filtering and time range selection for analytics

### Feature 7.3: Debug Information
This feature implements detailed debugging information for troubleshooting. It includes creating the NotificationTrackingDebug entity model, capturing provider-specific debug information, building UI components for exploring debug data, implementing debug information search and filtering, and creating debug information export capabilities.

#### Story 7.3.1: Implement NotificationTrackingDebug entity model

**Description:**
Design and implement the NotificationTrackingDebug entity model that will store detailed debugging information about notification delivery. This model provides deep insights for troubleshooting delivery issues by capturing provider-specific responses and error details.

**Acceptance Criteria:**
- NotificationTrackingDebug entity class implemented according to design document
- Database migration created for NotificationTrackingDebug table
- GUID v7 primary key implemented for NotificationTrackingDebug entities
- Foreign key relationship to NotificationTracking
- DebugInfo field using JSONB type for flexible storage
- ProviderType enum field to identify the source (SendGrid, Twilio, etc.)
- DeliveryStatus enum for tracking detailed status
- AttemptCount field to track retry attempts
- Created/Updated timestamp fields implemented
- Appropriate indexes for efficient querying
- Repository pattern implemented for NotificationTrackingDebug access
- Integration tests verify proper database schema
- Documentation of entity model and usage
- Performance considerations for large debug data
- Privacy controls for sensitive debug information

#### Story 7.3.2: Create provider-specific debug information capture

**Description:**
Implement systems to capture detailed debugging information from each notification provider, including request details, responses, error codes, and delivery attempt information. This information is critical for troubleshooting delivery issues.

**Acceptance Criteria:**
- Debug information capture for SendGrid responses
- Debug information capture for Twilio responses
- Debug information capture for webhook delivery
- Request payload logging (with PII redaction)
- Response body and headers capture
- Error code and message extraction
- Retry and attempt information recording
- Timestamp recording for each debugging event
- Integration with notification sending pipeline
- Performance impact minimization
- Storage optimization for large debug data
- Privacy protection for sensitive information
- Unit tests for debug capture logic
- Integration tests with mock provider responses
- Documentation of debug information captured per provider

#### Story 7.3.3: Build debug information UI and exploration tools

**Description:**
Create user interface components for exploring and analyzing debug information related to notification delivery. These tools help users understand delivery issues and troubleshoot problems with specific notifications.

**Acceptance Criteria:**
- Debug information view in notification detail page
- Formatted display of JSON debug data
- Collapsible sections for different debug information types
- Visual indicators for errors vs. successes
- Timeline view of delivery attempts
- Provider-specific information formatting
- Raw data view option for advanced users
- Search within debug information
- Mobile-responsive design
- Accessibility compliance for debug UI
- Performance optimization for rendering large debug data
- User permission checks for accessing debug information
- Testing confirms debug UI displays correctly
- Usability testing with support/troubleshooting staff
- Documentation of debug UI usage

#### Story 7.3.4: Implement debug information search and filtering

**Description:**
Create a comprehensive query system for debug information that allows searching, filtering, and sorting by various criteria. This enables efficient troubleshooting of delivery issues across multiple notifications.

**Acceptance Criteria:**
- API endpoints for querying debug information
- Filtering by provider, status, date range, notification
- Filtering by error codes/types
- Full-text search within debug information
- Sorting options for query results
- Pagination for large result sets
- Performance optimization for debug queries
- Support for complex filtering combinations
- Permission-based filtering (tenant isolation)
- Validation of query parameters
- Error handling for invalid queries
- Documentation of query capabilities
- Unit tests for query functionality
- Integration tests for end-to-end queries
- Performance testing with large debug datasets

#### Story 7.3.5: Create debug information export

**Description:**
Implement functionality to export debug information for offline analysis, sharing with support teams, or archiving purposes. This allows for more detailed investigation of complex delivery issues.

**Acceptance Criteria:**
- Export functionality for debug information
- Multiple format options (JSON, CSV)
- Batch export for multiple notifications
- PII redaction options for exports
- Progress indicator for large exports
- Download mechanism for completed exports
- Email notification for large export completion
- Storage management for exports
- Export history tracking
- Permission checks for export operations
- Documentation of export functionality
- Testing confirms exports contain complete data
- Performance testing for large exports
- Security validation of exported data
- Retention policy for stored exports

### Feature 7.4: Data Retention
This feature implements data retention policies for compliance and resource management. It includes implementing retention policy enforcement, creating data purging mechanisms for expired data, building PII anonymization for expired records, implementing retention extension for paid subscription tiers, and creating retention policy management interfaces.

#### Story 7.4.1: Implement retention policy enforcement

**Description:**
Create a system for defining and enforcing data retention policies for notification tracking data. This ensures compliance with data protection regulations and optimizes storage usage by removing data that is no longer needed.

**Acceptance Criteria:**
- Retention policy configuration model
- Default retention period implementation (3 days)
- Tenant-specific retention period support
- Policy evaluation logic to identify expired data
- Integration with subscription plan limits
- Retention period calculation from send date
- Exception handling for retention-protected records
- Audit logging of retention policy enforcement
- Metrics collection for expired data
- Documentation of retention policies
- Unit tests for retention period calculations
- Integration tests for policy enforcement
- Performance testing with large datasets
- Compliance documentation for data retention
- Testing confirms expired data is correctly identified

#### Story 7.4.2: Create data purging mechanisms

**Description:**
Implement the mechanisms to safely purge expired notification tracking data from the system. This includes both scheduled background jobs and on-demand purging capabilities with appropriate safeguards.

**Acceptance Criteria:**
- Background job for regular data purging
- On-demand purge capability for administrators
- Batch processing for efficient purging
- Transaction management for data consistency
- Error handling and retry logic
- Purge preview functionality showing affected data
- Confirmation requirements for manual purges
- Audit logging of all purge operations
- Metrics collection for purged data volume
- Integration with retention policy enforcement
- Performance optimization for large purges
- Database impact minimization during purging
- Documentation of purging mechanisms
- Testing confirms data is correctly purged
- Validation to prevent accidental data loss

#### Story 7.4.3: Build PII anonymization for expired records

**Description:**
Implement functionality to anonymize personally identifiable information (PII) in notification records that have reached their retention limit but need to be retained for analytics or other purposes. This balances privacy requirements with operational needs.

**Acceptance Criteria:**
- PII identification in notification records
- Anonymization algorithm for recipient information
- Selective field anonymization (keep non-PII intact)
- Irreversible anonymization technique
- Anonymization process integrated with purging
- Visual indicators for anonymized records in UI
- Audit logging of anonymization operations
- Documentation of anonymization approach
- Unit tests for anonymization logic
- Integration tests for anonymization process
- Compliance validation for anonymization
- Performance testing for bulk anonymization
- Option to fully delete vs. anonymize
- Testing confirms PII is properly anonymized
- Validation that analytics still work with anonymized data

#### Story 7.4.4: Implement retention extension for paid tiers

**Description:**
Create functionality to extend data retention periods for paid subscription tiers. This allows premium customers to retain their notification tracking data for longer periods as a value-added service.

**Acceptance Criteria:**
- Subscription plan integration for retention periods
- Tier-based retention period configuration
- Upgrade path for extending retention
- Retention period enforcement based on subscription
- UI indicators for retention period per tenant
- Warning notifications for approaching retention limits
- Option to upgrade before data expiration
- Retention extension pricing information
- Documentation of retention options by plan
- Testing confirms extended retention works correctly
- Upgrade process testing for retention extension
- Downgrade handling (what happens to older data)
- Integration with billing system
- Performance impact analysis for extended retention
- Storage cost considerations and monitoring

#### Story 7.4.5: Create retention policy management UI

**Description:**
Implement user interface components for managing retention policies, viewing retention status, and initiating manual purge operations. This gives administrators visibility and control over the data retention process.

**Acceptance Criteria:**
- Retention policy management page for administrators
- Current retention settings display
- Retention policy editing (for authorized users)
- Data volume metrics by age
- Expiration preview showing upcoming purges
- Manual purge controls with confirmation
- Retention history and audit log
- Filter and search for retention-related events
- Export capability for retention logs
- Mobile-responsive design
- Accessibility compliance for all components
- Permission checks for retention management
- Documentation of retention management UI
- Testing confirms management functions work correctly
- Usability testing with administrators

### Feature 7.5: Notification Analytics
This feature implements basic analytics for notification performance. It includes creating delivery statistics calculations, implementing success/failure rate tracking, building time-based delivery metrics, implementing analytics data persistence for long-term reporting, and creating analytics dashboard components for visualization.

#### Story 7.5.1: Implement basic delivery statistics calculation

**Description:**
Create the core statistical calculations for notification delivery performance, including counts, rates, and aggregations. These statistics form the foundation of the analytics system and provide key insights into notification effectiveness.

**Acceptance Criteria:**
- Total sent count calculation by notification type
- Delivery success count and rate calculation
- Failure count and rate calculation with categorization
- Bounce/rejection statistics for email
- Delivery time statistics (average, median, percentiles)
- Click and open tracking for emails (if applicable)
- Calculation engine with caching for performance
- Real-time vs. aggregated statistics options
- Tenant isolation in statistical calculations
- Filtering capability by date, type, template
- Unit tests for statistical calculations
- Documentation of calculation methodologies
- Performance testing for large datasets
- Accuracy validation of statistical results
- Integration with tracking data system

#### Story 7.5.2: Create success/failure rate tracking

**Description:**
Implement specialized tracking for success and failure rates, including trend analysis, comparative metrics, and detailed breakdown of failure reasons. This helps users identify and address delivery issues affecting their notifications.

**Acceptance Criteria:**
- Success/failure rate calculation by time period
- Trend analysis for rate changes over time
- Comparative metrics against benchmarks
- Detailed failure categorization and tracking
- Provider-specific failure code analysis
- Domain/recipient pattern analysis for failures
- Alerting for abnormal failure rates
- Recommendation engine for addressing common failures
- Filtering and grouping of rate data
- Export capability for rate data
- Documentation of rate calculations
- Unit tests for rate tracking logic
- Integration tests with tracking data
- Performance optimization for rate calculations
- UI components for displaying rate information

#### Story 7.5.3: Build time-based delivery metrics

**Description:**
Create time-based metrics and analysis for notification delivery, including time-to-delivery tracking, time-of-day analysis, and historical trend reporting. These metrics provide insights into delivery performance over time and help optimize sending patterns.

**Acceptance Criteria:**
- Time-to-delivery tracking and reporting
- Time-of-day effectiveness analysis
- Day-of-week performance tracking
- Historical trend analysis over time periods
- Peak vs. off-peak performance comparison
- Time zone consideration in metrics
- Calendar heatmaps for visual time analysis
- Anomaly detection in time-based patterns
- Recommended sending time analysis
- Filtering by date ranges and time periods
- Export capability for time-based metrics
- Documentation of time metrics methodology
- Testing confirms accurate time calculations
- Performance optimization for time-series data
- UI components for time-based visualizations

#### Story 7.5.4: Implement analytics data persistence

**Description:**
Create a system for persisting analytics data long-term, even after detailed notification records have been purged or anonymized. This ensures historical analytics remain available for trend analysis and reporting without compromising privacy or storage efficiency.

**Acceptance Criteria:**
- Analytics aggregation model for long-term storage
- Scheduled aggregation jobs for data summarization
- Retention of analytics data beyond notification detail retention
- Privacy-compliant storage (no PII in long-term analytics)
- Data resolution management (daily, weekly, monthly aggregates)
- Storage efficiency optimization
- Data consistency validation during aggregation
- Backfill capability for historical data
- Integration with retention and purging systems
- Documentation of analytics data model
- Unit tests for aggregation logic
- Performance testing for aggregation jobs
- Testing confirms analytics persist after detail purging
- Validation of aggregated data accuracy
- API endpoints for querying historical analytics

#### Story 7.5.5: Create analytics dashboard and visualization

**Description:**
Implement comprehensive dashboard and visualization components for notification analytics. These should provide clear, actionable insights into notification performance through charts, graphs, and interactive displays.

**Acceptance Criteria:**
- Analytics dashboard with key performance indicators
- Delivery success/failure visualizations
- Time-based trend charts
- Comparative performance metrics
- Drill-down capability for detailed analysis
- Filtering by date range, notification type, template
- Interactive charts with tooltips and explanations
- Export functionality for charts and data
- Print-friendly dashboard layouts
- Mobile-responsive design
- Accessibility compliance for all visualizations
- Real-time or near-real-time data updates
- Performance optimization for dashboard rendering
- User preference saving for dashboard configuration
- Documentation of dashboard features and usage
- Usability testing with end users

## Epic 8: Subscription & Billing

**Description:**  
Subscription & Billing governs the commercial core of CommuniQueue. This epic implements tiered subscription plans, usage quotas, billing cycles, and coupon/promotion mechanisms—enabling the business model. It supports per-tenant entitlements, granular plan features, enterprise-grade exceptions (custom contracts), and robust usage accounting. By designing for flexibility (versioned plans, overrides, and discounts), CommuniQueue can sell to SMBs and large enterprises, adapt to market feedback, and experiment with pricing without code risk. Auditability and upgrade/downgrade flows are central, so every price or entitlement change is traceable, and the customer experience remains smooth.

**Why:**  
- Unlocks monetization options: SaaS, tiered pricing, self-service upgrades, enterprise sales.
- Enables tight control over system load and cost exposure (quotas, limits).
- Provides levers for sales growth (promotion campaigns, feature gating, account expansion).
- Ensures every transaction is trackable and defensible for revenue and compliance.

**What Success Looks Like:**  
- Users can self-serve upgrades/downgrades, and billing is transparent and fair.
- Admins can create exceptions for strategic accounts without complex manual workarounds.
- Overuse, abuse, and billing disputes are rare and quickly addressable.
- All financial flows are reportable, auditable, and support business growth.

### Feature 8.1: Subscription Plans
This feature implements the subscription plan framework. It includes creating the SubscriptionPlan entity model, implementing tiered plan definitions (Free/Standard/Plus/Premium/Enterprise), building the plan feature matrix for capability control, implementing plan versioning and management, and handling plan effective dates for transitions.

#### Story 8.1.1: Implement SubscriptionPlan entity model

**Description:**
Design and implement the SubscriptionPlan entity model that will define the subscription offerings available in the system. This model will serve as the foundation for the entire subscription and billing system, supporting different tiers and capabilities.

**Acceptance Criteria:**
- SubscriptionPlan entity class implemented according to design document
- Database migration created for SubscriptionPlan table
- GUID v7 primary key implemented for SubscriptionPlan entities
- Fields for plan name, description, tier (enum), and pricing
- PricePerMonth and PricePerYear fields for different billing cycles
- Fields for capability limits (AllowedTenants, AllowedProjects, etc.)
- Email and API usage limit fields
- RetentionDays field for data retention configuration
- EffectiveFrom and EffectiveTo date fields for plan versioning
- Appropriate indexes for efficient querying
- Repository pattern implemented for SubscriptionPlan access
- Integration tests verify proper database schema and relationships
- Documentation of entity model and field purposes
- Performance considerations for plan lookup
- Testing confirms model correctly stores all plan attributes

#### Story 8.1.2: Create tiered plan definition (Free/Standard/Plus/Premium/Enterprise)

**Description:**
Implement the predefined subscription tiers (Free, Standard, Plus, Premium, Enterprise) with their specific feature sets, limits, and pricing. Each tier should offer a clear value proposition with distinct capabilities and constraints.

**Acceptance Criteria:**
- Default plans created for each tier (Free, Standard, Plus, Premium, Enterprise)
- Clear differentiation of features/limits between tiers
- Free tier with basic functionality and strict limits
- Standard tier with essential features for small organizations
- Plus tier with expanded capabilities for growing organizations
- Premium tier with advanced features for power users
- Enterprise tier as a customizable framework
- Price points established for each paid tier
- Monthly and annual pricing options (with annual discount)
- Feature matrix defined for each tier
- Limit values configured (templates, projects, sends, etc.)
- Retention periods configured per tier
- API rate limits defined per tier
- UI to display plan comparison
- Documentation of plan tiers and included features
- Testing confirms all tiers function with correct limits
- Database seeding for default plan tiers

#### Story 8.1.3: Build plan feature matrix implementation

**Description:**
Create the system that maps subscription plans to specific features and capabilities. This matrix should control which features are available to users based on their subscription tier and enforce appropriate limits.

**Acceptance Criteria:**
- Feature flag system based on subscription tier
- Dynamic capability check methods for feature access
- Limit enforcement based on subscription tier
- Feature matrix configuration in database or code
- API for checking feature availability
- Extensible design for adding new features
- Documentation of all features and their tier availability
- Admin interface for viewing feature matrix
- Caching strategy for feature checks
- Unit tests for feature flag system
- Integration tests with different subscription tiers
- Performance optimization for frequent feature checks
- Documentation of how to add new features to matrix
- Testing confirms features correctly enabled/disabled by tier
- Graceful handling of deprecated features

#### Story 8.1.4: Implement plan management and versioning

**Description:**
Create the administrative functionality for managing subscription plans, including creating new plans, updating existing plans, and versioning plans to handle changes over time. This ensures the subscription system can evolve without disrupting existing subscribers.

**Acceptance Criteria:**
- Admin interface for managing subscription plans
- Create, read, update operations for plans
- Plan versioning system using effective dates
- Prevention of direct plan deletion (use effective dates instead)
- Validation rules for plan changes
- Plan cloning functionality for creating variations
- Plan comparison tools for administrators
- Audit logging of plan changes
- Preview capability for plan changes
- Impact analysis for plan modifications
- Documentation of plan management procedures
- Unit tests for plan versioning logic
- Integration tests for plan management
- Performance considerations for plan queries
- Testing confirms versioning correctly handles transitions
- Safeguards against breaking changes for existing subscribers

#### Story 8.1.5: Create plan effective date handling

**Description:**
Implement functionality to manage the effective dates of subscription plans, ensuring that the correct plan version is used at any given time and that transitions between plan versions occur smoothly.

**Acceptance Criteria:**
- Effective date range enforcement in plan queries
- Logic to find the currently effective plan version
- Handling for future plan versions
- Transition handling when plans expire or change
- Notification system for upcoming plan changes
- Overlap prevention in effective date ranges
- Default plan fallback if no effective plan found
- Historical plan version access for reporting
- Documentation of effective date behavior
- Unit tests for date range logic
- Integration tests for plan transitions
- Performance optimization for date-based queries
- Testing confirms correct plan selection based on date
- Administrator alerts for expiring plans
- Reporting on upcoming plan transitions

### Feature 8.2: Tenant Subscriptions
This feature associates subscriptions with tenants. It includes implementing the TenantSubscription entity model, creating subscription assignment mechanisms, tracking subscription periods, implementing subscription status management, and maintaining subscription history for auditing.

#### Story 8.2.1: Implement TenantSubscription entity model

**Description:**
Design and implement the TenantSubscription entity model that associates subscription plans with tenants. This model tracks which plan a tenant is subscribed to and manages the subscription lifecycle.

**Acceptance Criteria:**
- TenantSubscription entity class implemented according to design document
- Database migration created for TenantSubscription table
- GUID v7 primary key implemented for TenantSubscription entities
- Foreign key relationships to Tenant and SubscriptionPlan
- StartDate and EndDate fields for subscription period
- IsActive flag for subscription status
- FinalPricePerMonth field for price after discounts
- CouponCode field for tracking applied promotions
- EnterpriseOverridesId foreign key (nullable) for enterprise plans
- Created/Updated timestamp fields implemented
- Appropriate indexes for efficient querying
- Repository pattern implemented for TenantSubscription access
- Integration tests verify proper database schema and relationships
- Documentation of entity model and relationships
- Performance considerations for subscription lookups
- Testing confirms model correctly stores subscription data

#### Story 8.2.2: Create subscription assignment to tenants

**Description:**
Implement the functionality to assign subscription plans to tenants, including initial subscription creation, plan changes, and handling the transitions between different plans.

**Acceptance Criteria:**
- Default subscription assignment for new tenants (Free tier)
- UI for selecting and changing subscription plans
- API endpoints for subscription assignment
- Validation of tenant eligibility for selected plan
- Prorated billing calculation for mid-period changes
- Confirmation workflow for plan changes
- Email notifications for subscription changes
- Subscription change audit logging
- Transaction management for subscription changes
- Handling for subscription upgrades and downgrades
- Documentation of subscription assignment process
- Unit tests for assignment logic
- Integration tests for subscription changes
- Performance considerations for high-volume operations
- Testing confirms subscriptions correctly assigned to tenants
- Security checks for subscription operations

#### Story 8.2.3: Build subscription period tracking

**Description:**
Implement functionality to track subscription periods, including start and end dates, renewal processing, and period-based usage accounting. This ensures accurate billing cycles and proper service delivery based on subscription status.

**Acceptance Criteria:**
- Subscription period tracking based on start/end dates
- Automatic calculation of end date based on billing cycle
- Renewal processing before subscription expiration
- Grace period configuration for expired subscriptions
- Period-based usage reset (e.g., monthly send limits)
- Pro-rated calculations for partial periods
- Notification system for upcoming renewals/expirations
- Admin dashboard for viewing subscription periods
- Reporting on active/expiring subscriptions
- Documentation of period tracking behavior
- Unit tests for period calculations
- Integration tests for renewal processing
- Performance optimization for period queries
- Testing confirms correct period tracking
- Handling of time zone considerations in period boundaries

#### Story 8.2.4: Implement subscription status management

**Description:**
Create a comprehensive system for managing subscription statuses throughout their lifecycle, including activation, deactivation, cancellation, and handling grace periods or suspended states.

**Acceptance Criteria:**
- Subscription status tracking (Active, Expired, Canceled, etc.)
- Status transition rules and workflow
- UI for managing subscription status
- API endpoints for status changes
- Automatic status updates based on payment events
- Grace period handling for payment issues
- Service access control based on subscription status
- Reactivation process for expired subscriptions
- Cancellation workflow with confirmation
- Email notifications for status changes
- Audit logging of all status changes
- Documentation of status management
- Unit tests for status transition logic
- Integration tests for status workflows
- Testing confirms status correctly affects service access
- Administrator alerts for problematic status patterns

#### Story 8.2.5: Create subscription history and audit

**Description:**
Implement a system for tracking the complete history of tenant subscriptions, including all changes, for auditing, troubleshooting, and customer support purposes.

**Acceptance Criteria:**
- Subscription history tracking for all changes
- Historical record of plan changes with timestamps
- Status change history with reasons
- Payment record association with subscription events
- Subscription history view in admin interface
- Filtering and search capabilities for history
- Export functionality for subscription history
- Retention policy for history records
- Documentation of history tracking system
- Integration with general audit logging
- Unit tests for history recording
- Performance considerations for history queries
- Testing confirms all relevant changes are recorded
- Security controls for access to subscription history
- Customer-facing subscription history summary

### Feature 8.3: Enterprise Plan Customization
This feature implements customization capabilities for enterprise clients. It includes creating the EnterprisePlanOverride entity model, implementing enterprise-specific limit overrides, building UI components for managing enterprise customizations, implementing enterprise billing adjustments, and creating enterprise plan reporting tools.

#### Story 8.3.1: Implement EnterprisePlanOverride entity model

**Description:**
Design and implement the EnterprisePlanOverride entity model that allows for customized subscription parameters for enterprise customers. This model enables per-tenant customization beyond the standard plan tiers.

**Acceptance Criteria:**
- EnterprisePlanOverride entity class implemented according to design document
- Database migration created for EnterprisePlanOverride table
- GUID v7 primary key implemented for EnterprisePlanOverride entities
- Foreign key relationship to Tenant entity
- Nullable override fields for all standard plan limits
- Override fields for all key capabilities (projects, templates, etc.)
- ExtraChargePerUnit field for custom billing
- Notes field for documenting custom arrangements
- Created/Updated timestamp fields implemented
- Appropriate indexes for efficient querying
- Repository pattern implemented for EnterprisePlanOverride access
- Integration tests verify proper database schema
- Documentation of entity model and override behavior
- Testing confirms model correctly stores override data
- Performance considerations for override lookups

#### Story 8.3.2: Create enterprise-specific limit overrides

**Description:**
Implement the functionality to override standard plan limits for enterprise customers. This should allow for custom limits on any quantifiable aspect of the service, such as projects, templates, API calls, and retention periods.

**Acceptance Criteria:**
- Override system for all standard plan limits
- Tenant-specific limit configuration
- Integration with existing limit enforcement
- Override precedence over standard plan limits
- Default to standard limits when override not specified
- Validation of override values
- API endpoints for setting and retrieving overrides
- Integration with feature matrix system
- Documentation of available overrides
- Unit tests for override behavior
- Integration tests with limit enforcement
- Performance considerations for override checks
- Testing confirms overrides take precedence correctly
- Security controls for setting overrides
- Audit logging of override changes

#### Story 8.3.3: Build UI for managing enterprise customizations

**Description:**
Create user interface components for administrators to manage enterprise plan customizations. This should provide a comprehensive view of overrides and tools to configure custom limits and capabilities for enterprise tenants.

**Acceptance Criteria:**
- Enterprise plan management UI for administrators
- Override configuration form with all available options
- Current override values display
- Visual comparison with standard plan limits
- Validation and error handling
- Save/cancel functionality with confirmation
- History of override changes
- Copy overrides between tenants functionality
- Template overrides for quick application
- Mobile-responsive design
- Accessibility compliance for all components
- Documentation of UI usage
- Testing confirms UI correctly manages overrides
- Permission checks for enterprise management
- Performance optimization for UI rendering
- Usability testing with administrators

#### Story 8.3.4: Implement enterprise billing adjustments

**Description:**
Create functionality to calculate and apply custom billing adjustments for enterprise customers based on their specific overrides and usage patterns. This ensures accurate billing for customized enterprise plans.

**Acceptance Criteria:**
- Custom billing calculation based on overrides
- Base price plus usage-based charges
- Support for custom pricing arrangements
- Manual adjustment capability for administrators
- Override impact analysis on billing
- Billing preview functionality
- Invoice generation with override details
- Proration for mid-period changes
- Documentation of billing calculation
- Unit tests for billing adjustment logic
- Integration tests with billing system
- Testing confirms accurate calculations
- Audit trail for billing adjustments
- Reporting on enterprise billing
- Security controls for billing operations

#### Story 8.3.5: Create enterprise plan reporting

**Description:**
Implement specialized reporting tools for enterprise plans that provide insights into custom limit usage, billing impacts, and comparative analysis against standard plans. These reports help both administrators and enterprise customers understand their customized service.

**Acceptance Criteria:**
- Enterprise-specific usage reporting
- Custom limit utilization tracking
- Comparison reports against standard plans
- Cost-benefit analysis of custom limits
- Recommendation engine for limit adjustments
- Export functionality for reports
- Scheduled report delivery options
- Report customization for different stakeholders
- Visual dashboards for enterprise customers
- Documentation of reporting capabilities
- Integration with analytics system
- Performance optimization for complex reports
- Testing confirms report accuracy
- Security controls for report access
- Feedback mechanism for report usefulness

### Feature 8.4: Coupon System
This feature implements promotional capabilities through coupons. It includes creating the Coupon entity model, implementing coupon generation and management tools, building mechanisms for applying coupons to subscriptions, implementing discount calculation logic for both flat and percentage discounts, and handling coupon expiration and benefit windows.

#### Story 8.4.1: Implement Coupon entity model

**Description:**
Design and implement the Coupon entity model that defines promotional discounts that can be applied to subscriptions. This model should support various discount types and redemption rules.

**Acceptance Criteria:**
- Coupon entity class implemented according to design document
- Database migration created for Coupon table
- GUID v7 primary key implemented for Coupon entities
- Code field for coupon code (unique, case-insensitive)
- Description field for coupon purpose/campaign
- FlatAmountOff and PercentageOff fields (nullable, mutually exclusive)
- ExpireDate field for coupon validity
- BenefitUntil field for extended discount period
- Active flag for enabling/disabling coupons
- Maximum redemption count (optional)
- Applicable plan tiers (which plans can use this coupon)
- Created/Updated timestamp fields implemented
- Appropriate indexes for efficient querying
- Repository pattern implemented for Coupon access
- Integration tests verify proper database schema
- Documentation of entity model and fields
- Testing confirms model correctly stores coupon data
- Performance considerations for coupon lookups

#### Story 8.4.2: Create coupon generation and management

**Description:**
Implement administrative tools for generating, managing, and tracking coupons. This includes coupon creation, editing, deactivation, and reporting on coupon usage.

**Acceptance Criteria:**
- Coupon management UI for administrators
- Create, edit, deactivate operations for coupons
- Coupon code generation (manual and automatic)
- Validation rules for coupon creation
- Bulk coupon generation capability
- Coupon listing with filtering and search
- Usage tracking for coupons
- Reporting on coupon redemptions and impact
- Export functionality for coupon data
- Documentation of coupon management
- Unit tests for coupon operations
- Integration tests for management functions
- Performance considerations for large coupon sets
- Testing confirms management functions work correctly
- Security controls for coupon management

#### Story 8.4.3: Build coupon application to subscriptions

**Description:**
Create the functionality to apply coupons to tenant subscriptions, including validation, redemption tracking, and managing the association between coupons and subscriptions.

**Acceptance Criteria:**
- UI for entering and applying coupon codes
- API endpoint for coupon redemption
- Validation of coupon eligibility
- Coupon application to subscription
- Creation of TenantCoupon record
- Subscription price adjustment based on coupon
- Confirmation of successful application
- Error handling for invalid coupons
- Redemption count tracking
- Prevention of duplicate applications
- Audit logging of coupon applications
- Documentation of coupon application process
- Unit tests for application logic
- Integration tests with subscription system
- Testing confirms coupons correctly apply to subscriptions
- Security controls for coupon operations

#### Story 8.4.4: Implement discount calculation (flat/percentage)

**Description:**
Implement the logic to calculate discounts based on coupon types, including both flat amount discounts and percentage-based discounts. Ensure these calculations properly affect the final subscription price.

**Acceptance Criteria:**
- Discount calculation logic for flat amount coupons
- Discount calculation logic for percentage coupons
- Integration with subscription pricing
- Handling for discount limits (minimum price, etc.)
- Currency handling for flat discounts
- Rounding rules for calculated prices
- Display of original and discounted prices
- Documentation of calculation formulas
- Audit trail of price calculations
- Unit tests for discount calculations
- Integration tests with billing system
- Testing confirms accurate discount application
- Handling of edge cases (discount > price, etc.)
- Performance optimization for calculations
- Support for multiple currencies (if applicable)

#### Story 8.4.5: Create coupon expiration and benefit window handling

**Description:**
Implement functionality to manage coupon expiration dates and benefit windows, ensuring discounts are only applied during valid periods and that long-term benefits are correctly maintained through subscription renewals.

**Acceptance Criteria:**
- Expiration date enforcement for coupon redemption
- Benefit window tracking for active discounts
- Renewal handling with coupon benefits
- Notification system for expiring benefits
- Automatic price adjustment after benefit expiry
- Visual indicators for active/expired coupons
- Documentation of expiration/benefit behavior
- Unit tests for date handling logic
- Integration tests for benefit windows
- Testing confirms correct expiration behavior
- Performance considerations for date checks
- Audit logging of benefit expiration
- Administrator alerts for mass benefit expirations
- Reporting on upcoming expirations
- Proper handling of timezone differences

### Feature 8.5: Usage Limits & Enforcement
This feature implements the tracking and enforcement of usage limits. It includes creating usage tracking per subscription tier, implementing limit enforcement mechanisms, building usage warning notifications, implementing graceful degradation for limit exceedance, and creating usage reporting and projection tools.

#### Story 8.5.1: Implement usage tracking per subscription tier

**Description:**
Create a system to track usage of various resources (templates, projects, API calls, etc.) against the limits defined by subscription tiers. This provides the foundation for limit enforcement and usage reporting.

**Acceptance Criteria:**
- Usage tracking for all limited resources
- Tenant-specific usage counters
- Reset logic based on billing cycles
- Real-time usage updates
- Historical usage data retention
- Integration with relevant system operations
- Performance optimization for tracking operations
- Concurrency handling for usage increments
- Documentation of tracked resources
- Unit tests for tracking logic
- Integration tests with resource creation
- Testing confirms accurate usage tracking
- Resilience against tracking failures
- Backup/recovery for usage data
- API endpoints for querying current usage

#### Story 8.5.2: Create limit enforcement mechanisms

**Description:**
Implement the mechanisms to enforce subscription limits by preventing operations that would exceed defined thresholds. This ensures that tenants operate within their subscription tier constraints.

**Acceptance Criteria:**
- Limit checking before resource creation/usage
- Integration with all limited operations
- Enforcement based on subscription tier
- Override consideration for enterprise plans
- Clear error messages when limits are reached
- Validation in UI before server requests
- API validation for direct calls
- Documentation of enforcement points
- Unit tests for enforcement logic
- Integration tests with limited operations
- Performance optimization for frequent limit checks
- Testing confirms limits are properly enforced
- SuperAdmin exemption from limits
- Audit logging of limit enforcement
- Handling for race conditions in limit checking

#### Story 8.5.3: Build usage warnings and notifications

**Description:**
Create a notification system that alerts users as they approach usage limits, giving them the opportunity to manage their usage or upgrade their subscription before limits are reached.

**Acceptance Criteria:**
- Warning thresholds configuration (percentage-based)
- UI indicators for approaching limits
- Email notifications for limit warnings
- In-app notification center integration
- Dismissible warnings with don't-show-again option
- Escalating warning levels (e.g., 75%, 90%, 95%)
- Upgrade call-to-action in warnings
- Administrator alerts for organization-wide limits
- Documentation of warning system
- Unit tests for threshold calculations
- Integration tests for notification generation
- Testing confirms accurate warnings
- Prevention of notification spam
- User preference settings for notifications
- Mobile-responsive warning displays

#### Story 8.5.4: Implement graceful degradation for limit exceedance

**Description:**
Create mechanisms for graceful degradation of service when limits are reached, rather than complete service denial. This provides a better user experience while still enforcing subscription boundaries.

**Acceptance Criteria:**
- Read-only mode for resources at capacity
- Queuing system for critical operations
- Priority handling based on operation importance
- Clear user feedback about degraded functionality
- Temporary allowance with notification (grace usage)
- Emergency override capability for administrators
- Recovery path when usage decreases
- Documentation of degradation behavior
- Unit tests for degradation logic
- Integration tests with limit scenarios
- Testing confirms graceful degradation works
- User experience evaluation during degradation
- Performance impact analysis of degradation
- Audit logging of degradation events
- Security considerations for degraded operations

#### Story 8.5.5: Create usage reporting and projections

**Description:**
Implement reporting tools that provide insights into resource usage patterns, trends, and projections. These help users understand their usage, plan for future needs, and make informed decisions about subscription upgrades.

**Acceptance Criteria:**
- Usage dashboard with current status
- Historical usage trends visualization
- Usage breakdown by resource type
- Projections based on historical patterns
- Time-to-limit calculations
- Recommendation engine for plan upgrades
- Usage comparisons across billing cycles
- Export functionality for usage data
- Scheduled usage reports option
- Integration with analytics system
- Documentation of reporting capabilities
- Unit tests for projection algorithms
- Performance optimization for complex reports
- Testing confirms report accuracy
- Mobile-responsive report design
- Accessibility compliance for usage dashboards

## Epic 9: External API & Developer Experience

**Description:**  
External API & Developer Experience transforms CommuniQueue from a self-contained app into a true platform. This epic delivers a secure, well-documented API surface, interactive documentation, auto-generated SDKs, analytics, and developer-focused support. Key pillars: robust API authentication (keys, JWT), clear versioning, rapid onboarding for external devs, and self-service API management. These elements lower integration friction, accelerate third-party adoption, and set the foundation to become a central notification backbone for other SaaS or enterprise systems. API observability, scalable rate limiting, and automated error feedback prevent support escalations and drive customer satisfaction.

**Why:**  
- Makes CommuniQueue extensible—unlocks integrations with CRM, ERP, marketing, etc.
- Provides critical stickiness; users can embed CQ into their product(s) or workflow(s).
- Supports developer self-service, reducing support and accelerating integrations.
- Opening the API surface enables ecosystem growth, partnerships, and platform defensibility.

**What Success Looks Like:**  
- Third parties can build integrations in hours, not weeks.
- Developers can easily explore, test, and get support with minimal friction.
- API changes are compatible, versioned, and clearly communicated.
- The API’s usage is observable, monitorable, and billable by tenant.

### Feature 9.1: API Infrastructure
This feature establishes the foundational infrastructure for the CommuniQueue external API. It focuses on creating a robust, secure, and scalable API architecture that third-party developers can rely on. The infrastructure includes authentication mechanisms, versioning strategy, consistent error handling, and comprehensive request/response logging to ensure a professional-grade API experience.

#### Story 9.1.1: Implement API gateway and routing architecture

**Description:**
Design and implement the API gateway and routing architecture that will serve as the foundation for the CommuniQueue external API. This includes establishing the core infrastructure components that will handle request routing, load balancing, and integration with other system components.

**Acceptance Criteria:**
- API gateway implemented using appropriate technology (e.g., AWS API Gateway, Azure API Management, or custom solution)
- Routing configuration for all planned API endpoints
- Load balancing strategy implemented for horizontal scaling
- API domain and path structure established
- Integration with backend services and microservices
- HTTPS enforcement with proper SSL/TLS configuration
- Cross-origin resource sharing (CORS) policy configured
- IP allowlisting capability (if required)
- Request size limits and timeout configurations
- Traffic management and throttling capabilities
- Logging and monitoring hooks integrated
- Deployment pipelines for API infrastructure
- Documentation of gateway architecture
- Testing confirms gateway properly routes requests
- Performance testing under expected load
- Security review passes with no critical issues

#### Story 9.1.2: Create API versioning strategy and URL structure

**Description:**
Establish and implement a comprehensive API versioning strategy that allows the API to evolve while maintaining backward compatibility. This includes defining the URL structure, versioning scheme, and policies for managing API lifecycle.

**Acceptance Criteria:**
- API versioning strategy documented and implemented
- URL structure includes version identifier (e.g., /api/v1/...)
- Version included in request headers as alternative method
- Policy for maintaining backward compatibility
- Deprecation strategy for API versions
- Sunset policy for end-of-life versions
- Documentation of version differences
- Routing logic to direct requests to appropriate version handlers
- Version-specific middleware pipeline
- Testing confirms correct version routing
- Client communication plan for version changes
- Version dependency management in backend code
- Automated tests for version compatibility
- Documentation of URL patterns and conventions
- Strategy for handling unversioned requests

#### Story 9.1.3: Build comprehensive API authentication framework (JWT, API keys)

**Description:**
Implement a robust API authentication framework that supports multiple authentication methods including JWT tokens and API keys. This ensures secure access to the API while providing flexibility for different integration scenarios.

**Acceptance Criteria:**
- JWT authentication implemented for user context operations
- API key authentication implemented for machine-to-machine scenarios
- Authentication middleware in request pipeline
- Integration with Auth0 for JWT validation
- Secure storage and validation of API keys
- Role-based authorization tied to authentication
- Scope-based permissions for API operations
- Token lifetime and refresh handling
- API key rotation capabilities
- Clear authentication error responses
- Documentation of authentication methods
- Authentication examples for common scenarios
- Security testing confirms no authentication bypasses
- Performance testing of authentication mechanisms
- Support for multiple active API keys per tenant
- Audit logging of authentication activities

#### Story 9.1.4: Implement standardized error handling and response formats

**Description:**
Create a standardized system for API error handling and response formats that provides clear, actionable feedback to API consumers. This ensures consistency across all endpoints and makes integration easier for developers.

**Acceptance Criteria:**
- Standardized error response format defined
- HTTP status codes used appropriately
- Error response includes: code, message, details, requestId
- Validation errors return specific field information
- Global exception handling middleware
- Detailed error logging with correlation IDs
- User-friendly error messages for common scenarios
- Developer-oriented details for troubleshooting
- Localization support for error messages
- Documentation of error codes and meanings
- Testing confirms consistent error format across endpoints
- Security review to prevent information leakage in errors
- Performance impact assessment of error handling
- Integration with observability systems
- Different verbosity levels based on environment (dev vs prod)

#### Story 9.1.5: Create API request/response logging and diagnostic system

**Description:**
Implement a comprehensive logging and diagnostic system for API requests and responses. This system should capture detailed information for troubleshooting, audit, and analytics purposes while respecting privacy and performance considerations.

**Acceptance Criteria:**
- Request/response logging pipeline implemented
- Correlation ID generation and propagation
- Configurable logging levels for different environments
- PII redaction in logs (passwords, sensitive data)
- Structured logging format (JSON) for machine processing
- Performance metrics captured (timing, size)
- Integration with centralized logging system
- Log retention policy implementation
- Search and filtering capabilities for logs
- Logging dashboard for operations team
- Request replay capability for debugging
- Documentation of logging system
- Tenant isolation in log storage and access
- Performance testing confirms minimal impact
- Compliance review for data protection regulations
- Testing confirms diagnostic value of logs

#### Story 9.1.6: Build API health check and status endpoints

**Description:**
Create health check and status endpoints that provide information about API availability, performance, and operational status. These endpoints help with monitoring, alerting, and transparency for API consumers.

**Acceptance Criteria:**
- Public health check endpoint (/health) implemented
- Detailed internal health status endpoint with authentication
- Component-level health reporting
- Integration with backend service health checks
- Standard health response format
- Status page integration for public reporting
- Customizable health check criteria
- Performance metrics included in health response
- Degraded state reporting (partial availability)
- Scheduled maintenance information
- Historical uptime reporting
- Documentation of health endpoints
- Testing confirms accurate health reporting
- Alerting integration for health status changes
- Load balancer integration for routing decisions
- Rate limiting exemption for health endpoints

### Feature 9.2: API Documentation & Developer Portal
This feature creates a comprehensive developer experience centered around API documentation. It includes implementing interactive API documentation, creating a developer portal for API consumers, building tutorials and integration guides, and establishing a changelog system to track API evolution. The documentation will be both human-readable and machine-consumable for tooling integration.

#### Story 9.2.1: Implement OpenAPI/Swagger specification for all endpoints

**Description:**
Create comprehensive OpenAPI (formerly Swagger) specifications for all API endpoints. These specifications serve as the source of truth for API documentation, SDK generation, and testing tools.

**Acceptance Criteria:**
- OpenAPI 3.0+ specification created for all API endpoints
- Specifications organized by API version
- Detailed schema definitions for all models
- Complete parameter descriptions with validation rules
- Response definitions for all status codes
- Authentication requirements specified
- Examples included for requests and responses
- Extended documentation using Markdown
- Tags and operation IDs for logical grouping
- Specification validation passing with no errors
- CI/CD integration to verify specification accuracy
- Specifications available in both JSON and YAML formats
- Automated generation from code where possible
- Manual review process for specification quality
- Documentation of specification update process
- Testing confirms specification matches implementation

#### Story 9.2.2: Create interactive API documentation with live testing capabilities

**Description:**
Implement an interactive API documentation system based on the OpenAPI specifications that allows developers to explore the API, understand available endpoints, and test API calls directly from the documentation.

**Acceptance Criteria:**
- Interactive API documentation using Swagger UI or similar tool
- Live testing capability with request builder
- Authentication integration for testing authenticated endpoints
- Syntax highlighting for request/response examples
- Request/response validation against schemas
- Filtering and search functionality for endpoints
- Mobile-responsive documentation design
- Dark/light theme support
- Copy-to-clipboard functionality for examples
- Language-specific code snippet generation
- Performance optimization for large API specifications
- Documentation of how to use the interactive features
- Testing confirms documentation accurately reflects API
- Accessibility compliance (WCAG AA minimum)
- Integration with developer portal authentication
- Analytics to track most viewed/tested endpoints

#### Story 9.2.3: Build developer portal with authentication and personalization

**Description:**
Create a comprehensive developer portal that serves as the central hub for API documentation, resources, and account management. The portal should support authentication, personalization, and provide a seamless experience for API consumers.

**Acceptance Criteria:**
- Developer portal website implemented
- User registration and authentication
- Integration with Auth0 for identity management
- User profile management
- API key management interface
- Personal dashboard with usage metrics
- Saved examples and favorites
- Documentation integrated into portal
- Support/contact capabilities
- Responsive design for all devices
- Search functionality across all content
- User feedback/rating system
- Announcement/news section
- Accessibility compliance (WCAG AA minimum)
- Analytics for portal usage
- Performance optimization for global access
- Testing confirms all features function correctly
- Security review passes with no critical issues

#### Story 9.2.4: Implement API changelog and versioning notes

**Description:**
Create a system for maintaining and displaying API changelogs and version notes. This helps developers stay informed about API changes, new features, deprecations, and breaking changes.

**Acceptance Criteria:**
- Changelog section in developer portal
- Version-specific release notes
- Breaking vs. non-breaking change indicators
- Deprecation notices with migration guidance
- Upcoming feature announcements
- Filtering by version and change type
- Notification system for subscribed developers
- RSS feed for changelog updates
- Markdown support for rich content
- Linking to relevant documentation
- Integration with API versioning strategy
- Admin interface for managing changelog entries
- Documentation of changelog update process
- Testing confirms changelog accurately reflects changes
- User testing validates clarity and usefulness

#### Story 9.2.5: Create comprehensive API tutorials and integration guides

**Description:**
Develop a collection of tutorials, integration guides, and best practices documentation to help developers successfully integrate with the CommuniQueue API. These should cover common use cases and provide step-by-step guidance.

**Acceptance Criteria:**
- Getting started guide for new developers
- Authentication tutorial with examples
- Core API workflow tutorials
- Common use case guides
- Best practices documentation
- Language-specific integration guides
- Troubleshooting and FAQ section
- Error handling guidance
- Performance optimization tips
- Security best practices
- Tutorial content in Markdown format
- Code examples for all tutorials
- Navigation structure for finding relevant guides
- Feedback mechanism for tutorial quality
- Regular review process for content freshness
- Testing confirms tutorials work as described
- User testing validates clarity and completeness

#### Story 9.2.6: Build API request/response examples for all endpoints

**Description:**
Create comprehensive request and response examples for all API endpoints that demonstrate typical usage patterns. These examples should cover successful operations as well as common error scenarios.

**Acceptance Criteria:**
- Example requests for all API endpoints
- Example responses for success scenarios
- Example responses for common error cases
- Examples in multiple formats (curl, HTTP, JavaScript, etc.)
- Examples included in OpenAPI specification
- Downloadable examples as code snippets
- Example management system for updates
- Context explanations for each example
- Integration with interactive documentation
- Validation that examples are syntactically correct
- Testing confirms examples work against actual API
- Regular review process for example freshness
- User feedback mechanism for examples
- Documentation of example creation process
- Analytics to identify most used examples

### Feature 9.3: SDK Generation & Code Samples
This feature focuses on making API integration easier for developers by providing auto-generated SDKs, code samples in multiple languages, and integration templates. It includes tools to keep SDKs and examples in sync with the API as it evolves, ensuring developers always have access to up-to-date integration resources.

#### Story 9.3.1: Create SDK generation pipeline from OpenAPI specification

**Description:**
Implement an automated pipeline that generates SDK code from the OpenAPI specifications. This ensures that SDKs are always in sync with the latest API definitions and reduces manual maintenance effort.

**Acceptance Criteria:**
- SDK generation pipeline using OpenAPI Generator or similar tool
- CI/CD integration for automated generation on API changes
- Version management for generated SDKs
- Configuration templates for different languages
- Custom templates for CommuniQueue-specific patterns
- Quality checks for generated code
- Documentation generation integrated in pipeline
- Package publication automation
- Versioning aligned with API versions
- Handling for breaking vs. non-breaking changes
- Error reporting for generation failures
- Testing of generated SDKs against actual API
- Process documentation for SDK maintenance
- Metrics collection on generation success/failure
- Emergency override for problematic generations

#### Story 9.3.2: Build .NET SDK with strong typing and IntelliSense support

**Description:**
Create a .NET SDK for the CommuniQueue API that provides a strongly-typed client with full IntelliSense support. This SDK should follow .NET best practices and make integration seamless for .NET developers.

**Acceptance Criteria:**
- .NET SDK generated from OpenAPI specification
- Strong typing for all models and responses
- Full IntelliSense documentation from API specs
- Async/await pattern implementation
- Proper exception handling and custom exceptions
- Retry and resilience patterns
- Authentication handling (API key and JWT)
- Logging integration with standard .NET logging
- Configuration options via standard patterns
- NuGet package creation and publishing
- Example project using the SDK
- Unit tests for SDK functionality
- Documentation with XML comments
- Readme and getting started guide
- Support for .NET Standard 2.0+ and .NET 6.0+
- Performance testing against realistic scenarios

#### Story 9.3.3: Implement JavaScript/TypeScript SDK for web applications

**Description:**
Create a JavaScript/TypeScript SDK for web applications that provides an easy way to integrate with the CommuniQueue API from browser and Node.js environments. The SDK should provide TypeScript definitions for type safety and developer productivity.

**Acceptance Criteria:**
- JavaScript SDK with TypeScript definitions
- Browser and Node.js compatibility
- Module formats support (ESM, CommonJS)
- Promise-based API with async/await support
- Error handling with custom error types
- Request/response interceptors
- Authentication handling (API key and JWT)
- Automatic request retries with configurable policy
- Comprehensive TypeScript typings
- Bundle size optimization
- Tree-shaking support
- npm package creation and publishing
- Example project using the SDK
- Unit and integration tests
- Documentation with JSDoc comments
- Readme and getting started guide
- TypeScript version compatibility documented
- Browser compatibility documented

#### Story 9.3.4: Create Python SDK for data integration scenarios

**Description:**
Develop a Python SDK that enables data integration scenarios with the CommuniQueue API. This SDK should be compatible with common Python data tools and follow Python best practices.

**Acceptance Criteria:**
- Python SDK generated from OpenAPI specification
- Type hints for all methods and models
- Support for Python 3.7+
- Async/await support (optional)
- Authentication handling (API key and JWT)
- Exception hierarchy for API errors
- Retry and backoff mechanisms
- Integration with standard Python logging
- Pandas DataFrame support for data methods
- PyPI package creation and publishing
- Example Jupyter notebook demonstrations
- Unit and integration tests
- Documentation with docstrings
- Readme and getting started guide
- Support for common Python environments
- Performance testing for data operations
- Compliance with PEP 8 style guidelines

#### Story 9.3.5: Build code sample repository with common integration patterns

**Description:**
Create a comprehensive repository of code samples demonstrating common integration patterns with the CommuniQueue API. These samples should cover various languages and scenarios to help developers quickly implement typical use cases.

**Acceptance Criteria:**
- GitHub repository for code samples
- Samples organized by language and scenario
- Complete working examples (not just snippets)
- Core scenarios covered (authentication, sending, templates)
- Multiple programming languages (.NET, JavaScript, Python, etc.)
- README files with explanation and setup instructions
- Dependency management files (package.json, requirements.txt)
- CI/CD to verify samples build and run
- Consistent coding style across samples
- Regular updates to match API changes
- License information for all samples
- Contribution guidelines for community additions
- Integration with developer portal for discovery
- User feedback mechanism for sample quality
- Analytics to track sample usage and popularity
- Testing confirms samples work as documented

#### Story 9.3.6: Implement API client configuration templates

**Description:**
Create configuration templates for API clients that help developers quickly set up and configure their integrations with the CommuniQueue API. These templates should cover common configuration scenarios and provide sensible defaults.

**Acceptance Criteria:**
- Configuration templates for all SDK languages
- Environment-specific configurations (dev, prod)
- Retry and timeout settings templates
- Authentication configuration examples
- Logging configuration templates
- Proxy configuration examples
- Rate limiting handling configuration
- Error handling strategies
- Performance optimization settings
- Documentation of all configuration options
- Real-world examples of configurations
- Template validation to ensure correctness
- Integration with SDK documentation
- Regular updates to match SDK changes
- User feedback on template usefulness
- Testing confirms templates work with SDKs

### Feature 9.4: API Monitoring & Analytics
This feature implements comprehensive monitoring and analytics for the API surface. It includes tracking API usage patterns, performance metrics, error rates, and client behaviors. The monitoring system will provide both internal dashboards for CommuniQueue administrators and usage insights for API consumers through the developer portal.

#### Story 9.4.1: Implement API call volume and pattern tracking

**Description:**
Create a system to track and analyze API call volumes and usage patterns. This data helps understand how the API is being used, identify popular endpoints, and plan for capacity needs.

**Acceptance Criteria:**
- API call tracking implemented for all endpoints
- Metrics collection for call volume by endpoint
- Tenant-specific usage tracking
- Time-based aggregation (hourly, daily, monthly)
- Request metadata capture (source IP, user agent)
- Integration with existing logging infrastructure
- Real-time and historical data views
- Data retention policy implementation
- Privacy compliance for collected data
- Performance impact minimization
- Documentation of tracking methodology
- Testing confirms accurate tracking
- Dashboard for visualizing call patterns
- Export capability for further analysis
- Alert thresholds for unusual patterns
- Documentation of metrics definitions

#### Story 9.4.2: Create API performance monitoring and alerting

**Description:**
Implement a system to monitor API performance metrics, establish baselines, and create alerts for performance degradation. This ensures the API maintains high availability and responsiveness.

**Acceptance Criteria:**
- Performance metric collection (response time, throughput)
- Endpoint-specific performance tracking
- Latency breakdown (network, processing, database)
- Integration with APM tools
- Baseline establishment for normal operation
- Anomaly detection for performance issues
- Alerting system for performance degradation
- Dashboard for performance visualization
- Historical performance data retention
- Correlation with system metrics (CPU, memory)
- Regular performance reporting
- Documentation of performance targets
- Testing confirms accurate performance measurement
- Minimal performance impact from monitoring itself
- Integration with on-call systems
- Geographic performance tracking

#### Story 9.4.3: Build API error tracking and analysis tools

**Description:**
Create tools to track, categorize, and analyze API errors. These tools help identify recurring issues, understand their impact, and prioritize fixes based on frequency and severity.

**Acceptance Criteria:**
- Error tracking for all API endpoints
- Error categorization and classification
- Frequency and trend analysis
- Impact assessment (affected users/tenants)
- Error correlation across multiple requests
- Root cause analysis tools
- Integration with logging and observability systems
- Dashboard for error visualization
- Alerting for critical or frequent errors
- Error prioritization based on impact
- Historical error data retention
- Documentation of error categories
- Testing confirms accurate error tracking
- Export capability for detailed analysis
- User impact reporting
- Regular error summary reports

#### Story 9.4.4: Implement client-specific API usage dashboards

**Description:**
Create personalized dashboards for API clients that display their specific API usage, performance metrics, and error rates. These dashboards help clients understand their usage patterns and troubleshoot integration issues.

**Acceptance Criteria:**
- Client-specific dashboard in developer portal
- Usage metrics visualization (calls, bandwidth)
- Performance metrics relevant to client
- Error tracking specific to client's calls
- Historical usage trends
- Quota usage and limitations display
- Cost implications (if applicable)
- Export capability for client data
- Customizable date ranges
- Mobile-responsive design
- Accessibility compliance (WCAG AA minimum)
- Performance optimization for dashboard rendering
- Documentation of dashboard features
- Testing confirms dashboard accuracy
- Client feedback mechanism
- Security controls for data access

#### Story 9.4.5: Create API usage reporting and export tools

**Description:**
Implement reporting and export tools that allow both administrators and clients to generate detailed reports on API usage. These reports support billing, capacity planning, and integration analysis.

**Acceptance Criteria:**
- Reporting interface for generating API usage reports
- Configurable report parameters (date range, metrics)
- Export formats (CSV, JSON, Excel)
- Scheduled report generation capability
- Email delivery of scheduled reports
- Report template system for common reports
- Admin reports across all clients
- Client-specific reports with appropriate scope
- Data visualization in reports
- Report history and archiving
- Documentation of available reports
- Testing confirms report accuracy
- Performance optimization for large reports
- Security controls for report access
- Compliance with data protection requirements
- Integration with billing system

#### Story 9.4.6: Build API usage prediction and capacity planning tools

**Description:**
Create tools that analyze historical API usage patterns to predict future usage and support capacity planning. These tools help ensure the API infrastructure can scale appropriately to meet demand.

**Acceptance Criteria:**
- Usage trend analysis from historical data
- Predictive models for future usage
- Seasonality detection and handling
- Growth pattern identification
- Capacity threshold recommendations
- What-if scenario modeling
- Integration with infrastructure scaling
- Visualization of predictions and actual usage
- Confidence intervals for predictions
- Regular prediction accuracy assessment
- Documentation of prediction methodology
- Alert thresholds for capacity planning
- Export capability for prediction data
- Testing confirms reasonable prediction accuracy
- Performance considerations for prediction algorithms
- Regular retraining of prediction models

### Feature 9.5: API Rate Limiting & Throttling
This feature implements advanced rate limiting and throttling mechanisms to protect the API from abuse while ensuring fair access for all consumers. It includes configurable rate limits based on subscription tier, burst handling for legitimate traffic spikes, and graceful degradation patterns that maintain API stability under load.

#### Story 9.5.1: Implement tier-based API rate limiting framework

**Description:**
Create a framework for implementing rate limits based on subscription tiers. This ensures that API consumers are limited according to their subscription level while allowing for flexible configuration of limits.

**Acceptance Criteria:**
- Rate limiting framework implemented
- Integration with subscription tier system
- Configurable limits per tier
- Different limit types (requests per second, minute, hour)
- Tenant-specific limit tracking
- Distributed rate limit tracking for scaling
- Cache-based implementation for performance
- Minimal impact on request latency
- Documentation of rate limiting framework
- Unit tests for rate limiting logic
- Integration tests with subscription system
- Performance testing under load
- Testing confirms limits applied correctly
- Graceful handling of limit edge cases
- Documentation of limit calculation methods
- Support for multiple limit types simultaneously

#### Story 9.5.2: Create configurable rate limit rules by endpoint and method

**Description:**
Implement a system to configure different rate limits for specific endpoints and HTTP methods. This allows for more granular control over API usage patterns based on the resource requirements of different operations.

**Acceptance Criteria:**
- Configuration system for endpoint-specific limits
- HTTP method-specific limits (GET, POST, etc.)
- Priority rules for overlapping configurations
- Default limits for unconfigured endpoints
- Admin interface for managing configurations
- Configuration validation and error prevention
- Real-time configuration updates
- Documentation of configuration options
- Unit tests for configuration logic
- Integration tests with endpoint routing
- Testing confirms endpoint-specific limits work
- Performance impact analysis of granular limits
- Audit logging of configuration changes
- Export/import of configurations
- Template configurations for common patterns
- Documentation of endpoint limit rationale

#### Story 9.5.3: Build rate limit notification and header system

**Description:**
Implement a system to communicate rate limit information to API consumers through HTTP headers and notifications. This helps developers understand their limit usage and adapt their integration accordingly.

**Acceptance Criteria:**
- Standard rate limit HTTP headers implemented
- Remaining quota information in responses
- Reset time information in headers
- Near-limit warning mechanism
- Developer portal notifications for approaching limits
- Email alerts for persistent high usage
- Documentation of header format and meaning
- Examples of handling limit information in clients
- SDK integration with limit handling
- Testing confirms header accuracy
- Performance impact minimization
- Customizable notification thresholds
- User preference settings for notifications
- Documentation of best practices for limit handling
- Integration with monitoring systems
- Tenant isolation for limit notifications

#### Story 9.5.4: Implement burst handling and request queuing

**Description:**
Create mechanisms to handle legitimate traffic bursts and implement request queuing for scenarios where brief rate limit exceedance is acceptable. This provides a better experience for API consumers with variable traffic patterns.

**Acceptance Criteria:**
- Burst allowance configuration based on tier
- Short-term exceedance handling
- Request queuing system for eligible endpoints
- Queue prioritization strategy
- Maximum queue size and timeout settings
- Backpressure mechanisms for queue management
- Client notification of queued requests
- Queue status in response headers
- Metrics collection for queue utilization
- Alert thresholds for persistent queuing
- Documentation of queuing behavior
- Testing confirms burst handling works correctly
- Performance impact analysis of queuing
- Failure handling for queue overflow
- Tenant isolation in queue management
- Integration with monitoring systems

#### Story 9.5.5: Create rate limit override and exemption system

**Description:**
Implement a system for creating temporary or permanent rate limit overrides and exemptions. This supports special cases, emergency situations, and custom arrangements with specific API consumers.

**Acceptance Criteria:**
- Override system for rate limits
- Temporary exemption with expiration
- Permanent exemption capability
- Endpoint-specific overrides
- Admin interface for managing overrides
- Approval workflow for override requests
- Audit logging of all overrides
- Notification system for active overrides
- Override history and reporting
- Documentation of override process
- Testing confirms overrides work correctly
- Security controls for override management
- Integration with customer support system
- Override request form in developer portal
- Performance impact assessment of exemptions
- Regular review process for permanent exemptions

#### Story 9.5.6: Build rate limit analytics and abuse detection

**Description:**
Create analytics tools focused on rate limiting patterns and implement systems to detect potential API abuse. These help maintain API health by identifying problematic usage patterns before they impact service quality.

**Acceptance Criteria:**
- Analytics dashboard for rate limit patterns
- Visualization of limit utilization
- Detection of repeated limit violations
- Pattern recognition for abuse scenarios
- IP-based traffic analysis
- Tenant behavior profiling
- Automatic flagging of suspicious patterns
- Alert system for potential abuse
- Historical analysis of rate limit events
- Reporting on most constrained clients
- Documentation of abuse detection methodology
- Testing confirms detection effectiveness
- Performance optimization for analytics
- False positive minimization
- Integration with security monitoring
- Automated response options for confirmed abuse
- Manual investigation tools for flagged activity

## Epic 10: Post-MVP Reporting & Analytics

**Description:**  
Post-MVP Reporting & Analytics evolves CommuniQueue into a true insight-driven platform, surfacing actionable analytics to users at every level—tenant, project, and template. This epic goes beyond operational tracking, introducing dashboards, visualizations, time-series analysis, A/B testing frameworks, cost reporting, and scheduled exports. The vision is to transform “did it send?” into “is it effective?”—enabling users to optimize campaigns, justify ROI, identify issues, and benchmark against previous periods or industry norms. Advanced features (engagement tracking, benchmarking, predictive analytics) are designed to turn CQ into a strategic communications hub, not just a delivery engine.

**Why:**  
- Empowers users (and buyers) with data to drive internal decisions and justify spend.
- Differentiates against competitors—advanced analytics is a key SaaS retention and upsell driver.
- Enables proactive optimization: better engagement, lower costs, and risk detection.
- Serves compliance, forecast, and operational improvement needs for clients.

**What Success Looks Like:**  
- Users can measure and optimize their communications, realizing tangible business value.
- High engagement and delivery rates due to actionable insights.
- Product adoption and expansion rates grow as users see demonstrable campaign ROI.
- Platform becomes sticky, as organizations rely on CQ for historic and real-time reporting.

### Feature 10.1: Analytics Dashboard
This feature implements a comprehensive analytics dashboard. It includes creating tenant-level analytics dashboard components, implementing project/template analytics views, building time-series visualization components, implementing analytics filtering and date range selection, and creating analytics export functionality.

#### Story 10.1.1: Create tenant-level analytics dashboard

**Description:**
Design and implement a comprehensive analytics dashboard at the tenant level that provides key insights into notification activity, performance, and trends. This dashboard serves as the primary analytics interface for tenant administrators.

**Acceptance Criteria:**
- Tenant analytics dashboard with key performance indicators
- Summary metrics showing total notifications sent
- Success/failure rate visualization
- Channel breakdown (email, SMS, webhook)
- Delivery performance over time graph
- Top templates by usage
- Recent activity timeline
- Responsive design for various screen sizes
- Role-based access control for analytics
- Real-time or near-real-time data updates
- Performance optimization for large data volumes
- Proper tenant data isolation
- Accessibility compliance (WCAG AA minimum)
- User testing confirms dashboard usability
- Tooltips and explanations for metrics
- Initial loading state and error handling
- Integration with notification tracking system
- Documentation of dashboard metrics and calculations

#### Story 10.1.2: Implement project/template analytics views

**Description:**
Create specialized analytics views for projects and templates that provide detailed performance data at a more granular level. These views help users understand the effectiveness of specific projects and templates.

**Acceptance Criteria:**
- Project-level analytics dashboard
- Template-level analytics dashboard
- Drill-down capability from tenant to project to template
- Comparative metrics between projects/templates
- Usage trends by project/template
- Success/failure analysis by template
- Delivery performance by template type
- Template version comparison
- User engagement metrics where applicable
- Filtering by date, status, and other parameters
- Mobile-responsive design
- Accessibility compliance
- Performance optimization for large template sets
- Clear navigation between analytics levels
- Export capabilities for project/template data
- Documentation of metrics methodology
- Testing confirms data accuracy at all levels
- Integration with template versioning system

#### Story 10.1.3: Build time-series visualization components

**Description:**
Develop reusable time-series visualization components that can display temporal data effectively across the analytics system. These components should support various data types, time granularities, and interactive features.

**Acceptance Criteria:**
- Reusable time-series chart components
- Multiple visualization types (line, bar, area charts)
- Time granularity options (hourly, daily, weekly, monthly)
- Interactive features (zoom, pan, hover details)
- Proper time zone handling
- Comparison capability (period over period)
- Anomaly highlighting
- Trend line overlay option
- Consistent styling across all visualizations
- Responsive design for different screen sizes
- Accessibility features for chart interaction
- Performance optimization for large datasets
- Animation options for data transitions
- Export capability for chart data
- Print-friendly rendering
- Documentation for component usage
- Testing across different browsers and devices
- Integration with analytics data sources

#### Story 10.1.4: Implement analytics filtering and date ranges

**Description:**
Create a flexible filtering system for analytics data that allows users to refine their view based on various criteria, especially date ranges. This empowers users to focus on specific time periods and data segments for deeper analysis.

**Acceptance Criteria:**
- Date range selector with preset options (today, yesterday, last 7/30/90 days)
- Custom date range picker with calendar interface
- Filter controls for notification type, status, project, template
- Advanced filtering for specific attributes
- Filter combination logic (AND/OR operations)
- Filter state persistence across sessions
- URL parameter support for sharing filtered views 
- Clear visual indication of active filters
- Easy filter removal/reset
- Filter impact preview (count of affected data)
- Mobile-friendly filter controls
- Keyboard accessibility for all filter controls
- Performance optimization for filtered queries
- Filter history/favorites for frequently used combinations
- Documentation of filtering capabilities
- Testing confirms filtering accuracy
- Integration with visualization components for immediate updates

#### Story 10.1.5: Create analytics export functionality

**Description:**
Implement functionality to export analytics data in various formats for offline analysis, reporting, and sharing. This allows users to use the data in other tools and include it in presentations or reports.

**Acceptance Criteria:**
- Export controls integrated into all analytics views
- Multiple export formats (CSV, Excel, JSON)
- Data export with current filtering applied
- Chart/visualization export as images (PNG, JPG, SVG)
- PDF export for dashboard reports
- Background processing for large exports
- Email notification for completed exports
- Download management for export files
- Export history and access to previous exports
- Data formatting appropriate to export type
- Proper handling of time zones in exported data
- Security controls to prevent unauthorized exports
- Rate limiting to prevent abuse
- Documentation of export features
- Testing confirms export accuracy and usability
- Compliance with data protection requirements
- Performance testing for large data exports

### Feature 10.2: Notification Metrics
This feature implements detailed notification performance metrics. It includes creating message volume metrics, implementing success/failure rate analytics, building delivery time performance metrics, implementing provider-specific analytics, and creating cost/usage efficiency metrics.

#### Story 10.2.1: Implement message volume metrics

**Description:**
Create comprehensive message volume metrics that track and analyze the quantity of notifications sent through the system. These metrics provide insights into usage patterns, growth trends, and capacity needs.

**Acceptance Criteria:**
- Total message volume tracking by time period
- Volume breakdown by channel (email, SMS, webhook)
- Volume trends over time (daily, weekly, monthly)
- Peak volume identification and analysis
- Volume by project and template
- Comparison with previous periods
- Volume forecasting based on trends
- Volume quota tracking against subscription limits
- Volume anomaly detection
- Visualization of volume patterns
- Real-time volume monitoring
- Documentation of volume metric calculations
- Testing confirms accurate volume reporting
- Performance optimization for high-volume calculations
- Integration with capacity planning tools
- Export capability for volume metrics

#### Story 10.2.2: Create success/failure rate analytics

**Description:**
Implement detailed success and failure rate analytics for notification delivery. These metrics help identify delivery problems, track quality of service, and improve reliability by understanding failure patterns.

**Acceptance Criteria:**
- Overall success/failure rate calculations
- Rate breakdown by notification type
- Detailed failure categorization
- Failure trend analysis over time
- Correlation of failures with specific conditions
- Provider-specific failure analysis
- Domain-specific failure analysis for email
- Success/failure visualization with drill-down capability
- Comparative analysis across time periods
- Alerting thresholds for abnormal failure rates
- Root cause attribution where possible
- Documentation of success/failure classifications
- Testing confirms accurate rate calculations
- Performance optimization for real-time rates
- Failure pattern identification algorithms
- Integration with notification debugging tools
- Export capability for rate data

#### Story 10.2.3: Build delivery time performance metrics

**Description:**
Create metrics that analyze the time performance of notification delivery, including processing time, provider delivery time, and end-to-end delivery metrics. These help identify bottlenecks and ensure timely message delivery.

**Acceptance Criteria:**
- End-to-end delivery time tracking
- Component-level timing breakdown
- Processing time in system before provider handoff
- Provider delivery time tracking
- Performance percentiles (50th, 90th, 99th)
- Time performance trends over time periods
- Performance comparison across notification types
- Performance by geographic region
- Time anomaly detection and flagging
- Performance visualization with drill-down
- Real-time performance monitoring
- Performance SLA tracking against targets
- Documentation of timing measurement methodology
- Testing confirms accurate time measurements
- Performance optimization for metrics calculation
- Integration with system performance monitoring
- Export capability for performance data

#### Story 10.2.4: Implement provider-specific analytics

**Description:**
Create specialized analytics for each notification provider (SendGrid, Twilio, etc.) that provides detailed insights into provider-specific performance, features, and delivery patterns.

**Acceptance Criteria:**
- Provider-specific dashboards for each integrated service
- SendGrid-specific email analytics (opens, clicks, bounces)
- Twilio-specific SMS analytics (delivery status, regions)
- Webhook-specific analytics (response codes, latency)
- Provider cost tracking and analysis
- Provider reliability comparison
- Provider-specific feature usage (templates, attachments)
- Provider API limits and usage tracking
- Provider-specific error code analysis
- Custom metrics for each provider's unique capabilities
- Documentation of provider-specific metrics
- Testing confirms accurate provider data
- Performance optimization for provider API calls
- Integration with provider reporting APIs where available
- Export capability for provider analytics
- Regular updates to match provider API changes

#### Story 10.2.5: Create cost/usage efficiency metrics

**Description:**
Implement analytics focused on cost efficiency and resource utilization. These metrics help users optimize their notification strategy to maximize value while controlling costs.

**Acceptance Criteria:**
- Cost per notification calculation by type
- Cost trend analysis over time
- Cost breakdown by project/template
- Resource utilization efficiency metrics
- Cost comparison across different channels
- Return on investment calculation tools
- Cost saving recommendation engine
- Cost projection based on usage patterns
- Cost anomaly detection
- Budget tracking against actual costs
- Cost optimization suggestions
- Documentation of cost calculation methodology
- Testing confirms accurate cost reporting
- Integration with billing and subscription systems
- Export capability for cost data
- Visual dashboard for cost efficiency
- Tenant isolation for cost data
- Security controls for sensitive cost information

### Feature 10.3: Usage Reporting
This feature implements detailed usage reporting for billing and capacity planning. It includes creating tenant usage tracking, implementing subscription utilization reports, building quota consumption visualizations, implementing trend analysis and projections, and creating usage anomaly detection for identifying unusual patterns.

#### Story 10.3.1: Implement tenant usage tracking

**Description:**
Create a comprehensive system for tracking tenant usage across all metered services and resources. This provides the foundation for usage-based billing, capacity planning, and tenant behavior analysis.

**Acceptance Criteria:**
- Tenant usage tracking across all metered resources
- Real-time usage data collection
- Historical usage data storage with appropriate retention
- Usage breakdown by resource type (notifications, storage, API calls)
- Usage tracking by user within tenant
- Resource-specific usage metrics
- Usage data aggregation at various time intervals
- Usage data access API for reporting
- Privacy controls for usage data
- Documentation of tracking methodology
- Testing confirms accurate usage tracking
- Performance optimization for high-volume tracking
- Resilience against tracking failures
- Backup and recovery for usage data
- Integration with notification and API systems
- Security controls for usage data access

#### Story 10.3.2: Create subscription utilization reports

**Description:**
Implement reporting tools that analyze tenant usage against their subscription plan limits. These reports help tenants understand their utilization levels and make informed decisions about subscription changes.

**Acceptance Criteria:**
- Subscription utilization dashboard
- Utilization percentage calculation for all limited resources
- Visualization of usage vs. limits
- Historical utilization trends
- Remaining capacity indicators
- Warning thresholds for high utilization
- Utilization forecasting based on trends
- Subscription recommendation engine
- Comparative analysis with different subscription tiers
- Export capability for utilization reports
- Scheduled utilization reports option
- Documentation of utilization calculations
- Testing confirms accurate utilization reporting
- Performance optimization for report generation
- Integration with subscription management system
- Mobile-responsive report design
- Accessibility compliance for all reports

#### Story 10.3.3: Build quota consumption visualizations

**Description:**
Create intuitive visualizations specifically designed to illustrate quota consumption and availability. These visualizations help users quickly understand their resource usage status and plan accordingly.

**Acceptance Criteria:**
- Gauge visualizations for quota consumption
- Progress bar representations for linear quotas
- Hierarchical visualizations for nested quotas
- Time-series visualizations for quota usage over time
- Color-coded status indicators (green/yellow/red)
- Interactive elements showing detailed quota information
- Multi-quota comparison views
- Drill-down capability for quota details
- Reset period indicators for cyclical quotas
- Mobile-responsive visualization design
- Accessibility features for all visualizations
- Documentation of visualization interpretations
- Testing confirms visualization accuracy
- Performance optimization for visualization rendering
- Integration with subscription and usage systems
- Print-friendly visualization options
- Export capability for visualization data

#### Story 10.3.4: Implement trend analysis and projections

**Description:**
Create analytical tools that analyze usage trends and project future usage based on historical patterns. These projections help with capacity planning, subscription decisions, and resource management.

**Acceptance Criteria:**
- Usage trend analysis for all tracked resources
- Multiple trend detection algorithms
- Growth rate calculation (linear, percentage)
- Seasonality detection and analysis
- Usage projection with confidence intervals
- Time-to-limit projections
- What-if scenario modeling
- Projection visualization with actual vs. projected
- Adjustable projection parameters
- Notification options for projection thresholds
- Documentation of projection methodology
- Testing confirms reasonable projection accuracy
- Performance optimization for trend calculations
- Regular re-evaluation of projection accuracy
- Export capability for trend data
- Mobile-responsive trend visualization
- Accessibility compliance for trend reports

#### Story 10.3.5: Create usage anomaly detection

**Description:**
Implement systems to detect unusual patterns or anomalies in resource usage. These help identify potential issues, security concerns, or unexpected changes in usage behavior.

**Acceptance Criteria:**
- Anomaly detection algorithms for usage patterns
- Real-time anomaly identification
- Multiple detection methods (statistical, machine learning)
- Anomaly classification by type and severity
- Anomaly visualization and highlighting
- Anomaly alerting system with configurable thresholds
- False positive reduction mechanisms
- Anomaly investigation tools
- Historical anomaly tracking
- Tenant-specific baseline calibration
- Documentation of anomaly detection methodology
- Testing confirms effective anomaly detection
- Performance optimization for detection algorithms
- Integration with security monitoring systems
- Export capability for anomaly data
- User feedback mechanism for detected anomalies
- Regular algorithm refinement based on feedback

### Feature 10.4: Scheduled Reports
This feature implements automated report generation and delivery. It includes creating a report scheduling system, implementing report template management, building report delivery mechanisms (email, download), implementing multiple report format options (PDF, CSV, JSON), and creating report history and archiving.

#### Story 10.4.1: Implement report scheduling system

**Description:**
Create a flexible scheduling system that allows users to define and manage automated report generation. This enables regular delivery of important analytics without manual intervention.

**Acceptance Criteria:**
- Report scheduling interface
- Schedule definition with multiple frequency options
- One-time and recurring schedule support
- Time zone handling for scheduled reports
- Start/end date configuration for recurring reports
- Schedule management (pause, resume, delete)
- Schedule preview showing next run dates
- Conflict detection for resource-intensive reports
- Failure handling and retry logic
- Notification of schedule failures
- Schedule history tracking
- Documentation of scheduling capabilities
- Testing confirms reports run on schedule
- Performance impact management for scheduled tasks
- Security controls for schedule creation
- User permission validation for scheduled reports
- Integration with system job scheduler

#### Story 10.4.2: Create report template management

**Description:**
Implement a template system for reports that allows users to define, save, and reuse report configurations. Templates streamline the report creation process and ensure consistency across repeated reports.

**Acceptance Criteria:**
- Report template creation interface
- Template parameters configuration
- Template organization and categorization
- Template version management
- Template sharing between users
- Default system templates for common reports
- Template preview functionality
- Template cloning and modification
- Template search and filtering
- Template metadata management
- Documentation of template capabilities
- Testing confirms template-based report generation
- Performance optimization for template processing
- Security controls for template access
- Export/import functionality for templates
- Template validation to ensure proper configuration
- Integration with scheduling system

#### Story 10.4.3: Build report delivery mechanisms (email, download)

**Description:**
Create multiple delivery mechanisms for reports to ensure users can access them in the most convenient way. This includes email delivery, in-app downloads, and potential integration with external storage systems.

**Acceptance Criteria:**
- Email delivery system for reports
- Configurable email templates for report delivery
- Email recipient management
- Email attachment size limits and handling
- Direct download links for large reports
- In-app notification of report completion
- Report access management in user interface
- External storage integration (S3, Dropbox, etc.)
- Delivery failure handling and notifications
- Delivery logging and tracking
- Documentation of delivery options
- Testing confirms successful delivery via all channels
- Performance optimization for large report delivery
- Security controls for report access
- Compliance with data protection requirements
- Support for multiple recipients
- Delivery receipt tracking

#### Story 10.4.4: Implement report format options (PDF, CSV, JSON)

**Description:**
Provide multiple export format options for reports to support various use cases from presentation to data analysis. Each format should be optimized for its intended use case.

**Acceptance Criteria:**
- PDF report generation with proper formatting
- CSV export for tabular data
- JSON export for programmatic consumption
- Excel (XLSX) export option
- Format-specific optimization for each type
- Visual components properly rendered in PDF
- Data integrity preserved in all formats
- Large dataset handling for each format
- Format selection in report configuration
- Multi-format generation option
- Preview capability for each format
- Documentation of format capabilities and limitations
- Testing confirms proper generation in all formats
- Performance optimization for format conversion
- Format validation before delivery
- Configurable options for each format (headers, etc.)
- Integration with delivery system for all formats

#### Story 10.4.5: Create report history and archiving

**Description:**
Implement a system to maintain a history of generated reports and provide archiving capabilities. This ensures users can access historical reports and manage report storage according to their needs.

**Acceptance Criteria:**
- Report history interface showing all generated reports
- Filtering and searching of report history
- Report metadata display (generation time, size, etc.)
- Report retention policy configuration
- Manual and automatic archiving capabilities
- Archived report retrieval process
- Storage usage tracking for reports
- Purge functionality for outdated reports
- Archive storage integration (S3, etc.)
- Export capability for report metadata
- Documentation of history and archiving features
- Testing confirms history tracking accuracy
- Performance optimization for large history
- Security controls for history access
- Compliance with data retention policies
- Restoration process for archived reports
- Storage cost estimation for report archives

### Feature 10.5: Advanced Analytics
This feature implements sophisticated analytics capabilities for deeper insights. It includes creating message engagement tracking, implementing A/B testing framework for future feature development, building predictive analytics for usage forecasting, implementing cross-project/tenant benchmarking, and creating advanced filtering and data exploration tools.

#### Story 10.5.1: Implement message engagement tracking

**Description:**
Create comprehensive engagement tracking for notifications to understand how recipients interact with messages. This includes opens, clicks, responses, and other engagement metrics depending on the notification channel.

**Acceptance Criteria:**
- Email open tracking implementation
- Email click tracking for links
- SMS response tracking where applicable
- Webhook response analysis
- Engagement timeline visualization
- Engagement rate calculations
- Engagement comparison across templates
- Device and platform tracking for engagement
- Geographic engagement analysis
- Time-based engagement patterns
- Engagement funnel analysis
- Documentation of tracking methodology
- Testing confirms accurate engagement tracking
- Privacy compliance for tracking methods
- Performance optimization for tracking data
- Integration with notification providers
- Export capability for engagement data
- User consent management for tracking

#### Story 10.5.2: Create A/B testing framework (future)

**Description:**
Design and implement a framework for A/B testing notification templates to optimize engagement and effectiveness. This allows users to experiment with different content, formatting, and delivery strategies to determine the most effective approach.

**Acceptance Criteria:**
- A/B test creation interface
- Test variable definition (subject, content, timing)
- Test group management and sampling
- Automatic variant assignment
- Statistical significance calculation
- Results analysis and visualization
- Winner declaration based on metrics
- Promotion of winning variant
- Test history and comparison
- Documentation of A/B testing methodology
- Testing confirms proper variant distribution
- Performance impact analysis of testing
- Integration with template system
- Export capability for test results
- Security controls for test management
- Compliance with privacy requirements
- Integration with engagement tracking

#### Story 10.5.3: Build predictive analytics for usage

**Description:**
Implement advanced predictive analytics that forecast future usage patterns based on historical data, identified trends, and external factors. These predictions help with capacity planning, resource allocation, and business planning.

**Acceptance Criteria:**
- Predictive models for various usage metrics
- Multiple prediction timeframes (short, medium, long-term)
- Confidence intervals for predictions
- Seasonality handling in predictions
- Anomaly exclusion options for predictions
- Visual comparison of predicted vs. actual
- Model accuracy tracking and improvement
- Feature importance analysis
- What-if scenario modeling
- Prediction explanation capabilities
- Documentation of prediction methodology
- Testing confirms reasonable prediction accuracy
- Performance optimization for prediction calculations
- Regular model retraining schedule
- Export capability for prediction data
- Integration with capacity planning tools
- User feedback mechanism for prediction quality

#### Story 10.5.4: Implement cross-project/tenant benchmarking

**Description:**
Create benchmarking capabilities that allow comparison of performance metrics across projects, templates, or anonymized tenants. This helps identify best practices, opportunities for improvement, and unusual performance patterns.

**Acceptance Criteria:**
- Benchmarking comparisons across projects
- Anonymized tenant benchmarking
- Industry/vertical benchmarks where available
- Percentile ranking within comparison groups
- Performance deviation highlighting
- Custom benchmark group creation
- Benchmark visualization with drill-down
- Benchmark metric selection
- Time period alignment for fair comparison
- Recommendation engine based on benchmarks
- Documentation of benchmarking methodology
- Testing confirms accurate benchmark calculations
- Privacy controls for cross-tenant benchmarking
- Performance optimization for benchmark queries
- Export capability for benchmark data
- Regular benchmark refresh schedule
- Opt-out capability for benchmark inclusion

#### Story 10.5.5: Create advanced filtering and data exploration tools

**Description:**
Implement sophisticated data exploration tools that go beyond basic filtering to allow deep analysis of notification data. These tools help users discover patterns, correlations, and insights that aren't apparent through standard reports.

**Acceptance Criteria:**
- Advanced filtering with multiple conditions
- Compound filter logic (AND, OR, NOT)
- Filter templates and saved filters
- Dynamic filter suggestions based on data
- Cross-field correlation analysis
- Pivot table functionality
- Data drilling capabilities
- Custom calculation fields
- Interactive exploration interface
- Visualization creation from exploration
- Natural language query capability (if applicable)
- Documentation of exploration capabilities
- Testing confirms exploration accuracy
- Performance optimization for complex queries
- Export capability for exploration results
- Sharing functionality for discoveries
- Integration with reporting system
- Security controls for data exploration
- Mobile-responsive exploration tools
- Accessibility compliance for exploration interface
