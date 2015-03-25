using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1IteratorLogic
{
    public static class IteratorLogic
    {
        public static IEnumerator<T> EvenIndexes<T>(ICollection<T> collection)
        {
            IEnumerator<T> enumerator = collection.GetEnumerator();
            for (int i = 0; i < collection.Count; i = i + 2)
                yield return collection.ElementAt(i);
        }
        public static IEnumerator<T> OddIndexes<T>(ICollection<T> collection)
        {
            IEnumerator<T> enumerator = collection.GetEnumerator();
            for (int i = 1; i < collection.Count; i = i + 2)
                yield return collection.ElementAt(i);
        }

        public static IEnumerator<T> ThroughTwoElements<T>(ICollection<T> collection)
        {
            IEnumerator<T> enumerator = collection.GetEnumerator();
            for (int i = 1; i < collection.Count; i = i + 3)
                yield return collection.ElementAt(i);
        }

        public static IEnumerator<T> Decrease<T>(ICollection<T> collection)
        {
            IEnumerator<T> enumerator = collection.GetEnumerator();
            for (int i = collection.Count - 1; i >= 0; --i)
                yield return collection.ElementAt(i);
        }
    }
}
