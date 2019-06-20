using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Determines if a number is composed of 2's and/or 5's
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>True if n is composed of 2's and/or 5's</returns>
        static bool isComposedOf2and5(int n)
        {
            if (n == 0) return true;
            while (n % 2 == 0) n /= 2;
            while (n % 5 == 0) n /= 5;
            return n == 1;
        }

        /// <summary>
        /// Calculates the sum of all the primes below 100,000 that will never be a factor of R(10^n)
        /// </summary>
        static void P133()
        {
            Console.WriteLine((from p in Functions.getPrimesList(100000) where Functions.getGCD(10, p) == 1 && !isComposedOf2and5(Functions.getMultiplicativeOrder(10, p)) select p).Sum() + 10);
        }
    }
}
