using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortUtil
{
    public static class SortHelper
    {
        #region Public methods

        /// <summary>
        /// Sorts int[][] rows by sum
        /// </summary>
        /// <param name="matrix">matrix</param>
        /// <param name="ascending">is ascending order</param>
        public static void SortRowsBySum(int[][] matrix, bool ascending)
        {
            Comparison<int[]> comparison;

            if (ascending)
            {
                comparison = (a, b) => { return a.Sum() - b.Sum(); };
            }
            else
            {
                comparison = (a, b) => { return b.Sum() - a.Sum(); };
            }

            SortRows<int>(matrix, comparison);
        }

        /// <summary>
        /// Sorts int[][] rows by minimum element
        /// </summary>
        /// <param name="matrix">matrix</param>
        /// <param name="ascending">is ascending order</param>
        public static void SortRowsByMinElement(int[][] matrix, bool ascending)
        {
            Comparison<int[]> comparison;

            if (ascending)
            {
                comparison = (a, b) => { return a.Min() - b.Min(); };
            }
            else
            {
                comparison = (a, b) => { return b.Min() - a.Min(); };
            }

            SortRows<int>(matrix, comparison);
        }

        /// <summary>
        /// Sorts int[][] rows by maximum element
        /// </summary>
        /// <param name="matrix">matrix</param>
        /// <param name="ascending">is ascending order</param>
        public static void SortRowsByMaxElement(int[][] matrix, bool ascending)
        {
            Comparison<int[]> comparison;

            if (ascending)
            {
                comparison = (a, b) => { return a.Max() - b.Max(); };
            }
            else
            {
                comparison = (a, b) => { return b.Max() - a.Max(); };
            }

            SortRows<int>(matrix, comparison);
        }

        /// <summary>
        /// Sorts T[][] rows using a comparison method
        /// </summary>
        /// <typeparam name="T">matrix element</typeparam>
        /// <param name="matrix">matrix</param>
        /// <param name="comparison">comparison method</param>
        public static void SortRows<T>(T[][] matrix, Comparison<T[]> comparison)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("matrix");
            }
            if (comparison == null)
            {
                throw new ArgumentNullException("comparison");
            }

            MergeSort(matrix, 0, matrix.Length - 1, comparison);
        }

        /// <summary>
        /// Sorts T[][] rows using a comparer
        /// </summary>
        /// <typeparam name="T">matrix element</typeparam>
        /// <param name="matrix">matrix</param>
        /// <param name="comparer">comparer</param>
        public static void SortRows<T>(T[][] matrix, IComparer<T[]> comparer)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("matrix");
            }
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            MergeSort(matrix, 0, matrix.Length - 1, comparer.Compare);
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Sorts T[][] rows using Merge sort algorithm
        /// </summary>
        /// <typeparam name="T">matrix element</typeparam>
        /// <param name="matrix">matrix</param>
        /// <param name="left">left sort bound</param>
        /// <param name="right">right sort bound</param>
        /// <param name="comparison">comparison method</param>
        private static void MergeSort<T>(T[][] matrix, int left, int right, Comparison<T[]> comparison)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(matrix, left, middle, comparison);
                MergeSort(matrix, middle + 1, right, comparison);
                Merge(matrix, left, middle, right, comparison);
            }
        }

        /// <summary>
        /// Merges two subarrays
        /// </summary>
        /// <typeparam name="T">matrix element</typeparam>
        /// <param name="matrix">matrix</param>
        /// <param name="left">left merge bound</param>
        /// <param name="middle">middle</param>
        /// <param name="right">right merge bound</param>
        /// <param name="comparison">comparison method</param>
        private static void Merge<T>(T[][] matrix, int left, int middle, int right, Comparison<T[]> comparison)
        {
            T[][] leftSubItems = new T[middle - left + 1][];
            Array.Copy(matrix, left, leftSubItems, 0, leftSubItems.Length);
            T[][] rightSubItems = new T[right - middle][];
            Array.Copy(matrix, middle + 1, rightSubItems, 0, rightSubItems.Length);

            int j = 0, k = 0;

            for (int i = left; i < right + 1; i++)
            {
                if (k >= rightSubItems.Length ||
                    (j < leftSubItems.Length &&
                    comparison(leftSubItems[j], rightSubItems[k]) < 0))
                {
                    matrix[i] = leftSubItems[j];
                    j++;
                }
                else
                {
                    matrix[i] = rightSubItems[k];
                    k++;
                }
            }
        }
        #endregion
    }
}
