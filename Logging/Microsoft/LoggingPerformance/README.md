# Performance implications of the different methods of logging

This benchmark compares the different options of logging 4 arguments.

For the purpose of the test, the logger used is extremelly simple:

```csharp
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
        }
    }
}
```

## Scenarios

### Params

This method uses the [LoggerExtensions Class](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loggerextensions)

The methods in this class use a [params](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/params) ` object[]` for the logging arguments and,
for that reason, regardless of the logging level being enabled or not, the array is always intantiated.

### Typed

This method is similar to the corresponding method on [LoggerExtensions Class](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loggerextensions),
but uses typed arguments ([code](BenchmarkLoggingExtensions.cs)).

The logging operation is forwarded to a methdo in the [LoggerExte
nsions Class](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loggerextensions),
but only if the logging level is enabled. For that reason, the `object[]` is instantiated only when the logging level is enabled.

### LoggerMessage

This method uses the [LoggerMessage Class](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loggermessage) to create a strongly typed delegate for the arguments.

Logger messages do not require an array of arguments and the preprocesses the message format.

For more information: [High-performance logging in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/high-performance-logging).

### LoggerMessageGenerator

This method is similar to **LoggerMessage**, except that it uses compile-time logging source generation to generate the logger message delegate and a method for invocationg the delegate.

The code generator generates code that checks if the log level is enabled before ivocating the delegate and the delegate is greated to not check the log level.

