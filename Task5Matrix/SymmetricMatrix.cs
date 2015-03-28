using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Matrix
{
    public class SymmetricMatrix<T> : SquareMatrix<T> where T : IComparable<T>
    {
        protected SymmetricMatrix(): base() {  }
        public SymmetricMatrix(T[,] matrix): base()
        {
            if (!CheckMatrix(matrix)) throw new ArgumentException("This matrix is not symmetric.");
            this.matrix = new T[Length, Length];
            Array.Copy(matrix, this.matrix, matrix.Length);
        }

        private bool CheckMatrix(T[,] matrix)
        {
            Length = (int)Math.Pow((double)matrix.Length, 0.5);
            if (Length * Length != matrix.Length) return false;
            for (int i = 0; i < Length; ++i)
                for (int j = i + 1; j < Length; ++j)
                {
                    if ( matrix[i, j].CompareTo(matrix[j, i]) != 0) return false;
                }
            return true;
        }
    }
}
