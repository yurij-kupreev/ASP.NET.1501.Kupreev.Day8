using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5MatrixGenerator
{
    public static class MatrixGenerator
    {
        public static int[,] GenerateIntSymmetricMatrix(int dimension)
        {
            int[,] matrix = new int[dimension, dimension];
            Random rn = new Random();
            for (int i = 0; i < dimension; ++i)
                for (int j = i; j < dimension; ++j)
                {
                    matrix[i,j] = rn.Next(-10, 10);
                    if (i != j) matrix[j,i] = matrix[i,j];
                }
            return matrix;
        }

        public static int[,] GenerateIntDiagonalMatrix(int dimension)
        {
            int[,] matrix = new int[dimension, dimension];
            Random rn = new Random();
            for (int i = 0; i < dimension; ++i)
                matrix[i, i] = rn.Next(-10, 10);
            return matrix;
        }

        public static int[,] GenerateIntSquareMatrix(int dimension)
        {
            int[,] matrix = new int[dimension, dimension];
            Random rn = new Random();
            for (int i = 0; i < dimension; ++i)
                for (int j = 0; j < dimension; ++j)
                {
                    matrix[i, j] = rn.Next(-10, 10);
                }
            return matrix;
        }
    }
}
