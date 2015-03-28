using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3BinarySearch
{
    public class BinarySearch
    {
        public static int? Search<T>(T[] array, T key)
        {
            if (array == null || key == null) throw new ArgumentNullException();
            return Search<T>(array, key, null);
        }
        public static int? Search<T>(T[] array, T key, Func<T, T, int> comparerLogic)
        {
            if (array == null || key == null) throw new ArgumentNullException();
            //if (!(key is IComparer<T>)) throw new ArgumentException();
            if (comparerLogic == null && Comparer<T>.Default != null) comparerLogic = Comparer<T>.Default.Compare;
            //if (comparerLogic.Method == null) throw new ArgumentException("There is no comparator for this type.");
            // if (comparerLogic.GetInvocationList().Length == 0) throw new ArgumentException("There is no comparator for this type.");
            // Как проверить, есть ли стандартная логика сравнения?

            return SearchLogic<T>(array, key, comparerLogic);
        }
        private static int? SearchLogic<T>(T[] array, T key, Func<T, T, int> comparerLogic)
        {
            int left = 0;
            int right = array.Length - 1;
            while (right >= left)
            {
                int middle = (left + right) / 2;
                int comp;
                try
                {
                    comp = comparerLogic(array[middle], key); //array[middle].CompareTo(key);
                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException("Transmission type is not implemente logic comparison.");
                }
                if (comp > 0)
                {
                    right = middle - 1;
                }
                else if (comp < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    return middle;
                }
            }
            throw new KeyNotFoundException("There is no such key in the array.");
        }
    }
}
