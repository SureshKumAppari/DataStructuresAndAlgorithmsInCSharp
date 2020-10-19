using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class LengthOfLongestSubstringTwoDistinctClass
    {
        public static int LengthOfLongestSubstringTwoDistinct(string s)
        {
            var n = s.Length;

            var charAndMostRightIndex = new Dictionary<char, int>();

            var left = 0;

            var global = 0;

            for (int right = 0; right < n; right++)
            {
                charAndMostRightIndex[s[right]] = right;

                while (charAndMostRightIndex.Count > 2)
                {
                    if (charAndMostRightIndex[s[left]] == left)
                    {
                        charAndMostRightIndex.Remove(s[left]);
                    }
                    left++;
                }


                global = Math.Max(global, right - left + 1);
            }
            return global;
        }
    }
}
