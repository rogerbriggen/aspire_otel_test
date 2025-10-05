using Serilog;
using Serilog.Sinks.OpenTelemetry;

namespace aspire_otel_test;

public class Program
{
    public static void Main(string[] args)
    {
        // Configure Serilog from appsettings.json
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build())
            .WriteTo.OpenTelemetry(options =>
            {
                options.Endpoint = "http://localhost:4317"; // Passe ggf. die Endpoint-Adresse an
                options.Protocol = Serilog.Sinks.OpenTelemetry.OtlpProtocol.Grpc;
                options.ResourceAttributes = new Dictionary<string, object>
                {
                    ["service.name"] = "aspire_otel_test"
                };
            })
            .CreateLogger();

        var builder = WebApplication.CreateBuilder(args);
        builder.Host.UseSerilog();
        builder.AddServiceDefaults();

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
