using ProjectEuler.Common;
using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the number of bouncy numbers below 10 raised to a number
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>The number of bouncy below 10^n</returns>
        static BigInteger getBouncy(int n)
        {
            return BigInteger.Pow(10, n) - Functions.getnCk(9 + n, n) - (from i in Enumerable.Range(1, n) select Functions.getnCk(9 + i, i)).Aggregate((sum, next) => sum + next) + 10 * n;
        }

        /// <summary>
        /// Calculates the number of non-bouncy numbers under a googol
        /// </summary>
        static void P113()
        {
            Console.WriteLine(BigInteger.Pow(10, 100) - getBouncy(100) - 1);
        }
    }
}