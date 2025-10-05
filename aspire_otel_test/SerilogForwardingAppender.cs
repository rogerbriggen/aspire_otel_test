using log4net.Appender;
using log4net.Core;
using Serilog;

namespace aspire_otel_test;

public class SerilogForwardingAppender : AppenderSkeleton
{
    protected override void Append(LoggingEvent loggingEvent)
    {
        var level = loggingEvent.Level;
        var message = loggingEvent.RenderedMessage;
        var exception = loggingEvent.ExceptionObject;
        var loggerName = loggingEvent.LoggerName;

        var serilogLogger = Log.Logger.ForContext("SourceContext", loggerName);

        if (level >= Level.Error)
            serilogLogger.Error(exception, message);
        else if (level >= Level.Warn)
            serilogLogger.Warning(exception, message);
        else if (level >= Level.Info)
            serilogLogger.Information(exception, message);
        else if (level >= Level.Debug)
            serilogLogger.Debug(exception, message);
        else
            serilogLogger.Verbose(exception, message);
    }
}
