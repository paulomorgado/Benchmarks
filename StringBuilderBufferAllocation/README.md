# StringBuilder buffer allocation

.NET 5.0 intorduced the [`GC.AllocateUninitializedArray<T>(Int32, Boolean)` Method](https://docs.microsoft.com/en-us/dotnet/api/system.gc.allocateuninitializedarray?view=net-5.0).

However, it's not optimized for small arrays (up to 2048 items).

[Benchmarks](Benchmark.md)
