using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Iterator
{
    public static class SpecificIterator
    {
        public static IEnumerable<T> GetIterator<T>(this ICollection<T> collection, Func<ICollection<T>, IEnumerator<T>> func)
        {
            IEnumerator<T> newEnumerator = func(collection);
            while (newEnumerator.MoveNext())
            {
                yield return newEnumerator.Current;
            }
            
        }
    }
}
