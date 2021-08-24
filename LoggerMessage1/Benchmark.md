``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT
  Job-IBQSHY : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  Job-OFBPDV : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT
  Job-TGDLJA : .NET Core 3.1.18 (CoreCLR 4.700.21.35901, CoreFX 4.700.21.36305), X64 RyuJIT
  Job-DDUFUW : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT

```

|                        Method |            Runtime |       Mean |      Error |     StdDev |     Median | Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------------ |------------------- |-----------:|-----------:|-----------:|-----------:|------:|--------:|-------:|----------:|
|              LogWarningNoArgs |           .NET 6.0 |  28.664 ns |  2.5950 ns |  7.6513 ns |  25.598 ns |  0.59 |    0.17 |      - |         - |
|              LogWarningNoArgs |           .NET 5.0 |  30.025 ns |  3.0779 ns |  9.0751 ns |  26.821 ns |  0.61 |    0.18 |      - |         - |
|              LogWarningNoArgs |      .NET Core 3.1 |  37.714 ns |  0.7405 ns |  1.4959 ns |  37.544 ns |  0.80 |    0.06 |      - |         - |
|              LogWarningNoArgs | .NET Framework 4.8 |  49.329 ns |  1.3944 ns |  4.0675 ns |  48.752 ns |  1.00 |    0.00 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|                LogDebugNoArgs |           .NET 6.0 |  20.512 ns |  0.4471 ns |  0.9332 ns |  20.462 ns |  0.43 |    0.04 |      - |         - |
|                LogDebugNoArgs |           .NET 5.0 |  23.448 ns |  2.0850 ns |  6.0821 ns |  20.734 ns |  0.49 |    0.13 |      - |         - |
|                LogDebugNoArgs |      .NET Core 3.1 |  34.806 ns |  0.7108 ns |  1.6474 ns |  34.733 ns |  0.73 |    0.08 |      - |         - |
|                LogDebugNoArgs | .NET Framework 4.8 |  47.618 ns |  1.4638 ns |  4.2930 ns |  48.310 ns |  1.00 |    0.00 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|              LogWarningIntArg |           .NET 6.0 |  92.157 ns |  1.8926 ns |  4.4240 ns |  91.469 ns |  0.95 |    0.09 | 0.0134 |      56 B |
|              LogWarningIntArg |           .NET 5.0 |  64.933 ns |  1.2720 ns |  3.4173 ns |  64.800 ns |  0.66 |    0.07 | 0.0134 |      56 B |
|              LogWarningIntArg |      .NET Core 3.1 | 104.286 ns |  2.1321 ns |  4.7688 ns | 103.060 ns |  1.07 |    0.11 | 0.0134 |      56 B |
|              LogWarningIntArg | .NET Framework 4.8 |  99.457 ns |  2.8379 ns |  8.3677 ns |  97.360 ns |  1.00 |    0.00 | 0.0134 |      56 B |
|                               |                    |            |            |            |            |       |         |        |           |
|                LogDebugIntArg |           .NET 6.0 |  88.957 ns |  7.7807 ns | 21.4304 ns |  86.682 ns |  0.91 |    0.24 | 0.0134 |      56 B |
|                LogDebugIntArg |           .NET 5.0 |  74.009 ns |  5.1974 ns | 14.8285 ns |  67.008 ns |  0.75 |    0.13 | 0.0134 |      56 B |
|                LogDebugIntArg |      .NET Core 3.1 | 102.834 ns |  2.1014 ns |  5.3104 ns | 102.247 ns |  1.07 |    0.09 | 0.0134 |      56 B |
|                LogDebugIntArg | .NET Framework 4.8 |  99.805 ns |  2.8456 ns |  8.3902 ns |  99.081 ns |  1.00 |    0.00 | 0.0134 |      56 B |
|                               |                    |            |            |            |            |       |         |        |           |
|           LogWarningStringArg |           .NET 6.0 |  93.062 ns | 11.3604 ns | 33.4964 ns |  98.467 ns |  0.54 |    0.04 | 0.0076 |      32 B |
|           LogWarningStringArg |           .NET 5.0 |  70.617 ns |  5.2272 ns | 15.0815 ns |  65.302 ns |  0.62 |    0.14 | 0.0076 |      32 B |
|           LogWarningStringArg |      .NET Core 3.1 | 101.049 ns |  3.6568 ns | 10.5507 ns |  96.957 ns |  0.86 |    0.07 | 0.0076 |      32 B |
|           LogWarningStringArg | .NET Framework 4.8 | 112.781 ns |  2.2972 ns |  4.3707 ns | 112.155 ns |  1.00 |    0.00 | 0.0076 |      32 B |
|                               |                    |            |            |            |            |       |         |        |           |
|             LogDebugStringArg |           .NET 6.0 |  95.258 ns |  4.8983 ns | 14.2108 ns |  95.542 ns |  0.85 |    0.14 | 0.0076 |      32 B |
|             LogDebugStringArg |           .NET 5.0 |  76.774 ns |  4.8889 ns | 14.1835 ns |  77.469 ns |  0.69 |    0.14 | 0.0076 |      32 B |
|             LogDebugStringArg |      .NET Core 3.1 |  95.993 ns |  2.8291 ns |  8.2973 ns |  94.926 ns |  0.87 |    0.15 | 0.0076 |      32 B |
|             LogDebugStringArg | .NET Framework 4.8 | 112.721 ns |  4.9195 ns | 14.1939 ns | 112.334 ns |  1.00 |    0.00 | 0.0076 |      32 B |
|                               |                    |            |            |            |            |       |         |        |           |
|    LoggerMessageWarningNoArgs |           .NET 6.0 |  14.936 ns |  0.3357 ns |  0.5967 ns |  15.063 ns |  0.76 |    0.09 |      - |         - |
|    LoggerMessageWarningNoArgs |           .NET 5.0 |  15.677 ns |  0.9081 ns |  2.5614 ns |  14.819 ns |  0.80 |    0.16 |      - |         - |
|    LoggerMessageWarningNoArgs |      .NET Core 3.1 |  15.675 ns |  0.4257 ns |  1.2215 ns |  15.660 ns |  0.80 |    0.10 |      - |         - |
|    LoggerMessageWarningNoArgs | .NET Framework 4.8 |  19.757 ns |  0.6921 ns |  1.9969 ns |  20.022 ns |  1.00 |    0.00 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|      LoggerMessageDebugNoArgs |           .NET 6.0 |   6.354 ns |  0.3579 ns |  0.9917 ns |   6.251 ns |  1.18 |    0.23 |      - |         - |
|      LoggerMessageDebugNoArgs |           .NET 5.0 |   5.294 ns |  0.3095 ns |  0.8781 ns |   5.039 ns |  1.00 |    0.20 |      - |         - |
|      LoggerMessageDebugNoArgs |      .NET Core 3.1 |   6.257 ns |  0.1742 ns |  0.3637 ns |   6.250 ns |  1.12 |    0.10 |      - |         - |
|      LoggerMessageDebugNoArgs | .NET Framework 4.8 |   5.332 ns |  0.2259 ns |  0.6625 ns |   5.387 ns |  1.00 |    0.00 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|    LoggerMessageWarningIntArg |           .NET 6.0 |  16.190 ns |  0.3691 ns |  0.5746 ns |  16.030 ns |  0.42 |    0.03 |      - |         - |
|    LoggerMessageWarningIntArg |           .NET 5.0 |  14.610 ns |  0.6698 ns |  1.9002 ns |  13.927 ns |  0.37 |    0.06 |      - |         - |
|    LoggerMessageWarningIntArg |      .NET Core 3.1 |  20.320 ns |  0.4555 ns |  1.1511 ns |  20.211 ns |  0.51 |    0.04 |      - |         - |
|    LoggerMessageWarningIntArg | .NET Framework 4.8 |  39.871 ns |  0.8417 ns |  2.0960 ns |  40.037 ns |  1.00 |    0.00 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|      LoggerMessageDebugIntArg |           .NET 6.0 |   9.709 ns |  0.4300 ns |  1.2678 ns |   9.830 ns |  1.50 |    0.26 |      - |         - |
|      LoggerMessageDebugIntArg |           .NET 5.0 |   3.788 ns |  0.1130 ns |  0.1793 ns |   3.764 ns |  0.58 |    0.05 |      - |         - |
|      LoggerMessageDebugIntArg |      .NET Core 3.1 |   5.674 ns |  0.2164 ns |  0.6068 ns |   5.541 ns |  0.87 |    0.12 |      - |         - |
|      LoggerMessageDebugIntArg | .NET Framework 4.8 |   6.545 ns |  0.2189 ns |  0.6350 ns |   6.475 ns |  1.00 |    0.00 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
| LoggerMessageWarningStringArg |           .NET 6.0 |  32.082 ns |  0.9476 ns |  2.7190 ns |  31.487 ns |  0.45 |    0.05 |      - |         - |
| LoggerMessageWarningStringArg |           .NET 5.0 |  24.768 ns |  1.2993 ns |  3.8107 ns |  24.177 ns |  0.35 |    0.06 |      - |         - |
| LoggerMessageWarningStringArg |      .NET Core 3.1 |  38.338 ns |  0.8039 ns |  2.0462 ns |  38.231 ns |  0.54 |    0.05 |      - |         - |
| LoggerMessageWarningStringArg | .NET Framework 4.8 |  71.439 ns |  1.4769 ns |  4.1414 ns |  71.807 ns |  1.00 |    0.00 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|   LoggerMessageDebugStringArg |           .NET 6.0 |   5.822 ns |  0.1692 ns |  0.2918 ns |   5.823 ns |  0.81 |    0.13 |      - |         - |
|   LoggerMessageDebugStringArg |           .NET 5.0 |   7.121 ns |  0.6616 ns |  1.9506 ns |   7.483 ns |  1.03 |    0.40 |      - |         - |
|   LoggerMessageDebugStringArg |      .NET Core 3.1 |   7.821 ns |  0.2575 ns |  0.7389 ns |   7.745 ns |  1.13 |    0.24 |      - |         - |
|   LoggerMessageDebugStringArg | .NET Framework 4.8 |   7.091 ns |  0.3400 ns |  0.9864 ns |   7.228 ns |  1.00 |    0.00 |      - |         - |


|                        Method |            Runtime |       Mean |      Error |     StdDev |     Median | Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------------ |------------------- |-----------:|-----------:|-----------:|-----------:|------:|--------:|-------:|----------:|
|              LogWarningNoArgs |           .NET 6.0 |  28.664 ns |  2.5950 ns |  7.6513 ns |  25.598 ns |  0.59 |    0.17 |      - |         - |
|    LoggerMessageWarningNoArgs |           .NET 6.0 |  14.936 ns |  0.3357 ns |  0.5967 ns |  15.063 ns |  0.76 |    0.09 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|              LogWarningNoArgs |           .NET 5.0 |  30.025 ns |  3.0779 ns |  9.0751 ns |  26.821 ns |  0.61 |    0.18 |      - |         - |
|    LoggerMessageWarningNoArgs |           .NET 5.0 |  15.677 ns |  0.9081 ns |  2.5614 ns |  14.819 ns |  0.80 |    0.16 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|              LogWarningNoArgs |      .NET Core 3.1 |  37.714 ns |  0.7405 ns |  1.4959 ns |  37.544 ns |  0.80 |    0.06 |      - |         - |
|    LoggerMessageWarningNoArgs |      .NET Core 3.1 |  15.675 ns |  0.4257 ns |  1.2215 ns |  15.660 ns |  0.80 |    0.10 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|              LogWarningNoArgs | .NET Framework 4.8 |  49.329 ns |  1.3944 ns |  4.0675 ns |  48.752 ns |  1.00 |    0.00 |      - |         - |
|    LoggerMessageWarningNoArgs | .NET Framework 4.8 |  19.757 ns |  0.6921 ns |  1.9969 ns |  20.022 ns |  1.00 |    0.00 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|                               |                    |            |            |            |            |       |         |        |           |
|                LogDebugNoArgs |           .NET 6.0 |  20.512 ns |  0.4471 ns |  0.9332 ns |  20.462 ns |  0.43 |    0.04 |      - |         - |
|      LoggerMessageDebugNoArgs |           .NET 6.0 |   6.354 ns |  0.3579 ns |  0.9917 ns |   6.251 ns |  1.18 |    0.23 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|                LogDebugNoArgs |           .NET 5.0 |  23.448 ns |  2.0850 ns |  6.0821 ns |  20.734 ns |  0.49 |    0.13 |      - |         - |
|      LoggerMessageDebugNoArgs |           .NET 5.0 |   5.294 ns |  0.3095 ns |  0.8781 ns |   5.039 ns |  1.00 |    0.20 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|                LogDebugNoArgs |      .NET Core 3.1 |  34.806 ns |  0.7108 ns |  1.6474 ns |  34.733 ns |  0.73 |    0.08 |      - |         - |
|      LoggerMessageDebugNoArgs |      .NET Core 3.1 |   6.257 ns |  0.1742 ns |  0.3637 ns |   6.250 ns |  1.12 |    0.10 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|                LogDebugNoArgs | .NET Framework 4.8 |  47.618 ns |  1.4638 ns |  4.2930 ns |  48.310 ns |  1.00 |    0.00 |      - |         - |
|      LoggerMessageDebugNoArgs | .NET Framework 4.8 |   5.332 ns |  0.2259 ns |  0.6625 ns |   5.387 ns |  1.00 |    0.00 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|                               |                    |            |            |            |            |       |         |        |           |
|              LogWarningIntArg |           .NET 6.0 |  92.157 ns |  1.8926 ns |  4.4240 ns |  91.469 ns |  0.95 |    0.09 | 0.0134 |      56 B |
|    LoggerMessageWarningIntArg |           .NET 6.0 |  16.190 ns |  0.3691 ns |  0.5746 ns |  16.030 ns |  0.42 |    0.03 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|              LogWarningIntArg |           .NET 5.0 |  64.933 ns |  1.2720 ns |  3.4173 ns |  64.800 ns |  0.66 |    0.07 | 0.0134 |      56 B |
|    LoggerMessageWarningIntArg |           .NET 5.0 |  14.610 ns |  0.6698 ns |  1.9002 ns |  13.927 ns |  0.37 |    0.06 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|              LogWarningIntArg |      .NET Core 3.1 | 104.286 ns |  2.1321 ns |  4.7688 ns | 103.060 ns |  1.07 |    0.11 | 0.0134 |      56 B |
|    LoggerMessageWarningIntArg |      .NET Core 3.1 |  20.320 ns |  0.4555 ns |  1.1511 ns |  20.211 ns |  0.51 |    0.04 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|              LogWarningIntArg | .NET Framework 4.8 |  99.457 ns |  2.8379 ns |  8.3677 ns |  97.360 ns |  1.00 |    0.00 | 0.0134 |      56 B |
|    LoggerMessageWarningIntArg | .NET Framework 4.8 |  39.871 ns |  0.8417 ns |  2.0960 ns |  40.037 ns |  1.00 |    0.00 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|                               |                    |            |            |            |            |       |         |        |           |
|                LogDebugIntArg |           .NET 6.0 |  88.957 ns |  7.7807 ns | 21.4304 ns |  86.682 ns |  0.91 |    0.24 | 0.0134 |      56 B |
|      LoggerMessageDebugIntArg |           .NET 6.0 |   9.709 ns |  0.4300 ns |  1.2678 ns |   9.830 ns |  1.50 |    0.26 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|                LogDebugIntArg |           .NET 5.0 |  74.009 ns |  5.1974 ns | 14.8285 ns |  67.008 ns |  0.75 |    0.13 | 0.0134 |      56 B |
|      LoggerMessageDebugIntArg |           .NET 5.0 |   3.788 ns |  0.1130 ns |  0.1793 ns |   3.764 ns |  0.58 |    0.05 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|                LogDebugIntArg |      .NET Core 3.1 | 102.834 ns |  2.1014 ns |  5.3104 ns | 102.247 ns |  1.07 |    0.09 | 0.0134 |      56 B |
|      LoggerMessageDebugIntArg |      .NET Core 3.1 |   5.674 ns |  0.2164 ns |  0.6068 ns |   5.541 ns |  0.87 |    0.12 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|                LogDebugIntArg | .NET Framework 4.8 |  99.805 ns |  2.8456 ns |  8.3902 ns |  99.081 ns |  1.00 |    0.00 | 0.0134 |      56 B |
|      LoggerMessageDebugIntArg | .NET Framework 4.8 |   6.545 ns |  0.2189 ns |  0.6350 ns |   6.475 ns |  1.00 |    0.00 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|                               |                    |            |            |            |            |       |         |        |           |
|           LogWarningStringArg |           .NET 6.0 |  93.062 ns | 11.3604 ns | 33.4964 ns |  98.467 ns |  0.54 |    0.04 | 0.0076 |      32 B |
| LoggerMessageWarningStringArg |           .NET 6.0 |  32.082 ns |  0.9476 ns |  2.7190 ns |  31.487 ns |  0.45 |    0.05 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|           LogWarningStringArg |           .NET 5.0 |  70.617 ns |  5.2272 ns | 15.0815 ns |  65.302 ns |  0.62 |    0.14 | 0.0076 |      32 B |
| LoggerMessageWarningStringArg |           .NET 5.0 |  24.768 ns |  1.2993 ns |  3.8107 ns |  24.177 ns |  0.35 |    0.06 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|           LogWarningStringArg |      .NET Core 3.1 | 101.049 ns |  3.6568 ns | 10.5507 ns |  96.957 ns |  0.86 |    0.07 | 0.0076 |      32 B |
| LoggerMessageWarningStringArg |      .NET Core 3.1 |  38.338 ns |  0.8039 ns |  2.0462 ns |  38.231 ns |  0.54 |    0.05 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|           LogWarningStringArg | .NET Framework 4.8 | 112.781 ns |  2.2972 ns |  4.3707 ns | 112.155 ns |  1.00 |    0.00 | 0.0076 |      32 B |
| LoggerMessageWarningStringArg | .NET Framework 4.8 |  71.439 ns |  1.4769 ns |  4.1414 ns |  71.807 ns |  1.00 |    0.00 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|                               |                    |            |            |            |            |       |         |        |           |
|             LogDebugStringArg |           .NET 6.0 |  95.258 ns |  4.8983 ns | 14.2108 ns |  95.542 ns |  0.85 |    0.14 | 0.0076 |      32 B |
|   LoggerMessageDebugStringArg |           .NET 6.0 |   5.822 ns |  0.1692 ns |  0.2918 ns |   5.823 ns |  0.81 |    0.13 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|             LogDebugStringArg |           .NET 5.0 |  76.774 ns |  4.8889 ns | 14.1835 ns |  77.469 ns |  0.69 |    0.14 | 0.0076 |      32 B |
|   LoggerMessageDebugStringArg |           .NET 5.0 |   7.121 ns |  0.6616 ns |  1.9506 ns |   7.483 ns |  1.03 |    0.40 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|             LogDebugStringArg |      .NET Core 3.1 |  95.993 ns |  2.8291 ns |  8.2973 ns |  94.926 ns |  0.87 |    0.15 | 0.0076 |      32 B |
|   LoggerMessageDebugStringArg |      .NET Core 3.1 |   7.821 ns |  0.2575 ns |  0.7389 ns |   7.745 ns |  1.13 |    0.24 |      - |         - |
|                               |                    |            |            |            |            |       |         |        |           |
|             LogDebugStringArg | .NET Framework 4.8 | 112.721 ns |  4.9195 ns | 14.1939 ns | 112.334 ns |  1.00 |    0.00 | 0.0076 |      32 B |
|   LoggerMessageDebugStringArg | .NET Framework 4.8 |   7.091 ns |  0.3400 ns |  0.9864 ns |   7.228 ns |  1.00 |    0.00 |      - |         - |
