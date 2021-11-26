```yml
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22509
Unknown processor
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  Job-OPZHUZ : .NET 5.0.12 (5.0.1221.52207), X64 RyuJIT
  Job-BTRPRB : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  Job-ACDLTH : .NET Core 3.1.21 (CoreCLR 4.700.21.51404, CoreFX 4.700.21.51508), X64 RyuJIT
  Job-OQVFXM : .NET Framework 4.8 (4.8.9014.0), X64 RyuJIT
```

|              Method |            Runtime |        Mean | Ratio |  Gen 0 | Allocated |
|-------------------- |------------------- |------------:|------:|-------:|----------:|
|            FromText | .NET Framework 4.8 | 836.5534 ns | 1.000 |      - |         - |
|         FromNumbers | .NET Framework 4.8 |  14.6450 ns | 0.018 |      - |         - |
|    FromNewByteArray | .NET Framework 4.8 |  33.6459 ns | 0.041 | 0.0095 |      40 B |
| FromCachedByteArray | .NET Framework 4.8 |  16.8952 ns | 0.021 |      - |         - |
|           FromConst | .NET Framework 4.8 |   0.3653 ns | 0.000 |      - |         - |
|            FromText |      .NET Core 3.1 | 234.7546 ns | 0.286 |      - |         - |
|         FromNumbers |      .NET Core 3.1 |  12.8790 ns | 0.016 |      - |         - |
|    FromNewByteArray |      .NET Core 3.1 |  26.6148 ns | 0.033 | 0.0095 |      40 B |
| FromCachedByteArray |      .NET Core 3.1 |   7.3232 ns | 0.009 |      - |         - |
|           FromConst |      .NET Core 3.1 |   0.5800 ns | 0.001 |      - |         - |
|            FromText |           .NET 5.0 | 284.9920 ns | 0.381 |      - |         - |
|         FromNumbers |           .NET 5.0 |  12.7501 ns | 0.016 |      - |         - |
|    FromNewByteArray |           .NET 5.0 |  32.0879 ns | 0.040 | 0.0095 |      40 B |
| FromCachedByteArray |           .NET 5.0 |  12.7763 ns | 0.016 |      - |         - |
|           FromConst |           .NET 5.0 |   0.0005 ns | 0.000 |      - |         - |
|            FromText |           .NET 6.0 | 109.6260 ns | 0.144 |      - |         - |
|         FromNumbers |           .NET 6.0 |  12.2377 ns | 0.015 |      - |         - |
|    FromNewByteArray |           .NET 6.0 |  23.2408 ns | 0.029 | 0.0095 |      40 B |
| FromCachedByteArray |           .NET 6.0 |   4.1205 ns | 0.005 |      - |         - |
|           FromConst |           .NET 6.0 |   0.3215 ns | 0.000 |      - |         - |
