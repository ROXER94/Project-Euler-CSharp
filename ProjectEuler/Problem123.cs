using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the smallest value of n for which the remainder first exceeds 10^10 in the equation (p(n)-1)^n + (p(n)+1)^n % p(n)^2
        /// </summary>
        static void P123()
        {
            int ans = 7037;
            List<long> primes = Functions.getPrimesList(300000);
            while (2 * (ans + 1) * primes[ans] < 10000000000)
                ans += 2;
            Console.WriteLine(ans + 2);
        }
    }
}