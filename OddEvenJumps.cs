﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeConsole
{
    class OddEvenJumps
    {
        public static Solve(string[] args)
        {
            int[] intarray = new int[] {2, 3, 1, 1, 4}; //{ 10, 13, 12, 14, 15 };
            OddEvenLocation(intarray);
        }

        public static int OddEvenLocation(int[] A)
        {
            if (A == null || A.Length <= 1)
            {
                return A.Length;
            }

            bool[] oddJumps = new bool[A.Length];
            bool[] evenJumps = new bool[A.Length];
            oddJumps[A.Length - 1] = evenJumps[A.Length - 1] = true;

            int[] indices = Enumerable.Range(0, A.Length).ToArray();
            int[] oddNext = findNext(indices.OrderBy(index => A[index]).ThenBy(index => index).ToArray()); // lower of higher values
            int[] evenNext = findNext(indices.OrderByDescending(index => A[index]).ThenBy(index => index).ToArray()); // higher of lower values

            for (int i = A.Length - 2; i >= 0; i--)
            {
                if (oddNext[i] > 0)
                {
                    oddJumps[i] = evenJumps[oddNext[i]];
                }

                if (evenNext[i] > 0)
                {
                    evenJumps[i] = oddJumps[evenNext[i]];
                }
            }

            int sum = oddJumps.Select(x => x ? 1 : 0).Sum();
            return sum;
        }

        private static int[] findNext(int[] indices)
        {
            int[] next = new int[indices.Length];
            Stack<int> stack = new Stack<int>();
            foreach (int i in indices)
            {
                while (stack.Count > 0 && stack.Peek() < i)
                {
                    int nextIndex = stack.Pop();
                    next[nextIndex] = i;
                }

                stack.Push(i);
            }

            return next;
        }
    }
}
