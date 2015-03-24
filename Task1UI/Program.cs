using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1Iterator;
using Task1IteratorLogic;

namespace Task1UI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listInt = new List<int>();
            for (int i = 0; i < 20; ++i) { listInt.Add(i); }
            IEnumerable<int> enumeratorDemo = listInt.GetIterator(IteratorLogic.OddIndexes);
            foreach (var i in enumeratorDemo)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            enumeratorDemo = listInt.GetIterator(IteratorLogic.ThroughTwoElements);
            foreach (var i in enumeratorDemo)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            List<String> listString = new List<String>();
            listString.Add("Mark");
            listString.Add("Liza");
            listString.Add("Paul");
            listString.Add("Andrew");
            listString.Add("Anna");
            listString.Add("Jillian");
            listString.Add("Maria");
            listString.Add("Oleg");
            listString.Add("Polina");
            IEnumerable<String> enumeratorDemoString = listString.GetIterator(IteratorLogic.EvenIndexes);
            foreach (var i in enumeratorDemoString)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            enumeratorDemoString = listString.GetIterator(IteratorLogic.ThroughTwoElements);
            foreach (var i in enumeratorDemoString)
            {
                Console.WriteLine(i);
            }

        }
    }
}
