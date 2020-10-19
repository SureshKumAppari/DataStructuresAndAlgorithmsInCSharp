using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class validUtf8Class
    {
        public static bool ValidUtf8(int[] data)
            {
                int count = 0;

                for (int i = 0; i < data.Length; i++)
                {
                    if (count == 0)
                    {
                        var mask = 1 << 7;
                        while ((mask & data[i]) == mask && mask > 1)
                        {
                            count++;
                            mask = mask >> 1;
                        }
                        if (count == 1 || count > 4) return false;
                        count = (count == 0) ? count : --count;
                    }
                    else
                    {
                        var mask1 = 1 << 7;
                        var mask2 = 1 << 6;
                        if (count > 0 && (mask1 & data[i]) == mask1 && (mask2 & data[i]) == 0)
                        {
                            count--;
                        }
                        else return false;
                    }
                }
                return count == 0;
            }


        //public static bool ValidUtf8(int[] data)
        //{
        //    if (data == null)
        //    {
        //        return false;
        //    }

        //    int fullMask = (1 << 8) - 1;
        //    int oneByte = 0; // 0, first char
        //    int twoBytes = 6; // 110, first 3 chars
        //    int threeBytes = 14; // 1110, first 4 chars
        //    int fourBytes = 30; // 11110, first 5 chars
        //    int nextByte = 2; // 10, first 2 chars

        //    // apply full mask to the integers
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        data[i] &= fullMask;
        //    }

        //    bool checkFirstByte = true;
        //    int expectedByteCount = 0;

        //    foreach (var num in data)
        //    {
        //        if (checkFirstByte)
        //        {
        //            if ((num >> 7) == oneByte)
        //            { // 1 byte UTF-8
        //                continue;
        //            }
        //            else if ((num >> 5) == twoBytes)
        //            { // 2 bytes
        //                expectedByteCount = 1;
        //            }
        //            else if ((num >> 4) == threeBytes)
        //            { // 3 bytes
        //                expectedByteCount = 2;
        //            }
        //            else if ((num >> 3) == fourBytes)
        //            { // 4 bytes
        //                expectedByteCount = 3;
        //            }
        //            else
        //            {
        //                return false;
        //            }

        //            checkFirstByte = false;
        //        }
        //        else if ((num >> 6) == nextByte)
        //        { // check byte starting with 10
        //            expectedByteCount--;

        //            if (expectedByteCount == 0)
        //            {
        //                checkFirstByte = true;
        //            }
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }

        //    return expectedByteCount == 0;
        //}
    }
}
