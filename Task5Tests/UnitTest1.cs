using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5Matrix;
using Task5MatrixGenerator;
using Task5MatrixHelper;

namespace Task5Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MatrixHelperAddTest()
        {
            var matrixleft = new SquareMatrix<int>(new int[9] { 3, 4, 0, 0, 4, 0, 0, 0, 15 });
            var matrixright = new SymmetricMatrix<int>(new int[6] { 1, 1, 1, 1, 1, 1 });
            var newMatrix = new SquareMatrix<int>(3);
            ISquareMatrix<int> result = newMatrix;
            MatrixHelper.Add<int>((ISquareMatrix<int>)matrixleft, (ISquareMatrix<int>)matrixright, result);
            var expected = new SquareMatrix<int>(new int[9] { 4, 5, 1, 1, 5, 1, 1, 1, 16 });
            Assert.IsTrue(CompareMatrix((ISquareMatrix<int>)expected, result));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MatrixHelperExceptionTest()
        {
            var matrixleft = new SquareMatrix<int>(new int[9] { 3, 4, 0, 0, 4, 0, 0, 0, 15 });
            var matrixright = new SymmetricMatrix<int>(new int[3] { 1, 1, 1 });
            var newMatrix = new SquareMatrix<int>(3);
            ISquareMatrix<int> result = newMatrix;
            MatrixHelper.Add<int>((ISquareMatrix<int>)matrixleft, (ISquareMatrix<int>)matrixright, result);
        }

        private bool CompareMatrix(ISquareMatrix<int> matrixLeft, ISquareMatrix<int> matrixRight)
        {
            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                {
                    if (matrixLeft[i, j] != matrixRight[i, j]) return false;
                }
            return true;
        }
    }
}
