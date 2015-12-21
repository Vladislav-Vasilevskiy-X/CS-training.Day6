using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMath
{
    public class GCD
    {
        #region Public methods
        
        /// <summary>
        /// Returns estimated time for computing GCD of two numbers in timer tics
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="algorithm">algorithm to use</param>
        /// <returns></returns>
        public static long GetEstimatedComputingTime(int a, int b, Func<int, int, int> algorithm)
        {
            if (algorithm == null)
            {
                throw new ArgumentNullException("algorithm");
            }

            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Restart();
            algorithm(a, b);
            timer.Stop();

            return timer.ElapsedTicks;
        }

        /// <summary>
        /// Returns the greatest common divisor of two numbers using the specified algorithm
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="algorithm">algorithm to use</param>
        /// <returns></returns>
        public static int GreatestCommonDivisor(int a, int b, Func<int, int, int> algorithm)
        {
            if (algorithm == null)
            {
                throw new ArgumentNullException("algorithm");
            }

            return algorithm(a, b);
        }

        /// <summary>
        /// Returns the greatest common divisor of several numbers using the specified algorithm
        /// </summary>
        /// <param name="algorithm">algorithm to use</param>
        /// <param name="numbers">numbers</param>
        /// <returns></returns>
        public static int GreatestCommonDivisor(Func<int, int, int> algorithm, params int[] numbers)
        {
            int numbersMinimumQuantity = 2;

            if (algorithm == null)
            {
                throw new ArgumentNullException("algorithm");
            }

            if (numbers == null)
            {
                throw new ArgumentNullException("numbers");
            }

            if (numbers.Length < numbersMinimumQuantity)
            {
                throw new ArgumentException("At least two numbers must be passed to calculate the GCD");
            }

            int gcd = algorithm(numbers[0], numbers[1]);

            for (int i = 2; i < numbers.Length; i++)
            {
                gcd = algorithm(gcd, numbers[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Returns the greatest common divisor of two numbers
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns></returns>
        public static int GreatestCommonDivisorEuclidean(int a, int b)
        {
            a = a >= 0 ? a : -a;
            b = b >= 0 ? b : -b;

            return b == 0 ? a : GreatestCommonDivisorEuclidean(b, a % b);
        }

        /// <summary>
        /// Returns the greatest common divisor of two numbers
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns></returns>
        public static int GreatestCommonDivisorBinary(int a, int b)
        {
            a = a >= 0 ? a : -a;
            b = b >= 0 ? b : -b;
            int shift = 0;

            if (a == b || a == 0 || b == 0)
            {
                return a | b;
            }

            for (shift = 0; ((a | b) & 1) == 0; shift++)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    int c = b;
                    b = a;
                    a = c;
                }

                b = b - a;
            } while (b != 0);

            return a << shift;
        }
        #endregion
    }
}
