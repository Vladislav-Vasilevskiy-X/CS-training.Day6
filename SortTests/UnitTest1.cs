using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortUtil;
using System.Linq;
using System.Collections.Generic;

namespace SortTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SortRowsBySumAscendingOrder()
        {
            int[][] matrix = { new int[] { 8, 10, -4 },
                new int[] { 4, 1, 6, 4 },
                new int[] { 7, -1, 9 } };

            SortHelper.SortRowsBySum(matrix, true);

            Assert.AreEqual(true, matrix[0].Sum() <= matrix[1].Sum() && matrix[1].Sum() <= matrix[2].Sum());
        }

        [TestMethod]
        public void SortRowsBySumDescendingOrder()
        {
            int[][] matrix = { new int[] { 8, 10, -4 },
                new int[] { 4, 1, 6, 4 },
                new int[] { 7, -1, 9 } };

            SortHelper.SortRowsBySum(matrix, false);

            Assert.AreEqual(true, matrix[0].Sum() >= matrix[1].Sum() && matrix[1].Sum() >= matrix[2].Sum());
        }

        [TestMethod]
        public void SortRowsByMinAscendingOrder()
        {
            int[][] matrix = { new int[] { 8, 10, -4 },
                new int[] { 4, 1, 6, 4 },
                new int[] { 7, -1, 9 } };

            SortHelper.SortRowsByMinElement(matrix, true);

            Assert.AreEqual(true, matrix[0].Min() <= matrix[1].Min() && matrix[1].Min() <= matrix[2].Min());
        }

        [TestMethod]
        public void SortRowsByMinDescendingOrder()
        {
            int[][] matrix = { new int[] { 8, 10, -4 },
                new int[] { 4, 1, 6, 4 },
                new int[] { 7, -1, 9 } };

            SortHelper.SortRowsByMinElement(matrix, false);

            Assert.AreEqual(true, matrix[0].Min() >= matrix[1].Min() && matrix[1].Min() >= matrix[2].Min());
        }

        [TestMethod]
        public void SortRowsByMaxAscendingOrder()
        {
            int[][] matrix = { new int[] { 8, 10, -4 },
                new int[] { 4, 1, 6, 4 },
                new int[] { 7, -1, 9 } };

            SortHelper.SortRowsByMaxElement(matrix, true);

            Assert.AreEqual(true, matrix[0].Max() <= matrix[1].Max() && matrix[1].Max() <= matrix[2].Max());
        }

        [TestMethod]
        public void SortRowsByMaxDescendingOrder()
        {
            int[][] matrix = { new int[] { 8, 10, -4 },
                new int[] { 4, 1, 6, 4 },
                new int[] { 7, -1, 9 } };

            SortHelper.SortRowsByMaxElement(matrix, false);

            Assert.AreEqual(true, matrix[0].Max() >= matrix[1].Max() && matrix[1].Max() >= matrix[2].Max());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortRowsComparisonNullMatrix()
        {
            int[][] matrix = null;

            SortHelper.SortRows<int>(matrix, (a, b) => a.Max() - b.Max());

            Assert.AreEqual(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortRowsComparerNullMatrix()
        {
            int[][] matrix = null;

            SortHelper.SortRows(matrix, Comparer<int[]>.Create((a, b) => a.Max() - b.Max()));

            Assert.AreEqual(null, null);
        }
    }

}
