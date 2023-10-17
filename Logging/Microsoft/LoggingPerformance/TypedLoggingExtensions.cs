using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

public static class TypedLoggingExtensions
{
    public static void Log<T1, T2, T3, T4>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        ArgumentNullException.ThrowIfNull(logger);

        if (logger.IsEnabled(logLevel))
        {

            LoggerExtensions.Log(
                logger: logger,
                logLevel: logLevel,
                eventId: eventId,
                exception: exception,
                message: message,
                args: new object?[] { arg1, arg2, arg3, arg4 });
        }
    }

    internal static void Log<T1, T2>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string? message, T1 arg1, T2 arg2)
    {
        ArgumentNullException.ThrowIfNull(logger);

        if (logger.IsEnabled(logLevel))
        {

            LoggerExtensions.Log(
                logger: logger,
                logLevel: logLevel,
                eventId: eventId,
                exception: exception,
                message: message,
                args: new object?[] { arg1, arg2 });
        }
    }
}
