// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.Extensions.Logging
{
    public static class LoggerMessageEx
    {
        public static Action<ILogger, Exception?> Define(LogLevel logLevel, EventId eventId, string formatString)
            => Define(logLevel, eventId, formatString, options: null);

        public static Action<ILogger, Exception?> Define(LogLevel logLevel, EventId eventId, string formatString, LogDefineOptions? options)
        {
            var formatter = CreateLogValuesFormatter(formatString, expectedNamedParameterCount: 0);

            void Log(ILogger logger, Exception? exception)
            {
                logger.Log(logLevel, eventId, new LogValues(formatter), exception, LogValues.Callback);
            }

            if (options != null && options.SkipEnabledCheck)
            {
                return Log;
            }

            return (logger, exception) =>
            {
                if (logger.IsEnabled(logLevel))
                {
                    Log(logger, exception);
                }
            };
        }

        public static Action<ILogger, T1, T2, T3, Exception?> Define<T1, T2, T3>(LogLevel logLevel, EventId eventId, string formatString)
            => Define<T1, T2, T3>(logLevel, eventId, formatString, options: null);

        public static Action<ILogger, T1, T2, T3, Exception?> Define<T1, T2, T3>(LogLevel logLevel, EventId eventId, string formatString, LogDefineOptions? options)
        {
            var formatter = CreateLogValuesFormatter(formatString, expectedNamedParameterCount: 3);

            void Log(ILogger logger, T1 arg1, T2 arg2, T3 arg3, Exception? exception)
            {
                logger.Log(logLevel, eventId, new LogValues<T1, T2, T3>(formatter, arg1, arg2, arg3), exception, LogValues<T1, T2, T3>.Callback);
            }

            if (options != null && options.SkipEnabledCheck)
            {
                return Log;
            }

            return (logger, arg1, arg2, arg3, exception) =>
            {
                if (logger.IsEnabled(logLevel))
                {
                    Log(logger, arg1, arg2, arg3, exception);
                }
            };
        }

        public static Action<ILogger, T1, T2, T3, T4, T5, T6, Exception?> Define<T1, T2, T3, T4, T5, T6>(LogLevel logLevel, EventId eventId, string formatString)
            => Define<T1, T2, T3, T4, T5, T6>(logLevel, eventId, formatString, options: null);

        public static Action<ILogger, T1, T2, T3, T4, T5, T6, Exception?> Define<T1, T2, T3, T4, T5, T6>(LogLevel logLevel, EventId eventId, string formatString, LogDefineOptions? options)
        {
            var formatter = CreateLogValuesFormatter(formatString, expectedNamedParameterCount: 6);

            void Log(ILogger logger, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, Exception? exception)
            {
                logger.Log(logLevel, eventId, new LogValues<T1, T2, T3, T4, T5, T6>(formatter, arg1, arg2, arg3, arg4, arg5, arg6), exception, LogValues<T1, T2, T3, T4, T5, T6>.Callback);
            }

            if (options != null && options.SkipEnabledCheck)
            {
                return Log;
            }

            return (logger, arg1, arg2, arg3, arg4, arg5, arg6, exception) =>
            {
                if (logger.IsEnabled(logLevel))
                {
                    Log(logger, arg1, arg2, arg3, arg4, arg5, arg6, exception);
                }
            };
        }

        private static LogValuesFormatter CreateLogValuesFormatter(string formatString, int expectedNamedParameterCount)
        {
            var logValuesFormatter = new LogValuesFormatter(formatString);

            var actualCount = logValuesFormatter.ValueNames.Length;
            if (actualCount != expectedNamedParameterCount)
            {
                throw new ArgumentException($"The format string '{formatString}' does not have the expected number of named parameters. Expected {expectedNamedParameterCount} parameter(s) but found {actualCount} parameter(s).");
            }

            return logValuesFormatter;
        }
    }
}
