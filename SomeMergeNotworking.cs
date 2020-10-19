using System;

namespace PracticeConsole
{
    class SomeMergeNotworking
    {
        public static int[] source = new int[5];
        public static int[] target;
        private static void nMain(string[] args)
        {
            for (int i = 0; i < source.Length; i++)
            {
                source[i] = int.Parse(Console.ReadLine());
            }
            // Instantiate and allocate the target array.
            //
            //
            // Display the target array.
            mergeSort(source);
            for (int i = 0; i < source.Length; i++)
            {
                Console.WriteLine(source[i]);
            }
            Console.ReadLine();
        }

        public static int[] mergeSort(int[] arr)
        {
            if (arr.Length <= 1) return arr;
            int mid = 0;
            int.TryParse(Math.Floor(arr.Length / 2.0).ToString(), out mid);
            var left = mergeSort(arr.Slice(0, mid));
            var right = mergeSort(arr.Slice(mid, arr.Length));
            return merge(left, right);
        }

        public static int[] merge(int[] arr1, int[] arr2)
        {
            target = new int[arr1.Length + arr2.Length];

            int i = 0;
            int j = 0;
            int resIdx = 0;
            while (i < arr1.Length && j < arr2.Length && resIdx < target.Length - 1)
            {
                if (arr2[j] > arr1[i])
                {
                    target[resIdx] = arr1[i];
                    i++;
                }
                else
                {
                    target[resIdx] = arr2[j];
                    j++;
                }
                resIdx++;
            }

            while (i < arr1.Length && resIdx < arr1.Length)
            {
                target[resIdx] = arr1[i];
                i++;
                resIdx++;
            }

            while (j < arr2.Length && resIdx < arr2.Length)
            {
                target[resIdx] = arr2[j];
                j++;
                resIdx++;
            }

            return target;
        }
    }
}
