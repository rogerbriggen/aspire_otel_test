using OpenTelemetry.Metrics;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;

namespace OtelLib;

public class OtelTest(ILogger<OtelTest> logger)
{
    private static Meter s_meter = new Meter("OtelLib.OtelTest", "1.0.0");
    private static Counter<long> s_counter = s_meter.CreateCounter<long>("custom_counter");

    public void GenerateMetric(long value, string? tag = null)
    {
        if (tag != null)
        {
            s_counter.Add(value, new KeyValuePair<string, object?>("tag", tag));
        }
        else
        {
            s_counter.Add(value);
        }
        logger.LogInformation("Metric generated: value={value}, tag={tag}", value, tag);
    }
}
