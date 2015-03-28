using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Queue;

namespace Task2UI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas1 = { 1, 2, 3, 4 };
            int[] mas2 = { 5, 6, 7, 8 };
            int[] mas3 = { 9, 0, 1, 2 };
            int[] mas4 = { 0, 6, 7, 9 };
            int[] mas5 = { 0, 6, 7, 9 };

            CustomQueue<int[]> testQueue = new CustomQueue<int[]>();
            testQueue.Enqueue(mas1);
            testQueue.Enqueue(mas2);
            testQueue.Enqueue(mas3);
            testQueue.Dequeue();
            testQueue.Enqueue(mas4);
            //Console.WriteLine(string.Join(",", testQueue.Dequeue()));
            //Console.WriteLine(string.Join(",", testQueue.Dequeue()));
            //Console.WriteLine(string.Join(",", testQueue.Dequeue()));
            //Console.WriteLine();
            foreach (var a in testQueue)
            {
                Console.WriteLine(string.Join(",", a));
            }
        }
    }
}
