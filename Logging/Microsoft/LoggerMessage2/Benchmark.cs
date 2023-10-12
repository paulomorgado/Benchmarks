// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

namespace LoggerMessageBenchmarks
{
    internal sealed class BenchmarkLogger : ILogger
    {
        public static readonly BenchmarkLogger Instance = new BenchmarkLogger();
        public IDisposable BeginScope<TState>(TState state) => throw new NotImplementedException();
        public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Warning;
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            formatter(state, exception);
        }
    }

    public class Benchmark
    {
        public const string Template0Arguments = "message";
        public const string Template3Arguments = "arg0 = {arg0}, arg1 = {arg1}, arg2 = {arg2}";
        public const string Template6Arguments = "arg0 = {arg0}, arg1 = {arg1}, arg2 = {arg2}, arg4 = {arg4}, arg5 = {arg5}, arg6 = {arg6}";

        public const string Text1 = "The quick brown fox jumps over the lazy dog";
        public const string Text2 = "I quickly explained that many big jobs involve few hazards";

        public const LogLevel EventLogLevel = LogLevel.Critical;
        public static readonly EventId EventEventId = new EventId(0);

        public static readonly Action<ILogger, Exception?> LoggerMessageDelegate0Arguments = LoggerMessage.Define(EventLogLevel, EventEventId, Template0Arguments);
        public static readonly Action<ILogger, int, int?, int, Exception?> LoggerMessageDelegate3ValueTypeArguments = LoggerMessage.Define<int, int?, int>(EventLogLevel, EventEventId, Template3Arguments);
        public static readonly Action<ILogger, int, int?, int, int, int?, int, Exception?> LoggerMessageDelegate6ValueTypeArguments = LoggerMessage.Define<int, int?, int, int, int?, int>(EventLogLevel, EventEventId, Template6Arguments);
        public static readonly Action<ILogger, string, string?, string, Exception?> LoggerMessageDelegate3ReferenceTypeArguments = LoggerMessage.Define<string, string?, string>(EventLogLevel, EventEventId, Template3Arguments);
        public static readonly Action<ILogger, string, string?, string, string, string?, string, Exception?> LoggerMessageDelegate6ReferenceTypeArguments = LoggerMessage.Define<string, string?, string, string, string?, string>(EventLogLevel, EventEventId, Template6Arguments);

        public static readonly Action<ILogger, Exception?> GeneratedLoggerMessageDelegate0Arguments = LoggerMessage.Define(EventLogLevel, EventEventId, Template0Arguments, new LogDefineOptions { SkipEnabledCheck = true });
        public static readonly Action<ILogger, int, int?, int, Exception?> GeneratedLoggerMessageDelegate3ValueTypeArguments = LoggerMessage.Define<int, int?, int>(EventLogLevel, EventEventId, Template3Arguments, new LogDefineOptions { SkipEnabledCheck = true });
        public static readonly Action<ILogger, int, int?, int, int, int?, int, Exception?> GeneratedLoggerMessageDelegate6ValueTypeArguments = LoggerMessage.Define<int, int?, int, int, int?, int>(EventLogLevel, EventEventId, Template6Arguments, new LogDefineOptions { SkipEnabledCheck = true });
        public static readonly Action<ILogger, string, string?, string, Exception?> GeneratedLoggerMessageDelegate3ReferenceTypeArguments = LoggerMessage.Define<string, string?, string>(EventLogLevel, EventEventId, Template3Arguments, new LogDefineOptions { SkipEnabledCheck = true });
        public static readonly Action<ILogger, string, string?, string, string, string?, string, Exception?> GeneratedLoggerMessageDelegate6ReferenceTypeArguments = LoggerMessage.Define<string, string?, string, string, string?, string>(EventLogLevel, EventEventId, Template6Arguments, new LogDefineOptions { SkipEnabledCheck = true });

        public static readonly Action<ILogger, Exception?> LoggerMessageExDelegate0Arguments = LoggerMessageEx.Define(EventLogLevel, EventEventId, Template0Arguments);
        public static readonly Action<ILogger, int, int?, int, Exception?> LoggerMessageExDelegate3ValueTypeArguments = LoggerMessageEx.Define<int, int?, int>(EventLogLevel, EventEventId, Template3Arguments);
        public static readonly Action<ILogger, int, int?, int, int, int?, int, Exception?> LoggerMessageExDelegate6ValueTypeArguments = LoggerMessageEx.Define<int, int?, int, int, int?, int>(EventLogLevel, EventEventId, Template6Arguments);
        public static readonly Action<ILogger, string, string?, string, Exception?> LoggerMessageExDelegate3ReferenceTypeArguments = LoggerMessageEx.Define<string, string?, string>(EventLogLevel, EventEventId, Template3Arguments);
        public static readonly Action<ILogger, string, string?, string, string, string?, string, Exception?> LoggerMessageExDelegate6ReferenceTypeArguments = LoggerMessageEx.Define<string, string?, string, string, string?, string>(EventLogLevel, EventEventId, Template6Arguments);

        public static readonly LogValuesFormatter LogValuesFormatter0Arguments = new LogValuesFormatter(Template0Arguments);
        public static readonly LogValuesFormatter LogValuesFormatter3Arguments = new LogValuesFormatter(Template3Arguments);
        public static readonly LogValuesFormatter LogValuesFormatter6Arguments = new LogValuesFormatter(Template6Arguments);
    }

    [MemoryDiagnoser]
    public class Benchmark0Arguments
    {
        [Benchmark(Baseline = true)]
        public void LoggerMessageDefine0Arguments()
            => Benchmark.LoggerMessageDelegate0Arguments(BenchmarkLogger.Instance, null);

        [Benchmark]
        public void LoggerMessageDefineEx0Arguments()
            => Benchmark.LoggerMessageExDelegate0Arguments(BenchmarkLogger.Instance, null);
    }

    [MemoryDiagnoser]
    public class Benchmark0ArgumentsGenerated
    {
        [Benchmark(Baseline = true)]
        public void LoggerMessageDefine0ArgumentsGenerated()
        {
            if (BenchmarkLogger.Instance.IsEnabled(Benchmark.EventLogLevel))
            {
                Benchmark.GeneratedLoggerMessageDelegate0Arguments(BenchmarkLogger.Instance, null);
            }
        }

        [Benchmark]
        public void LoggerMessageDefineEx0ArgumentsGenerated()
        {
            if (BenchmarkLogger.Instance.IsEnabled(Benchmark.EventLogLevel))
            {
                BenchmarkLogger.Instance.Log(
                    logLevel: Benchmark.EventLogLevel,
                    eventId: Benchmark.EventEventId,
                    state: new LogValues(Benchmark.LogValuesFormatter0Arguments),
                    exception: null,
                    formatter: LogValues.Callback);
            }
        }
    }

    [MemoryDiagnoser]
    public class Benchmark3ValueTypeArguments
    {
        [Benchmark(Baseline = true)]
        public void LoggerMessageDefine3ValueTypeArguments()
            => Benchmark.LoggerMessageDelegate3ValueTypeArguments(BenchmarkLogger.Instance, 0, null, int.MaxValue, null);

        [Benchmark]
        public void LoggerMessageDefineEx3ValueTypeArguments()
            => Benchmark.LoggerMessageExDelegate3ValueTypeArguments(BenchmarkLogger.Instance, 0, null, int.MaxValue, null);
    }

    [MemoryDiagnoser]
    public class Benchmark3ValueTypeArgumentsGenerated
    {
        [Benchmark(Baseline = true)]
        public void LoggerMessageDefine3ValueTypeArgumentsGenerated()
        {
            if (BenchmarkLogger.Instance.IsEnabled(Benchmark.EventLogLevel))
            {
                Benchmark.GeneratedLoggerMessageDelegate3ValueTypeArguments(BenchmarkLogger.Instance, 0, null, int.MaxValue, null);
            }
        }

        [Benchmark]
        public void LoggerMessageDefineEx3ValueTypeArgumentsGenerated()
        {
            if (BenchmarkLogger.Instance.IsEnabled(Benchmark.EventLogLevel))
            {
                BenchmarkLogger.Instance.Log(
                    logLevel: Benchmark.EventLogLevel,
                    eventId: Benchmark.EventEventId,
                    state: new LogValues<int, int?, int>(Benchmark.LogValuesFormatter3Arguments, 0, null, int.MaxValue),
                    exception: null,
                    formatter: LogValues<int, int?, int>.Callback);
            }
        }
    }

    [MemoryDiagnoser]
    public class Benchmark6ValueTypeArguments
    {
        [Benchmark(Baseline = true)]
        public void LoggerMessageDefine6ValueTypeArguments()
            => Benchmark.LoggerMessageDelegate6ValueTypeArguments(BenchmarkLogger.Instance, 0, null, int.MaxValue, 0, null, int.MinValue, null);

        [Benchmark]
        public void LoggerMessageDefineEx6ValueTypeArguments()
            => Benchmark.LoggerMessageExDelegate6ValueTypeArguments(BenchmarkLogger.Instance, 0, null, int.MaxValue, 0, null, int.MinValue, null);
    }

    [MemoryDiagnoser]
    public class Benchmark6ValueTypeArgumentsGenerated
    {
        [Benchmark(Baseline = true)]
        public void LoggerMessageDefine6ValueTypeArgumentsGenerated()
        {
            if (BenchmarkLogger.Instance.IsEnabled(Benchmark.EventLogLevel))
            {
                Benchmark.GeneratedLoggerMessageDelegate6ValueTypeArguments(BenchmarkLogger.Instance, 0, null, int.MaxValue, 0, null, int.MinValue, null);
            }
        }

        [Benchmark]
        public void LoggerMessageDefineEx6ValueTypeArgumentsGenerated()
        {
            if (BenchmarkLogger.Instance.IsEnabled(Benchmark.EventLogLevel))
            {
                BenchmarkLogger.Instance.Log(
                    logLevel: Benchmark.EventLogLevel,
                    eventId: Benchmark.EventEventId,
                    state: new LogValues<int, int?, int, int, int?, int>(Benchmark.LogValuesFormatter6Arguments, 0, null, int.MaxValue, 0, null, int.MinValue),
                    exception: null,
                    formatter: LogValues<int, int?, int, int, int?, int>.Callback);
            }
        }
    }

    [MemoryDiagnoser]
    public class Benchmark3ReferenceTypeArguments
    {
        [Benchmark(Baseline = true)]
        public void LoggerMessageDefine3ReferenceTypeArguments()
            => Benchmark.LoggerMessageDelegate3ReferenceTypeArguments(BenchmarkLogger.Instance, string.Empty, null, Benchmark.Text1, null);

        [Benchmark]
        public void LoggerMessageDefineEx3ReferenceTypeArguments()
            => Benchmark.LoggerMessageExDelegate3ReferenceTypeArguments(BenchmarkLogger.Instance, string.Empty, null, Benchmark.Text1, null);
    }

    [MemoryDiagnoser]
    public class Benchmark3ReferenceTypeArgumentsGenerated
    {
        [Benchmark(Baseline = true)]
        public void LoggerMessageDefine3ReferenceTypeArgumentsGenerated()
        {
            if (BenchmarkLogger.Instance.IsEnabled(Benchmark.EventLogLevel))
            {
                Benchmark.GeneratedLoggerMessageDelegate3ReferenceTypeArguments(BenchmarkLogger.Instance, string.Empty, null, Benchmark.Text1, null);
            }
        }

        [Benchmark]
        public void LoggerMessageDefineEx3ReferenceTypeArgumentsGenerated()
        {
            if (BenchmarkLogger.Instance.IsEnabled(Benchmark.EventLogLevel))
            {
                BenchmarkLogger.Instance.Log(
                    logLevel: Benchmark.EventLogLevel,
                    eventId: Benchmark.EventEventId,
                    state: new LogValues<string, string?, string>(Benchmark.LogValuesFormatter6Arguments, string.Empty, null, Benchmark.Text1),
                    exception: null,
                    formatter: LogValues<string, string?, string>.Callback);
            }
        }
    }

    [MemoryDiagnoser]
    public class Benchmark6ReferenceTypeArguments
    {
        [Benchmark(Baseline = true)]
        public void LoggerMessageDefine6ReferenceTypeArguments()
            => Benchmark.LoggerMessageDelegate6ReferenceTypeArguments(BenchmarkLogger.Instance, string.Empty, null, Benchmark.Text1, string.Empty, null, Benchmark.Text2, null);

        [Benchmark]
        public void LoggerMessageDefineEx6ReferenceTypeArguments()
            => Benchmark.LoggerMessageExDelegate6ReferenceTypeArguments(BenchmarkLogger.Instance, string.Empty, null, Benchmark.Text1, string.Empty, null, Benchmark.Text2, null);
    }

    [MemoryDiagnoser]
    public class Benchmark6ReferenceTypeArgumentsGenerated
    {
        [Benchmark(Baseline = true)]
        public void LoggerMessageDefine6ReferenceTypeArgumentsGenerated()
        {
            if (BenchmarkLogger.Instance.IsEnabled(Benchmark.EventLogLevel))
            {
                Benchmark.GeneratedLoggerMessageDelegate6ReferenceTypeArguments(BenchmarkLogger.Instance, string.Empty, null, Benchmark.Text1, string.Empty, null, Benchmark.Text2, null);
            }
        }

        [Benchmark]
        public void LoggerMessageDefineEx6ReferenceTypeArgumentsGenerated()
        {
            if (BenchmarkLogger.Instance.IsEnabled(Benchmark.EventLogLevel))
            {
                BenchmarkLogger.Instance.Log(
                    logLevel: Benchmark.EventLogLevel,
                    eventId: Benchmark.EventEventId,
                    state: new LogValues<string, string?, string, string, string?, string>(Benchmark.LogValuesFormatter6Arguments, string.Empty, null, Benchmark.Text1, string.Empty, null, Benchmark.Text2),
                    exception: null,
                    formatter: LogValues<string, string?, string, string, string?, string>.Callback);
            }
        }
    }
}
