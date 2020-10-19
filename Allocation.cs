using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class Allocation
    {
        static int n, b;
        static int ans = 0;

        public static void notMain(string[] args)
        {
            int t;
            t = Convert.ToInt32(Console.ReadLine());
            int tc = 0;
            while (t-- > 0)
            {
                tc++;
                n = Convert.ToInt32(Console.ReadLine());
                int[] a = new int[n];
                b = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    a[i] = Convert.ToInt32(Console.ReadLine());
                }
                Array.Sort(a);
                ans = 0;

                for (int i = 0; i < n; i++)
                {
                    if (a[i] <= b)
                    {
                        ans++;
                        b -= a[i];
                    }
                }
                Console.WriteLine("Case #" + tc + ": " + ans);
            }

            Console.ReadLine();
        }
    }
}
