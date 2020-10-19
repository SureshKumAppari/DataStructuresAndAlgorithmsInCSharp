using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class NumberOfPatternsClass
    {
        public static int NumberOfPatterns(int m, int n)
        {
            int res = 0;
            bool[,] visited = new bool[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    res += Search(i, j, m, n, visited);
                }
            }

            return res;
        }

        private static int Search(int i, int j, int m, int n, bool[,] visited)
        {
            if (visited[i, j])
            {
                return 0;
            }

            if (--n == 0)
            {
                return 1;
            }

            int res = 0;
            if (--m <= 0)
            {
                res = 1;
            }

            visited[i, j] = true;

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (!((x == i && Math.Abs(y - j) == 2 && !visited[i, 1]) || (y == j && Math.Abs(x - i) == 2 && !visited[1, j]) || (Math.Abs(x - i) == 2 && Math.Abs(y - j) == 2 && !visited[1, 1])))
                    {
                        res += Search(x, y, m, n, visited);
                    }
                }
            }

            visited[i, j] = false;
            return res;
        }
    }
}
