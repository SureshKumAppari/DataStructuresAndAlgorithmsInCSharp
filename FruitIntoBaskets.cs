using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PracticeConsole
{
    class FruitIntoBaskets
    {
        public static void notMain(string[] args)
        {
            TotalFruitInput();

        }

        private static void TotalFruitInput()
        {
            Console.WriteLine("Enter the number of trees!");
            int n = int.Parse(Console.ReadLine());
            int[] tree = new int[n];
            Console.WriteLine("Enter fruits for each tree");
            for (int i = 0; i < n; i++)
            {
                tree[i] = int.Parse(Console.ReadLine());
            }
            int res = TotalFruit(tree);
            Console.WriteLine($"maximum fruits you can collect: {res}");
            Console.WriteLine("Enter any key to exit");
            Console.ReadLine();
        }

        public static int TotalFruit(int[] tree)
        {
            if (tree == null)
                return 0;

            int lastFruit = -1;
            int secondLastFruit = -1;
            int lastFruitCount = -1;
            int currentMax = 1;
            int max = 0;
            // traverse whole tree 
            for (int i = 0; i < tree.Length; i++)
            {
                // if current fruit is among the last two fruit increase currentMax
                if ((tree[i] == lastFruit) || (tree[i] == secondLastFruit))
                {
                    currentMax++;
                }
                else
                {
                    // if current fruit is not among the last two fruit
                    //then secondLastFruitCount becomes lastFruitCount and lastFruitCount becomes 1
                    if (lastFruitCount != -1)
                        currentMax = lastFruitCount + 1;
                }

                if (tree[i] != lastFruit)
                {
                    // keep updating the last two fruits  
                    secondLastFruit = lastFruit;
                    lastFruit = tree[i];
                    lastFruitCount = 1;
                }
                else
                {
                    //if still last fruit is same increase the count 
                    lastFruitCount++;
                }

                max = Math.Max(max, currentMax);
            }


            return max;
        }
    }
}
