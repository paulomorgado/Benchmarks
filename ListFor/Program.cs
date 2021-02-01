using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ListFor
{
    class Program
    {
        static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

    }

    public class Benchmark
    {
        public IEnumerable<IEnumerable<Action>> Enumerables()
        {
            yield return Enumerable.Range(0, 1).Select(_ => new Action(() => { }));
            yield return Enumerable.Range(0, 10).Select(_ => new Action(() => { }));
            yield return Enumerable.Range(0, 100).Select(_ => new Action(() => { }));
        }

        public IEnumerable<object> Lists() => this.Enumerables().Select(e => new ListWrapper<Action>(e.ToList()));

        public IEnumerable<object> Arrays() => this.Enumerables().Select(e => new ArrayWrapper<Action>(e.ToArray()));

        [Benchmark]
        [ArgumentsSource(nameof(Arrays))]
        public void ArrayForPreDecrement(ArrayWrapper<Action> arrayWrapper)
        {
            var actions = arrayWrapper.Array;
            for (var i = actions.Length; i-- > 0;)
            {
                //actions[i]();
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(Arrays))]
        public void ArrayForPostDecrement(ArrayWrapper<Action> arrayWrapper)
        {
            var actions = arrayWrapper.Array;
            for (var i = actions.Length - 1; i > 0; i--)
            {
                //actions[i]();
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(Lists))]
        public void ListForPreDecrement(ListWrapper<Action> listwrapper)
        {
            var actions = listwrapper.List;
            for (var i = actions.Count; i-- > 0;)
            {
                //actions[i]();
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(Lists))]
        public void ListForPostDecrement(ListWrapper<Action> listwrapper)
        {
            var actions = listwrapper.List;
            for (var i = actions.Count - 1; i > 0; i--)
            {
                //actions[i]();
            }
        }

        public sealed class ArrayWrapper<T>
        {
            public readonly T[] Array;
            public ArrayWrapper(T[] array) => this.Array = array;
            public override string ToString() => $"Array[{this.Array.Length}]";
        }

        public sealed class ListWrapper<T>
        {
            public readonly List<T> List;
            public ListWrapper(List<T> list) => this.List = list;
            public override string ToString() => $"List[{this.List.Count}]";
        }
    }
}
