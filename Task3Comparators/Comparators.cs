using System;
using System.Collections.Generic;
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
}
