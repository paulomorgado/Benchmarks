using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ComparerComparison
{
    class Program
    {
        static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        public IEnumerable<int[]> Data()
        {
            yield return Array.Empty<int>();
            yield return new int[] { 1 };
            yield return Enumerable.Range(1, 100).Reverse().ToArray();
            yield return Enumerable.Range(1, 1000).Reverse().ToArray();
            yield return Enumerable.Range(1, 10000).Reverse().ToArray();
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public void ArraySortWithIComparer(int[] data) => Sort(data, Comparer<int>.Default);

        [Benchmark()]
        [ArgumentsSource(nameof(Data))]
        public void ArraySortWithComparison(int[] data) => Sort(data, Comparer<int>.Default.Compare);

        private static void Sort<T>(T[] data, IComparer<T> comparer)
        {
            for (var i = data.Length - 1; i > 0; i--)
            {
                for (var j = i - 1; j >= 0; j--)
                {
                    if (comparer.Compare(data[i], data[j]) < 0)
                    {
                        Switch(data, i, j);
                    }
                }
            }
        }

        private static void Sort<T>(T[] data, Comparison<T> comparison)
        {
            for (var i = data.Length - 1; i > 0; i--)
            {
                for (var j = i - 1; j >= 0; j--)
                {
                    if (comparison(data[i], data[j]) < 0)
                    {
                        Switch(data, i, j);
                    }
                }
            }
        }

        private static void Switch<T>(T[] data, int i, int j)
        {
            var t = data[i];
            data[i] = data[j];
            data[j] = t;
        }
    }
}
