using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of semiprimes below 100,000,000
        /// </summary>
        static void P187()
        {
            int ans = 0;
            int limit = 100000000;
            long[] primes = Functions.getPrimesList(limit / 2).ToArray();
            for (int i = 0; primes[i] < Math.Sqrt(limit); i++)
                for (int j = i; j < primes.Length; j++)
                {
                    if (primes[i] * primes[j] >= limit) break;
                    ans++;
                }
            Console.WriteLine(ans);
        }
    }
}