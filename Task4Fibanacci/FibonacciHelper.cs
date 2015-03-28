using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Fibanacci
{
    public static class FibonacciHelper
    {
        public static int FibonacciSum(int number)
        {
            if (number == 0) throw new ArgumentException("Can not transmit a zero value in function.");
            int sum = 0;
            foreach(var a in GetValue(GenerateFibonacciSequence(number)))
            {
                sum += a;
            }
            return sum;
        }

        private static int[] GenerateFibonacciSequence(int number)
        {
            int[] sequence = new int[number];
            sequence[0] = 0;
            if (number > 1) sequence[1] = 1;
            for (int i = 2; i < number; ++i)
            {
                sequence[i] = sequence[i - 1] + sequence[i - 2];
            }
            return sequence;
        }

        private static IEnumerable<int> GetValue(int[] sequence)
        {
            for (int i = 0; i < sequence.Length; ++i)
            {
                yield return sequence[i];
            }
        }
        
    }
}
