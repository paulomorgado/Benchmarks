``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.22000
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.6.21355.2
  [Host]     : .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
  Job-NHSWRI : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT
  Job-QPKQWZ : .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
  Job-PRIIIC : .NET Core 3.1.17 (CoreCLR 4.700.21.31506, CoreFX 4.700.21.31502), X64 RyuJIT
  Job-LYOUSB : .NET Framework 4.8 (4.8.4395.0), X64 RyuJIT


```
|   Method |            Runtime |                Text1 |                Text2 |         Mean |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------- |------------------- |--------------------- |--------------------- |-------------:|-------:|------:|------:|----------:|
| **Original** |           **.NET 5.0** |                    **?** |                    **?** |    **13.399 ns** | **0.0057** |     **-** |     **-** |      **24 B** |
| Original |           .NET 6.0 |                    ? |                    ? |     8.398 ns | 0.0057 |     - |     - |      24 B |
| Original |      .NET Core 3.1 |                    ? |                    ? |     4.121 ns | 0.0057 |     - |     - |      24 B |
| Original | .NET Framework 4.8 |                    ? |                    ? |     4.920 ns | 0.0057 |     - |     - |      24 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 |                    ? |                    ? |     4.227 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 |                    ? |                    ? |     2.160 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 |                    ? |                    ? |     1.818 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 |                    ? |                    ? |     1.664 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 |                    ? |                    ? |     1.430 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 |                    ? |                    ? |     1.247 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 |                    ? |                    ? |     1.846 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 |                    ? |                    ? |     8.842 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 |                    ? |                    ? |     2.251 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 |                    ? |                    ? |     2.202 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 |                    ? |                    ? |     4.127 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 |                    ? |                    ? |     1.569 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
| **Original** |           **.NET 5.0** |                    **?** |                     **** |     **4.125 ns** | **0.0057** |     **-** |     **-** |      **24 B** |
| Original |           .NET 6.0 |                    ? |                      |     3.821 ns | 0.0057 |     - |     - |      24 B |
| Original |      .NET Core 3.1 |                    ? |                      |     3.947 ns | 0.0057 |     - |     - |      24 B |
| Original | .NET Framework 4.8 |                    ? |                      |     3.743 ns | 0.0057 |     - |     - |      24 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 |                    ? |                      |     1.728 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 |                    ? |                      |     1.716 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 |                    ? |                      |     1.914 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 |                    ? |                      |     1.630 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 |                    ? |                      |     1.054 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 |                    ? |                      |     1.290 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 |                    ? |                      |     1.282 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 |                    ? |                      |     8.479 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 |                    ? |                      |     1.593 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 |                    ? |                      |     1.466 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 |                    ? |                      |     1.633 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 |                    ? |                      |     1.435 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
| **Original** |           **.NET 5.0** |                    **?** | **I qui(...)56789 [69]** |     **4.455 ns** | **0.0057** |     **-** |     **-** |      **24 B** |
| Original |           .NET 6.0 |                    ? | I qui(...)56789 [69] |     3.623 ns | 0.0057 |     - |     - |      24 B |
| Original |      .NET Core 3.1 |                    ? | I qui(...)56789 [69] |     3.904 ns | 0.0057 |     - |     - |      24 B |
| Original | .NET Framework 4.8 |                    ? | I qui(...)56789 [69] |     3.810 ns | 0.0057 |     - |     - |      24 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 |                    ? | I qui(...)56789 [69] |     3.623 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 |                    ? | I qui(...)56789 [69] |     1.682 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 |                    ? | I qui(...)56789 [69] |     1.830 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 |                    ? | I qui(...)56789 [69] |     1.686 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 |                    ? | I qui(...)56789 [69] |     1.086 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 |                    ? | I qui(...)56789 [69] |     1.186 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 |                    ? | I qui(...)56789 [69] |     1.372 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 |                    ? | I qui(...)56789 [69] |     8.486 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 |                    ? | I qui(...)56789 [69] |     1.522 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 |                    ? | I qui(...)56789 [69] |     1.506 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 |                    ? | I qui(...)56789 [69] |     1.490 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 |                    ? | I qui(...)56789 [69] |     1.483 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
| **Original** |           **.NET 5.0** |                    **?** | **the q(...)56789 [64]** |     **4.438 ns** | **0.0057** |     **-** |     **-** |      **24 B** |
| Original |           .NET 6.0 |                    ? | the q(...)56789 [64] |     6.200 ns | 0.0057 |     - |     - |      24 B |
| Original |      .NET Core 3.1 |                    ? | the q(...)56789 [64] |     5.893 ns | 0.0057 |     - |     - |      24 B |
| Original | .NET Framework 4.8 |                    ? | the q(...)56789 [64] |     9.202 ns | 0.0057 |     - |     - |      24 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 |                    ? | the q(...)56789 [64] |     2.115 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 |                    ? | the q(...)56789 [64] |     4.455 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 |                    ? | the q(...)56789 [64] |     1.605 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 |                    ? | the q(...)56789 [64] |     2.418 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 |                    ? | the q(...)56789 [64] |     2.064 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 |                    ? | the q(...)56789 [64] |     1.292 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 |                    ? | the q(...)56789 [64] |     1.964 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 |                    ? | the q(...)56789 [64] |    10.925 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 |                    ? | the q(...)56789 [64] |     4.426 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 |                    ? | the q(...)56789 [64] |     1.845 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 |                    ? | the q(...)56789 [64] |     4.864 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 |                    ? | the q(...)56789 [64] |     1.981 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
| **Original** |           **.NET 5.0** |                     **** |                    **?** |     **6.531 ns** | **0.0057** |     **-** |     **-** |      **24 B** |
| Original |           .NET 6.0 |                      |                    ? |     5.075 ns | 0.0057 |     - |     - |      24 B |
| Original |      .NET Core 3.1 |                      |                    ? |    17.667 ns | 0.0057 |     - |     - |      24 B |
| Original | .NET Framework 4.8 |                      |                    ? |     6.276 ns | 0.0057 |     - |     - |      24 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 |                      |                    ? |     2.486 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 |                      |                    ? |     4.248 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 |                      |                    ? |     6.716 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 |                      |                    ? |     4.087 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 |                      |                    ? |     1.409 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 |                      |                    ? |     1.938 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 |                      |                    ? |     3.204 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 |                      |                    ? |    13.414 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 |                      |                    ? |     2.161 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 |                      |                    ? |     4.659 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 |                      |                    ? |     1.635 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 |                      |                    ? |     1.848 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
| **Original** |           **.NET 5.0** |                     **** |                     **** |   **210.809 ns** | **0.0477** |     **-** |     **-** |     **200 B** |
| Original |           .NET 6.0 |                      |                      |   162.859 ns | 0.0477 |     - |     - |     200 B |
| Original |      .NET Core 3.1 |                      |                      |   176.828 ns | 0.0477 |     - |     - |     200 B |
| Original | .NET Framework 4.8 |                      |                      |   457.033 ns | 0.0477 |     - |     - |     201 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 |                      |                      |     6.615 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 |                      |                      |     3.562 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 |                      |                      |     3.393 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 |                      |                      |     8.448 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 |                      |                      |     5.702 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 |                      |                      |     5.622 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 |                      |                      |     5.397 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 |                      |                      |    24.704 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 |                      |                      |     3.795 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 |                      |                      |     4.016 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 |                      |                      |     8.402 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 |                      |                      |    10.527 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
| **Original** |           **.NET 5.0** |                     **** | **I qui(...)56789 [69]** |   **399.081 ns** | **0.0858** |     **-** |     **-** |     **360 B** |
| Original |           .NET 6.0 |                      | I qui(...)56789 [69] |   412.648 ns | 0.0858 |     - |     - |     360 B |
| Original |      .NET Core 3.1 |                      | I qui(...)56789 [69] |   487.798 ns | 0.0858 |     - |     - |     360 B |
| Original | .NET Framework 4.8 |                      | I qui(...)56789 [69] |   742.461 ns | 0.0877 |     - |     - |     369 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 |                      | I qui(...)56789 [69] |     4.676 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 |                      | I qui(...)56789 [69] |     4.841 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 |                      | I qui(...)56789 [69] |     5.067 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 |                      | I qui(...)56789 [69] |     5.944 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 |                      | I qui(...)56789 [69] |     9.238 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 |                      | I qui(...)56789 [69] |     7.386 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 |                      | I qui(...)56789 [69] |    12.711 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 |                      | I qui(...)56789 [69] |    22.030 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 |                      | I qui(...)56789 [69] |     5.822 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 |                      | I qui(...)56789 [69] |     6.631 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 |                      | I qui(...)56789 [69] |     7.551 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 |                      | I qui(...)56789 [69] |     6.683 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
| **Original** |           **.NET 5.0** |                     **** | **the q(...)56789 [64]** |   **418.387 ns** | **0.0477** |     **-** |     **-** |     **200 B** |
| Original |           .NET 6.0 |                      | the q(...)56789 [64] |   378.422 ns | 0.0477 |     - |     - |     200 B |
| Original |      .NET Core 3.1 |                      | the q(...)56789 [64] |   419.604 ns | 0.0477 |     - |     - |     200 B |
| Original | .NET Framework 4.8 |                      | the q(...)56789 [64] |   517.594 ns | 0.0858 |     - |     - |     361 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 |                      | the q(...)56789 [64] |     4.464 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 |                      | the q(...)56789 [64] |     7.101 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 |                      | the q(...)56789 [64] |     3.335 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 |                      | the q(...)56789 [64] |     3.613 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 |                      | the q(...)56789 [64] |    10.420 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 |                      | the q(...)56789 [64] |     9.319 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 |                      | the q(...)56789 [64] |     5.818 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 |                      | the q(...)56789 [64] |    17.204 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 |                      | the q(...)56789 [64] |     5.933 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 |                      | the q(...)56789 [64] |     8.773 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 |                      | the q(...)56789 [64] |     4.755 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 |                      | the q(...)56789 [64] |     5.531 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
| **Original** |           **.NET 5.0** | **I qui(...)56789 [69]** |                    **?** |     **8.323 ns** | **0.0057** |     **-** |     **-** |      **24 B** |
| Original |           .NET 6.0 | I qui(...)56789 [69] |                    ? |     6.616 ns | 0.0057 |     - |     - |      24 B |
| Original |      .NET Core 3.1 | I qui(...)56789 [69] |                    ? |     7.734 ns | 0.0057 |     - |     - |      24 B |
| Original | .NET Framework 4.8 | I qui(...)56789 [69] |                    ? |     6.894 ns | 0.0057 |     - |     - |      24 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 | I qui(...)56789 [69] |                    ? |     2.537 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 | I qui(...)56789 [69] |                    ? |     3.691 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 | I qui(...)56789 [69] |                    ? |     2.947 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 | I qui(...)56789 [69] |                    ? |     6.707 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 | I qui(...)56789 [69] |                    ? |     3.524 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 | I qui(...)56789 [69] |                    ? |     1.668 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 | I qui(...)56789 [69] |                    ? |     1.350 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 | I qui(...)56789 [69] |                    ? |    12.155 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 | I qui(...)56789 [69] |                    ? |     1.693 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 | I qui(...)56789 [69] |                    ? |     2.767 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 | I qui(...)56789 [69] |                    ? |     2.344 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 | I qui(...)56789 [69] |                    ? |     1.547 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
| **Original** |           **.NET 5.0** | **I qui(...)56789 [69]** |                     **** |   **367.827 ns** | **0.0858** |     **-** |     **-** |     **360 B** |
| Original |           .NET 6.0 | I qui(...)56789 [69] |                      |   357.086 ns | 0.0858 |     - |     - |     360 B |
| Original |      .NET Core 3.1 | I qui(...)56789 [69] |                      |   251.758 ns | 0.0858 |     - |     - |     360 B |
| Original | .NET Framework 4.8 | I qui(...)56789 [69] |                      |   414.540 ns | 0.0877 |     - |     - |     369 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 | I qui(...)56789 [69] |                      |     4.078 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 | I qui(...)56789 [69] |                      |     3.829 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 | I qui(...)56789 [69] |                      |     3.925 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 | I qui(...)56789 [69] |                      |     3.510 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 | I qui(...)56789 [69] |                      |     7.302 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 | I qui(...)56789 [69] |                      |    11.654 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 | I qui(...)56789 [69] |                      |     5.946 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 | I qui(...)56789 [69] |                      |    12.872 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 | I qui(...)56789 [69] |                      |     4.772 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 | I qui(...)56789 [69] |                      |     5.827 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 | I qui(...)56789 [69] |                      |     4.749 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 | I qui(...)56789 [69] |                      |     4.237 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
| **Original** |           **.NET 5.0** | **I qui(...)56789 [69]** | **I qui(...)56789 [69]** | **2,143.797 ns** | **0.1221** |     **-** |     **-** |     **520 B** |
| Original |           .NET 6.0 | I qui(...)56789 [69] | I qui(...)56789 [69] | 2,008.135 ns | 0.1221 |     - |     - |     520 B |
| Original |      .NET Core 3.1 | I qui(...)56789 [69] | I qui(...)56789 [69] | 2,150.595 ns | 0.1221 |     - |     - |     520 B |
| Original | .NET Framework 4.8 | I qui(...)56789 [69] | I qui(...)56789 [69] | 2,841.687 ns | 0.1259 |     - |     - |     538 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 | I qui(...)56789 [69] | I qui(...)56789 [69] | 1,518.858 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 | I qui(...)56789 [69] | I qui(...)56789 [69] | 1,580.417 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 | I qui(...)56789 [69] | I qui(...)56789 [69] | 1,596.827 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 | I qui(...)56789 [69] | I qui(...)56789 [69] | 2,905.033 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 | I qui(...)56789 [69] | I qui(...)56789 [69] | 1,478.679 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 | I qui(...)56789 [69] | I qui(...)56789 [69] | 1,418.404 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 | I qui(...)56789 [69] | I qui(...)56789 [69] | 1,579.955 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 | I qui(...)56789 [69] | I qui(...)56789 [69] | 2,956.263 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 | I qui(...)56789 [69] | I qui(...)56789 [69] | 1,424.078 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 | I qui(...)56789 [69] | I qui(...)56789 [69] | 1,404.936 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 | I qui(...)56789 [69] | I qui(...)56789 [69] | 1,601.818 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 | I qui(...)56789 [69] | I qui(...)56789 [69] | 2,896.941 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
| **Original** |           **.NET 5.0** | **I qui(...)56789 [69]** | **the q(...)56789 [64]** |   **254.170 ns** | **0.0858** |     **-** |     **-** |     **360 B** |
| Original |           .NET 6.0 | I qui(...)56789 [69] | the q(...)56789 [64] |   244.126 ns | 0.0858 |     - |     - |     360 B |
| Original |      .NET Core 3.1 | I qui(...)56789 [69] | the q(...)56789 [64] |   231.257 ns | 0.0861 |     - |     - |     360 B |
| Original | .NET Framework 4.8 | I qui(...)56789 [69] | the q(...)56789 [64] |   745.556 ns | 0.1259 |     - |     - |     530 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 | I qui(...)56789 [69] | the q(...)56789 [64] |   280.750 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 | I qui(...)56789 [69] | the q(...)56789 [64] |   260.170 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 | I qui(...)56789 [69] | the q(...)56789 [64] |   297.177 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 | I qui(...)56789 [69] | the q(...)56789 [64] |   716.669 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 | I qui(...)56789 [69] | the q(...)56789 [64] |   268.676 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 | I qui(...)56789 [69] | the q(...)56789 [64] |   255.250 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 | I qui(...)56789 [69] | the q(...)56789 [64] |   359.210 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 | I qui(...)56789 [69] | the q(...)56789 [64] |   822.534 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 | I qui(...)56789 [69] | the q(...)56789 [64] |    23.652 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 | I qui(...)56789 [69] | the q(...)56789 [64] |    24.402 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 | I qui(...)56789 [69] | the q(...)56789 [64] |    37.336 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 | I qui(...)56789 [69] | the q(...)56789 [64] |    81.416 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
| **Original** |           **.NET 5.0** | **the q(...)56789 [64]** |                    **?** |     **6.440 ns** | **0.0057** |     **-** |     **-** |      **24 B** |
| Original |           .NET 6.0 | the q(...)56789 [64] |                    ? |     4.900 ns | 0.0057 |     - |     - |      24 B |
| Original |      .NET Core 3.1 | the q(...)56789 [64] |                    ? |     6.191 ns | 0.0057 |     - |     - |      24 B |
| Original | .NET Framework 4.8 | the q(...)56789 [64] |                    ? |     5.852 ns | 0.0057 |     - |     - |      24 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 | the q(...)56789 [64] |                    ? |     3.382 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 | the q(...)56789 [64] |                    ? |     3.085 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 | the q(...)56789 [64] |                    ? |     2.827 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 | the q(...)56789 [64] |                    ? |     4.469 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 | the q(...)56789 [64] |                    ? |     1.974 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 | the q(...)56789 [64] |                    ? |     1.569 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 | the q(...)56789 [64] |                    ? |     4.071 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 | the q(...)56789 [64] |                    ? |    14.105 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 | the q(...)56789 [64] |                    ? |     2.684 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 | the q(...)56789 [64] |                    ? |     2.081 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 | the q(...)56789 [64] |                    ? |     2.505 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 | the q(...)56789 [64] |                    ? |     2.969 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
| **Original** |           **.NET 5.0** | **the q(...)56789 [64]** |                     **** |   **287.264 ns** | **0.0477** |     **-** |     **-** |     **200 B** |
| Original |           .NET 6.0 | the q(...)56789 [64] |                      |   263.434 ns | 0.0477 |     - |     - |     200 B |
| Original |      .NET Core 3.1 | the q(...)56789 [64] |                      |   241.336 ns | 0.0477 |     - |     - |     200 B |
| Original | .NET Framework 4.8 | the q(...)56789 [64] |                      |   477.147 ns | 0.0858 |     - |     - |     361 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 | the q(...)56789 [64] |                      |     3.908 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 | the q(...)56789 [64] |                      |     3.946 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 | the q(...)56789 [64] |                      |     3.700 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 | the q(...)56789 [64] |                      |     5.368 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 | the q(...)56789 [64] |                      |     7.037 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 | the q(...)56789 [64] |                      |     4.834 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 | the q(...)56789 [64] |                      |     7.250 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 | the q(...)56789 [64] |                      |    15.118 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 | the q(...)56789 [64] |                      |     5.528 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 | the q(...)56789 [64] |                      |     5.698 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 | the q(...)56789 [64] |                      |     4.336 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 | the q(...)56789 [64] |                      |     4.601 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
| **Original** |           **.NET 5.0** | **the q(...)56789 [64]** | **I qui(...)56789 [69]** |   **325.833 ns** | **0.0858** |     **-** |     **-** |     **360 B** |
| Original |           .NET 6.0 | the q(...)56789 [64] | I qui(...)56789 [69] |   256.213 ns | 0.0858 |     - |     - |     360 B |
| Original |      .NET Core 3.1 | the q(...)56789 [64] | I qui(...)56789 [69] |   243.110 ns | 0.0858 |     - |     - |     360 B |
| Original | .NET Framework 4.8 | the q(...)56789 [64] | I qui(...)56789 [69] |   535.165 ns | 0.1259 |     - |     - |     530 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 | the q(...)56789 [64] | I qui(...)56789 [69] |   268.712 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 | the q(...)56789 [64] | I qui(...)56789 [69] |   260.728 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 | the q(...)56789 [64] | I qui(...)56789 [69] |   298.066 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 | the q(...)56789 [64] | I qui(...)56789 [69] |   542.378 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 | the q(...)56789 [64] | I qui(...)56789 [69] |   264.744 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 | the q(...)56789 [64] | I qui(...)56789 [69] |   266.048 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 | the q(...)56789 [64] | I qui(...)56789 [69] |   302.474 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 | the q(...)56789 [64] | I qui(...)56789 [69] |   557.093 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 | the q(...)56789 [64] | I qui(...)56789 [69] |    23.391 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 | the q(...)56789 [64] | I qui(...)56789 [69] |    25.128 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 | the q(...)56789 [64] | I qui(...)56789 [69] |    27.319 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 | the q(...)56789 [64] | I qui(...)56789 [69] |    49.222 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
| **Original** |           **.NET 5.0** | **the q(...)56789 [64]** | **the q(...)56789 [64]** | **2,065.303 ns** | **0.0458** |     **-** |     **-** |     **200 B** |
| Original |           .NET 6.0 | the q(...)56789 [64] | the q(...)56789 [64] | 1,905.238 ns | 0.0458 |     - |     - |     200 B |
| Original |      .NET Core 3.1 | the q(...)56789 [64] | the q(...)56789 [64] | 2,152.365 ns | 0.0458 |     - |     - |     200 B |
| Original | .NET Framework 4.8 | the q(...)56789 [64] | the q(...)56789 [64] | 2,703.400 ns | 0.1221 |     - |     - |     522 B |
|          |                    |                      |                      |              |        |       |       |           |
|  Indexer |           .NET 5.0 | the q(...)56789 [64] | the q(...)56789 [64] | 1,450.172 ns |      - |     - |     - |         - |
|  Indexer |           .NET 6.0 | the q(...)56789 [64] | the q(...)56789 [64] | 1,306.959 ns |      - |     - |     - |         - |
|  Indexer |      .NET Core 3.1 | the q(...)56789 [64] | the q(...)56789 [64] | 1,472.230 ns |      - |     - |     - |         - |
|  Indexer | .NET Framework 4.8 | the q(...)56789 [64] | the q(...)56789 [64] | 2,559.594 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|     Span |           .NET 5.0 | the q(...)56789 [64] | the q(...)56789 [64] | 1,423.876 ns |      - |     - |     - |         - |
|     Span |           .NET 6.0 | the q(...)56789 [64] | the q(...)56789 [64] | 1,362.844 ns |      - |     - |     - |         - |
|     Span |      .NET Core 3.1 | the q(...)56789 [64] | the q(...)56789 [64] | 1,443.200 ns |      - |     - |     - |         - |
|     Span | .NET Framework 4.8 | the q(...)56789 [64] | the q(...)56789 [64] | 2,774.929 ns |      - |     - |     - |         - |
|          |                    |                      |                      |              |        |       |       |           |
|  Pointer |           .NET 5.0 | the q(...)56789 [64] | the q(...)56789 [64] | 1,379.297 ns |      - |     - |     - |         - |
|  Pointer |           .NET 6.0 | the q(...)56789 [64] | the q(...)56789 [64] | 1,362.902 ns |      - |     - |     - |         - |
|  Pointer |      .NET Core 3.1 | the q(...)56789 [64] | the q(...)56789 [64] | 1,514.380 ns |      - |     - |     - |         - |
|  Pointer | .NET Framework 4.8 | the q(...)56789 [64] | the q(...)56789 [64] | 2,571.639 ns |      - |     - |     - |         - |
