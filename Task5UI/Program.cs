using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Task5Matrix;
using Task5MatrixGenerator;
using Task5MatrixHelper;

namespace Task5UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new SquareMatrix<int>(MatrixGenerator.GenerateIntSquareMatrix(5));
            a[3, 3] = 5;
            a[2, 4] = 3;
            Print(a);
            Console.WriteLine();
            var b = new SymmetricMatrix<int>(MatrixGenerator.GenerateIntSymmetricMatrix(5));
            b[1, 0] = 5;
            b[2, 1] = 3;
            Print(b);
            Console.WriteLine();
            var c = new DiagonalMatrix<int>(MatrixGenerator.GenerateIntDiagonalMatrix(5));
            c[0, 0] = 5;
            c[1, 1] = 3;
            Print(c);
        }

        static void Print(ISquareMatrix<int> matrix)
        {
            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix.Length; ++j)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
