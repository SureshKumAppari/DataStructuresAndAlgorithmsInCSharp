using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class FindMissingRangesClass
    {
        public static List<String> FindMissingRanges(int[] nums, int lower, int upper)
        {
            int n = nums.Length;

            if (n == 0)
            {
                return new List<string>(){ formatRange(lower, upper)};
            }

            List<String> missingRanges = new List<string>();

            // Edge case 1) Missing ranges at the beginning
            if (nums[0] > lower)
            {
                missingRanges.Add(formatRange(lower, nums[0] - 1));
            }

            // Missing ranges between array elements
            for (int i = 1; i < n; ++i)
            {
                if (nums[i] - nums[i - 1] > 1)
                {
                    missingRanges.Add(formatRange(nums[i - 1] + 1, nums[i] - 1));
                }
            }

            // Edge case 2) Missing ranges at the end
            if (nums[n - 1] < upper)
            {
                missingRanges.Add(formatRange(nums[n - 1] + 1, upper));
            }

            return missingRanges;
        }

        // formats range in the requested format
        static String formatRange(int lower, int upper)
        {
            if (lower == upper)
            {
                return lower.ToString();
            }
            else
            {
                return lower + "->" + upper;
            }
        }
    }
}
