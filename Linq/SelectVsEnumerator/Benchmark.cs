using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace PauloMorgado.Benchmarks.Linq.SelectVsEnumerator
{
    [MemoryDiagnoser]
    [LongRunJob]
    public class Benchamrk
    {
        [Params(0, 10, 100, 1000)]
        public int Sleep { get; set; }

        [Params(10, 100, 1000)]
        public int Items { get; set; }

        private readonly Consumer consumer = new Consumer();

        [Benchmark(Baseline = true)]
        public void Linq() =>
            Enumerable.Range(0, this.Items)
                .Select(i =>
                {
                    if (this.Sleep > 0)
                    {
                        Thread.Sleep(this.Sleep);
                    }

                    return i;
                })
                .Consume(this.consumer);

        [Benchmark]
        public void NoLinq()
        {
            NoLinqImpl(Enumerable.Range(0, this.Items))
                .Consume(this.consumer);

            IEnumerable<int> NoLinqImpl(IEnumerable<int> source)
            {
                foreach (var i in source)
                {
                    if (this.Sleep > 0)
                    {
                        Thread.Sleep(this.Sleep);
                    }

                    yield return i;
                }
            }
        }
    }
}
