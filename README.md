<p><a target="_blank" href="https://app.eraser.io/workspace/3pObBD7LoP58viBAVOf5" id="edit-in-eraser-github-link"><img alt="Edit in Eraser" src="https://firebasestorage.googleapis.com/v0/b/second-petal-295822.appspot.com/o/images%2Fgithub%2FOpen%20in%20Eraser.svg?alt=media&amp;token=968381c8-a7e7-472a-8ed6-4a6626da5501"></a></p>

# CommuniQueue
CommuniQueue is a secure, multi-tenant notification SaaS platform for templated message management, dispatch, and tracking over email, SMS, and webhooks.

## Overview
CommuniQueue is designed for organizational flexibility, featuring:

- Role-based access control (RBAC)
- Rich template/version control
- Pluggable subscription models
- Robust metrics
- Extensible logging
- Seamless developer operations
The platform is built on a modern, scalable .NET/Blazor + Postgres stack.

## Solution Structure
The solution follows a modern .NET microservices architecture with the following projects:

- **CommuniQueueV2.ApiService**: RESTful API endpoints for client applications and third-party integrations
- **CommuniQueueV2.AppHost**: .NET Aspire orchestration project for container orchestration and local development
- **CommuniQueueV2.ServiceDefaults**: Common service configuration shared across projects
- **CommuniQueueV2.Tests**: Unit and integration tests
- **CommuniQueueV2.Web**: Blazor Server application providing the main user interface
## Technology Stack
- **Backend**: .NET 9 (C#)
- **Frontend**: Blazor Server with TailwindCSS
- **Database**: PostgreSQL (AWS RDS or Aurora Serverless)
- **Authentication**: Auth0
- **Email Service**: SendGrid
- **SMS Service**: Twilio
- **Containerization**: Docker
- **Cloud Infrastructure**: AWS (App Runner, SQS, S3, CloudFront, ApiGateway, RDS, Lambda)
- **Orchestration**: .NET Aspire, Serverless Framework
- **CI/CD**: GitHub Actions / AWS CodePipeline
## Features
- Multi-tenancy with customizable subscription tiers
- Comprehensive RBAC (role-based access control)
- Template management with versioning
- Notification delivery and tracking across multiple channels (email, SMS, webhook)
- API access with key management
- Flexible data retention policies
- Subscription and coupon management
- Comprehensive logging and observability
## Development Setup
### Prerequisites
- .NET 9 SDK
- Docker Desktop/Rancher Desktop (for local development)
- PostgreSQL (local instance or container)
- IDE (Visual Studio 2022+ or VS Code with C# extensions)
### Getting Started
1. Clone the repository
```bash
git clone https://github.com/yourusername/communiqueue.git
cd communiqueue
```
1. Run the application with Aspire
```bash
dotnet run --project CommuniQueueV2.AppHost
```
1. Access the application
- Blazor UI: [﻿https://localhost:5001](https://localhost:5001/) 
- API: [﻿https://localhost:5002/swagger](https://localhost:5002/swagger) 
### Database Migration
```bash
dotnet ef database update --project CommuniQueueV2.ApiService
```
## Configuration
Configuration settings are managed through appsettings.json files and environment variables.
Key configuration areas include:

- Database connection
- Auth0 settings
- SendGrid/Twilio API keys
- Subscription plan parameters
- Logging levels and sinks
## Architecture
CommuniQueue follows a microservices architecture:

- Blazor Server application for the UI
- API service for REST endpoints
- Background worker service for message processing
- Shared libraries for common business logic and models
All services communicate via well-defined interfaces and message queues for asynchronous processing.

## Contact
Michael Cavanaugh
[﻿funkel@battlelineproductions.com](mailto:funkel@battlelineproductions.com) 



<!--- Eraser file: https://app.eraser.io/workspace/3pObBD7LoP58viBAVOf5 --->