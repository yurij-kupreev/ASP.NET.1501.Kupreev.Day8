using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Matrix
{
    public class SymmetricMatrix<T> : ISquareMatrix<T> where T : IComparable<T>
    {
        private T[] matrix;
        public int Length { get; set; }
        public MatrixChangeEvent mce { get; set; }

        public SymmetricMatrix(T[] matrix)
        {
            if (matrix == null) throw new ArgumentNullException();
            if (!CheckMatrix(matrix.Length)) throw new ArgumentException("This matrix is not symmetric.");
            this.matrix = new T[matrix.Length];
            Array.Copy(matrix, this.matrix, matrix.Length);
            mce = new MatrixChangeEvent();
            mce.Change += SomeAction;
        }

        public SymmetricMatrix(int length)
        {
            Length = length;
            int size = 0;
            for (int i = 1; i <= Length; ++i)
            {
                size += i;
            }
            this.matrix = new T[size];
            mce = new MatrixChangeEvent();
            mce.Change += SomeAction;
        }

        public T this[int x, int y]
        {
            get
            {
                if (x >= Length || y >= Length || x < 0 || y < 0) throw new ArgumentException();
                int index;
                if (x <= y) index = CalculateIndex(x, y);
                else index = CalculateIndex(y, x);
                return matrix[index];
            }
            set
            {
                if (x >= Length || y >= Length || x < 0 || y < 0) throw new ArgumentException();
                int index;
                if (x <= y) index = CalculateIndex(x, y);
                else index = CalculateIndex(y, x);
                matrix[index] = value;
                mce.ChangedElement(x, y);
            }
        }

        public T[] getMatrix()
        {
            return matrix;
        }

        private void SomeAction(Object sender, ChangeEventArgs eventArgs)
        {
            Console.WriteLine("Changed element at position " + eventArgs.X + " " + eventArgs.Y
                + " and position " + eventArgs.Y + " " + eventArgs.X);
        }

        private int CalculateIndex(int x, int y)
        {
            int sum = 0;
            for (int i = Length; i > (Length - x); --i)
            {
                sum += i;
            }
            sum += (y - x);
            return sum;
        }

        private bool CheckMatrix(int matrixLength)
        {
            int sum = 0;
            for (int i = 1; i <= matrixLength; ++i)
            {
                sum += i;
                if (sum == matrixLength)
                {
                    Length = i;
                    return true;
                }
            }
            return false;  
        }
    }
}
