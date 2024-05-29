```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3593/23H2/2023Update/SunValley3)
13th Gen Intel Core i9-13900K, 1 CPU, 32 logical and 24 physical cores
.NET SDK 9.0.100-preview.4.24267.66
  [Host]     : .NET 9.0.0 (9.0.24.26619), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.26619), X64 RyuJIT AVX2


```
| Method               | scheme | host             | basePath   | path                | query                | Mean      | Ratio | Gen0   | Allocated | Alloc Ratio |
|--------------------- |------- |----------------- |----------- |-------------------- |--------------------- |----------:|------:|-------:|----------:|------------:|
| **StringBuilder**        | **http**   | **cname.domain.tld** | ****           | **/**                   | ****                     | **67.161 ns** |  **1.00** | **0.0288** |     **544 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld |            | /                   |                      | 24.606 ns |  0.37 | 0.0038 |      72 B |        0.13 |
| String_Concat        | http   | cname.domain.tld |            | /                   |                      | 23.160 ns |  0.34 | 0.0038 |      72 B |        0.13 |
| String_Create        | http   | cname.domain.tld |            | /                   |                      |  9.903 ns |  0.15 | 0.0038 |      72 B |        0.13 |
|                      |        |                  |            |                     |                      |           |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** | ****           | **/**                   | **?para(...)alue3 [42]** | **92.873 ns** |  **1.00** | **0.0446** |     **840 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld |            | /                   | ?para(...)alue3 [42] | 26.817 ns |  0.29 | 0.0085 |     160 B |        0.19 |
| String_Concat        | http   | cname.domain.tld |            | /                   | ?para(...)alue3 [42] | 25.303 ns |  0.27 | 0.0085 |     160 B |        0.19 |
| String_Create        | http   | cname.domain.tld |            | /                   | ?para(...)alue3 [42] | 11.978 ns |  0.13 | 0.0085 |     160 B |        0.19 |
|                      |        |                  |            |                     |                      |           |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** | ****           | **/path/one/two/three** | ****                     | **74.314 ns** |  **1.00** | **0.0314** |     **592 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld |            | /path/one/two/three |                      | 23.582 ns |  0.32 | 0.0059 |     112 B |        0.19 |
| String_Concat        | http   | cname.domain.tld |            | /path/one/two/three |                      | 35.836 ns |  0.48 | 0.0059 |     112 B |        0.19 |
| String_Create        | http   | cname.domain.tld |            | /path/one/two/three |                      |  9.352 ns |  0.13 | 0.0059 |     112 B |        0.19 |
|                      |        |                  |            |                     |                      |           |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** | ****           | **/path/one/two/three** | **?para(...)alue3 [42]** | **93.593 ns** |  **1.00** | **0.0467** |     **880 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld |            | /path/one/two/three | ?para(...)alue3 [42] | 28.930 ns |  0.31 | 0.0102 |     192 B |        0.22 |
| String_Concat        | http   | cname.domain.tld |            | /path/one/two/three | ?para(...)alue3 [42] | 41.730 ns |  0.45 | 0.0102 |     192 B |        0.22 |
| String_Create        | http   | cname.domain.tld |            | /path/one/two/three | ?para(...)alue3 [42] | 13.065 ns |  0.14 | 0.0102 |     192 B |        0.22 |
|                      |        |                  |            |                     |                      |           |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** | **/base-path** | **/**                   | ****                     | **71.984 ns** |  **1.00** | **0.0305** |     **576 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld | /base-path | /                   |                      | 23.342 ns |  0.32 | 0.0051 |      96 B |        0.17 |
| String_Concat        | http   | cname.domain.tld | /base-path | /                   |                      | 20.272 ns |  0.28 | 0.0051 |      96 B |        0.17 |
| String_Create        | http   | cname.domain.tld | /base-path | /                   |                      | 10.282 ns |  0.14 | 0.0051 |      96 B |        0.17 |
|                      |        |                  |            |                     |                      |           |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** | **/base-path** | **/**                   | **?para(...)alue3 [42]** | **93.702 ns** |  **1.00** | **0.0459** |     **864 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld | /base-path | /                   | ?para(...)alue3 [42] | 28.924 ns |  0.31 | 0.0093 |     176 B |        0.20 |
| String_Concat        | http   | cname.domain.tld | /base-path | /                   | ?para(...)alue3 [42] | 25.931 ns |  0.28 | 0.0093 |     176 B |        0.20 |
| String_Create        | http   | cname.domain.tld | /base-path | /                   | ?para(...)alue3 [42] | 13.951 ns |  0.15 | 0.0093 |     176 B |        0.20 |
|                      |        |                  |            |                     |                      |           |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** | **/base-path** | **/path/one/two/three** | ****                     | **75.755 ns** |  **1.00** | **0.0327** |     **616 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld | /base-path | /path/one/two/three |                      | 24.781 ns |  0.33 | 0.0068 |     128 B |        0.21 |
| String_Concat        | http   | cname.domain.tld | /base-path | /path/one/two/three |                      | 36.724 ns |  0.48 | 0.0068 |     128 B |        0.21 |
| String_Create        | http   | cname.domain.tld | /base-path | /path/one/two/three |                      | 11.092 ns |  0.15 | 0.0068 |     128 B |        0.21 |
|                      |        |                  |            |                     |                      |           |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** | **/base-path** | **/path/one/two/three** | **?para(...)alue3 [42]** | **89.961 ns** |  **1.00** | **0.0479** |     **904 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld | /base-path | /path/one/two/three | ?para(...)alue3 [42] | 31.002 ns |  0.34 | 0.0114 |     216 B |        0.24 |
| String_Concat        | http   | cname.domain.tld | /base-path | /path/one/two/three | ?para(...)alue3 [42] | 41.576 ns |  0.46 | 0.0114 |     216 B |        0.24 |
| String_Create        | http   | cname.domain.tld | /base-path | /path/one/two/three | ?para(...)alue3 [42] | 14.374 ns |  0.16 | 0.0115 |     216 B |        0.24 |


## StringBuilder

This benchmark uses the same implementation as `UriHelper.GetDisplayUrl`.

## String_Interpolation

This benchmark uses string interpolation to build the URL.

## String_Concat

This benchmark uses the new in **.NET 9.0** `String.Concat(ReadOnlySpan<string?> values)` to build the URL.

## String_Create

This benchmark uses `String.Create` and spans to build the URL.

