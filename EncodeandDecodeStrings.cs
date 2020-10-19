using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{

	public class Codec
	{

        // Encodes a list of strings to a single string.
        public static string encode(IList<string> strs)
        {

            StringBuilder sb = new StringBuilder();
            foreach (var str in strs)
            {
                sb.Append($"{str.Length}/{str}");
            }
            return sb.ToString();
        }

        // Decodes a single string to a list of strings.
        public static IList<string> decode(string s)
        {
            List<string> lst = new List<string>();
            int i = 0;
            while (i < s.Length)
            {
                var l = s.Substring(i, s.IndexOf('/', i) - i);
                var t = s.Substring(i + 1 + l.Length, Convert.ToInt32(l));
                lst.Add(t);
                i += t.Length + l.Length + 1;
            }
            return lst;
        }
    }

}
