using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class RemoveStonesClass
    {
        public static int RemoveStones(int[][] stones)
        {
            int N = stones.Length;
            DSU dsu = new DSU(20000);

            foreach (int[] stone in stones)
                dsu.union(stone[0], stone[1] + 10000);

            HashSet<int> seen = new HashSet<int>();
            foreach (int[] stone in stones)
                seen.Add(dsu.find(stone[0]));

            return N - seen.Count;
        }
    }
    class DSU
    {
        int[] parent;
        public DSU(int N)
        {
            parent = new int[N];
            for (int i = 0; i < N; ++i)
                parent[i] = i;
        }
        public int find(int x)
        {
            if (parent[x] != x) parent[x] = find(parent[x]);
            return parent[x];
        }
        public void union(int x, int y)
        {
            parent[find(x)] = find(y);
        }
    }
}
