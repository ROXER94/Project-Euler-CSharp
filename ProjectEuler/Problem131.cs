using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of primes below 1,000,000 where n^3 + p*n^2 is a perfect cube
        /// </summary>
        static void P131()
        {
            IDictionary<long, bool> primesDict = Functions.getPrimesDict(1000000);
            Console.WriteLine((from n in Enumerable.Range(0, 1000) where primesDict.ContainsKey(3 * n * n + 3 * n + 1) select 1).Count());
        }
    }
}