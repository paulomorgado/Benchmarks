# Performance test for [Duende.AccessTokenManagement](https://github.com/DuendeSoftware/Duende.AccessTokenManagement)

## [AddClientCredentialsTokenHandlerBenchmarks](AddClientCredentialsTokenHandlerBenchmarks.cs)

### ClientCredentialsTokenHandlerWithTransientTokenServices

Creates a `ClientCredentialsTokenHandler` using registered transient dependencies.

### ClientCredentialsTokenHandlerWithSingletonTokenServices

Creates a `ClientCredentialsTokenHandler` using registered singleton dependencies.

### Benchmark Results

```

BenchmarkDotNet v0.13.10, Windows 11 (10.0.22631.2715/23H2/2023Update/SunValley3)
13th Gen Intel Core i9-13900K, 1 CPU, 32 logical and 24 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  Job-RAZUBW : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  Job-DWXEKL : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2

```
| Method                                                  | Runtime  | Mean      | Ratio | Gen0   | Allocated | Alloc Ratio |
|-------------------------------------------------------- |--------- |----------:|------:|-------:|----------:|------------:|
| ClientCredentialsTokenHandlerWithTransientTokenServices | .NET 6.0 | 117.03 ns |  1.37 | 0.0229 |     432 B |        1.00 |
| ClientCredentialsTokenHandlerWithSingletonTokenServices | .NET 6.0 |  71.99 ns |  0.84 | 0.0038 |      72 B |        0.17 |
| ClientCredentialsTokenHandlerWithTransientTokenServices | .NET 8.0 |  85.62 ns |  1.00 | 0.0229 |     432 B |        1.00 |
| ClientCredentialsTokenHandlerWithSingletonTokenServices | .NET 8.0 |  48.94 ns |  0.57 | 0.0038 |      72 B |        0.17 |

## [IsDPoPErrorBenchmarks](IsDPoPErrorBenchmarks.cs)

### UsingLinqAndStringOperations

Parses the **DPoP** header using **LINQ** and `string` operations.

### UsingIterationAndSpanOperations

Parses the **DPoP** header using iterations and `Span<char>` operations.

### Benchmark Results

```

BenchmarkDotNet v0.13.10, Windows 11 (10.0.22631.2715/23H2/2023Update/SunValley3)
13th Gen Intel Core i9-13900K, 1 CPU, 32 logical and 24 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  Job-UNPWZE : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  Job-WDOIWV : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2

```
| Method                          | Runtime  | Mean       | Ratio | Gen0   | Allocated | Alloc Ratio |
|-------------------------------- |--------- |-----------:|------:|-------:|----------:|------------:|
| UsingLinqAndStringOperations    | .NET 6.0 | 69.5984 ns | 1.338 | 0.0088 |     168 B |        1.00 |
| UsingIterationAndSpanOperations | .NET 6.0 |  0.3063 ns | 0.006 |      - |         - |        0.00 |
| UsingLinqAndStringOperations    | .NET 8.0 | 52.0763 ns | 1.000 | 0.0089 |     168 B |        1.00 |
| UsingIterationAndSpanOperations | .NET 8.0 |  0.2891 ns | 0.006 |      - |         - |        0.00 |
