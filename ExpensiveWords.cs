using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PracticeConsole
{
    class ExpensiveWords
    {
        public static void notMain(string[] args)
        {
            //Console.WriteLine(ExpWords("heeellooo",
            //    new string[] { "hello", "hi", "helo" }));
            int i = '1' - '0';
            Console.WriteLine(i);
            Console.ReadLine();
        }

        public static int ExpWords(string s, string[] words)
        {
            var res = 0;

            foreach (string word in words)
            {
                res = Expensive(s, word, 0, 0) ? 1 : 0;
            }
            return res;
        }

        public static bool Expensive(string s, string t, int si, int ti)
        {
            if (si == s.Length && ti == t.Length) return true;

            if (si == s.Length || ti == t.Length || (s[si] != t[ti])) return false;

            var cur = s[si];

            int scount = 0, tcount = 0;

            while (si < s.Length && s[si] == cur)
            {
                scount++;
                si++;
            }

            while (ti < t.Length && t[ti] == cur)
            {
                tcount++;
                ti++;
            }

            return (scount == tcount || scount >= 3 && scount > tcount) && Expensive(s, t, si, ti);
        }
    }

}
