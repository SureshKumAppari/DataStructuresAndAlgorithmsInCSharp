using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class MinAreaRectClass
    {
        public static int MinAreaRect(int[][] points)
        {
            HashSet<int> pointSet = new HashSet<int>();
            foreach (int[] point in points)
                pointSet.Add(40001 * point[0] + point[1]);

            int ans = int.MaxValue;
            for (int i = 0; i < points.Length; ++i)
                for (int j = i + 1; j < points.Length; ++j)
                {
                    if (points[i][0] != points[j][0] && points[i][1] != points[j][1])
                    {
                        if (pointSet.Contains(40001 * points[i][0] + points[j][1]) &&
                                pointSet.Contains(40001 * points[j][0] + points[i][1]))
                        {
                            ans = Math.Min(ans, Math.Abs(points[j][0] - points[i][0]) *
                                                Math.Abs(points[j][1] - points[i][1]));
                        }
                    }
                }

            return ans < int.MaxValue ? ans : 0;
        }
    }
}
