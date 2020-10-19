using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class LongestAbsoluteFilePath
    {
        public static int LengthLongestPath(string input)
        {
            var stack = new Stack<int[]>();
            int max = 0;

            foreach (var w in input.Split('\n'))
            {
                var infos = info(w);
                while (stack.Count > 0 && infos[0] != stack.Peek()[0] + 1)  //if isn't ancestor of current line, removes from stack
                    stack.Pop();
                if (stack.Count > 0) // if anybody remains from previous while loop, it's ancestor for current line
                    infos[2] += 1 + stack.Peek()[2]; // uses father info to calc total path size
                stack.Push(infos);
                if (w.Contains(".")) // update max only if it's a file
                    max = Math.Max(max, infos[2]);
            }
            return max;
        }

        private static int[] info(string w)
        {
            var dir = w.Replace("\t", "");
            return new int[3] { w.Length - dir.Length, dir.Length, dir.Length }; // [level, dir size, path size]
        }

        //public static int LengthLongestPath(string input)
        //{
        //    string[] arrInput = input.Split('\n');

        //    Stack<string> pathStack = new Stack<string>(0);

        //    int maxLen = 0;

        //    int currentStackLen = 0;

        //    foreach (string subInput in arrInput)
        //    {
        //        if (string.IsNullOrEmpty(subInput))
        //        {
        //            continue;
        //        }

        //        // The zero-based index position of value if that character is found, 
        //        //or -1 if it is not.
        //        int tabCount = subInput.LastIndexOf('\t') + 1;

        //        string name = null;
        //        if (tabCount > 1)
        //        {
        //            name = subInput.Substring(tabCount - 1);
        //        }
        //        else
        //        {
        //            name = subInput;
        //        }

        //        while (tabCount < pathStack.Count)
        //        {
        //            string popItem = (string)pathStack.Pop();
        //            currentStackLen -= popItem.Length;
        //        }

        //        pathStack.Push(name);
        //        currentStackLen += name.Length;

        //        if (name.Contains('.'))
        //        {
        //            maxLen = (currentStackLen > maxLen) ? currentStackLen : maxLen;
        //        }
        //    }

        //    return maxLen;
        //}
    }
}
