// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BenchmarkDotNet.Attributes;

namespace TextComparison1.Benchmarks
{
    [MemoryDiagnoser]
    public class HasSameCharSequenceBenchmarks
    {
        private const string TextValue1 = "the quick brown fox jumped over the 3 lazy dog's back 0123456789";
        private const string TextValue2 = "I quickly explained that many big jobs involve few hazards 0123456789";

        [Params(null, "", TextValue1, TextValue2)]
        public string? Text1;

        [Params(null, "", TextValue1, TextValue2)]
        public string? Text2;

        [Benchmark]
        public bool Original()
        {
            return new TextComparison1.Original().HasSameCharSequence(this.Text1, this.Text2);
        }

        [Benchmark]
        public bool Indexer()
        {
            return TextComparison1.Indexer.HasSameCharSequence(this.Text1, this.Text2);
        }

        [Benchmark]
        public bool Span()
        {
            return TextComparison1.Span.HasSameCharSequence(this.Text1, this.Text2);
        }

        [Benchmark]
        public bool Pointer()
        {
            return TextComparison1.Pointer.HasSameCharSequence(this.Text1, this.Text2);
        }
    }
}
