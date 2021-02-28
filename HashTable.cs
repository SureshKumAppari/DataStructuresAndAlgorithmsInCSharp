using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PracticeConsole.ArrayAndStrings
{
    class HashTable
    {
        //private static void printFreq(char[] str)
        //{
        //    int[] freq = new int[256];
        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        freq[str[i]]++;
        //    }
        //    for (int i = 0; i < 256; i++)
        //    {
        //        if (freq[i] > 0)
        //        {
        //            Console.WriteLine("[" + (char)(i) + "] = " + freq[i]);
        //        }
        //    }
        //}

        //public static void main(String[] args)
        //{
        //    char[] str = "Hello world".ToCharArray();
        //    printFreq(str);
        //}

        //private static void printFreq(char[] str)
        //{
        //    int[] freq = new int[26];
        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        // 'a' has an ascii value of 97, so there is an offset in accessing the index.
        //        freq[str[i] - 'a']++;
        //    }
        //    for (int i = 0; i < 26; i++)
        //    {
        //        if (freq[i] > 0)
        //        {
        //            Console.WriteLine("[" + (char)(i + 'a') + "] = " + freq[i]);
        //        }
        //    }
        //}

        //public static void Main(String[] args)
        //{
        //    char[] str = "helloworld".ToCharArray();
        //    printFreq(str);
        //}

        private static void printFreq(char[] str)
        {
            Dictionary<char, int> freq = new Dictionary<char,int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (freq.ContainsKey(str[i]))
                {
                    freq[str[i]]++;
                }
                else
                {
                    freq.Add(str[i], 1);
                }
            }
            foreach( var entry in freq)
            {
                Console.WriteLine("[" + (char)(entry.Key) + "] = " + entry.Value);
            }
        }

        public static Solve(String[] args)
        {
            char[] str = "◣⚽◢⚡◣⚾⚡◢".ToCharArray();
            printFreq(str);
            int[] nums = new int[6];
            nums[0] = nums[1];
        }
    }
}
