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
            else if (number == 1) return 0;
            int sum = 0;
            foreach (var a in GetFibonacciValue(number))
            {
                sum += a;
            }
            return sum;
        }

        private static IEnumerable<int> GetFibonacciValue(int number)
        {
            int prev = 0, next = 1, value = 1;
            while (number-- > 1)
            {
                yield return value;
                value = prev + next;
                prev = next;
                next = value;
            }
        }
        
    }
}
