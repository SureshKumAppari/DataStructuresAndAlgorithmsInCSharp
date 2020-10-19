using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole.ArrayAndStrings
{
    class ReverseWords
    {
        public void RevWords(char[] str)
        {
            int start = 0, end = str.Length - 1;
            Reverse(str, start, end);
            for(int i=0; i< str.Length; i++)
            {
                if(str[i] == ' ' || i == str.Length - 1)
                {
                    if (i == str.Length - 1)
                        end = i;
                    else end = i - 1;
                    Reverse(str, start, end);
                    start = i + 1;
                }
            }
        }

        public static void Reverse(char[] str, int start, int end)
        {
            while(start < end)
            {
                char t = str[start];
                str[start++] = str[end];
                str[end--] = t;
            }
        }
    }
}
