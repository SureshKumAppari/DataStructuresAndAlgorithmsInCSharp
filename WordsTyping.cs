using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class WordsType
    {
        public static int WordsTyping(string[] sentence, int rows, int cols)
        {

            //fill the sentences with the words
            StringBuilder sb = new StringBuilder();
            foreach (string str in sentence)
            {
                string s = str + " ";
                sb.Append(s);
            }
            //hello world ;
            int start = 0;
            for (int i = 0; i < rows; i++)
            {
                start = start + cols;
                if (sb[start % sb.Length] == ' ')
                {
                    start++;     //move over the space by adding 1 to start;
                }
                else
                { //need to look for the previous space ;
                    while (start > 0 && sb[(start - 1) % sb.Length] != ' ')
                        start--;
                }
            }
            return start / sb.Length;
        }
    }
}
