using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace PracticeConsole
{
    class DecodeString
    {
        public static void notMain(string[] args)
        {
            Console.WriteLine(DecodeStr(Console.ReadLine()));
            Console.ReadLine();
        }

        // 2[a]3[bc] == aabcbcbc
        public static string DecodeStr(string s)
        {
            string res = string.Empty;
            Stack<string> resStack = new Stack<string>();
            Stack<int> countStack = new Stack<int>();
            int currentIdx = 0;

            while(currentIdx < s.Length)
            {
                if(char.IsDigit(s[currentIdx]))
                {
                    int count = s[currentIdx] - '0';
                    currentIdx++;
                    while (char.IsDigit(s[currentIdx]))
                    {
                        count = 10 * count + s[currentIdx] - '0';
                        currentIdx++;
                    }
                    countStack.Push(count);
                }
                else if(s[currentIdx] == '[')
                {
                    resStack.Push(res);
                    res = string.Empty;
                    currentIdx++;
                }
                else if(s[currentIdx] == ']')
                {
                    StringBuilder repeatString = new StringBuilder();
                    int repeatTimes = countStack.Pop();
                    for(int i = 0; i < repeatTimes; i++)
                    {
                        repeatString.Append(res);
                    }
                    res = resStack.Pop() + repeatString.ToString();
                }
                else
                {
                    res += s[currentIdx];
                }
            }
            return res;
        }
    }
}
