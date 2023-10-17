using Microsoft.Extensions.Logging;

public class Logger : ILogger
{
    private LogLevel logLevel;

    public Logger(LogLevel logLevel) => this.logLevel = logLevel;

    public IDisposable BeginScope<TState>(TState state) => throw new NotImplementedException();
    public bool IsEnabled(LogLevel logLevel) => this.logLevel <= logLevel;
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (this.IsEnabled(logLevel))
        {
            //_ = $"[{logLevel}]:{eventId}:{formatter(state, exception)}";
        }
    }
}
