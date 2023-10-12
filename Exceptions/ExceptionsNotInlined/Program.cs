using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace ExceptionsNotInlined
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = DefaultConfig.Instance
                .AddJob(Job.Default.WithRuntime(CoreRuntime.Core80))
                .AddJob(Job.Default.WithRuntime(CoreRuntime.Core70))
                .AddJob(Job.Default.WithRuntime(CoreRuntime.Core60))
                //.AddJob(Job.Default.WithRuntime(ClrRuntime.Net481))
                ;
            BenchmarkSwitcher.FromAssembly(typeof(Benchmarks).Assembly).RunAll(config);
        }
    }

    [HideColumns("Error", "StdDev", "Median", "RatioSD")]
    [DisassemblyDiagnoser(maxDepth: 0)]
    public class Benchmarks
    {
        [Params(false/*, true*/)]
        public bool Condition { get; set; }

        [Benchmark(Baseline = true)]
        public void WithThrowInMethod()
        {
            MethodWithThrowInMethod(this.Condition);
            MethodWithThrowInMethod(this.Condition);
            MethodWithThrowInMethod(this.Condition);
            MethodWithThrowInMethod(this.Condition);
            MethodWithThrowInMethod(this.Condition);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void MethodWithThrowInMethod(bool condition, [CallerArgumentExpression(nameof(condition))] string? paramName = default)
        {
            if (condition)
            {
                throw new Exception($"The condition {paramName} is not met.");
            }
        }

        [Benchmark()]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WithThrowInExternalMethod()
        {
            MethodWithThrowInExternalMethod(this.Condition);
            MethodWithThrowInExternalMethod(this.Condition);
            MethodWithThrowInExternalMethod(this.Condition);
            MethodWithThrowInExternalMethod(this.Condition);
            MethodWithThrowInExternalMethod(this.Condition);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void MethodWithThrowInExternalMethod(bool condition, [CallerArgumentExpression(nameof(condition))] string? paramName = default)
        {
            if (condition)
            {
                Throw($"The condition {paramName} is not met.");

                [MethodImpl(MethodImplOptions.NoInlining)]
                static void Throw(string message) => throw new Exception(message);
            }
        }
    }
}
