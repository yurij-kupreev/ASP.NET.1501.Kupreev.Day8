using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Matrix
{
    public sealed class DiagonalMatrix<T> : ISquareMatrix<T> where T : IComparable<T>
    {
        private T[] matrix;
        public int Length { get; set; }
        public MatrixChangeEvent mce { get; set; }
        private DiagonalMatrix() { }
        public DiagonalMatrix(T[] matrix)
        {
            if (matrix == null) throw new ArgumentNullException();
            if (!CheckMatrix(matrix.Length)) throw new ArgumentException("This matrix is not diagonal.");
            this.matrix = new T[matrix.Length];
            Array.Copy(matrix, this.matrix, matrix.Length);
            mce = new MatrixChangeEvent();
            mce.Change += SomeAction;
        }

        public DiagonalMatrix(int length)
        {
            this.matrix = new T[length];
            Length = length;
            mce = new MatrixChangeEvent();
            mce.Change += SomeAction;
        }

        public T this[int x, int y]
        {
            get
            {
                if (x >= Length || y >= Length || x < 0 || y < 0) throw new ArgumentException();
                if (x == y)
                    return matrix[x];
                else return default(T);
            }
            set
            {
                if ((x >= Length || y >= Length || x < 0 || y < 0) && x != y) throw new ArgumentException();
                matrix[x] = value;
                mce.ChangedElement(x, y);
            }
        }

        public T[] getMatrix()
        {
            return matrix;
        }

        private void SomeAction(Object sender, ChangeEventArgs eventArgs)
        {
            Console.WriteLine("Changed element at position " + eventArgs.X + " " + eventArgs.Y);
        }

        public bool CheckMatrix(int matrixLength)
        {
            Length = matrixLength;
            return true;
        }
    }
}
