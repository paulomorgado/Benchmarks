``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21301
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]     : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  Job-BZLJBK : .NET Framework 4.8 (4.8.4311.0), X64 RyuJIT
  Job-BYYWSC : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT
  Job-PWRAQS : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT


```
|                 Method |        Job |       Runtime |    Toolchain | test |       Mean |     Error |     StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |----------- |-------------- |------------- |----- |-----------:|----------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
| **ImmutableDictionaryAdd** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |   **16** |  **39.310 μs** | **3.9532 μs** | **11.5317 μs** |  **38.450 μs** |  **2.63** |    **0.97** |      **-** |     **-** |     **-** |    **8192 B** |
| ImmutableDictionaryAdd | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |   16 |  21.228 μs | 1.8649 μs |  5.4987 μs |  23.014 μs |  1.43 |    0.52 | 1.0681 |     - |     - |    4544 B |
| ImmutableDictionaryAdd | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |   16 |  15.727 μs | 1.2598 μs |  3.7146 μs |  15.146 μs |  1.00 |    0.00 | 1.0986 |     - |     - |    4608 B |
|                        |            |               |              |      |            |           |            |            |       |         |        |       |       |           |
|          DictionaryAdd | Job-BZLJBK |      .NET 4.8 |        net48 |   16 |  20.591 μs | 1.8134 μs |  5.3469 μs |  21.584 μs |  0.94 |    0.27 | 1.5869 |     - |     - |    6780 B |
|          DictionaryAdd | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |   16 |  23.151 μs | 1.7043 μs |  5.0251 μs |  24.004 μs |  1.10 |    0.24 | 1.5564 |     - |     - |    6632 B |
|          DictionaryAdd | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |   16 |  21.579 μs | 0.4279 μs |  1.1347 μs |  21.318 μs |  1.00 |    0.00 | 1.5869 |     - |     - |    6760 B |
|                        |            |               |              |      |            |           |            |            |       |         |        |       |       |           |
| **ImmutableDictionaryAdd** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |   **32** |  **73.776 μs** | **3.3076 μs** |  **9.7006 μs** |  **74.310 μs** |  **5.03** |    **0.53** | **2.5635** |     **-** |     **-** |   **11169 B** |
| ImmutableDictionaryAdd | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |   32 |  30.130 μs | 1.9982 μs |  5.7332 μs |  29.428 μs |  2.02 |    0.42 | 2.6245 |     - |     - |   11072 B |
| ImmutableDictionaryAdd | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |   32 |  15.103 μs | 0.3498 μs |  0.9867 μs |  14.906 μs |  1.00 |    0.00 | 2.5024 |     - |     - |   10560 B |
|                        |            |               |              |      |            |           |            |            |       |         |        |       |       |           |
|          DictionaryAdd | Job-BZLJBK |      .NET 4.8 |        net48 |   32 | 101.571 μs | 7.4886 μs | 20.1177 μs | 102.691 μs |  3.86 |    0.74 | 5.0049 |     - |     - |   21255 B |
|          DictionaryAdd | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |   32 |  41.371 μs | 1.3245 μs |  3.7574 μs |  40.465 μs |  1.57 |    0.18 | 5.0049 |     - |     - |   20936 B |
|          DictionaryAdd | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |   32 |  26.388 μs | 0.6811 μs |  1.9651 μs |  25.794 μs |  1.00 |    0.00 | 5.0659 |     - |     - |   21192 B |
|                        |            |               |              |      |            |           |            |            |       |         |        |       |       |           |
| **ImmutableDictionaryAdd** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |    **4** |   **2.083 μs** | **0.1621 μs** |  **0.4269 μs** |   **1.932 μs** |  **0.94** |    **0.29** | **0.1602** |     **-** |     **-** |     **674 B** |
| ImmutableDictionaryAdd | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |    4 |   3.490 μs | 0.2457 μs |  0.7246 μs |   3.363 μs |  1.63 |    0.50 | 0.1755 |     - |     - |     736 B |
| ImmutableDictionaryAdd | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |    4 |   2.263 μs | 0.1774 μs |  0.5232 μs |   2.157 μs |  1.00 |    0.00 | 0.1602 |     - |     - |     672 B |
|                        |            |               |              |      |            |           |            |            |       |         |        |       |       |           |
|          DictionaryAdd | Job-BZLJBK |      .NET 4.8 |        net48 |    4 |   1.260 μs | 0.0887 μs |  0.2560 μs |   1.173 μs |  0.92 |    0.30 | 0.2327 |     - |     - |     979 B |
|          DictionaryAdd | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |    4 |   1.641 μs | 0.1014 μs |  0.2991 μs |   1.554 μs |  1.18 |    0.33 | 0.2251 |     - |     - |     944 B |
|          DictionaryAdd | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |    4 |   1.493 μs | 0.1487 μs |  0.4385 μs |   1.412 μs |  1.00 |    0.00 | 0.2327 |     - |     - |     976 B |
|                        |            |               |              |      |            |           |            |            |       |         |        |       |       |           |
| **ImmutableDictionaryAdd** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |    **8** |   **5.447 μs** | **0.2846 μs** |  **0.8074 μs** |   **5.176 μs** |  **1.43** |    **0.26** | **0.4120** |     **-** |     **-** |    **1733 B** |
| ImmutableDictionaryAdd | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |    8 |   6.004 μs | 0.3184 μs |  0.8875 μs |   5.735 μs |  1.59 |    0.34 | 0.4730 |     - |     - |    1984 B |
| ImmutableDictionaryAdd | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |    8 |   3.902 μs | 0.2734 μs |  0.7299 μs |   3.661 μs |  1.00 |    0.00 | 0.4272 |     - |     - |    1792 B |
|                        |            |               |              |      |            |           |            |            |       |         |        |       |       |           |
|          DictionaryAdd | Job-BZLJBK |      .NET 4.8 |        net48 |    8 |   5.033 μs | 0.4493 μs |  1.3176 μs |   4.830 μs |  1.22 |    0.50 | 0.5646 |     - |     - |    2407 B |
|          DictionaryAdd | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |    8 |   3.728 μs | 0.1245 μs |  0.3593 μs |   3.631 μs |  0.91 |    0.27 | 0.5569 |     - |     - |    2336 B |
|          DictionaryAdd | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |    8 |   4.587 μs | 0.4849 μs |  1.4298 μs |   4.323 μs |  1.00 |    0.00 | 0.5722 |     - |     - |    2400 B |
