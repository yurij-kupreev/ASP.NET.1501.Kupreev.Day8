using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Iterator
{
    public static class SpecificIterator
    {
        public static IEnumerable<T> GetIterator<T>(this ICollection<T> collection, Func<IEnumerator<T>, IEnumerator<T>> func)
        {
            IEnumerator<T> enumerator = collection.GetEnumerator();
            IEnumerator<T> newEnumerator = func(enumerator);
            while (newEnumerator.MoveNext())
            {
                yield return newEnumerator.Current;
            }
            
        }
    }
}
