using System;

namespace TextComparison1
{
    public static class Span
    {
        public static bool HasSameCharSequence(string? text1, string? text2)
        {
            if (text1 == null || text2 == null)
            {
                return false;
            }

            return HasSameCharSequence(text1.AsSpan(), text2.AsSpan());
        }

        public static bool HasSameCharSequence(ReadOnlySpan<char> text1, ReadOnlySpan<char> text2)
        {
            var i1 = text1.Length - 1;
            var i2 = text2.Length - 1;

            while (i1 >= 0 && i2 >= 0)
            {
                while (i1 >= 0 && !char.IsLetterOrDigit(text1[i1]))
                {
                    i1--;
                }

                while (i2 >= 0 && !char.IsLetterOrDigit(text2[i2]))
                {
                    i2--;
                }

                if (i1 >= 0 && i2 >= 0 && char.ToLower(text1[i1]) != char.ToLower(text2[i2]))
                {
                    return false;
                }

                i1--;
                i2--;
            }

            return i1 < 0 && i2 < 0;
        }
    }
}
