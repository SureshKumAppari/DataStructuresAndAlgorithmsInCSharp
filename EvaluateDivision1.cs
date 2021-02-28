using System;
using System.Collections.Generic;
using System.Reflection;

namespace PracticeConsole
{
    /// <summary>
    /// Follows : Floyd Warshall
    /// Time Complexity : O(n) + O(k) * O(n)
    /// Space Complexity : O(2*n) + O(k) + O(log n)
    /// </summary>
    class EvaluateDivision1
    {
        static void Solve(string[] args)
        {
            // ************************Input*********************

            //[["a","b"],["b","c"]]
            //[2.0,3.0]
            //[["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]

            // ************************Input*********************


            List<List<string>> equations = new List<List<string>>
            {
                new List<string>
                {
                    "a",
                    "b"
                },
                new List<string>
                {
                    "b",
                    "c"
                }
            };
            double[] values = new double[2] { 2.0, 3.0 };

            List<List<string>> queries = new List<List<string>>
            {
                new List<string>
                {
                    "a","c"
                },
                new List<string>
                {
                    "b","a"
                },
                new List<string>
                {
                    "a","e"
                },
                new List<string>
                {
                    "a","a"
                },
                new List<string>
                {
                    "x","x"
                }
            };
            double[] res = Solution.CalcEquation(equations, values, queries);
            foreach (double d in res)
            {
                Console.WriteLine(d.ToString());
            }
        }
        public class Solution
        {
            public static double[] CalcEquation(List<List<string>> equations, double[] values, List<List<string>> queries)
            {
                Dictionary<string, Dictionary<string, double>> lookup = new Dictionary<string, Dictionary<string, double>>();

                for (int i = 0; i < equations.Count; i++)
                {
                    if (!lookup.ContainsKey(equations[i][0]))
                    {
                        lookup[equations[i][0]] = new Dictionary<string, double>();
                    }

                    if (!lookup.ContainsKey(equations[i][1]))
                    {
                        lookup[equations[i][1]] = new Dictionary<string, double>();
                    }

                    lookup[equations[i][0]][equations[i][1]] = 1 / values[i];
                    lookup[equations[i][1]][equations[i][0]] = values[i];

                }

                double[] results = new double[queries.Count];
                HashSet<string> visited = new HashSet<string>();

                for(int i = 0; i < queries.Count; i++)
                {
                    results[i] = FindPath(queries[i][1], queries[i][0], lookup, visited);
                }

                return results;
            }

            private static double FindPath(string source, string target,
                Dictionary<string, Dictionary<string, double>> lookup, HashSet<string> visited)
            {
                if (!lookup.ContainsKey(source)) { return -1; }
                if (target == source) return 1;
                double distance = -1;

                visited.Add(source);

                foreach (string d in lookup[source].Keys)
                {

                    if (visited.Contains(d)) { continue; }
                    distance = FindPath(d, target, lookup, visited);
                    if (distance != -1) { distance *= lookup[source][d]; break; }
                }
                visited.Remove(source);
                return distance;
            }
        }
    }
}
