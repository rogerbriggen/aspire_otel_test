# aspire_otel_test

Test with .NET Aspire and OpenTelemetry

## Overview

This is a .NET Aspire application demonstrating OpenTelemetry integration with a Web frontend and API backend.

## Technology Stack

- **.NET 9.0** - Latest stable .NET SDK
- **.NET Aspire** - Cloud-native application stack
- **OpenTelemetry** - Distributed tracing, metrics, and logging
- **ASP.NET Core Controllers** - Following .NET guidelines (not minimal API)
- **Blazor** - Modern web UI framework

## Project Structure

The solution consists of four projects:

- **AspireOtelTest.AppHost** - Aspire orchestration host for managing the distributed application
- **AspireOtelTest.ServiceDefaults** - Shared configuration including OpenTelemetry setup
- **AspireOtelTest.ApiService** - REST API service with controller-based endpoints
- **AspireOtelTest.Web** - Blazor web frontend

## OpenTelemetry Features

The application includes comprehensive OpenTelemetry instrumentation:

- **Metrics**: ASP.NET Core, HTTP Client, and Runtime metrics
- **Tracing**: Distributed tracing for ASP.NET Core and HTTP requests
- **Logging**: Structured logging with OpenTelemetry
- **OTLP Exporter**: Export telemetry to any OTLP-compatible backend

## Running the Application

1. Ensure you have .NET 9 SDK installed
2. Install the Aspire workload:
   ```bash
   dotnet workload install aspire
   ```
3. Run the AppHost project:
   ```bash
   cd AspireOtelTest.AppHost
   dotnet run
   ```

The Aspire dashboard will open, showing the running services and telemetry data.

## Code Guidelines

This project follows .NET naming and coding conventions:

- PascalCase for public members, types, and namespaces
- Controller-based API (not minimal API)
- Proper separation of concerns with Models and Controllers folders
- Modern C# features (primary constructors, collection expressions)
