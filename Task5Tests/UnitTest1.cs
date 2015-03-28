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
            var matrixleft = new SquareMatrix<int>(new int[3, 3] { { 3, 4, 0 }, { 0, 4, 0 }, { 0, 0, 15 } });
            var matrixright = new SymmetricMatrix<int>(new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } });
            IMatrix<int> value = matrixleft;
            value.Add<int>(matrixright, (int x, int y) => { return x + y; });
            var expected = new SquareMatrix<int>(new int[3, 3] { { 4, 5, 1 }, { 1, 5, 1 }, { 1, 1, 16 } });
            Assert.IsTrue(CompareMatrix(expected, value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MatrixHelperExceptionTest()
        {
            var matrixleft = new SquareMatrix<int>(new int[3, 3] { { 3, 4, 0 }, { 0, 4, 0 }, { 0, 0, 15 } });
            var matrixright = new SymmetricMatrix<int>(new int[4, 4] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } });
            IMatrix<int> value = matrixleft;
            value.Add<int>(matrixright, (int x, int y) => { return x + y; });
        }

        private bool CompareMatrix(IMatrix<int> matrixLeft, IMatrix<int> matrixRight)
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
