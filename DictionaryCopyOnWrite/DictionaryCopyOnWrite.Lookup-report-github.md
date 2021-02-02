``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21306
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.200-preview.21077.7
  [Host]     : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  Job-WUFNMB : .NET Framework 4.8 (4.8.4311.0), X64 RyuJIT
  Job-QVXTTI : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT
  Job-AJCNCP : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT


```
|                     Method |        Job |       Runtime |    Toolchain | Count | test |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------- |----------- |-------------- |------------- |------ |----- |------------:|------------:|------------:|------------:|------:|--------:|------:|------:|------:|----------:|
|  **ImmutableDictionaryLookup** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |    **10** |   **16** |    **799.1 ns** |    **15.99 ns** |    **43.22 ns** |    **791.8 ns** |  **1.52** |    **0.11** |     **-** |     **-** |     **-** |         **-** |
|  ImmutableDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    10 |   16 |    564.6 ns |    11.23 ns |    25.57 ns |    564.9 ns |  1.02 |    0.06 |     - |     - |     - |         - |
|  ImmutableDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    10 |   16 |    545.9 ns |     9.42 ns |     8.81 ns |    543.5 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|           DictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |    10 |   16 |    475.9 ns |     9.42 ns |    26.56 ns |    475.2 ns |  1.85 |    0.12 |     - |     - |     - |         - |
|           DictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    10 |   16 |    458.9 ns |     9.13 ns |    15.99 ns |    459.8 ns |  1.80 |    0.06 |     - |     - |     - |         - |
|           DictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    10 |   16 |    255.3 ns |     4.36 ns |     4.28 ns |    255.8 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
| ConcurrentDictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |    10 |   16 |    665.2 ns |    15.59 ns |    44.47 ns |    664.9 ns |  1.42 |    0.09 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    10 |   16 |    492.2 ns |     9.56 ns |    13.08 ns |    493.8 ns |  1.05 |    0.04 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    10 |   16 |    468.6 ns |     9.43 ns |    13.53 ns |    467.7 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|  **ImmutableDictionaryLookup** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |    **10** |   **32** |    **821.7 ns** |    **15.47 ns** |    **12.92 ns** |    **823.1 ns** |  **1.54** |    **0.06** |     **-** |     **-** |     **-** |         **-** |
|  ImmutableDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    10 |   32 |    609.2 ns |    12.05 ns |    28.41 ns |    603.5 ns |  1.16 |    0.08 |     - |     - |     - |         - |
|  ImmutableDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    10 |   32 |    525.5 ns |    10.22 ns |    25.82 ns |    524.1 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|           DictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |    10 |   32 |    645.4 ns |    27.84 ns |    81.22 ns |    630.5 ns |  2.69 |    0.41 |     - |     - |     - |         - |
|           DictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    10 |   32 |    483.7 ns |     9.58 ns |    15.74 ns |    479.5 ns |  1.98 |    0.11 |     - |     - |     - |         - |
|           DictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    10 |   32 |    240.7 ns |     4.86 ns |    12.27 ns |    237.2 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
| ConcurrentDictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |    10 |   32 |    640.0 ns |    17.70 ns |    50.50 ns |    636.2 ns |  1.36 |    0.12 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    10 |   32 |    495.5 ns |     9.90 ns |    18.34 ns |    492.4 ns |  1.05 |    0.05 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    10 |   32 |    472.1 ns |     9.40 ns |    14.36 ns |    468.3 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|  **ImmutableDictionaryLookup** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |    **10** |    **4** |    **775.8 ns** |    **15.33 ns** |    **19.93 ns** |    **775.8 ns** |  **1.54** |    **0.09** |     **-** |     **-** |     **-** |         **-** |
|  ImmutableDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    10 |    4 |    571.9 ns |    11.85 ns |    34.94 ns |    563.8 ns |  1.14 |    0.10 |     - |     - |     - |         - |
|  ImmutableDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    10 |    4 |    504.3 ns |    10.12 ns |    28.71 ns |    501.5 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|           DictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |    10 |    4 |    496.3 ns |    13.91 ns |    39.91 ns |    499.3 ns |  2.11 |    0.23 |     - |     - |     - |         - |
|           DictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    10 |    4 |    477.9 ns |     9.56 ns |    23.62 ns |    474.1 ns |  2.10 |    0.13 |     - |     - |     - |         - |
|           DictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    10 |    4 |    233.2 ns |     4.69 ns |     7.01 ns |    234.2 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
| ConcurrentDictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |    10 |    4 |    585.3 ns |    13.97 ns |    39.18 ns |    575.9 ns |  1.21 |    0.09 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    10 |    4 |    481.0 ns |     9.16 ns |     8.57 ns |    478.8 ns |  1.01 |    0.07 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    10 |    4 |    481.4 ns |     9.70 ns |    20.25 ns |    479.5 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|  **ImmutableDictionaryLookup** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |    **10** |    **8** |    **802.5 ns** |    **13.87 ns** |    **18.52 ns** |    **804.0 ns** |  **1.65** |    **0.06** |     **-** |     **-** |     **-** |         **-** |
|  ImmutableDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    10 |    8 |    545.8 ns |    10.97 ns |    19.78 ns |    544.3 ns |  1.11 |    0.05 |     - |     - |     - |         - |
|  ImmutableDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    10 |    8 |    487.4 ns |     9.60 ns |    10.27 ns |    484.1 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|           DictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |    10 |    8 |    512.8 ns |    13.94 ns |    39.77 ns |    506.3 ns |  2.03 |    0.18 |     - |     - |     - |         - |
|           DictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    10 |    8 |    514.9 ns |     8.70 ns |     7.72 ns |    512.6 ns |  2.00 |    0.06 |     - |     - |     - |         - |
|           DictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    10 |    8 |    257.1 ns |     5.10 ns |     7.14 ns |    255.3 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
| ConcurrentDictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |    10 |    8 |    576.3 ns |    13.43 ns |    38.33 ns |    578.5 ns |  1.22 |    0.06 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |    10 |    8 |    481.3 ns |     9.17 ns |     9.41 ns |    481.2 ns |  1.00 |    0.02 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |    10 |    8 |    478.9 ns |     9.41 ns |     8.80 ns |    478.4 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|  **ImmutableDictionaryLookup** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |   **100** |   **16** |  **8,085.8 ns** |   **156.62 ns** |   **404.29 ns** |  **8,093.2 ns** |  **1.51** |    **0.11** |     **-** |     **-** |     **-** |         **-** |
|  ImmutableDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   100 |   16 |  5,456.2 ns |   106.52 ns |   189.34 ns |  5,430.8 ns |  1.02 |    0.07 |     - |     - |     - |         - |
|  ImmutableDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   100 |   16 |  5,322.1 ns |   102.81 ns |   234.14 ns |  5,313.2 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|           DictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |   100 |   16 |  4,900.8 ns |   138.39 ns |   397.06 ns |  4,856.9 ns |  1.73 |    0.16 |     - |     - |     - |         - |
|           DictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   100 |   16 |  4,528.8 ns |    89.66 ns |   159.38 ns |  4,554.6 ns |  1.62 |    0.09 |     - |     - |     - |         - |
|           DictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   100 |   16 |  2,800.8 ns |    55.41 ns |   105.42 ns |  2,776.3 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
| ConcurrentDictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |   100 |   16 |  6,501.4 ns |   129.68 ns |   308.19 ns |  6,510.0 ns |  1.39 |    0.09 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   100 |   16 |  4,760.1 ns |    90.94 ns |    89.32 ns |  4,729.1 ns |  1.02 |    0.04 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   100 |   16 |  4,644.2 ns |    92.92 ns |   160.29 ns |  4,644.1 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|  **ImmutableDictionaryLookup** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |   **100** |   **32** |  **7,981.5 ns** |   **157.05 ns** |   **291.11 ns** |  **7,949.0 ns** |  **1.54** |    **0.09** |     **-** |     **-** |     **-** |         **-** |
|  ImmutableDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   100 |   32 |  5,386.7 ns |   105.02 ns |   125.02 ns |  5,404.2 ns |  1.04 |    0.05 |     - |     - |     - |         - |
|  ImmutableDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   100 |   32 |  5,184.9 ns |   102.50 ns |   207.06 ns |  5,159.4 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|           DictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |   100 |   32 |  4,651.6 ns |    96.41 ns |   271.94 ns |  4,650.2 ns |  2.06 |    0.14 |     - |     - |     - |         - |
|           DictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   100 |   32 |  5,000.4 ns |    87.98 ns |    94.14 ns |  5,019.7 ns |  2.23 |    0.09 |     - |     - |     - |         - |
|           DictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   100 |   32 |  2,242.2 ns |    44.32 ns |    70.30 ns |  2,220.2 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
| ConcurrentDictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |   100 |   32 |  5,628.0 ns |   112.07 ns |   199.20 ns |  5,568.4 ns |  1.24 |    0.06 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   100 |   32 |  4,663.9 ns |    85.90 ns |    76.15 ns |  4,691.3 ns |  1.02 |    0.03 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   100 |   32 |  4,569.6 ns |    91.22 ns |   136.53 ns |  4,583.8 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|  **ImmutableDictionaryLookup** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |   **100** |    **4** |  **7,843.5 ns** |   **156.02 ns** |   **304.31 ns** |  **7,767.0 ns** |  **1.68** |    **0.10** |     **-** |     **-** |     **-** |         **-** |
|  ImmutableDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   100 |    4 |  5,115.3 ns |   100.73 ns |   186.71 ns |  5,153.9 ns |  1.09 |    0.05 |     - |     - |     - |         - |
|  ImmutableDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   100 |    4 |  4,685.5 ns |    86.95 ns |   109.97 ns |  4,677.8 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|           DictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |   100 |    4 |  4,896.8 ns |   104.13 ns |   298.76 ns |  4,870.4 ns |  2.17 |    0.14 |     - |     - |     - |         - |
|           DictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   100 |    4 |  4,575.4 ns |    85.83 ns |    71.67 ns |  4,574.4 ns |  2.00 |    0.04 |     - |     - |     - |         - |
|           DictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   100 |    4 |  2,274.6 ns |    44.77 ns |    47.91 ns |  2,278.1 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
| ConcurrentDictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |   100 |    4 |  5,652.3 ns |   115.43 ns |   331.19 ns |  5,601.8 ns |  1.22 |    0.07 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   100 |    4 |  4,820.0 ns |    96.03 ns |   196.16 ns |  4,807.7 ns |  1.05 |    0.04 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   100 |    4 |  4,592.7 ns |    61.87 ns |    57.87 ns |  4,595.2 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|  **ImmutableDictionaryLookup** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |   **100** |    **8** |  **7,702.8 ns** |   **153.66 ns** |   **239.23 ns** |  **7,705.1 ns** |  **1.47** |    **0.06** |     **-** |     **-** |     **-** |         **-** |
|  ImmutableDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   100 |    8 |  5,161.6 ns |   102.14 ns |   125.44 ns |  5,177.0 ns |  0.98 |    0.03 |     - |     - |     - |         - |
|  ImmutableDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   100 |    8 |  5,241.0 ns |    93.77 ns |    83.12 ns |  5,216.3 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|           DictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |   100 |    8 |  4,663.9 ns |   125.03 ns |   360.75 ns |  4,637.1 ns |  2.07 |    0.16 |     - |     - |     - |         - |
|           DictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   100 |    8 |  5,059.7 ns |    99.79 ns |   184.97 ns |  5,026.1 ns |  2.25 |    0.11 |     - |     - |     - |         - |
|           DictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   100 |    8 |  2,262.5 ns |    45.23 ns |    63.41 ns |  2,258.5 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
| ConcurrentDictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |   100 |    8 |  6,892.9 ns |   248.78 ns |   729.63 ns |  6,696.0 ns |  1.43 |    0.10 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |   100 |    8 |  4,681.6 ns |    84.91 ns |   121.78 ns |  4,690.2 ns |  1.00 |    0.04 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |   100 |    8 |  4,667.8 ns |    77.75 ns |    68.92 ns |  4,655.6 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|  **ImmutableDictionaryLookup** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |  **1000** |   **16** | **80,480.3 ns** | **1,609.43 ns** | **2,505.69 ns** | **80,059.4 ns** |  **1.59** |    **0.07** |     **-** |     **-** |     **-** |         **-** |
|  ImmutableDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |  1000 |   16 | 55,164.6 ns | 1,092.81 ns | 2,639.27 ns | 55,413.8 ns |  1.08 |    0.07 |     - |     - |     - |         - |
|  ImmutableDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |  1000 |   16 | 50,358.4 ns |   774.96 ns |   686.98 ns | 50,330.3 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|           DictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |  1000 |   16 | 48,525.9 ns | 1,079.84 ns | 3,115.57 ns | 48,186.2 ns |  1.96 |    0.13 |     - |     - |     - |         - |
|           DictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |  1000 |   16 | 50,006.5 ns |   988.09 ns | 1,249.62 ns | 50,001.8 ns |  2.05 |    0.08 |     - |     - |     - |         - |
|           DictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |  1000 |   16 | 24,433.8 ns |   487.33 ns |   698.92 ns | 24,465.3 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
| ConcurrentDictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |  1000 |   16 | 64,956.5 ns | 1,296.65 ns | 3,415.89 ns | 64,409.6 ns |  1.39 |    0.09 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |  1000 |   16 | 47,434.3 ns |   947.00 ns | 1,529.23 ns | 47,481.2 ns |  1.01 |    0.04 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |  1000 |   16 | 46,956.3 ns |   929.02 ns | 1,473.52 ns | 46,915.3 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|  **ImmutableDictionaryLookup** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |  **1000** |   **32** | **81,340.0 ns** | **1,621.13 ns** | **3,311.53 ns** | **81,173.5 ns** |  **1.66** |    **0.08** |     **-** |     **-** |     **-** |         **-** |
|  ImmutableDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |  1000 |   32 | 54,777.9 ns |   763.67 ns |   637.70 ns | 54,771.4 ns |  1.11 |    0.02 |     - |     - |     - |         - |
|  ImmutableDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |  1000 |   32 | 49,368.4 ns |   987.20 ns | 1,097.27 ns | 49,619.6 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|           DictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |  1000 |   32 | 51,993.1 ns | 1,034.96 ns | 2,398.67 ns | 51,526.2 ns |  2.34 |    0.17 |     - |     - |     - |         - |
|           DictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |  1000 |   32 | 45,960.0 ns |   884.45 ns | 1,118.55 ns | 45,946.0 ns |  2.05 |    0.14 |     - |     - |     - |         - |
|           DictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |  1000 |   32 | 22,381.0 ns |   438.63 ns | 1,147.83 ns | 22,343.9 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
| ConcurrentDictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |  1000 |   32 | 63,253.4 ns | 1,263.41 ns | 3,415.70 ns | 62,968.0 ns |  1.35 |    0.11 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |  1000 |   32 | 47,459.1 ns |   923.88 ns |   864.20 ns | 47,516.7 ns |  1.03 |    0.02 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |  1000 |   32 | 46,261.8 ns |   614.64 ns |   544.86 ns | 46,233.6 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|  **ImmutableDictionaryLookup** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |  **1000** |    **4** | **79,147.7 ns** | **1,572.29 ns** | **3,973.38 ns** | **78,720.4 ns** |  **1.68** |    **0.10** |     **-** |     **-** |     **-** |         **-** |
|  ImmutableDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |  1000 |    4 | 54,488.2 ns | 1,087.36 ns | 1,692.88 ns | 54,276.7 ns |  1.17 |    0.04 |     - |     - |     - |         - |
|  ImmutableDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |  1000 |    4 | 46,663.1 ns |   906.70 ns | 1,146.68 ns | 46,720.5 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|           DictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |  1000 |    4 | 46,431.1 ns |   920.81 ns | 2,489.45 ns | 46,460.1 ns |  2.09 |    0.12 |     - |     - |     - |         - |
|           DictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |  1000 |    4 | 49,097.5 ns |   885.56 ns |   785.03 ns | 49,005.9 ns |  2.21 |    0.05 |     - |     - |     - |         - |
|           DictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |  1000 |    4 | 22,251.5 ns |   358.21 ns |   335.07 ns | 22,314.4 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
| ConcurrentDictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |  1000 |    4 | 64,103.4 ns | 1,524.97 ns | 4,301.20 ns | 64,052.1 ns |  1.38 |    0.05 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |  1000 |    4 | 47,737.5 ns |   707.46 ns |   627.15 ns | 47,788.6 ns |  1.02 |    0.02 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |  1000 |    4 | 46,707.4 ns |   835.84 ns |   740.95 ns | 46,397.4 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|  **ImmutableDictionaryLookup** | **Job-WUFNMB** |      **.NET 4.8** |        **net48** |  **1000** |    **8** | **78,953.3 ns** | **1,558.30 ns** | **3,880.72 ns** | **79,386.9 ns** |  **1.66** |    **0.12** |     **-** |     **-** |     **-** |         **-** |
|  ImmutableDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |  1000 |    8 | 55,064.7 ns | 1,092.92 ns | 1,635.83 ns | 55,135.6 ns |  1.18 |    0.05 |     - |     - |     - |         - |
|  ImmutableDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |  1000 |    8 | 46,682.0 ns |   890.90 ns | 1,094.11 ns | 46,667.1 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
|           DictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |  1000 |    8 | 48,370.1 ns |   957.78 ns | 1,890.57 ns | 47,943.1 ns |  1.97 |    0.14 |     - |     - |     - |         - |
|           DictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |  1000 |    8 | 49,568.6 ns |   962.98 ns |   900.77 ns | 49,713.3 ns |  2.05 |    0.14 |     - |     - |     - |         - |
|           DictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |  1000 |    8 | 24,538.9 ns |   486.69 ns |   994.17 ns | 24,630.3 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                            |            |               |              |       |      |             |             |             |             |       |         |       |       |       |           |
| ConcurrentDictionaryLookup | Job-WUFNMB |      .NET 4.8 |        net48 |  1000 |    8 | 55,976.2 ns | 1,111.71 ns | 2,869.69 ns | 56,117.5 ns |  1.19 |    0.08 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-QVXTTI | .NET Core 3.1 | netcoreapp31 |  1000 |    8 | 49,281.0 ns |   965.49 ns | 1,836.95 ns | 49,395.5 ns |  1.03 |    0.04 |     - |     - |     - |         - |
| ConcurrentDictionaryLookup | Job-AJCNCP | .NET Core 5.0 | netcoreapp50 |  1000 |    8 | 46,548.0 ns |   901.23 ns |   885.13 ns | 46,431.6 ns |  1.00 |    0.00 |     - |     - |     - |         - |
