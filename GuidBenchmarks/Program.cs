// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Logging;

namespace GuidBenchmarks
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    [MemoryDiagnoser]
    public class GuidConstructorBenchmark
    {
        private const string guidAsText = "924712e2-d9a3-426f-b4dd-01c86374d196";
        private static readonly Guid constGuid = new Guid(guidAsText);
        private static readonly byte[] guidBytes = new byte[] { 0xE2, 0x12, 0x47, 0x92, 0xA3, 0xD9, 0x6F, 0x42, 0xB4, 0xDD, 0x01, 0xC8, 0x63, 0x74, 0xD1, 0x96 };

        [Benchmark(Baseline = true)]
        public Guid FromText() => new Guid(guidAsText);

        [Benchmark]
        public Guid FromNumbers() => new Guid(0x924712e2U, 0xd9a3, 0x426f, 0xb4, 0xdd, 0x01, 0xc8, 0x63, 0x74, 0xd1, 0x96);

        [Benchmark]
        public Guid FromNewByteArray() => new Guid(new byte[] { 0xE2, 0x12, 0x47, 0x92, 0xA3, 0xD9, 0x6F, 0x42, 0xB4, 0xDD, 0x01, 0xC8, 0x63, 0x74, 0xD1, 0x96 });

        [Benchmark]
        public Guid FromCachedByteArray() => new Guid(guidBytes);

        [Benchmark]
        public Guid FromConst() => constGuid;
    }
}
