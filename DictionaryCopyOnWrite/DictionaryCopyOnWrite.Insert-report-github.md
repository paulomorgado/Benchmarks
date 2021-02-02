``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21306
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.200-preview.21077.7
  [Host]     : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  Job-WUFNMB : .NET Framework 4.8 (4.8.4311.0), X64 RyuJIT
  Job-QVXTTI : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT
  Job-AJCNCP : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT


```
|                  Method |        Job |       Runtime |    Toolchain | test |         Mean |       Error |       StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------ |----------- |-------------- |------------- |----- |-------------:|------------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|  **ImmutableDictionaryAdd** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |   **16** |  **19,672.1 ns** | **1,220.10 ns** |  **3,597.49 ns** |  **2.46** |    **0.44** |  **1.0681** |     **-** |     **-** |    **4558 B** |
|  ImmutableDictionaryAdd | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   16 |  11,009.6 ns |   214.83 ns |    229.87 ns |  1.45 |    0.06 |  1.0529 |     - |     - |    4416 B |
|  ImmutableDictionaryAdd | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   16 |   7,575.0 ns |   151.11 ns |    244.02 ns |  1.00 |    0.00 |  1.0376 |     - |     - |    4352 B |
|                         |            |               |              |      |              |             |              |       |         |         |       |       |           |
|           DictionaryAdd | Job-WUFNMB |      .NET 4.8 |        net48 |   16 |  15,532.0 ns |   758.45 ns |  2,151.59 ns |  1.88 |    0.24 |  1.5869 |     - |     - |    6780 B |
|           DictionaryAdd | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   16 |  12,724.0 ns |   252.71 ns |    248.19 ns |  1.45 |    0.06 |  1.5717 |     - |     - |    6632 B |
|           DictionaryAdd | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   16 |   8,803.9 ns |   172.32 ns |    263.16 ns |  1.00 |    0.00 |  1.6022 |     - |     - |    6760 B |
|                         |            |               |              |      |              |             |              |       |         |         |       |       |           |
| ConcurrentDictionaryAdd | Job-WUFNMB |      .NET 4.8 |        net48 |   16 |  99,583.5 ns | 1,976.56 ns |  5,639.24 ns |  2.59 |    0.23 |  7.5684 |     - |     - |   31822 B |
| ConcurrentDictionaryAdd | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   16 |  87,947.7 ns | 1,731.62 ns |  2,986.96 ns |  2.27 |    0.18 |  6.2256 |     - |     - |   26416 B |
| ConcurrentDictionaryAdd | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   16 |  38,593.7 ns |   769.23 ns |  2,053.23 ns |  1.00 |    0.00 |  6.3477 |     - |     - |   26784 B |
|                         |            |               |              |      |              |             |              |       |         |         |       |       |           |
|  **ImmutableDictionaryAdd** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |   **32** |  **28,124.9 ns** |   **541.82 ns** |    **905.27 ns** |  **1.50** |    **0.07** |  **2.5940** |     **-** |     **-** |   **10976 B** |
|  ImmutableDictionaryAdd | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   32 |  27,664.1 ns |   544.63 ns |    582.75 ns |  1.48 |    0.04 |  2.6550 |     - |     - |   11200 B |
|  ImmutableDictionaryAdd | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   32 |  18,706.0 ns |   356.22 ns |    381.15 ns |  1.00 |    0.00 |  2.5635 |     - |     - |   10816 B |
|                         |            |               |              |      |              |             |              |       |         |         |       |       |           |
|           DictionaryAdd | Job-WUFNMB |      .NET 4.8 |        net48 |   32 |  44,745.1 ns |   893.03 ns |  2,223.94 ns |  1.36 |    0.09 |  5.0659 |     - |     - |   21255 B |
|           DictionaryAdd | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   32 |  46,577.7 ns |   906.51 ns |    890.32 ns |  1.40 |    0.06 |  5.0049 |     - |     - |   20937 B |
|           DictionaryAdd | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   32 |  32,960.8 ns |   657.42 ns |  1,218.57 ns |  1.00 |    0.00 |  5.0659 |     - |     - |   21192 B |
|                         |            |               |              |      |              |             |              |       |         |         |       |       |           |
| ConcurrentDictionaryAdd | Job-WUFNMB |      .NET 4.8 |        net48 |   32 | 256,922.0 ns | 5,082.12 ns | 12,370.59 ns |  1.88 |    0.12 | 20.0195 |     - |     - |   85502 B |
| ConcurrentDictionaryAdd | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   32 | 229,702.5 ns | 4,469.65 ns |  4,968.00 ns |  1.67 |    0.09 | 20.0195 |     - |     - |   84000 B |
| ConcurrentDictionaryAdd | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   32 | 136,288.7 ns | 2,495.79 ns |  6,661.77 ns |  1.00 |    0.00 | 20.9961 |     - |     - |   88304 B |
|                         |            |               |              |      |              |             |              |       |         |         |       |       |           |
|  **ImmutableDictionaryAdd** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |    **4** |   **1,872.3 ns** |    **37.50 ns** |     **82.32 ns** |  **1.42** |    **0.08** |  **0.1602** |     **-** |     **-** |     **674 B** |
|  ImmutableDictionaryAdd | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    4 |   1,698.4 ns |    33.63 ns |     68.70 ns |  1.28 |    0.07 |  0.1602 |     - |     - |     672 B |
|  ImmutableDictionaryAdd | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    4 |   1,319.1 ns |    25.87 ns |     37.10 ns |  1.00 |    0.00 |  0.1755 |     - |     - |     736 B |
|                         |            |               |              |      |              |             |              |       |         |         |       |       |           |
|           DictionaryAdd | Job-WUFNMB |      .NET 4.8 |        net48 |    4 |   1,002.5 ns |    20.39 ns |     58.18 ns |  1.02 |    0.06 |  0.2327 |     - |     - |     979 B |
|           DictionaryAdd | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    4 |   1,136.0 ns |    22.55 ns |     18.83 ns |  1.16 |    0.04 |  0.2251 |     - |     - |     944 B |
|           DictionaryAdd | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    4 |     980.4 ns |    19.43 ns |     38.79 ns |  1.00 |    0.00 |  0.2327 |     - |     - |     976 B |
|                         |            |               |              |      |              |             |              |       |         |         |       |       |           |
| ConcurrentDictionaryAdd | Job-WUFNMB |      .NET 4.8 |        net48 |    4 |  15,778.6 ns |   311.01 ns |    649.19 ns |  4.23 |    0.30 |  0.6714 |     - |     - |    2889 B |
| ConcurrentDictionaryAdd | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    4 |  16,357.3 ns |   319.95 ns |    314.23 ns |  4.27 |    0.18 |  0.8240 |     - |     - |    3504 B |
| ConcurrentDictionaryAdd | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    4 |   3,744.6 ns |    72.89 ns |    193.29 ns |  1.00 |    0.00 |  0.7553 |     - |     - |    3176 B |
|                         |            |               |              |      |              |             |              |       |         |         |       |       |           |
|  **ImmutableDictionaryAdd** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |    **8** |   **4,936.0 ns** |    **96.96 ns** |    **202.40 ns** |  **1.49** |    **0.09** |  **0.4425** |     **-** |     **-** |    **1862 B** |
|  ImmutableDictionaryAdd | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    8 |   4,723.4 ns |    86.19 ns |    146.36 ns |  1.43 |    0.10 |  0.4425 |     - |     - |    1856 B |
|  ImmutableDictionaryAdd | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    8 |   3,324.8 ns |    62.83 ns |    135.25 ns |  1.00 |    0.00 |  0.4425 |     - |     - |    1856 B |
|                         |            |               |              |      |              |             |              |       |         |         |       |       |           |
|           DictionaryAdd | Job-WUFNMB |      .NET 4.8 |        net48 |    8 |   3,421.1 ns |    68.50 ns |    145.99 ns |  1.22 |    0.10 |  0.5722 |     - |     - |    2407 B |
|           DictionaryAdd | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    8 |   3,420.6 ns |    65.49 ns |     61.26 ns |  1.18 |    0.05 |  0.5569 |     - |     - |    2336 B |
|           DictionaryAdd | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    8 |   2,825.0 ns |    61.06 ns |    172.23 ns |  1.00 |    0.00 |  0.5722 |     - |     - |    2400 B |
|                         |            |               |              |      |              |             |              |       |         |         |       |       |           |
| ConcurrentDictionaryAdd | Job-WUFNMB |      .NET 4.8 |        net48 |    8 |  39,818.1 ns |   786.94 ns |  1,959.75 ns |  4.38 |    0.33 |  2.6245 |     - |     - |   11081 B |
| ConcurrentDictionaryAdd | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    8 |  35,583.4 ns |   693.52 ns |  1,352.65 ns |  3.91 |    0.18 |  2.1362 |     - |     - |    9104 B |
| ConcurrentDictionaryAdd | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    8 |   9,103.5 ns |   181.21 ns |    357.70 ns |  1.00 |    0.00 |  1.6327 |     - |     - |    6856 B |
