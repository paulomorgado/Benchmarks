using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace StringTests
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(null, "", "text")]
        public string? Text;

        [Benchmark]
        public bool StringIsNullOrEmpty() => string.IsNullOrEmpty(this.Text);

        [Benchmark]
        public bool PatternMatching() => this.Text is not { Length: >0 };

        [Benchmark]
        public bool AggressiveInliningPatternMatching() => StringExtensions.AggressiveInliningPatternMatching(this.Text);

        [Benchmark]
        public bool NoInliningPatternMatching() => StringExtensions.NoInliningPatternMatching(this.Text);
    }

    public static class StringExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AggressiveInliningPatternMatching(string? text) => text is not { Length: > 0 };

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool NoInliningPatternMatching(string? text) => text is not { Length: > 0 };
    }
}
