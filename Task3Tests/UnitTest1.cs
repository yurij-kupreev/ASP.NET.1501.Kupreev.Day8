using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3BinarySearch;
using Task3Comparators;

namespace Task3Tests
{
    [TestClass]
    public class UnitTest1
    {
        int[][] matrix;
        int[] newarray;
        [TestMethod]
        public void BinarySearchTest()
        {
            Initialize();
            var actual = BinarySearch.Search<int[]>(matrix, newarray, Comparators.CompareIntArrays);
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BinarySearchTest2()
        {
            int[] a = new int[] { 1, 2, 3 };
            var actual = BinarySearch.Search<int>(a, 2);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BinarySearchTestException()
        {
            Initialize();
            var actual = BinarySearch.Search<int[]>(matrix, newarray);
        }
        private void Initialize()
        {
            int[] array = new int[50];
            newarray = new int[50];
            int[] array2 = new int[40];
            int[] array3 = new int[30];
            matrix = new int[3][];
            matrix[0] = array3;
            matrix[1] = array2;
            matrix[2] = array;
            for (int i = 0; i < 50; ++i)
            {
                array[i] = i + 2;
                newarray[i] = i + 2;
            }
        }
    }
}
