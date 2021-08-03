// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace TextComparison1
{
    public static class Pointer
    {
        public static bool HasSameCharSequence(string? text1, string? text2)
        {
            if (text1 == null || text2 == null)
            {
                return false;
            }

            var i1 = text1.Length - 1;
            var i2 = text2.Length - 1;

            unsafe
            {
                fixed (char* t1 = text1, t2 = text2)
                {
                    var p1 = t1;
                    var p2 = t2;

                    while (i1 >= 0 && i2 >= 0)
                    {
                        while (i1 >= 0 && !char.IsLetterOrDigit(*p1))
                        {
                            i1--;
                            p1++;
                        }

                        while (i2 >= 0 && !char.IsLetterOrDigit(*p2))
                        {
                            i2--;
                            p2++;
                        }

                        if (i1 >= 0 && i2 >= 0 && char.ToLower(*p1) != char.ToLower(*p2))
                        {
                            return false;
                        }

                        i1--;
                        p1++;
                        i2--;
                        p2++;
                    }
                }
            }

            return i1 < 0 && i2 < 0;
        }
    }
}
