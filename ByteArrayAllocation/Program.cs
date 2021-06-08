using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ByteArrayAllocation
{
    class Program
    {
        static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        public IEnumerable<int> Data()
        {
            yield return 1;
            yield return 1024;
            yield return 32 * 1024;
            yield return 64 * 1024;
            yield return 128 * 1024;
            yield return 1024 * 1024;
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public byte[] ArrayAllocation(int size) => new byte[size];

        [Benchmark()]
        [ArgumentsSource(nameof(Data))]
        public byte[] GC_AllocateUninitializedArray(int size) => GC.AllocateUninitializedArray<byte>(size);

        [Benchmark()]
        [ArgumentsSource(nameof(Data))]
        public byte[] GC_AllocateArray(int size) => GC.AllocateArray<byte>(size);
    }
}
