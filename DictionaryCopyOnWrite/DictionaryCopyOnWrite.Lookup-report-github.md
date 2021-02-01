``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21301
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]     : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  Job-BZLJBK : .NET Framework 4.8 (4.8.4311.0), X64 RyuJIT
  Job-BYYWSC : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT
  Job-PWRAQS : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT


```
|                    Method |        Job |       Runtime |    Toolchain | Count | test |         Mean |        Error |       StdDev |       Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |----------- |-------------- |------------- |------ |----- |-------------:|-------------:|-------------:|-------------:|------:|--------:|------:|------:|------:|----------:|
| **ImmutableDictionaryLookup** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |    **10** |   **16** |     **948.6 ns** |     **46.97 ns** |    **131.71 ns** |     **925.2 ns** |  **1.58** |    **0.29** |     **-** |     **-** |     **-** |         **-** |
| ImmutableDictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |    10 |   16 |     653.6 ns |     28.05 ns |     81.39 ns |     630.0 ns |  1.09 |    0.19 |     - |     - |     - |         - |
| ImmutableDictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |    10 |   16 |     605.5 ns |     26.07 ns |     74.39 ns |     588.4 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
|          DictionaryLookup | Job-BZLJBK |      .NET 4.8 |        net48 |    10 |   16 |     544.5 ns |     25.46 ns |     71.81 ns |     519.9 ns |  1.75 |    0.34 |     - |     - |     - |         - |
|          DictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |    10 |   16 |     730.6 ns |     46.22 ns |    135.57 ns |     702.1 ns |  2.31 |    0.50 |     - |     - |     - |         - |
|          DictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |    10 |   16 |     317.0 ns |     14.80 ns |     42.22 ns |     306.3 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
| **ImmutableDictionaryLookup** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |    **10** |   **32** |     **926.6 ns** |     **32.01 ns** |     **88.70 ns** |     **894.4 ns** |  **1.52** |    **0.23** |     **-** |     **-** |     **-** |         **-** |
| ImmutableDictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |    10 |   32 |     881.3 ns |     80.27 ns |    236.67 ns |     794.1 ns |  1.44 |    0.41 |     - |     - |     - |         - |
| ImmutableDictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |    10 |   32 |     619.3 ns |     22.57 ns |     65.12 ns |     610.4 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
|          DictionaryLookup | Job-BZLJBK |      .NET 4.8 |        net48 |    10 |   32 |     710.8 ns |     71.41 ns |    210.57 ns |     665.9 ns |  1.64 |    0.78 |     - |     - |     - |         - |
|          DictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |    10 |   32 |     566.7 ns |     21.42 ns |     61.79 ns |     566.4 ns |  1.27 |    0.36 |     - |     - |     - |         - |
|          DictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |    10 |   32 |     478.5 ns |     41.67 ns |    122.87 ns |     435.7 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
| **ImmutableDictionaryLookup** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |    **10** |    **4** |     **966.8 ns** |     **40.00 ns** |    **117.31 ns** |     **942.9 ns** |  **1.72** |    **0.25** |     **-** |     **-** |     **-** |         **-** |
| ImmutableDictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |    10 |    4 |     915.1 ns |     74.11 ns |    218.52 ns |     865.1 ns |  1.61 |    0.43 |     - |     - |     - |         - |
| ImmutableDictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |    10 |    4 |     568.7 ns |     19.44 ns |     56.39 ns |     557.0 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
|          DictionaryLookup | Job-BZLJBK |      .NET 4.8 |        net48 |    10 |    4 |     581.2 ns |     34.63 ns |     99.37 ns |     561.1 ns |  1.63 |    0.38 |     - |     - |     - |         - |
|          DictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |    10 |    4 |     630.2 ns |     48.84 ns |    143.99 ns |     584.9 ns |  1.82 |    0.69 |     - |     - |     - |         - |
|          DictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |    10 |    4 |     372.9 ns |     31.56 ns |     93.05 ns |     334.3 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
| **ImmutableDictionaryLookup** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |    **10** |    **8** |   **1,053.7 ns** |     **83.92 ns** |    **243.47 ns** |     **957.3 ns** |  **1.79** |    **0.46** |     **-** |     **-** |     **-** |         **-** |
| ImmutableDictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |    10 |    8 |     994.8 ns |     85.71 ns |    252.73 ns |   1,104.1 ns |  1.69 |    0.48 |     - |     - |     - |         - |
| ImmutableDictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |    10 |    8 |     597.2 ns |     26.64 ns |     77.30 ns |     580.8 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
|          DictionaryLookup | Job-BZLJBK |      .NET 4.8 |        net48 |    10 |    8 |     787.4 ns |     75.64 ns |    223.02 ns |     723.4 ns |  2.28 |    0.93 |     - |     - |     - |         - |
|          DictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |    10 |    8 |     771.7 ns |     48.64 ns |    143.41 ns |     753.8 ns |  2.18 |    0.62 |     - |     - |     - |         - |
|          DictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |    10 |    8 |     374.6 ns |     33.00 ns |     97.29 ns |     345.2 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
| **ImmutableDictionaryLookup** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |   **100** |   **16** |   **9,970.5 ns** |    **485.48 ns** |  **1,392.95 ns** |   **9,648.0 ns** |  **1.08** |    **0.25** |     **-** |     **-** |     **-** |         **-** |
| ImmutableDictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |   100 |   16 |   8,602.6 ns |    549.80 ns |  1,621.10 ns |   8,409.5 ns |  0.93 |    0.20 |     - |     - |     - |         - |
| ImmutableDictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |   100 |   16 |   9,373.4 ns |    476.39 ns |  1,404.65 ns |   9,791.5 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
|          DictionaryLookup | Job-BZLJBK |      .NET 4.8 |        net48 |   100 |   16 |   6,095.5 ns |    375.46 ns |  1,101.15 ns |   5,898.2 ns |  1.37 |    0.31 |     - |     - |     - |         - |
|          DictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |   100 |   16 |   7,070.0 ns |    468.24 ns |  1,380.61 ns |   6,857.2 ns |  1.60 |    0.41 |     - |     - |     - |         - |
|          DictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |   100 |   16 |   4,532.3 ns |    230.32 ns |    679.10 ns |   4,399.0 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
| **ImmutableDictionaryLookup** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |   **100** |   **32** |  **16,142.8 ns** |  **1,091.57 ns** |  **3,218.53 ns** |  **17,173.6 ns** |  **1.44** |    **0.27** |     **-** |     **-** |     **-** |         **-** |
| ImmutableDictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |   100 |   32 |   6,135.9 ns |    274.66 ns |    792.45 ns |   6,039.5 ns |  0.59 |    0.08 |     - |     - |     - |         - |
| ImmutableDictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |   100 |   32 |  10,065.9 ns |    201.24 ns |    307.31 ns |  10,025.4 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
|          DictionaryLookup | Job-BZLJBK |      .NET 4.8 |        net48 |   100 |   32 |   6,378.5 ns |    738.29 ns |  2,165.29 ns |   5,549.5 ns |  1.39 |    0.35 |     - |     - |     - |         - |
|          DictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |   100 |   32 |   7,373.2 ns |    702.61 ns |  2,071.66 ns |   8,687.8 ns |  0.87 |    0.17 |     - |     - |     - |         - |
|          DictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |   100 |   32 |   5,904.8 ns |    114.23 ns |    205.98 ns |   5,904.2 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
| **ImmutableDictionaryLookup** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |   **100** |    **4** |  **18,018.3 ns** |    **352.17 ns** |    **537.81 ns** |  **17,859.6 ns** |  **2.07** |    **0.06** |     **-** |     **-** |     **-** |         **-** |
| ImmutableDictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |   100 |    4 |  10,772.7 ns |    177.05 ns |    189.45 ns |  10,780.7 ns |  1.23 |    0.03 |     - |     - |     - |         - |
| ImmutableDictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |   100 |    4 |   8,797.9 ns |    109.15 ns |    102.10 ns |   8,779.2 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
|          DictionaryLookup | Job-BZLJBK |      .NET 4.8 |        net48 |   100 |    4 |  10,345.9 ns |    199.96 ns |    205.34 ns |  10,377.2 ns |  2.57 |    0.42 |     - |     - |     - |         - |
|          DictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |   100 |    4 |  10,183.0 ns |    200.91 ns |    223.31 ns |  10,122.5 ns |  2.57 |    0.38 |     - |     - |     - |         - |
|          DictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |   100 |    4 |   3,234.3 ns |    277.55 ns |    818.35 ns |   3,013.1 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
| **ImmutableDictionaryLookup** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |   **100** |    **8** |   **8,077.4 ns** |    **204.65 ns** |    **577.21 ns** |   **8,062.0 ns** |  **0.84** |    **0.07** |     **-** |     **-** |     **-** |         **-** |
| ImmutableDictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |   100 |    8 |  12,312.7 ns |    239.16 ns |    302.46 ns |  12,274.0 ns |  1.29 |    0.04 |     - |     - |     - |         - |
| ImmutableDictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |   100 |    8 |   9,595.5 ns |    185.31 ns |    271.63 ns |   9,575.5 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
|          DictionaryLookup | Job-BZLJBK |      .NET 4.8 |        net48 |   100 |    8 |   9,642.0 ns |    703.24 ns |  2,062.47 ns |  10,704.5 ns |  1.05 |    0.14 |     - |     - |     - |         - |
|          DictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |   100 |    8 |  11,925.3 ns |    228.17 ns |    296.69 ns |  11,921.6 ns |  2.07 |    0.06 |     - |     - |     - |         - |
|          DictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |   100 |    8 |   5,752.6 ns |    113.42 ns |    130.61 ns |   5,738.7 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
| **ImmutableDictionaryLookup** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |  **1000** |   **16** | **176,924.7 ns** |  **3,190.54 ns** |  **2,984.43 ns** | **177,371.1 ns** |  **1.80** |    **0.05** |     **-** |     **-** |     **-** |         **-** |
| ImmutableDictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |  1000 |   16 | 117,674.9 ns |  2,303.99 ns |  2,155.15 ns | 117,777.2 ns |  1.19 |    0.04 |     - |     - |     - |         - |
| ImmutableDictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |  1000 |   16 |  98,926.2 ns |  1,893.79 ns |  2,026.33 ns |  98,588.7 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
|          DictionaryLookup | Job-BZLJBK |      .NET 4.8 |        net48 |  1000 |   16 | 110,756.8 ns |  2,198.54 ns |  3,153.08 ns | 110,160.8 ns |  2.01 |    0.07 |     - |     - |     - |         - |
|          DictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |  1000 |   16 |  90,921.9 ns |  1,214.61 ns |  1,076.72 ns |  90,707.5 ns |  1.64 |    0.05 |     - |     - |     - |         - |
|          DictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |  1000 |   16 |  55,261.2 ns |  1,054.66 ns |  1,255.50 ns |  54,932.3 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
| **ImmutableDictionaryLookup** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |  **1000** |   **32** | **142,291.8 ns** | **12,038.44 ns** | **35,495.62 ns** | **139,846.5 ns** |  **2.02** |    **0.61** |     **-** |     **-** |     **-** |         **-** |
| ImmutableDictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |  1000 |   32 |  78,106.2 ns |  6,327.80 ns | 18,358.09 ns |  73,649.7 ns |  1.11 |    0.29 |     - |     - |     - |         - |
| ImmutableDictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |  1000 |   32 |  73,251.5 ns |  5,798.87 ns | 17,098.10 ns |  68,848.3 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
|          DictionaryLookup | Job-BZLJBK |      .NET 4.8 |        net48 |  1000 |   32 |  61,004.3 ns |  2,453.28 ns |  7,156.33 ns |  60,960.8 ns |  1.81 |    0.48 |     - |     - |     - |         - |
|          DictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |  1000 |   32 |  66,064.1 ns |  3,634.55 ns | 10,486.50 ns |  63,374.9 ns |  1.98 |    0.61 |     - |     - |     - |         - |
|          DictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |  1000 |   32 |  36,306.4 ns |  3,289.63 ns |  9,699.56 ns |  33,501.0 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
| **ImmutableDictionaryLookup** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |  **1000** |    **4** | **102,247.0 ns** |  **6,861.88 ns** | **19,466.02 ns** |  **99,392.4 ns** |  **1.54** |    **0.36** |     **-** |     **-** |     **-** |         **-** |
| ImmutableDictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |  1000 |    4 |  82,229.6 ns |  8,122.84 ns | 23,950.36 ns |  75,987.5 ns |  1.27 |    0.49 |     - |     - |     - |         - |
| ImmutableDictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |  1000 |    4 |  68,151.6 ns |  4,160.20 ns | 12,135.49 ns |  65,953.8 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
|          DictionaryLookup | Job-BZLJBK |      .NET 4.8 |        net48 |  1000 |    4 |  69,439.9 ns |  6,926.24 ns | 20,422.17 ns |  64,718.4 ns |  1.97 |    0.75 |     - |     - |     - |         - |
|          DictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |  1000 |    4 |  61,879.4 ns |  3,695.74 ns | 10,896.97 ns |  59,905.8 ns |  1.75 |    0.47 |     - |     - |     - |         - |
|          DictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |  1000 |    4 |  37,422.2 ns |  3,226.86 ns |  9,514.46 ns |  35,013.2 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
| **ImmutableDictionaryLookup** | **Job-BZLJBK** |      **.NET 4.8** |        **net48** |  **1000** |    **8** | **182,815.3 ns** |  **3,073.22 ns** |  **2,724.33 ns** | **182,566.5 ns** |  **2.01** |    **0.06** |     **-** |     **-** |     **-** |         **-** |
| ImmutableDictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |  1000 |    8 | 115,949.3 ns |  1,602.49 ns |  1,420.56 ns | 115,577.2 ns |  1.27 |    0.03 |     - |     - |     - |         - |
| ImmutableDictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |  1000 |    8 |  91,165.4 ns |  1,793.60 ns |  1,993.58 ns |  91,512.1 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                           |            |               |              |       |      |              |              |              |              |       |         |       |       |       |           |
|          DictionaryLookup | Job-BZLJBK |      .NET 4.8 |        net48 |  1000 |    8 | 101,717.4 ns |  2,010.92 ns |  2,752.57 ns | 101,952.2 ns |  1.60 |    0.05 |     - |     - |     - |         - |
|          DictionaryLookup | Job-BYYWSC | .NET Core 3.1 | netcoreapp31 |  1000 |    8 | 100,060.9 ns |  1,965.36 ns |  2,413.64 ns |  99,752.8 ns |  1.58 |    0.04 |     - |     - |     - |         - |
|          DictionaryLookup | Job-PWRAQS | .NET Core 5.0 | netcoreapp50 |  1000 |    8 |  63,104.6 ns |    868.81 ns |    770.18 ns |  62,983.5 ns |  1.00 |    0.00 |     - |     - |     - |         - |
