using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole.ArrayAndStrings
{
    public class LongestSubStrWithAtMostKDistinctChar
    {
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {

            int[] ctr = new int[256];
            int j = -1, distinct = 0, maxlen = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                distinct += Convert.ToInt32(ctr[s[i]]++ == 0);
                while (distinct > k)
                    distinct -= Convert.ToInt32(--ctr[s[++j]] == 0);
                maxlen = Math.Max(maxlen, i - j);
            }
            return maxlen;

        }
        public int LengthOfLongestSubstring(string s)
        {
            int[] map = new int[256];
            int left = 0;
            int max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                while (map[s[i]] != 0) map[s[left++]]--;
                map[s[i]]++;
                max = Math.Max(i - left + 1, max);
            }
            return max;
        }
    }
}
