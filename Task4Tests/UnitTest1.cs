using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4Fibanacci;

namespace Task4Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FibonacciSumTest()
        {
            var actual = FibonacciHelper.FibonacciSum(6);
            var expected = 12;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FibonacciSumExceptionTest()
        {
            FibonacciHelper.FibonacciSum(0);
        }
    }
}
