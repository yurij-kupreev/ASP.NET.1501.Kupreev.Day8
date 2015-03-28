using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Matrix
{
    public class SquareMatrix<T> : IMatrix<T> where T : IComparable<T>
    {
        protected T[,] matrix;
        public int Length { get; set; }
        protected readonly MatrixChangeEvent mce;

        public SquareMatrix(T[,] matrix)
        {
            if (!CheckMatrix(matrix)) throw new ArgumentException("This matrix is not Square.");
            this.matrix = new T[Length, Length];
            Array.Copy(matrix, this.matrix, matrix.Length);
            mce = new MatrixChangeEvent();
            mce.Change += SomeAction;
        }

        protected SquareMatrix()
        {
            mce = new MatrixChangeEvent();
            mce.Change += SomeAction;
        }

        public T this[int x, int y]
        {
            get
            {
                if (x >= Length || y >= Length || x < 0 || y < 0) throw new ArgumentException();
                return matrix[x, y];
            }
            set
            {
                if (x >= Length || y >= Length || x < 0 || y < 0) throw new ArgumentException();
                matrix[x, y] = value;
                mce.ChangedElement(x, y);
            }
        }

        public T[,] getMatrix()
        {
            return matrix;
        }

        protected void SomeAction(Object sender, ChangeEventArgs eventArgs)
        {
            Console.WriteLine("Changed element at position " + eventArgs.X + " " + eventArgs.Y);
        }

        private bool CheckMatrix(T[,] matrix)
        {
            Length = (int)Math.Pow((double)matrix.Length, 0.5);
            if (Length * Length == matrix.Length) return true;
            else return false;
        }
    }
}
