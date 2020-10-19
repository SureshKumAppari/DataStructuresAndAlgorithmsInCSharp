using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class nextClosetsTime
    {
        public static string nextClosestTime(string time)
        {
            int[] arr = new int[4] { time[0] - 48, time[1] - 48, time[3] - 48, time[4] - 48 };
            Array.Sort(arr);

            //arr is sorted so search from the smallest to largest

            //Search if there is a possible larger replacement for the last digit("4" as in "19:34")
            for (int i = 0; i < 4; i++)
            {
                if (arr[i] > time[4] - 48)
                    return time.Substring(0, 4) + arr[i].ToString();
            }

            //Search if there is a possible larger replacement for the 2nd last digit("3" as in "19:34")
            for (int i = 0; i < 4; i++)
            {
                if (arr[i] > time[3] - 48 && arr[i] < 6)
                    return time.Substring(0, 3) + arr[i].ToString() + arr[0].ToString();
            }

            //For hours, we have only 0,1,2 for the first digit, deal with them separately
            //but similar logic to the above: find a possible larger replacement
            for (int i = 0; i < 4; i++)
            {
                if (time[0] == '1' && arr[i] > time[1] - 48 && arr[i] < 10)
                    return "1" + arr[i].ToString() + ":" + arr[0].ToString() + arr[0].ToString();
                else if (time[0] == '2' && arr[i] > time[1] - 48 && arr[i] < 4)
                    return "2" + arr[i].ToString() + ":" + arr[0].ToString() + arr[0].ToString();
                else if (time[0] == '0' && arr[i] > time[1] - 48 && arr[i] < 10)
                    return "0" + arr[i].ToString() + ":" + "00";
            }

            //if none of the above applies, simply get the smallest possible time with all the digits
            return arr[0].ToString() + arr[0].ToString() + ":" + arr[0].ToString() + arr[0].ToString();
        }

        //public virtual string NextClosestTime(string time)
        //{
        //    int cur = 60 * int.Parse(time.Substring(0, 2));
        //    cur += int.Parse(time.Substring(3));
        //    ISet<int> allowed = new HashSet<int>();
        //    foreach (char c in time.ToCharArray())
        //    {
        //        if (c != ':')
        //        {
        //            allowed.Add(c - '0');
        //        }
        //    }

        //    while (true)
        //    {
        //        cur = (cur + 1) % (24 * 60);
        //        int[] digits = new int[] { cur / 60 / 10, cur / 60 % 10, cur % 60 / 10, cur % 60 % 10 };
        //        {
        //            foreach (int d in digits)
        //            {
        //                if (!allowed.Contains(d))
        //                {
        //                    goto searchBreak;
        //                }
        //            }
        //            return string.Format("{0:D2}:{1:D2}", cur / 60, cur % 60);
        //        }
        //    searchBreak:;
        //    }
        //}
    }
}
