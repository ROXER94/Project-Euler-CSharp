using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Determines if a number is a prime generating integer
        /// </summary>
        /// <param name="n">Int</param>
        /// <param name="primesDict">IDictionary</param>
        /// <returns>True if n is a prime generating integer</returns>
        static bool isPrimeGeneratingInteger(int n, IDictionary<long, bool> primesDict)
        {
            for (int d = 1; d <= Math.Pow(n, .5); d++)
                if (n % d == 0 && !primesDict.ContainsKey(d + n / d)) return false;
            return true;
        }

        /// <summary>
        /// Calculates the sum of all positive integers n below 100,000,000 such that the sum of each pair of factors of n is prime
        /// </summary>
        static void P357()
        {
            IDictionary<long, bool> primesDict = Functions.getPrimesDict(100000000);
            Console.WriteLine((from i in Enumerable.Range(2, 100000000) where i % 4 == 2 && primesDict.ContainsKey(i + 1) && isPrimeGeneratingInteger(i, primesDict) select (long)i).Sum() + 1);
        }
    }
}