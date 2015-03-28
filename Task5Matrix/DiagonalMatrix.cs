using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Matrix
{
    public sealed class DiagonalMatrix<T> : SymmetricMatrix<T> where T : IComparable<T>
    {
        private DiagonalMatrix() { }
        public DiagonalMatrix(T[,] matrix) : base()
        {
            if (!CheckMatrix(matrix)) throw new ArgumentException("This matrix is not diagonal.");
            this.matrix = new T[Length, Length];
            Array.Copy(matrix, this.matrix, matrix.Length);
        }

        private bool CheckMatrix(T[,] matrix)
        {
            Length = (int)Math.Pow((double)matrix.Length, 0.5);
            if (Length * Length != matrix.Length) return false;
            for (int i = 0; i < Length; ++i)
                for (int j = 0; j < Length; ++j)
                {
                    if (i != j && matrix[i, j].CompareTo(default(T)) != 0) return false;
                }
            return true;
        }
    }
}
