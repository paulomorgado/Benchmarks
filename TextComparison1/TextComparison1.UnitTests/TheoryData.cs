using System;
using System.Linq;
using Xunit;

namespace TextComparison1.UnitTests
{
    public static class TheoryData
    {
        public static TheoryData<string, string, bool> HasSameCharSequenceTheoryData { get; } = BuildHasSameCharSequenceTheoryData();

        private static TheoryData<string, string, bool> BuildHasSameCharSequenceTheoryData()
        {
            const string HasSameCharSequenceText1 = "the quick brown fox jumped over the 3 lazy dog's back 0123456789";
            const string HasSameCharSequenceText2 = "I quickly explained that many big jobs involve few hazards 0123456789";
            var hasSameCharSequenceText1Fuzzed1 = HasSameCharSequenceText1.Replace(" ", Fuzzer.GetString());
            var hasSameCharSequenceText1Fuzzed2 = HasSameCharSequenceText1.Replace(" ", Fuzzer.GetString());
            var hasSameCharSequenceText2Fuzzed1 = HasSameCharSequenceText2.Replace(" ", Fuzzer.GetString());
            var hasSameCharSequenceText2Fuzzed2 = HasSameCharSequenceText2.Replace(" ", Fuzzer.GetString());

            return new TheoryData<string, string, bool>
                {
                    { null, null, false },
                    { string.Empty, string.Empty, true },
                    { HasSameCharSequenceText1, HasSameCharSequenceText1, true },
                    { HasSameCharSequenceText1.ToLower(), HasSameCharSequenceText1.ToUpper(), true },
                    { HasSameCharSequenceText2, HasSameCharSequenceText2, true },
                    { HasSameCharSequenceText2.ToLower(), HasSameCharSequenceText2.ToUpper(), true },
                    { HasSameCharSequenceText1, HasSameCharSequenceText2, false },
                    { HasSameCharSequenceText1, hasSameCharSequenceText1Fuzzed1, true },
                    { hasSameCharSequenceText1Fuzzed1, hasSameCharSequenceText1Fuzzed2, true },
                    { HasSameCharSequenceText2, hasSameCharSequenceText2Fuzzed1, true },
                    { hasSameCharSequenceText2Fuzzed1, hasSameCharSequenceText2Fuzzed2, true },
                    { hasSameCharSequenceText1Fuzzed1, hasSameCharSequenceText2Fuzzed2, false },
                };
        }

        private static class Fuzzer
        {
            private const string fuzzChars = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
            private static readonly Random random = new Random();

            public static string GetString()
            {
                lock (random)
                {
                    var chars = new char[random.Next(1, 5)];

                    for (var i = chars.Length - 1; i >= 0; i--)
                    {
                        chars[i] = fuzzChars[random.Next(fuzzChars.Length)];
                    }

                    return new string(chars);
                }
            }
        }
    }
}
