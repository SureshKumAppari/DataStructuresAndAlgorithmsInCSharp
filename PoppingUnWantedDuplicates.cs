using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole.ArrayAndStrings
{
    class PoppingUnWantedDuplicates
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length < 2)
            {
                return nums.Length;
            }

            int i = 2;
            for (int j = 2; j < nums.Length; ++j)
            {
                if (nums[j] != nums[i - 1] || nums[i - 1] != nums[i - 2])
                {
                    nums[i++] = nums[j];
                }
            }
            return i;
        }
    }
}
