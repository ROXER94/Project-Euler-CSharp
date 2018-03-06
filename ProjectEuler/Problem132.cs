using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the first forty prime factors of R(10^9)
        /// </summary>
        static void P132()
        {
            long ans = 0;
            int count = 0;
            foreach (long p in Functions.getPrimesList(200000))
            {
                if (count == 40) break;
                if (BigInteger.ModPow(10, BigInteger.Pow(10, 9), 9 * p) == 1)
                {
                    ans += p;
                    count++;
                }
            }
            Console.WriteLine(ans);
        }
    }
}