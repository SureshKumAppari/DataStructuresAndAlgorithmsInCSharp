using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole.ArrayAndStrings
{
    class RemoveDupFromSortedArray
    {
        public int RemoveDuplicates(int[] nums)
        {

            if (nums == null || nums.Length == 0)
                return 0;

            int start = 0;
            for (int j = start + 1; j < nums.Length; j++)
            {
                if (nums[start] != nums[j])
                {
                    start++;
                }

                nums[start] = nums[j];
            }
            return start + 1;

        }
    }

}
