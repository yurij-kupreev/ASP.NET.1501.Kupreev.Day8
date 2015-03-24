using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1IteratorLogic
{
    public static class IteratorLogic
    {
        public static IEnumerator<T> EvenIndexes<T>(IEnumerator<T> enumerator)
        {
            int k = 0;
            while (enumerator.MoveNext())
            {
                if (k++ % 2 == 0) yield return enumerator.Current;
            }
        }
        public static IEnumerator<T> OddIndexes<T>(IEnumerator<T> enumerator)
        {
            int k = 1;
            while (enumerator.MoveNext())
            {
                if (k++ % 2 == 0) yield return enumerator.Current;
            }
        }

        public static IEnumerator<T> ThroughTwoElements<T>(IEnumerator<T> enumerator)
        {
            int k = 0;
            while (enumerator.MoveNext())
            {
                if (k++ % 3 == 0) yield return enumerator.Current;
            }
        }
    }
}
