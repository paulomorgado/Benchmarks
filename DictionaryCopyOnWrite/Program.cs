using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace DictionaryCopyOnWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    [MemoryDiagnoser]
    public class Insert
    {
        public IEnumerable<TestSource> Data() => TestSource.GetTestData();

        private static readonly ImmutableDictionary<string, string> emptyImmutableDictionary = 
            ImmutableDictionary.Create<string, string>(StringComparer.Ordinal);


        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public IDictionary<string, string> ImmutableDictionaryAdd(TestSource test)
        {
            var dictionary = ImmutableDictionary<string, string>.Empty;

            foreach (var s in test.Data)
            {
                dictionary = dictionary.Add(s, s);
            }

            return dictionary;
        }

        private static readonly Dictionary<string, string> emptyDictionary = 
            new(StringComparer.Ordinal);

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public IDictionary<string, string> DictionaryAdd(TestSource test)
        {
            var dictionary = emptyDictionary;

            foreach (var s in test.Data)
            {
                var newDictionary =
                    new Dictionary<string, string>(dictionary.Count + 1, dictionary.Comparer);

                foreach (var kvp in dictionary)
                {
                    newDictionary.Add(kvp.Key, kvp.Value);
                }

                newDictionary.Add(s, s);

                dictionary = newDictionary;
            }

            return dictionary;
        }
    }

    [MemoryDiagnoser]
    public class Lookup
    {
        private static readonly string lookup = Guid.Empty.ToString("N");


        [Params(10, 100, 1000)]
        public int Count { get; set; }

        public IEnumerable<TestImmutableDictionary> ImmutableDictionaryData() => TestImmutableDictionary.GetTestData();

        [Benchmark]
        [ArgumentsSource(nameof(ImmutableDictionaryData))]
        public bool ImmutableDictionaryLookup(TestImmutableDictionary test)
        {
            var result = false;

            for (var i = 0; i < this.Count; i++)
            {
                result |= test.Dictionary.ContainsKey(lookup);
            }

            return result;
        }

        public IEnumerable<TestDictionary> DictionaryData() => TestDictionary.GetTestData();

        [Benchmark]
        [ArgumentsSource(nameof(DictionaryData))]
        public bool DictionaryLookup(TestDictionary test)
        {
            var result = false;

            for (var i = 0; i < this.Count; i++)
            {
                result |= test.Dictionary.ContainsKey(lookup);
            }

            return result;
        }
    }

    public class TestSource
    {
        public static IEnumerable<TestSource> GetTestData()
        {
            yield return new TestSource(4);
            yield return new TestSource(8);
            yield return new TestSource(16);
            yield return new TestSource(32);
        }

        public TestSource(int count)
        {
            this.Data = new string[count];

            for (var i = 0; i < this.Data.Length; i++)
            {
                this.Data[i] = Guid.NewGuid().ToString("N");
            }
        }

        public string[] Data { get; }

        public override string ToString() => this.Data.Length.ToString();
    }

    public class TestDictionary
    {
        public static IEnumerable<TestDictionary> GetTestData()
            => TestSource.GetTestData().Select(data => new TestDictionary(data));

        public TestDictionary(TestSource data)
        {
            this.Dictionary = new Dictionary<string, string>(
                data.Data.Length, 
                StringComparer.Ordinal);

            foreach(var s in data.Data)
            {
                this.Dictionary.Add(s, s);
            }
        }

        public Dictionary<string, string> Dictionary { get; }

        public override string ToString() => this.Dictionary.Count.ToString();
    }

    public class TestImmutableDictionary
    {
        public static IEnumerable<TestImmutableDictionary> GetTestData()
            => TestSource.GetTestData().Select(data => new TestImmutableDictionary(data));

        public TestImmutableDictionary(TestSource data)
        {
            this.Dictionary = ImmutableDictionary.CreateRange<string, string>(
                StringComparer.Ordinal, 
                new TestDictionary(data).Dictionary);
        }

        public ImmutableDictionary<string, string> Dictionary { get; }

        public override string ToString() => this.Dictionary.Count.ToString();
    }
}
