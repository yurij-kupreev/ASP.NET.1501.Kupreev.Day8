using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Comparators
{
    public static class Comparators
    {
        public static int CompareIntArrays(int[] left, int[] right)
        {
            if (left.Length != right.Length) return left.Length - right.Length;
            for (int i = 0; i < left.Length; ++i)
            {
                if (left[i] != right[i]) return left[i] - right[i];
            }
            return 0;
        }
    }

    public class CompareIntArrays<T> : IComparer<T>
    {
        public int Compare(T left, T right)
        {
            //if (!(left is int[]) || !(right is int[]))
            //    throw new ArgumentException();
            int [] arr1 = left as int[];
            int[] arr2 = right as int[];

            if (arr1.Length != arr2.Length) return arr1.Length - arr2.Length;
            for (int i = 0; i < arr1.Length; ++i)
            {
                if (arr1[i] != arr2[i]) return arr1[i] - arr2[i];
            }
            return 0;
        }
    }
}
