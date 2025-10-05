# Aspire and Opentlemetry Test

Test with .Net Aspire and OpenTelemetry

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


* ## Run it

Just start the project and open the Aspire dashboard in your browser.
Then you can navigate to
- <https://localhost:7036/WeatherForecast/>
- <https://localhost:7036/WeatherForecastSerilog/> -> This will increment also our own counter (OtelLib.OtelTest.custom_counter)
