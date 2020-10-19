using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class Plates
    {
        private static void notMain(string[] args)
        {
            int T;
            T = Convert.ToInt32(Console.ReadLine());
            for (int test = 1; test <= T; test++)
            {
                int n, k, p;
                n = Convert.ToInt32(Console.ReadLine());
                k = Convert.ToInt32(Console.ReadLine());
                p = Convert.ToInt32(Console.ReadLine());
                List<List<int>> a = NestedList<int>(n, k);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        a[i][j] = Convert.ToInt32(Console.ReadLine());
                    }
                }

                List<int> dp = new List<int>(p + 1);
                for (int i = 0; i < n; i++)
                {
                    List<int> ndp = new List<int>(dp);
                    for (int j = 0; j <= p; j++)
                    {
                        int cur = 0;
                        for (int l = 0; l <= k && j + l <= p; l++)
                        {
                            ndp[j + l] = Math.Max(ndp[j + l], dp[j] + cur);
                            if (l < k)
                            {
                                cur += a[i][l];
                            }
                        }
                    }
                    dp = ndp;
                }

                Console.WriteLine("Case #%d: %d\n", test, dp[p]);
                Console.ReadLine();
            }

            static List<List<T>> NestedList<T>(int outerSize, int innerSize)
            {
                List<List<T>> temp = new List<List<T>>();
                for (int count = 1; count <= outerSize; count++)
                {
                    temp.Add(new List<T>(innerSize));
                }

                return temp;
            }
        }
    }
}
