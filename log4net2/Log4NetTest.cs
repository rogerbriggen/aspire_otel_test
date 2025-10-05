namespace log4net2;

public class Log4NetTest
{
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Log4NetTest));

    public void CreateTestLog()
    {
        logger.Info("This is an info log from Log4NetTest.");
        logger.Warn($"This is a warning log from Log4NetTest. {nameof(Log4NetTest)}");
    }
}
