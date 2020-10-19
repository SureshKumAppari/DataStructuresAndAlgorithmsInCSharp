using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class AssignBikesClass
    {
        public static int[] AssignBikes(int[][] ws, int[][] bs)
        {
            //Allocate all the possible distance value into array with list of workers index and bike index
            // then we get a list of workers and bikes with the same Manhattan distance;
            // We don't need to sort the array since it is the distances already;
            // bool[] workers assigned and bool[] bikers occupied to keep track with work and bike has been assigned;

            Dictionary<int, List<int[]>> dist = new Dictionary<int, List<int[]>>();
            bool[] assigned = new bool[ws.Length];
            bool[] occupied = new bool[bs.Length];
            for (int i = 0; i < ws.Length; i++)
            {
                for (int j = 0; j < bs.Length; j++)
                {

                    int dis = getdist(ws[i], bs[j]);
                    if (!dist.ContainsKey(dis))
                        dist[dis] = new List<int[]>();
                    dist[dis].Add(new int[] { i, j });
                }
            }
            int[] ans = new int[ws.Length];
            List<int> sortedkeys = new List<int>(dist.Keys);
            sortedkeys.Sort();

            foreach (int k in sortedkeys)
            {
                for (int i = 0; i < dist[k].Count; i++)
                {
                    int worker = dist[k][i][0];
                    int bike = dist[k][i][1];
                    if (!assigned[worker] && !occupied[bike])
                    {
                        assigned[worker] = true;
                        occupied[bike] = true;
                        ans[worker] = bike;
                    }

                }
            }
            foreach(int i in ans)
            {
                Console.WriteLine(i + "");
            }
            return ans;
        }
        public static int getdist(int[] w, int[] b)
        {
            return Math.Abs(w[0] - b[0]) + Math.Abs(w[1] - b[1]);
        }
    }
}
