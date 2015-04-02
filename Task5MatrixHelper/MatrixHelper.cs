using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5Matrix;

namespace Task5MatrixHelper
{
    public static class MatrixHelper
    {
        public static void Add<T>(ISquareMatrix<T> matrixleft, ISquareMatrix<T> matrixright, ref ISquareMatrix<T> result)
        {
            if (matrixleft == null || matrixright == null || result == null || matrixleft.Length != matrixright.Length
                || matrixleft.Length != result.Length) 
                throw new ArgumentException();
            for (int i = 0; i < matrixleft.Length; ++i)
            {
                for (int j = 0; j < matrixleft.Length; ++j)
                {
                    try
                    {
                        result[i, j] = (dynamic)matrixleft[i, j] + matrixright[i, j];
                    }
                    catch (Exception e)
                    {
                        throw new ArgumentException("Invalid operation");
                    }
                }
            }
        }
    }
}
