using BenchmarkDotNet.Running;
using LoggerMessageBenchmarks;

BenchmarkSwitcher.FromAssembly(typeof(Benchmark).Assembly).Run(args);
