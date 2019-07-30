using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Dictionary used to memoize the Tribonacci sequence
        /// </summary>
        static IDictionary<int, BigInteger> TribonacciDict = new Dictionary<int, BigInteger>() { { 1, 1 }, { 2, 1 }, { 3, 1 } };

        /// <summary>
        /// Gets the nth Tribonacci number via memoization
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>The nth Tribonacci number</returns>
        static BigInteger getTribonacci(int n)
        {
            if (!TribonacciDict.ContainsKey(n))
                TribonacciDict[n] = getTribonacci(n - 1) + getTribonacci(n - 2) + getTribonacci(n - 3);
            return TribonacciDict[n];
        }

        /// <summary>
        /// Calculates the 124th odd number that does not divide any terms in the Tribonacci sequence
        /// </summary>
        static void P225()
        {
            int count = 0;
            for (int i = 1; i <= 100; i++)
                getTribonacci(230 * i);
            foreach (int ans in (from i in Enumerable.Range(27, 6642) where i % 2 == 1 select i))
            {
                bool divide = false;
                foreach (BigInteger t in TribonacciDict.Values)
                    if (t % ans == 0)
                    {
                        divide = true;
                        break;
                    }
                if (!divide) count++;
                if (count == 124)
                {
                    Console.WriteLine(ans);
                    break;
                }
            }
        }
    }
}