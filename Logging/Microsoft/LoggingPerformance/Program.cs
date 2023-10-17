using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Logging;

//var b = new Benchmarks();
//b.GlobalSetup();
//b.LogEnabled = true;
//b.Arguments = 2;
//b.Params();
//b.Typed();
//b.TypedCachedLoggerMessage();
//b.LoggerMessage();
//b.LoggerMessageGenerator();
//return;

BenchmarkSwitcher.FromAssembly(typeof(Benchmarks).Assembly).Run(args);

[HideColumns("Error", "StdDev", "Median", "RatioSD")]
[MemoryDiagnoser]
public class Benchmarks
{
    private Logger errorLogger;
    private Logger informationLogger;
    private Action<ILogger, int, bool, char, string, Exception> loggerMessage4Args;
    private Action<ILogger, int, string, Exception?> loggerMessage2Args;

    [GlobalSetup]
    public void GlobalSetup()
    {
        this.errorLogger = new Logger(LogLevel.Error);
        this.informationLogger = new Logger(LogLevel.Information);
        this.loggerMessage4Args = Microsoft.Extensions.Logging.LoggerMessage.Define<int, bool, char, string>(LogLevel.Information, default, Constants.formatString4Args);
        this.loggerMessage2Args = Microsoft.Extensions.Logging.LoggerMessage.Define<int, string>(LogLevel.Information, default, Constants.formatString2Args);

        // populate dictionaries
        TypedCachedLoggerMessageLoggingExtensions.Log(this.informationLogger, LogLevel.Warning, default, default, "AAA" + Constants.formatString4Args, default(string), default(string), default(string), default(string));
        TypedCachedLoggerMessageLoggingExtensions.Log(this.informationLogger, LogLevel.Warning, default, default, "BBB" + Constants.formatString4Args, default(object), default(object), default(object), default(object));
        TypedCachedLoggerMessageLoggingExtensions.Log(this.informationLogger, LogLevel.Warning, default, default, "CCC" + Constants.formatString2Args, default(string), default(string));
        TypedCachedLoggerMessageLoggingExtensions.Log(this.informationLogger, LogLevel.Warning, default, default, "DDD" + Constants.formatString2Args, default(object), default(object));
    }

    [Params(false, true)]
    public bool LogEnabled { get; set; }

    [Params(2, 4)]
    public int Arguments { get; set; }

    private ILogger Logger => this.LogEnabled ? this.informationLogger : this.errorLogger;


    [Benchmark(Baseline = true)]
    public void Params()
    {
        if (this.Arguments == 4)
        {
            LoggerExtensions.Log(this.Logger, LogLevel.Warning, default, default, Constants.formatString4Args, 0, false, 'c', "string");
        }
        else
        {
            LoggerExtensions.Log(this.Logger, LogLevel.Warning, default, default, Constants.formatString2Args, 0, "string");
        }
    }

    [Benchmark()]
    public void Typed()
    {
        if (this.Arguments == 4)
        {
            TypedLoggingExtensions.Log(this.Logger, LogLevel.Warning, default, default, Constants.formatString4Args, 0, false, 'c', "string");
        }
        else
        {
            TypedLoggingExtensions.Log(this.Logger, LogLevel.Warning, default, default, Constants.formatString2Args, 0, "string");
        }
    }

    //[Benchmark()]
    public void TypedCachedLoggerMessage()
    {
        if (this.Arguments == 4)
        {
            TypedCachedLoggerMessageLoggingExtensions.Log(this.Logger, LogLevel.Warning, default, default, Constants.formatString4Args, 0, false, 'c', "string");
        }
        else
        {
            TypedCachedLoggerMessageLoggingExtensions.Log(this.Logger, LogLevel.Warning, default, default, Constants.formatString2Args, 0, "string");
        }
    }

    [Benchmark()]
    public void LoggerMessage()
    {
        if (this.Arguments == 4)
        {
            this.loggerMessage4Args(this.Logger, 0, false, 'c', "string", null);
        }
        else
        {
            this.loggerMessage2Args(this.Logger, 0, "string", null);
        }
    }

    [Benchmark()]
    public void LoggerMessageGenerator()
    {
        if (this.Arguments == 4)
        {
            LoggerGeneratedExtensions.Log4Args(this.Logger, 0, false, 'c', "string", null);
        }
        else
        {
            LoggerGeneratedExtensions.Log2Args(this.Logger, 0, "string", null);
        }
    }
}
