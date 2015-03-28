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
        public static void Add<T>(this IMatrix<T> matrixleft, IMatrix<T> matrixright, Func <T,T,T> addLogic)
        {
            if (matrixright == null || addLogic == null || (matrixleft.Length != matrixright.Length)) throw new ArgumentException();
            for (int i = 0; i < matrixleft.Length; ++i)
            {
                for (int j = 0; j < matrixleft.Length; ++j)
                {
                    matrixleft[i, j] = addLogic(matrixleft[i, j],matrixright[i, j]);
                }
            }
        }
    }
}
