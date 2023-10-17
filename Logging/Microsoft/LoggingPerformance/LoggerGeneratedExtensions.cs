namespace Microsoft.Extensions.Logging;

public static partial class LoggerGeneratedExtensions
{
    [LoggerMessage(4, LogLevel.Warning, Constants.formatString4Args)]
    public static partial void Log4Args(this ILogger logger, int @int, bool @bool, char @char, string? @string, Exception? @exception);

    [LoggerMessage(2, LogLevel.Warning, Constants.formatString2Args)]
    public static partial void Log2Args(this ILogger logger, int @int, string? @string, Exception? @exception);
}
