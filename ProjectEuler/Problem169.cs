using System;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets fusc(n) for Dijkstra's Fusc Function
        /// </summary>
        /// <param name="n">BigInteger</param>
        /// <returns>The nth term in Stern's Diatomic Series</returns>
        static long getFusc(BigInteger n)
        {
            long a = 1;
            long b = 0;
            while (n > 0)
            {
                if (n % 2 == 0) a += b;
                else b += a;
                n /= 2;
            }
            return b;
        }

        /// <summary>
        /// Calculates the number of ways 10^25 can be expressed as a sum of powers of two using each power no more than twice
        /// </summary>
        static void P169()
        {
            Console.WriteLine(getFusc(BigInteger.Pow(10, 25) + 1));
        }
    }
}