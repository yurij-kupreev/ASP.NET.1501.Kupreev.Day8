using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5Matrix;
using Task5MatrixGenerator;

namespace Task5UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new SquareMatrix<int>(MatrixGenerator.GenerateIntSquareMatrix(5));
            a[3, 3] = 5;
            a[2, 4] = 3;
            Print(a, 5);
            Console.WriteLine();
            var b = new SymmetricMatrix<int>(MatrixGenerator.GenerateIntSymmetricMatrix(5));
            b[1, 0] = 5;
            b[2, 1] = 3;
            Print(b, 5);
            Console.WriteLine();
            var c = new DiagonalMatrix<int>(MatrixGenerator.GenerateIntDiagonalMatrix(5));
            c[0, 0] = 5;
            c[1, 1] = 3;
            Print(c, 5);
        }

        static void Print(IMatrix<int> matrix, int size)
        {
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
