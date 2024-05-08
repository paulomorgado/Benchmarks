```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3527/23H2/2023Update/SunValley3)
13th Gen Intel Core i9-13900K, 1 CPU, 32 logical and 24 physical cores
.NET SDK 8.0.300-preview.24203.14
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2


```
| Method               | scheme | host             | basePath   | path                | query                | Mean       | Ratio | Gen0   | Allocated | Alloc Ratio |
|--------------------- |------- |----------------- |----------- |-------------------- |--------------------- |-----------:|------:|-------:|----------:|------------:|
| **StringBuilder**        | **http**   | **cname.domain.tld** |            | **/**                   |                      |  **69.988 ns** |  **1.00** | **0.0288** |     **544 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld |            | /                   |                      |  26.739 ns |  0.38 | 0.0038 |      72 B |        0.13 |
| String_Create        | http   | cname.domain.tld |            | /                   |                      |   8.194 ns |  0.12 | 0.0038 |      72 B |        0.13 |
|                      |        |                  |            |                     |                      |            |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** |            | **/**                   | **?para(...)alue3 [42]** |  **98.486 ns** |  **1.00** | **0.0446** |     **840 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld |            | /                   | ?para(...)alue3 [42] |  31.592 ns |  0.32 | 0.0085 |     160 B |        0.19 |
| String_Create        | http   | cname.domain.tld |            | /                   | ?para(...)alue3 [42] |  15.580 ns |  0.16 | 0.0085 |     160 B |        0.19 |
|                      |        |                  |            |                     |                      |            |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** |            | **/path/one/two/three** |                      |  **80.926 ns** |  **1.00** | **0.0314** |     **592 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld |            | /path/one/two/three |                      |  27.104 ns |  0.34 | 0.0059 |     112 B |        0.19 |
| String_Create        | http   | cname.domain.tld |            | /path/one/two/three |                      |  10.069 ns |  0.12 | 0.0059 |     112 B |        0.19 |
|                      |        |                  |            |                     |                      |            |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** |            | **/path/one/two/three** | **?para(...)alue3 [42]** | **100.374 ns** |  **1.00** | **0.0467** |     **880 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld |            | /path/one/two/three | ?para(...)alue3 [42] |  32.507 ns |  0.32 | 0.0102 |     192 B |        0.22 |
| String_Create        | http   | cname.domain.tld |            | /path/one/two/three | ?para(...)alue3 [42] |  15.831 ns |  0.16 | 0.0102 |     192 B |        0.22 |
|                      |        |                  |            |                     |                      |            |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** | **/base-path** | **/**                   |                      |  **71.221 ns** |  **1.00** | **0.0305** |     **576 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld | /base-path | /                   |                      |  25.770 ns |  0.36 | 0.0051 |      96 B |        0.17 |
| String_Create        | http   | cname.domain.tld | /base-path | /                   |                      |  11.728 ns |  0.16 | 0.0051 |      96 B |        0.17 |
|                      |        |                  |            |                     |                      |            |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** | **/base-path** | **/**                   | **?para(...)alue3 [42]** | **101.443 ns** |  **1.00** | **0.0459** |     **864 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld | /base-path | /                   | ?para(...)alue3 [42] |  31.538 ns |  0.31 | 0.0093 |     176 B |        0.20 |
| String_Create        | http   | cname.domain.tld | /base-path | /                   | ?para(...)alue3 [42] |  17.074 ns |  0.17 | 0.0093 |     176 B |        0.20 |
|                      |        |                  |            |                     |                      |            |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** | **/base-path** | **/path/one/two/three** |                      |  **76.368 ns** |  **1.00** | **0.0327** |     **616 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld | /base-path | /path/one/two/three |                      |  27.561 ns |  0.36 | 0.0068 |     128 B |        0.21 |
| String_Create        | http   | cname.domain.tld | /base-path | /path/one/two/three |                      |  11.338 ns |  0.15 | 0.0068 |     128 B |        0.21 |
|                      |        |                  |            |                     |                      |            |       |        |           |             |
| **StringBuilder**        | **http**   | **cname.domain.tld** | **/base-path** | **/path/one/two/three** | **?para(...)alue3 [42]** |  **97.275 ns** |  **1.00** | **0.0479** |     **904 B** |        **1.00** |
| String_Interpolation | http   | cname.domain.tld | /base-path | /path/one/two/three | ?para(...)alue3 [42] |  34.144 ns |  0.35 | 0.0114 |     216 B |        0.24 |
| String_Create        | http   | cname.domain.tld | /base-path | /path/one/two/three | ?para(...)alue3 [42] |  17.378 ns |  0.18 | 0.0115 |     216 B |        0.24 |


## StringBuilder

This benchmark uses the same implementation as `UriHelper.GetDisplayUrl`.

## String_Interpolation

This benchmark uses string interpolation to build the URL.

## String_Create

This benchmark uses `String.Create` and spans to build the URL.

