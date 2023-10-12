[Serilog](https://serilog.net/) provides a [deestructuring operator](https://github.com/serilog/serilog/wiki/Structured-Data#preserving-object-structure) to preserve object structure while logging.

But that comes with a cost.

This benchmark measures the logging with `LogEventLevel.Debug` and `LogEventLevel.Information` to a logger configured with `LogEventLevel.Information`.

```

BenchmarkDotNet v0.13.8, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
13th Gen Intel Core i9-13900K, 1 CPU, 32 logical and 24 physical cores
.NET SDK 8.0.100-rc.2.23502.2
  [Host]     : .NET 8.0.0 (8.0.23.47906), X64 RyuJIT AVX2
  Job-FAODUB : .NET 6.0.23 (6.0.2323.48002), X64 RyuJIT AVX2
  Job-JVGSRH : .NET 7.0.12 (7.0.1223.47720), X64 RyuJIT AVX2
  Job-DMVWKG : .NET 8.0.0 (8.0.23.47906), X64 RyuJIT AVX2


```
| Method                | Runtime  | LogEventLevel | Mean       | Ratio | Gen0   | Allocated | Alloc Ratio |
|---------------------- |--------- |-------------- |-----------:|------:|-------:|----------:|------------:|
| **DiscreteProperties**    | **.NET 6.0** | **Debug**         |  **12.073 ns** |  **1.62** | **0.0055** |     **104 B** |        **1.00** |
| PropertyDestructuring | .NET 6.0 | Debug         |   4.979 ns |  0.67 |      - |         - |        0.00 |
| DiscreteProperties    | .NET 7.0 | Debug         |   9.876 ns |  1.34 | 0.0055 |     104 B |        1.00 |
| PropertyDestructuring | .NET 7.0 | Debug         |   6.015 ns |  0.81 |      - |         - |        0.00 |
| DiscreteProperties    | .NET 8.0 | Debug         |   7.336 ns |  1.00 | 0.0055 |     104 B |        1.00 |
| PropertyDestructuring | .NET 8.0 | Debug         |   5.093 ns |  0.69 |      - |         - |        0.00 |
|                       |          |               |            |       |        |           |             |
| **DiscreteProperties**    | **.NET 6.0** | **Information**   | **247.958 ns** |  **1.31** | **0.0358** |     **680 B** |        **1.00** |
| PropertyDestructuring | .NET 6.0 | Information   | 923.810 ns |  4.87 | 0.0877 |    1664 B |        2.45 |
| DiscreteProperties    | .NET 7.0 | Information   | 227.196 ns |  1.20 | 0.0360 |     680 B |        1.00 |
| PropertyDestructuring | .NET 7.0 | Information   | 697.015 ns |  3.67 | 0.0877 |    1664 B |        2.45 |
| DiscreteProperties    | .NET 8.0 | Information   | 189.758 ns |  1.00 | 0.0360 |     680 B |        1.00 |
| PropertyDestructuring | .NET 8.0 | Information   | 525.235 ns |  2.77 | 0.0877 |    1664 B |        2.45 |

While it shows that when the log is not emitted (`LogEventLevel.Debug`) the performance os property destructuring (both in CPU and memory)
is better than the performance of discrete properties, that drastically changes when the log is emitted (`LogEventLevel.Information`).
