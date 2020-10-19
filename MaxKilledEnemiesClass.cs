using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    public class MaxKilledEnemiesClass
    {
        public static int MaxKilledEnemies(char[][] grid)
        {
            if (grid.Length == 0 || grid[0].Length == 0) return 0;
            int ret = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '0')
                        ret = Math.Max(ret, helper(grid, i, j));
                }
            }
            return ret;
        }
        static int helper(char[][] grid, int i, int j)
        {
            int x = i, ret = 0;
            while (x >= 0)
            {
                if (grid[x][j] == 'W') break;
                if (grid[x][j] == 'E') ret++;
                x--;
            }
            x = i;
            while (x < grid.Length)
            {
                if (grid[x][j] == 'W') break;
                if (grid[x][j] == 'E') ret++;
                x++;
            }
            int y = j;
            while (y >= 0)
            {
                if (grid[i][y] == 'W') break;
                if (grid[i][y] == 'E') ret++;
                y--;
            }
            y = j;
            while (y < grid[0].Length)
            {
                if (grid[i][y] == 'W') break;
                if (grid[i][y] == 'E') ret++;
                y++;
            }
            return ret;
        }
    }
}
