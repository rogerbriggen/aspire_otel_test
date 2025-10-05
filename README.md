# Aspire and OpenTelemetry Test

Test with .NET Aspire and OpenTelemetry

## Projects Overview

- **aspire_otel_test**: Main ASP.NET Core Web API project. Demonstrates integration of Serilog, OpenTelemetry, and log4net forwarding. Provides endpoints for weather forecasts and custom metrics.
- **OtelLib**: Class library for custom OpenTelemetry metrics. Contains logic to generate and export metrics (e.g., counters) to the Aspire dashboard.
- **aspire_otel_test.ServiceDefaults**: Shared library for service defaults, including OpenTelemetry, health checks, and service discovery configuration. Used by all service projects for consistent setup.
- **aspire_otel_test.AppHost**: Distributed application host for orchestrating and running the Aspire solution. Entry point for launching all services together.
- **log4net2**: Example project using log4net for logging. Demonstrates how log4net logs can be forwarded to Serilog and included in the central logging pipeline.

## Aspire

* <https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview>
* <https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/dashboard/standalone?tabs=bash>

## OpenTelemetry

* <https://learn.microsoft.com/en-us/dotnet/core/diagnostics/observability-with-otel>
* <https://opentelemetry.io/docs/specs/>
* <https://opentelemetry.io/docs/languages/dotnet/>
* <https://github.com/open-telemetry/opentelemetry-dotnet>

### Default Ports

* OTLP/gRPC: Uses port 4317 by default.
* OTLP/HTTP: Uses port 4318 by default.

## Logging

- **Serilog**: Main logging provider for the web project. Configured to write to console, debug output, and OpenTelemetry.
- **log4net**: Legacy logging provider. Logs are forwarded to Serilog using a custom appender, so all logs appear in the same sinks.

## Metrics

- Custom metrics are generated in `OtelLib` and registered in the OpenTelemetry pipeline. These metrics are visible in the Aspire dashboard.

## How to Run

Just start the project and open the Aspire dashboard in your browser.
Then you can navigate to:
- <https://localhost:7036/WeatherForecast/>
- <https://localhost:7036/WeatherForecastSerilog/> ? This will increment our own counter (`OtelLib.OtelTest.custom_counter`)

## Useful Information

- All logs (Serilog and log4net) are unified and exported via Serilog sinks.
- Custom OpenTelemetry metrics require explicit registration in the service defaults.
- Health checks and service discovery are preconfigured for all services.
- The solution demonstrates best practices for observability in modern .NET distributed applications.
