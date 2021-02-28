using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole.ArrayAndStrings
{
    class TwoSumIIinputArray
    {
        static void Solve(string[] args)
        {
            Console.WriteLine(TwoSum(new int[4] { 1, 2, 7, 11 }, 9).ToString());
        }

        public static int[] TwoSum(int[] numbers, int target)
        {
            if (numbers.Length == 0)
                return null;

            int i = 0, j = numbers.Length - 1;

            while (i < j)
            {
                int sum = numbers[i] + numbers[j];
                if (sum == target)
                    return new int[] { i + 1, j + 1 };
                else if (sum < target) i++;
                else j--;
            }
            return new int[] { i + 1, j + 1 };
        }
    }
}
