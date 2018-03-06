using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the smallest integer that can be the length of a cathetus of exactly 47,547 different integer sided right-angled triangles
        /// </summary>
        static void P176()
        {
            int n = 47547;
            List<long> primes = Functions.getPrimesList(50);
            List<long> P = Functions.getPrimeFactors(2 * n + 1);
            P.Reverse();
            Console.WriteLine((from p in P.Skip(1) select Math.Pow(primes[P.IndexOf(p)], (p - 1) / 2)).Aggregate(Math.Pow(2, (P[0] + 1) / 2), (a, x) => a * x));
        }
    }
}