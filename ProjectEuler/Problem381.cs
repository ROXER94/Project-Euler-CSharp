using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of S(p) for primes between 5 and 100,000,000
        /// </summary>
        static void P381()
        {
            long ans = 0;
            var primes = Functions.getPrimesList(100000000);
            primes.Remove(2);
            primes.Remove(3);
            foreach (int p in primes)
            {
                int modInverse = -3 * Functions.getModInverse(8, p);
                ans += (long)(modInverse - p * Math.Floor((double)modInverse / p));
            }
            Console.WriteLine(ans);
        }
    }
}