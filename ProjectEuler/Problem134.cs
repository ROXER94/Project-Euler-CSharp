using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the prime pair connection for every pair of consecutive primes below 1,000,000
        /// </summary>
        static void P134()
        {
            long ans = 0;
            var primes = Functions.getPrimesList(1000004);
            primes.Remove(2);
            primes.Remove(3);
            for (int i = 0; i < primes.Count - 1; i++)
            {
                long p1 = primes.ElementAt(i);
                long p2 = primes.ElementAt(i + 1);
                ans += Functions.getChineseRemainderTheorem(new List<int> { (int)p2, (int)Math.Pow(10, p1.ToString().Length) }, new List<int> { 0, (int)p1 });
            }
            Console.WriteLine(ans);
        }
    }
}