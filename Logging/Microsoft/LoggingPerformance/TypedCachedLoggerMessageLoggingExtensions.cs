using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public static class TypedCachedLoggerMessageLoggingExtensions
{
    public static void Log<T1, T2, T3, T4>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        ArgumentNullException.ThrowIfNull(logger);

        if (logger.IsEnabled(logLevel))
        {
            GetLoggerMessage4Arguments(logLevel, eventId, message)
                .Invoke(logger, arg1, arg2, arg3, arg4, exception);
        }
    }

    internal static void Log<T1, T2>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string? message, T1 arg1, T2 arg2)
    {
        ArgumentNullException.ThrowIfNull(logger);

        if (logger.IsEnabled(logLevel))
        {
            GetLoggerMessage2Arguments(logLevel, eventId, message)
                .Invoke(logger, arg1, arg2, exception);
        }
    }
    private const string NullFormat = "[null]";

    private static readonly ConcurrentDictionary<Key, Action<ILogger, object?, object?, object?, object?, Exception?>> loggerMessages4Arguments = new();

    private static readonly ConcurrentDictionary<Key, Action<ILogger, object?, object?, Exception?>> loggerMessages2Arguments = new();

    public static Action<ILogger, object?, object?, Exception?> GetLoggerMessage2Arguments(LogLevel logLevel, EventId eventId, string? message)
    {
        message ??= NullFormat;

        var loggerMessage = loggerMessages2Arguments.GetOrAdd(
            key: new Key(logLevel, eventId.Id, message, eventId.Name),
            valueFactory: _ => LoggerMessage.Define<object?, object?>(logLevel, eventId, message, new() { SkipEnabledCheck = true }));

        return loggerMessage;
    }

    public static Action<ILogger, object?, object?, object?, object?, Exception?> GetLoggerMessage4Arguments(LogLevel logLevel, EventId eventId, string? message)
    {
        message ??= NullFormat;

        var loggerMessage = loggerMessages4Arguments.GetOrAdd(
            key: new Key(logLevel, eventId.Id, message, eventId.Name),
            valueFactory: _ => LoggerMessage.Define<object?, object?, object?, object?>(logLevel, eventId, message, new() { SkipEnabledCheck = true }));

        return loggerMessage;
    }

    private readonly struct Key : IEquatable<Key>
    {
        private readonly LogLevel logLevel;
        private readonly int eventId;
        private readonly string message;
        private readonly string? eventName;

        public Key(LogLevel logLevel, int eventId, string message, string? eventName)
        {
            this.logLevel = logLevel;
            this.eventId = eventId;
            this.message = message;
            this.eventName = eventName;
        }

        public bool Equals(Key other)
            => this.logLevel == other.logLevel
                && this.eventId == other.eventId
                && string.Equals(this.message, other.message)
                && string.Equals(this.eventName, other.eventName);

        public override bool Equals([NotNullWhen(true)] object? obj)
            => obj is Key other && this.Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                this.logLevel,
                this.eventId,
                this.message.GetHashCode(StringComparison.Ordinal),
                this.eventName?.GetHashCode(StringComparison.Ordinal) ?? 0);
    }
}
