``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.21390
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  Job-HIIRXB : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  Job-EALUSU : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-IBBSGZ : .NET Core 3.1.15 (CoreCLR 4.700.21.21202, CoreFX 4.700.21.21402), X64 RyuJIT
  Job-JZPXBE : .NET Framework 4.8 (4.8.4395.0), X64 RyuJIT


```
|                  Method |            Runtime |         data |               Mean |              Error |             StdDev |             Median |          Ratio |        RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------ |------------------- |------------- |-------------------:|-------------------:|-------------------:|-------------------:|---------------:|---------------:|-------:|------:|------:|----------:|
|  **ArraySortWithIComparer** |           **.NET 5.0** | **Int32[10000]** | **214,545,806.383 ns** |  **5,021,539.2533 ns** | **14,326,734.0488 ns** | **211,368,600.000 ns** | **101,868,151.50** |  **74,801,538.29** |      **-** |     **-** |     **-** |         **-** |
| ArraySortWithComparison |           .NET 5.0 | Int32[10000] | 236,460,408.148 ns |  8,609,299.9425 ns | 23,999,287.0953 ns | 229,233,833.333 ns | 110,438,384.42 |  83,025,870.14 |      - |     - |     - |      64 B |
|  ArraySortWithIComparer |           .NET 6.0 | Int32[10000] | 233,143,371.631 ns |  7,612,202.1526 ns | 21,718,041.0759 ns | 228,957,333.333 ns | 114,917,594.32 |  94,120,833.85 |      - |     - |     - |      48 B |
| ArraySortWithComparison |           .NET 6.0 | Int32[10000] | 262,034,734.884 ns | 18,913,988.3618 ns | 51,456,900.2652 ns | 244,405,150.000 ns | 123,988,559.95 | 105,042,252.32 |      - |     - |     - |     136 B |
|  ArraySortWithIComparer |      .NET Core 3.1 | Int32[10000] | 430,052,887.500 ns | 31,450,982.2868 ns | 90,743,275.0343 ns | 413,290,900.000 ns | 205,640,427.76 | 170,908,307.52 |      - |     - |     - |         - |
| ArraySortWithComparison |      .NET Core 3.1 | Int32[10000] | 323,879,994.949 ns | 20,513,422.8737 ns | 60,162,318.2807 ns | 307,564,900.000 ns | 154,954,568.56 | 115,259,428.28 |      - |     - |     - |      64 B |
|  ArraySortWithIComparer | .NET Framework 4.8 | Int32[10000] | 268,363,109.375 ns |  6,087,067.7000 ns | 17,562,582.0974 ns | 265,311,900.000 ns | 126,771,915.49 |  92,001,247.10 |      - |     - |     - |         - |
| ArraySortWithComparison | .NET Framework 4.8 | Int32[10000] | 250,603,117.553 ns |  6,893,351.9170 ns | 19,667,120.9044 ns | 247,895,550.000 ns | 119,829,955.42 |  88,962,579.03 |      - |     - |     - |   4,096 B |
|  **ArraySortWithIComparer** |           **.NET 5.0** |  **Int32[1000]** |   **2,491,324.641 ns** |     **49,633.9331 ns** |    **112,032.0584 ns** |   **2,480,443.750 ns** |     **804,414.62** |     **553,235.21** |      **-** |     **-** |     **-** |         **-** |
| ArraySortWithComparison |           .NET 5.0 |  Int32[1000] |   2,485,225.877 ns |     49,590.5471 ns |     99,037.6809 ns |   2,457,809.766 ns |     634,565.38 |     410,453.71 |      - |     - |     - |      64 B |
|  ArraySortWithIComparer |           .NET 6.0 |  Int32[1000] |   2,154,940.510 ns |     40,801.8356 ns |     93,749.0026 ns |   2,142,879.102 ns |     733,217.71 |     520,275.64 |      - |     - |     - |       1 B |
| ArraySortWithComparison |           .NET 6.0 |  Int32[1000] |   2,256,968.316 ns |     39,062.2131 ns |     89,751.9305 ns |   2,237,067.188 ns |     767,165.71 |     540,430.14 |      - |     - |     - |      65 B |
|  ArraySortWithIComparer |      .NET Core 3.1 |  Int32[1000] |   2,578,610.484 ns |     51,875.0505 ns |    147,160.8841 ns |   2,539,498.047 ns |   1,191,983.79 |     826,928.08 |      - |     - |     - |         - |
| ArraySortWithComparison |      .NET Core 3.1 |  Int32[1000] |   2,784,388.186 ns |    184,636.1901 ns |    502,316.3724 ns |   2,689,141.602 ns |   1,339,427.61 |   1,095,022.19 |      - |     - |     - |      64 B |
|  ArraySortWithIComparer | .NET Framework 4.8 |  Int32[1000] |   2,442,697.469 ns |     66,886.4529 ns |    194,049.7279 ns |   2,394,127.930 ns |   1,145,112.85 |     821,744.05 |      - |     - |     - |         - |
| ArraySortWithComparison | .NET Framework 4.8 |  Int32[1000] |   2,181,898.432 ns |     42,874.4038 ns |    103,546.5041 ns |   2,155,245.703 ns |     787,503.45 |     564,371.11 |      - |     - |     - |      96 B |
|  **ArraySortWithIComparer** |           **.NET 5.0** |   **Int32[100]** |      **23,791.998 ns** |        **450.5062 ns** |      **1,035.1130 ns** |      **23,561.986 ns** |       **8,094.59** |       **5,688.49** |      **-** |     **-** |     **-** |         **-** |
| ArraySortWithComparison |           .NET 5.0 |   Int32[100] |      23,515.435 ns |        461.9312 ns |        943.6030 ns |      23,384.190 ns |       6,291.39 |       4,088.46 |      - |     - |     - |      64 B |
|  ArraySortWithIComparer |           .NET 6.0 |   Int32[100] |      21,502.653 ns |        426.5249 ns |        356.1676 ns |      21,464.481 ns |       2,716.90 |         173.71 |      - |     - |     - |         - |
| ArraySortWithComparison |           .NET 6.0 |   Int32[100] |      21,392.594 ns |        414.8392 ns |        567.8365 ns |      21,401.692 ns |       3,035.33 |         573.11 |      - |     - |     - |      64 B |
|  ArraySortWithIComparer |      .NET Core 3.1 |   Int32[100] |      30,599.200 ns |        738.6795 ns |      2,107.4941 ns |      29,935.660 ns |      14,502.49 |      10,557.83 |      - |     - |     - |         - |
| ArraySortWithComparison |      .NET Core 3.1 |   Int32[100] |      22,046.171 ns |        435.7217 ns |        785.6961 ns |      21,925.891 ns |       4,672.76 |       2,827.24 |      - |     - |     - |      64 B |
|  ArraySortWithIComparer | .NET Framework 4.8 |   Int32[100] |      23,035.756 ns |        449.1741 ns |        685.9362 ns |      22,864.120 ns |       3,457.89 |         940.03 |      - |     - |     - |         - |
| ArraySortWithComparison | .NET Framework 4.8 |   Int32[100] |      21,938.912 ns |        425.8289 ns |        675.4097 ns |      22,064.441 ns |       3,534.83 |       1,332.27 |      - |     - |     - |      64 B |
|  **ArraySortWithIComparer** |           **.NET 5.0** |     **Int32[1]** |           **2.966 ns** |          **0.1007 ns** |          **0.2706 ns** |           **2.903 ns** |           **1.33** |           **0.99** |      **-** |     **-** |     **-** |         **-** |
| ArraySortWithComparison |           .NET 5.0 |     Int32[1] |          22.886 ns |          0.9772 ns |          2.7879 ns |          22.162 ns |          10.89 |           8.11 | 0.0153 |     - |     - |      64 B |
|  ArraySortWithIComparer |           .NET 6.0 |     Int32[1] |           1.456 ns |          0.0713 ns |          0.0977 ns |           1.449 ns |           0.21 |           0.04 |      - |     - |     - |         - |
| ArraySortWithComparison |           .NET 6.0 |     Int32[1] |          21.040 ns |          0.4617 ns |          0.9431 ns |          20.654 ns |           5.60 |           3.60 | 0.0153 |     - |     - |      64 B |
|  ArraySortWithIComparer |      .NET Core 3.1 |     Int32[1] |           1.500 ns |          0.0718 ns |          0.1118 ns |           1.511 ns |           0.24 |           0.09 |      - |     - |     - |         - |
| ArraySortWithComparison |      .NET Core 3.1 |     Int32[1] |          16.913 ns |          0.3439 ns |          0.5553 ns |          16.894 ns |           2.86 |           1.27 | 0.0153 |     - |     - |      64 B |
|  ArraySortWithIComparer | .NET Framework 4.8 |     Int32[1] |           3.250 ns |          0.1065 ns |          0.2986 ns |           3.156 ns |           1.50 |           1.10 |      - |     - |     - |         - |
| ArraySortWithComparison | .NET Framework 4.8 |     Int32[1] |          19.920 ns |          0.4428 ns |          1.1108 ns |          19.620 ns |           7.99 |           5.95 | 0.0153 |     - |     - |      64 B |
|  **ArraySortWithIComparer** |           **.NET 5.0** |     **Int32[0]** |           **1.544 ns** |          **0.0699 ns** |          **0.1818 ns** |           **1.495 ns** |           **0.66** |           **0.50** |      **-** |     **-** |     **-** |         **-** |
| ArraySortWithComparison |           .NET 5.0 |     Int32[0] |          25.197 ns |          0.8423 ns |          2.4302 ns |          24.599 ns |          12.20 |           9.25 | 0.0153 |     - |     - |      64 B |
|  ArraySortWithIComparer |           .NET 6.0 |     Int32[0] |           1.844 ns |          0.0804 ns |          0.1491 ns |           1.831 ns |           0.40 |           0.23 |      - |     - |     - |         - |
| ArraySortWithComparison |           .NET 6.0 |     Int32[0] |          24.595 ns |          0.5699 ns |          1.6351 ns |          24.547 ns |          11.74 |           8.68 | 0.0153 |     - |     - |      64 B |
|  ArraySortWithIComparer |      .NET Core 3.1 |     Int32[0] |           1.659 ns |          0.0786 ns |          0.1773 ns |           1.653 ns |           0.53 |           0.36 |      - |     - |     - |         - |
| ArraySortWithComparison |      .NET Core 3.1 |     Int32[0] |          19.623 ns |          0.5750 ns |          1.6219 ns |          19.484 ns |           9.09 |           6.48 | 0.0153 |     - |     - |      64 B |
|  ArraySortWithIComparer | .NET Framework 4.8 |     Int32[0] |           3.508 ns |          0.8802 ns |          2.5951 ns |           2.434 ns |           1.00 |           0.00 |      - |     - |     - |         - |
| ArraySortWithComparison | .NET Framework 4.8 |     Int32[0] |          35.823 ns |          3.5216 ns |         10.3835 ns |          34.843 ns |          18.74 |          16.11 | 0.0153 |     - |     - |      64 B |
