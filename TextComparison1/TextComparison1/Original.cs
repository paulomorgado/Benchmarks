using System;
using System.Collections.Generic;
using System.Linq;

namespace TextComparison1
{
    public class Original
    {
        public bool HasSameCharSequence(string? text1, string? text2)
        {
            if (text1 == null || text2 == null)
            {
                return false;
            }

            var seq1 = text1.ToLower().Where(chr => char.IsLetterOrDigit(chr));
            var seq2 = text2.ToLower().Where(chr => char.IsLetterOrDigit(chr));
            return seq1.SequenceEqual(seq2);
        }

        public bool DifferByStopword(string text1, string text2)
        {
            if (text1 == null || text2 == null)
            {
                return false;
            }

            var stopwordTerms = new string[] { " and ", " & ", " the ", " " };
            var words1 = text1.ToLower().Split(stopwordTerms, StringSplitOptions.RemoveEmptyEntries);
            var words2 = text2.ToLower().Split(stopwordTerms, StringSplitOptions.RemoveEmptyEntries);
            return words1.SequenceEqual(words2);
        }

        public bool AreSimilarWords(string text1, string text2)
        {
            if (text1 == null || text2 == null)
            {
                return false;
            }

            if (text1 == text2)
            {
                return true;
            }

            var text1Lower = text1.ToLower();
            var text2Lower = text2.ToLower();
            var set1 = new HashSet<string>() { text1Lower, text1Lower + "s", text1Lower + "es" };
            var set2 = new HashSet<string>() { text2Lower, text2Lower + "s", text2Lower + "es" };
            return set1.Overlaps(set2);
        }
    }
}
