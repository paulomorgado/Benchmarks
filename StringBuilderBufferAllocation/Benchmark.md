``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.21390
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  Job-LMRUNS : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  Job-PXPOTN : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-GKDAZI : .NET Core 3.1.15 (CoreCLR 4.700.21.21202, CoreFX 4.700.21.21402), X64 RyuJIT
  Job-FPTSDX : .NET Framework 4.8 (4.8.4395.0), X64 RyuJIT


```
|                   Method |            Runtime | Count |        Mean |     Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |------------------- |------ |------------:|----------:|-----------:|------------:|------:|--------:|-------:|-------:|------:|----------:|
| **StringBuilderConstructor** |           **.NET 5.0** |     **0** |    **37.33 ns** |  **5.142 ns** |  **14.835 ns** |    **36.57 ns** |  **1.99** |    **0.75** | **0.0249** |      **-** |     **-** |     **104 B** |
| StringBuilderConstructor |           .NET 6.0 |     0 |    18.94 ns |  0.808 ns |   2.264 ns |    18.71 ns |  0.95 |    0.13 | 0.0249 |      - |     - |     104 B |
| StringBuilderConstructor |      .NET Core 3.1 |     0 |    15.16 ns |  0.558 ns |   1.574 ns |    14.91 ns |  0.77 |    0.07 | 0.0249 |      - |     - |     104 B |
| StringBuilderConstructor | .NET Framework 4.8 |     0 |    19.97 ns |  0.441 ns |   1.162 ns |    19.66 ns |  1.00 |    0.00 | 0.0249 |      - |     - |     104 B |
|                          |                    |       |             |           |            |             |       |         |        |        |       |           |
| **StringBuilderConstructor** |           **.NET 5.0** |     **1** |    **15.49 ns** |  **0.498 ns** |   **1.422 ns** |    **14.97 ns** |  **0.93** |    **0.11** | **0.0191** |      **-** |     **-** |      **80 B** |
| StringBuilderConstructor |           .NET 6.0 |     1 |    14.75 ns |  0.330 ns |   0.551 ns |    14.66 ns |  0.87 |    0.05 | 0.0191 |      - |     - |      80 B |
| StringBuilderConstructor |      .NET Core 3.1 |     1 |    13.84 ns |  0.307 ns |   0.431 ns |    13.85 ns |  0.81 |    0.05 | 0.0191 |      - |     - |      80 B |
| StringBuilderConstructor | .NET Framework 4.8 |     1 |    17.14 ns |  0.379 ns |   0.799 ns |    16.88 ns |  1.00 |    0.00 | 0.0191 |      - |     - |      80 B |
|                          |                    |       |             |           |            |             |       |         |        |        |       |           |
| **StringBuilderConstructor** |           **.NET 5.0** |  **1024** |   **154.87 ns** |  **3.208 ns** |   **9.307 ns** |   **152.58 ns** |  **1.27** |    **0.11** | **0.5066** |      **-** |     **-** |   **2,120 B** |
| StringBuilderConstructor |           .NET 6.0 |  1024 |   158.50 ns |  3.150 ns |   9.037 ns |   156.28 ns |  1.30 |    0.12 | 0.5066 |      - |     - |   2,120 B |
| StringBuilderConstructor |      .NET Core 3.1 |  1024 |   118.38 ns |  2.816 ns |   8.125 ns |   117.37 ns |  0.97 |    0.09 | 0.5066 |      - |     - |   2,120 B |
| StringBuilderConstructor | .NET Framework 4.8 |  1024 |   122.59 ns |  2.586 ns |   7.378 ns |   121.37 ns |  1.00 |    0.00 | 0.5066 |      - |     - |   2,127 B |
|                          |                    |       |             |           |            |             |       |         |        |        |       |           |
| **StringBuilderConstructor** |           **.NET 5.0** |  **2048** |   **254.96 ns** |  **5.101 ns** |   **5.669 ns** |   **255.57 ns** |  **1.01** |    **0.10** | **0.9956** |      **-** |     **-** |   **4,168 B** |
| StringBuilderConstructor |           .NET 6.0 |  2048 |   269.99 ns |  5.200 ns |  12.658 ns |   267.01 ns |  1.10 |    0.09 | 0.9956 |      - |     - |   4,168 B |
| StringBuilderConstructor |      .NET Core 3.1 |  2048 |   241.37 ns |  5.406 ns |  15.511 ns |   238.60 ns |  1.00 |    0.10 | 0.9956 |      - |     - |   4,168 B |
| StringBuilderConstructor | .NET Framework 4.8 |  2048 |   242.14 ns |  7.173 ns |  21.036 ns |   233.61 ns |  1.00 |    0.00 | 0.9959 |      - |     - |   4,182 B |
|                          |                    |       |             |           |            |             |       |         |        |        |       |           |
| **StringBuilderConstructor** |           **.NET 5.0** |  **4096** |   **485.41 ns** |  **9.655 ns** |  **16.394 ns** |   **482.23 ns** |  **1.02** |    **0.10** | **1.9722** |      **-** |     **-** |   **8,264 B** |
| StringBuilderConstructor |           .NET 6.0 |  4096 |   501.71 ns | 10.011 ns |  26.895 ns |   497.75 ns |  1.05 |    0.11 | 1.9722 |      - |     - |   8,264 B |
| StringBuilderConstructor |      .NET Core 3.1 |  4096 |   446.61 ns |  8.885 ns |  18.149 ns |   443.30 ns |  0.95 |    0.07 | 1.9722 |      - |     - |   8,264 B |
| StringBuilderConstructor | .NET Framework 4.8 |  4096 |   495.83 ns | 20.019 ns |  58.395 ns |   469.79 ns |  1.00 |    0.00 | 1.9722 |      - |     - |   8,288 B |
|                          |                    |       |             |           |            |             |       |         |        |        |       |           |
| **StringBuilderConstructor** |           **.NET 5.0** |  **8192** |   **566.38 ns** | **11.161 ns** |  **23.543 ns** |   **563.16 ns** |  **0.57** |    **0.05** | **3.9215** |      **-** |     **-** |  **16,456 B** |
| StringBuilderConstructor |           .NET 6.0 |  8192 |   569.45 ns | 11.332 ns |  23.654 ns |   567.71 ns |  0.57 |    0.05 | 3.9215 |      - |     - |  16,456 B |
| StringBuilderConstructor |      .NET Core 3.1 |  8192 | 1,055.86 ns | 46.327 ns | 136.597 ns | 1,031.87 ns |  1.06 |    0.20 | 3.9215 | 0.2289 |     - |  16,456 B |
| StringBuilderConstructor | .NET Framework 4.8 |  8192 | 1,012.10 ns | 41.500 ns | 121.714 ns |   997.10 ns |  1.00 |    0.00 | 3.9215 |      - |     - |  16,496 B |
|                          |                    |       |             |           |            |             |       |         |        |        |       |           |
| **StringBuilderConstructor** |           **.NET 5.0** | **16384** |   **584.68 ns** | **10.315 ns** |  **18.334 ns** |   **581.02 ns** |  **0.40** |    **0.02** | **7.8115** |      **-** |     **-** |  **32,840 B** |
| StringBuilderConstructor |           .NET 6.0 | 16384 |   612.43 ns | 11.978 ns |  17.178 ns |   609.61 ns |  0.42 |    0.02 | 7.8115 |      - |     - |  32,840 B |
| StringBuilderConstructor |      .NET Core 3.1 | 16384 | 1,807.32 ns | 35.662 ns |  67.852 ns | 1,802.49 ns |  1.24 |    0.06 | 7.8106 | 0.8659 |     - |  32,840 B |
| StringBuilderConstructor | .NET Framework 4.8 | 16384 | 1,467.91 ns | 28.770 ns |  48.069 ns | 1,456.97 ns |  1.00 |    0.00 | 7.8106 |      - |     - |  32,880 B |
