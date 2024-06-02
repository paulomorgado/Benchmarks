```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3672/23H2/2023Update/SunValley3)
13th Gen Intel Core i9-13900K, 1 CPU, 32 logical and 24 physical cores
.NET SDK 9.0.100-preview.4.24267.66
  [Host]     : .NET 9.0.0 (9.0.24.26619), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.26619), X64 RyuJIT AVX2


```
| Method               | scheme | host             | basePath   | path                | query                | Mean     | Ratio | Gen0   | Allocated | Alloc Ratio |
|--------------------- |------- |----------------- |----------- |-------------------- |--------------------- |---------:|------:|-------:|----------:|------------:|
| **StringBuilder**        | **http**   | **cname.domain.tld** |            | **/**                   |                      | **75.01 ns** |  **1.00** | **0.0288** |     **544 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld |            | /                   |                      | 24.16 ns |  0.32 | 0.0038 |      72 B |        0.13 |
| String_Concat        | http   | cname.domain.tld |            | /                   |                      | 22.50 ns |  0.30 | 0.0038 |      72 B |        0.13 |
| String_Concat2       | http   | cname.domain.tld |            | /                   |                      | 22.13 ns |  0.30 | 0.0072 |     136 B |        0.25 |
| String_Create        | http   | cname.domain.tld |            | /                   |                      | 10.13 ns |  0.14 | 0.0038 |      72 B |        0.13 |
| String_Create2       | http   | cname.domain.tld |            | /                   |                      | 12.72 ns |  0.17 | 0.0038 |      72 B |        0.13 |
|                      |        |                  |            |                     |                      |          |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** |            | **/**                   | **?para(...)alue3 [42]** | **98.17 ns** |  **1.00** | **0.0446** |     **840 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld |            | /                   | ?para(...)alue3 [42] | 29.38 ns |  0.30 | 0.0085 |     160 B |        0.19 |
| String_Concat        | http   | cname.domain.tld |            | /                   | ?para(...)alue3 [42] | 27.57 ns |  0.28 | 0.0085 |     160 B |        0.19 |
| String_Concat2       | http   | cname.domain.tld |            | /                   | ?para(...)alue3 [42] | 25.14 ns |  0.26 | 0.0119 |     224 B |        0.27 |
| String_Create        | http   | cname.domain.tld |            | /                   | ?para(...)alue3 [42] | 16.74 ns |  0.17 | 0.0085 |     160 B |        0.19 |
| String_Create2       | http   | cname.domain.tld |            | /                   | ?para(...)alue3 [42] | 14.38 ns |  0.15 | 0.0085 |     160 B |        0.19 |
|                      |        |                  |            |                     |                      |          |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** |            | **/path/one/two/three** |                      | **80.38 ns** |  **1.00** | **0.0314** |     **592 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld |            | /path/one/two/three |                      | 26.52 ns |  0.33 | 0.0059 |     112 B |        0.19 |
| String_Concat        | http   | cname.domain.tld |            | /path/one/two/three |                      | 45.80 ns |  0.57 | 0.0059 |     112 B |        0.19 |
| String_Concat2       | http   | cname.domain.tld |            | /path/one/two/three |                      | 21.12 ns |  0.26 | 0.0093 |     176 B |        0.30 |
| String_Create        | http   | cname.domain.tld |            | /path/one/two/three |                      | 12.34 ns |  0.15 | 0.0059 |     112 B |        0.19 |
| String_Create2       | http   | cname.domain.tld |            | /path/one/two/three |                      | 11.40 ns |  0.14 | 0.0059 |     112 B |        0.19 |
|                      |        |                  |            |                     |                      |          |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** |            | **/path/one/two/three** | **?para(...)alue3 [42]** | **96.56 ns** |  **1.00** | **0.0467** |     **880 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld |            | /path/one/two/three | ?para(...)alue3 [42] | 29.63 ns |  0.31 | 0.0102 |     192 B |        0.22 |
| String_Concat        | http   | cname.domain.tld |            | /path/one/two/three | ?para(...)alue3 [42] | 49.75 ns |  0.52 | 0.0102 |     192 B |        0.22 |
| String_Concat2       | http   | cname.domain.tld |            | /path/one/two/three | ?para(...)alue3 [42] | 25.14 ns |  0.26 | 0.0136 |     256 B |        0.29 |
| String_Create        | http   | cname.domain.tld |            | /path/one/two/three | ?para(...)alue3 [42] | 16.61 ns |  0.17 | 0.0102 |     192 B |        0.22 |
| String_Create2       | http   | cname.domain.tld |            | /path/one/two/three | ?para(...)alue3 [42] | 15.46 ns |  0.16 | 0.0102 |     192 B |        0.22 |
|                      |        |                  |            |                     |                      |          |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** | **/base-path** | **/**                   |                      | **80.59 ns** |  **1.00** | **0.0305** |     **576 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld | /base-path | /                   |                      | 26.30 ns |  0.33 | 0.0051 |      96 B |        0.17 |
| String_Concat        | http   | cname.domain.tld | /base-path | /                   |                      | 23.96 ns |  0.30 | 0.0051 |      96 B |        0.17 |
| String_Concat2       | http   | cname.domain.tld | /base-path | /                   |                      | 20.62 ns |  0.26 | 0.0085 |     160 B |        0.28 |
| String_Create        | http   | cname.domain.tld | /base-path | /                   |                      | 13.31 ns |  0.17 | 0.0051 |      96 B |        0.17 |
| String_Create2       | http   | cname.domain.tld | /base-path | /                   |                      | 11.28 ns |  0.14 | 0.0051 |      96 B |        0.17 |
|                      |        |                  |            |                     |                      |          |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** | **/base-path** | **/**                   | **?para(...)alue3 [42]** | **95.52 ns** |  **1.00** | **0.0459** |     **864 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld | /base-path | /                   | ?para(...)alue3 [42] | 29.99 ns |  0.31 | 0.0093 |     176 B |        0.20 |
| String_Concat        | http   | cname.domain.tld | /base-path | /                   | ?para(...)alue3 [42] | 27.16 ns |  0.28 | 0.0093 |     176 B |        0.20 |
| String_Concat2       | http   | cname.domain.tld | /base-path | /                   | ?para(...)alue3 [42] | 28.02 ns |  0.29 | 0.0093 |     176 B |        0.20 |
| String_Create        | http   | cname.domain.tld | /base-path | /                   | ?para(...)alue3 [42] | 17.88 ns |  0.19 | 0.0093 |     176 B |        0.20 |
| String_Create2       | http   | cname.domain.tld | /base-path | /                   | ?para(...)alue3 [42] | 14.86 ns |  0.16 | 0.0093 |     176 B |        0.20 |
|                      |        |                  |            |                     |                      |          |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** | **/base-path** | **/path/one/two/three** |                      | **80.55 ns** |  **1.00** | **0.0327** |     **616 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld | /base-path | /path/one/two/three |                      | 27.13 ns |  0.34 | 0.0068 |     128 B |        0.21 |
| String_Concat        | http   | cname.domain.tld | /base-path | /path/one/two/three |                      | 45.87 ns |  0.57 | 0.0068 |     128 B |        0.21 |
| String_Concat2       | http   | cname.domain.tld | /base-path | /path/one/two/three |                      | 21.29 ns |  0.26 | 0.0102 |     192 B |        0.31 |
| String_Create        | http   | cname.domain.tld | /base-path | /path/one/two/three |                      | 14.12 ns |  0.18 | 0.0068 |     128 B |        0.21 |
| String_Create2       | http   | cname.domain.tld | /base-path | /path/one/two/three |                      | 12.51 ns |  0.16 | 0.0068 |     128 B |        0.21 |
|                      |        |                  |            |                     |                      |          |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** | **/base-path** | **/path/one/two/three** | **?para(...)alue3 [42]** | **96.22 ns** |  **1.00** | **0.0479** |     **904 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld | /base-path | /path/one/two/three | ?para(...)alue3 [42] | 31.51 ns |  0.33 | 0.0114 |     216 B |        0.24 |
| String_Concat        | http   | cname.domain.tld | /base-path | /path/one/two/three | ?para(...)alue3 [42] | 50.87 ns |  0.53 | 0.0114 |     216 B |        0.24 |
| String_Concat2       | http   | cname.domain.tld | /base-path | /path/one/two/three | ?para(...)alue3 [42] | 54.39 ns |  0.57 | 0.0114 |     216 B |        0.24 |
| String_Create        | http   | cname.domain.tld | /base-path | /path/one/two/three | ?para(...)alue3 [42] | 19.09 ns |  0.20 | 0.0115 |     216 B |        0.24 |
| String_Create2       | http   | cname.domain.tld | /base-path | /path/one/two/three | ?para(...)alue3 [42] | 16.46 ns |  0.17 | 0.0115 |     216 B |        0.24 |


## StringBuilder

This benchmark uses the same implementation as `UriHelper.GetDisplayUrl`.

## String_Interpolation

This benchmark uses string interpolation to build the URL.

## String_Concat

This benchmark uses the new in **.NET 9.0** `String.Concat(ReadOnlySpan<string?> values)` to build the URL.

## String_Concat

This benchmark chooses `String.Concat(string? str0, string? str1, string? str2, string? str3)` over the new in **.NET 9.0** `String.Concat(ReadOnlySpan<string?> values)` to build the URL, whenever possible.

## String_Create

This benchmark uses `String.Create` and spans to build the URL.

## String_Create

This benchmark uses `String.Create` with a custom string to pass the URL parts spans to build the URL.

