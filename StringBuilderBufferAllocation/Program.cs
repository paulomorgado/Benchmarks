using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace StringBuilderBufferAllocation
{
    class Program
    {
        static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(0, 1, 1024, 2048, 4096, 8192, 16384)]
        public int Count;

        [Benchmark]
        public void StringBuilderConstructor() => new StringBuilder(this.Count);
    }
}
