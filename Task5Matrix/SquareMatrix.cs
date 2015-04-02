using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Matrix
{
    public class SquareMatrix<T> : ISquareMatrix<T> where T : IComparable<T>
    {
        private T[] matrix;
        public int Length { get; set; }
        public MatrixChangeEvent mce { get; set; }

        public SquareMatrix(T[] matrix)
        {
            if (matrix == null) throw new ArgumentNullException();
            if (!CheckMatrix(matrix.Length)) throw new ArgumentException("This matrix is not Square.");
            this.matrix = new T[matrix.Length];
            Array.Copy(matrix, this.matrix, matrix.Length);
            mce = new MatrixChangeEvent();
            mce.Change += SomeAction;
        }

        public SquareMatrix(int length)
        {
            this.matrix = new T[length * length];
            Length = length;
            mce = new MatrixChangeEvent();
            mce.Change += SomeAction;
        }

        public T this[int x, int y]
        {
            get
            {
                if (x >= Length || y >= Length || x < 0 || y < 0) throw new ArgumentException();
                return matrix[x * Length + y];
            }
            set
            {
                if (x >= Length || y >= Length || x < 0 || y < 0) throw new ArgumentException();
                matrix[x * Length + y] = value;
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
            Length = (int)Math.Pow((double)matrixLength, 0.5);
            if (Length * Length == matrixLength)
            {
                return true;
            }
            else return false;
        }
    }
}
