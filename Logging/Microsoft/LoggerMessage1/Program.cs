// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Logging;

namespace LoggerMessageBenchmarks
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        private static Action<ILogger, Exception?> loggerMessageWarningNoArgs = LoggerMessage.Define(LogLevel.Warning, new EventId(0), "test");
        private static Action<ILogger, Exception?> loggerMessageDebugNoArgs = LoggerMessage.Define(LogLevel.Debug, new EventId(0), "test");
        private static Action<ILogger, int, Exception?> loggerMessageWarningIntArg = LoggerMessage.Define<int>(LogLevel.Warning, new EventId(0), "test {Number}");
        private static Action<ILogger, int, Exception?> loggerMessageDebugIntArg = LoggerMessage.Define<int>(LogLevel.Debug, new EventId(0), "test {Number}");
        private static Action<ILogger, string, Exception?> loggerMessageWarningStringArg = LoggerMessage.Define<string>(LogLevel.Warning, new EventId(0), "test {Text}");
        private static Action<ILogger, string, Exception?> loggerMessageDebugStringArg = LoggerMessage.Define<string>(LogLevel.Debug, new EventId(0), "test {Text}");

        [Benchmark]
        public void LogWarningNoArgs() => BenchmarkLogger.Instance.LogWarning("test");

        [Benchmark]
        public void LogDebugNoArgs() => BenchmarkLogger.Instance.LogDebug("test");

        [Benchmark]
        public void LoggerMessageWarningNoArgs() => loggerMessageWarningNoArgs(BenchmarkLogger.Instance, null);

        [Benchmark]
        public void LoggerMessageDebugNoArgs() => loggerMessageDebugNoArgs(BenchmarkLogger.Instance, null);

        [Benchmark]
        public void LogWarningIntArg() => BenchmarkLogger.Instance.LogWarning("test {Number}", 42);

        [Benchmark]
        public void LogDebugIntArg() => BenchmarkLogger.Instance.LogDebug("test {Number}", 42);

        [Benchmark]
        public void LoggerMessageWarningIntArg() => loggerMessageWarningIntArg(BenchmarkLogger.Instance, 42, null);

        [Benchmark]
        public void LoggerMessageDebugIntArg() => loggerMessageDebugIntArg(BenchmarkLogger.Instance, 42, null);

        [Benchmark]
        public void LogWarningStringArg() => BenchmarkLogger.Instance.LogWarning("test {Text}", "blah");

        [Benchmark]
        public void LogDebugStringArg() => BenchmarkLogger.Instance.LogDebug("test {Text}", "blah");

        [Benchmark]
        public void LoggerMessageWarningStringArg() => loggerMessageWarningStringArg(BenchmarkLogger.Instance, "blah", null);

        [Benchmark]
        public void LoggerMessageDebugStringArg() => loggerMessageDebugStringArg(BenchmarkLogger.Instance, "blah", null);
    }

    public class BenchmarkLogger : ILogger
    {
        public static readonly BenchmarkLogger Instance = new BenchmarkLogger();
        public IDisposable BeginScope<TState>(TState state) => throw new NotImplementedException();
        public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Warning;
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
        }
    }
}
