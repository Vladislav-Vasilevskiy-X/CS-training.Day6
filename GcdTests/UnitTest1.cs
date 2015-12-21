using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomMath;

namespace GcdTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GreatestCommonDivisorEuclideanOneNegative()
        {
            int gcd = GCD.GreatestCommonDivisorEuclidean(30, -15);
            int expected = 15;

            Assert.AreEqual(expected, gcd);
        }

        [TestMethod]
        public void GreatestCommonDivisorEuclideanBothNegative()
        {
            int gcd = GCD.GreatestCommonDivisorEuclidean(-1, -15);
            int expected = 1;

            Assert.AreEqual(expected, gcd);
        }

        [TestMethod]
        public void GreatestCommonDivisoEuclideanrBothPositive()
        {
            int gcd = GCD.GreatestCommonDivisorEuclidean(1024, 384);
            int expected = 128;

            Assert.AreEqual(expected, gcd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GreatestCommonDivisorNullArray()
        {
            int gcd = GCD.GreatestCommonDivisor(GCD.GreatestCommonDivisorEuclidean, null);
            int expected = 1;

            Assert.AreEqual(expected, gcd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GreatestCommonDivisorOneNumber()
        {
            int gcd = GCD.GreatestCommonDivisor(GCD.GreatestCommonDivisorBinary, 32);
            int expected = 1;

            Assert.AreEqual(expected, gcd);
        }

        [TestMethod]
        public void GreatestCommonDivisorBinaryOneNegative()
        {
            int gcd = GCD.GreatestCommonDivisorBinary(30, -15);
            int expected = 15;

            Assert.AreEqual(expected, gcd);
        }

        [TestMethod]
        public void GreatestCommonDivisorBinaryBothNegative()
        {
            int gcd = GCD.GreatestCommonDivisorBinary(-1, -15);
            int expected = 1;

            Assert.AreEqual(expected, gcd);
        }

        [TestMethod]
        public void GreatestCommonDivisorBinaryBothPositive()
        {
            int gcd = GCD.GreatestCommonDivisorBinary(1024, 384);
            int expected = 128;

            Assert.AreEqual(expected, gcd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetEstimatedComputingTime()
        {
            long time = GCD.GetEstimatedComputingTime(32, 24, null);
            long expected = 1;

            Assert.AreEqual(expected, time);
        }

        [TestMethod]
        public void GetEstimatedComputingTimeEuclideanAlgorithm()
        {
            long time = GCD.GetEstimatedComputingTime(32, 24, GCD.GreatestCommonDivisorEuclidean);

            Assert.AreEqual(true, time >= 0 && time < TimeSpan.TicksPerMillisecond * 100);
        }

        [TestMethod]
        public void GetEstimatedComputingTimeBinaryAlgorithm()
        {
            long time = GCD.GetEstimatedComputingTime(32, 24, GCD.GreatestCommonDivisorBinary);

            Assert.AreEqual(true, time >= 0 && time < TimeSpan.TicksPerSecond);
        }
    }
}