For more information: [Compile-time logging source generation](https://learn.microsoft.com/en-us/dotnet/core/extensions/logger-message-generator).

## Results

```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
13th Gen Intel Core i9-13900K, 1 CPU, 32 logical and 24 physical cores
.NET SDK 8.0.100-rc.2.23502.2
  [Host]     : .NET 8.0.0 (8.0.23.47906), X64 RyuJIT AVX2
  Job-HUXQSG : .NET 6.0.23 (6.0.2323.48002), X64 RyuJIT AVX2
  Job-FWMVCA : .NET 7.0.12 (7.0.1223.47720), X64 RyuJIT AVX2
  Job-ENAABE : .NET 8.0.0 (8.0.23.47906), X64 RyuJIT AVX2


```
| Method                 | Runtime  | LogEnabled | Arguments | Mean       | Ratio | Gen0   | Allocated | Alloc Ratio |
|----------------------- |--------- |----------- |---------- |-----------:|------:|-------:|----------:|------------:|
| **Params**                 | **.NET 6.0** | **False**      | **2**         | **24.9026 ns** |  **1.37** | **0.0034** |      **64 B** |        **1.00** |
| Typed                  | .NET 6.0 | False      | 2         |  2.1061 ns |  0.12 |      - |         - |        0.00 |
| LoggerMessage          | .NET 6.0 | False      | 2         |  2.6297 ns |  0.14 |      - |         - |        0.00 |
| LoggerMessageGenerator | .NET 6.0 | False      | 2         |  1.9349 ns |  0.11 |      - |         - |        0.00 |
| Params                 | .NET 7.0 | False      | 2         | 25.4994 ns |  1.41 | 0.0034 |      64 B |        1.00 |
| Typed                  | .NET 7.0 | False      | 2         |  2.1538 ns |  0.12 |      - |         - |        0.00 |
| LoggerMessage          | .NET 7.0 | False      | 2         |  2.8880 ns |  0.16 |      - |         - |        0.00 |
| LoggerMessageGenerator | .NET 7.0 | False      | 2         |  1.9726 ns |  0.11 |      - |         - |        0.00 |
| Params                 | .NET 8.0 | False      | 2         | 18.1189 ns |  1.00 | 0.0034 |      64 B |        1.00 |
| Typed                  | .NET 8.0 | False      | 2         |  0.2915 ns |  0.02 |      - |         - |        0.00 |
| LoggerMessage          | .NET 8.0 | False      | 2         |  0.2883 ns |  0.02 |      - |         - |        0.00 |
| LoggerMessageGenerator | .NET 8.0 | False      | 2         |  0.2779 ns |  0.02 |      - |         - |        0.00 |
|                        |          |            |           |            |       |        |           |             |
| **Params**                 | **.NET 6.0** | **False**      | **4**         | **31.7635 ns** | **1.281** | **0.0068** |     **128 B** |        **1.00** |
| Typed                  | .NET 6.0 | False      | 4         |  1.9246 ns | 0.078 |      - |         - |        0.00 |
| LoggerMessage          | .NET 6.0 | False      | 4         |  2.8974 ns | 0.117 |      - |         - |        0.00 |
| LoggerMessageGenerator | .NET 6.0 | False      | 4         |  1.7729 ns | 0.072 |      - |         - |        0.00 |
| Params                 | .NET 7.0 | False      | 4         | 31.3542 ns | 1.265 | 0.0068 |     128 B |        1.00 |
| Typed                  | .NET 7.0 | False      | 4         |  1.8182 ns | 0.073 |      - |         - |        0.00 |
| LoggerMessage          | .NET 7.0 | False      | 4         |  2.8460 ns | 0.115 |      - |         - |        0.00 |
| LoggerMessageGenerator | .NET 7.0 | False      | 4         |  1.7554 ns | 0.071 |      - |         - |        0.00 |
| Params                 | .NET 8.0 | False      | 4         | 24.7899 ns | 1.000 | 0.0068 |     128 B |        1.00 |
| Typed                  | .NET 8.0 | False      | 4         |  0.2801 ns | 0.011 |      - |         - |        0.00 |
| LoggerMessage          | .NET 8.0 | False      | 4         |  0.2878 ns | 0.012 |      - |         - |        0.00 |
| LoggerMessageGenerator | .NET 8.0 | False      | 4         |  0.0921 ns | 0.004 |      - |         - |        0.00 |
|                        |          |            |           |            |       |        |           |             |
| **Params**                 | **.NET 6.0** | **True**       | **2**         | **25.0759 ns** |  **1.40** | **0.0034** |      **64 B** |        **1.00** |
| Typed                  | .NET 6.0 | True       | 2         | 26.2365 ns |  1.46 | 0.0034 |      64 B |        1.00 |
| LoggerMessage          | .NET 6.0 | True       | 2         |  9.0386 ns |  0.50 |      - |         - |        0.00 |
| LoggerMessageGenerator | .NET 6.0 | True       | 2         |  7.7205 ns |  0.43 |      - |         - |        0.00 |
| Params                 | .NET 7.0 | True       | 2         | 24.8535 ns |  1.38 | 0.0034 |      64 B |        1.00 |
| Typed                  | .NET 7.0 | True       | 2         | 25.8516 ns |  1.44 | 0.0034 |      64 B |        1.00 |
| LoggerMessage          | .NET 7.0 | True       | 2         |  9.6807 ns |  0.54 |      - |         - |        0.00 |
| LoggerMessageGenerator | .NET 7.0 | True       | 2         |  9.0674 ns |  0.50 |      - |         - |        0.00 |
| Params                 | .NET 8.0 | True       | 2         | 17.9729 ns |  1.00 | 0.0034 |      64 B |        1.00 |
| Typed                  | .NET 8.0 | True       | 2         | 18.9614 ns |  1.06 | 0.0034 |      64 B |        1.00 |
| LoggerMessage          | .NET 8.0 | True       | 2         |  7.2775 ns |  0.40 |      - |         - |        0.00 |
| LoggerMessageGenerator | .NET 8.0 | True       | 2         |  7.6559 ns |  0.43 |      - |         - |        0.00 |
|                        |          |            |           |            |       |        |           |             |
| **Params**                 | **.NET 6.0** | **True**       | **4**         | **31.0947 ns** |  **1.29** | **0.0068** |     **128 B** |        **1.00** |
| Typed                  | .NET 6.0 | True       | 4         | 31.9057 ns |  1.33 | 0.0068 |     128 B |        1.00 |
| LoggerMessage          | .NET 6.0 | True       | 4         |  8.4916 ns |  0.35 |      - |         - |        0.00 |
| LoggerMessageGenerator | .NET 6.0 | True       | 4         |  7.9179 ns |  0.33 |      - |         - |        0.00 |
| Params                 | .NET 7.0 | True       | 4         | 31.2276 ns |  1.30 | 0.0068 |     128 B |        1.00 |
| Typed                  | .NET 7.0 | True       | 4         | 33.5794 ns |  1.40 | 0.0068 |     128 B |        1.00 |
| LoggerMessage          | .NET 7.0 | True       | 4         |  9.3239 ns |  0.39 |      - |         - |        0.00 |
| LoggerMessageGenerator | .NET 7.0 | True       | 4         |  9.1307 ns |  0.38 |      - |         - |        0.00 |
| Params                 | .NET 8.0 | True       | 4         | 24.0681 ns |  1.00 | 0.0068 |     128 B |        1.00 |
| Typed                  | .NET 8.0 | True       | 4         | 24.8185 ns |  1.03 | 0.0068 |     128 B |        1.00 |
| LoggerMessage          | .NET 8.0 | True       | 4         |  7.2761 ns |  0.30 |      - |         - |        0.00 |
| LoggerMessageGenerator | .NET 8.0 | True       | 4         |  7.2935 ns |  0.30 |      - |         - |        0.00 |

## Analysis

When the log level is not enabled, the results show that the **Params** method takes signinficant more time than the others and also allocates memory (the `object[]`).

When the log level is enabled, the **Typed** method is slightly slower than the **Params** because the log level ends up being checked twice.
This happens because the methods from [LoggerExtensions Class](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loggerextensions) use an
[internal formatter](https://source.dot.net/#Microsoft.Extensions.Logging.Abstractions/FormattedLogValues.cs). Replicating the formatter or, writting a better one,
would overcome this difference.

The difference between **LoggerMessage** and **LoggerMessageGenerator** is due to the fact that, for **LoggerMessage** the delegate is always invocated and
the code invocated checks if the log level is enabled, while **LoggerMessageGenerator** checks the if the log level is enabled and only invokes the delegate if it is
and the code invoked by the delegate doesn't.

While the current recomendation is to use the source generator, there is potential value in using the typed approach on code bases that use
the [LoggerExtensions Class](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loggerextensions).

Depending on the concrete loggers used, these times might become irrlevant. But **Params** is always the worst case scenario when the logger is not enabled.

Depending on the number of messages cached by **Params** (and **Typed** are just a proxy for that), the timings for **Params** and **Typed** will increase.
