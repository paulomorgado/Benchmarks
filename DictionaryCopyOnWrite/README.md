# DictionaryCopyOnWrite

This benchmark tests the performance differences between using a `Dictionary<TKey, TValue>` or an `ImmutableDictionary<TKey, TValue>`.

The [benchmarks](DictionaryCopyOnWrite.Insert-report-github.md) for adding new items show that `ImmutableDictionary<TKey, TValue>` performs better, in general. Although, for small sizes, `Dictionary<TKey, TValue>` can perform better.

On the other hand, the [benchmarks](DictionaryCopyOnWrite.Lookup-report-github.md) for lookups show that `Dictionary<TKey, TValue>` performs better.
