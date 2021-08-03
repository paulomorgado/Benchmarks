using System;
using Shouldly;
using Xunit;

namespace TextComparison1.UnitTests
{
    public static class HasSameCharSequenceTests
    {
        [Theory]
        [MemberData(nameof(TheoryData.HasSameCharSequenceTheoryData), MemberType = typeof(TheoryData))]
        public static void OriginalTests(string text1, string text2, bool expectedResult)
        {
            new Original().HasSameCharSequence(text1, text2).ShouldBe(expectedResult);
        }

        [Theory]
        [MemberData(nameof(TheoryData.HasSameCharSequenceTheoryData), MemberType = typeof(TheoryData))]
        public static void IndexerTests(string text1, string text2, bool expectedResult)
        {
            Indexer.HasSameCharSequence(text1, text2).ShouldBe(expectedResult);
        }

        [Theory]
        [MemberData(nameof(TheoryData.HasSameCharSequenceTheoryData), MemberType = typeof(TheoryData))]
        public static void PointerTests(string text1, string text2, bool expectedResult)
        {
            Pointer.HasSameCharSequence(text1, text2).ShouldBe(expectedResult);
        }

        [Theory]
        [MemberData(nameof(TheoryData.HasSameCharSequenceTheoryData), MemberType = typeof(TheoryData))]
        public static void SpanTests(string text1, string text2, bool expectedResult)
        {
            Span.HasSameCharSequence(text1, text2).ShouldBe(expectedResult);
        }
    }
}
