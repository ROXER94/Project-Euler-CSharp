using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the sum of integers divisible by a number up to and including a limit
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>The sum of integers divisible by n up to and including a limit</returns>
        static int getSumDivisibleBy(int n, int limit)
        {
            int p = limit / n;
            return n * p * (p + 1) / 2;
        }

        /// <summary>
        /// Calculates the sum of all the multiples of 3 or 5 below 1000
        /// </summary>
        static void P001()
        {
            int limit = 999;
            Console.WriteLine(getSumDivisibleBy(3, limit) + getSumDivisibleBy(5, limit) - getSumDivisibleBy(15, limit));
        }
    }
}