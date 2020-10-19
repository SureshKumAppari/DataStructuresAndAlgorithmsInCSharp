using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class MergeClass
    {
        public static int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return new int[][] { };

            List<int[]> result = new List<int[]>();

            Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));

            int s = intervals[0][0],
                e = intervals[0][1];

            for (int i = 1; i < intervals.Length; i++)
                if (e < intervals[i][0])
                {
                    result.Add(new int[] { s, e });

                    s = intervals[i][0];
                    e = intervals[i][1];
                }
                else
                    e = Math.Max(e, intervals[i][1]);

            result.Add(new int[] { s, e });

            return result.ToArray();
        }
    }
}
