using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the smallest odd composite that cannot be written as the sum of a prime and twice a square
        /// </summary>
        static void P046()
        {
            HashSet<int> primes = new HashSet<int> { 2 };
            HashSet<int> composites = new HashSet<int>();
            for (int i = 3; i <= 10000; i += 2)
            {
                if (Functions.isPrime(i)) primes.Add(i);
                else composites.Add(i);
            }
            var doubleSquares = from i in Enumerable.Range(1, 70) select 2 * i * i;
            HashSet<int> Goldbach = new HashSet<int>();
            foreach (int p in primes)
                foreach (int ds in doubleSquares)
                    if (!Goldbach.Contains(p + ds) && (p + ds) % 2 != 0 && !Functions.isPrime(p + ds))
                        Goldbach.Add(p + ds);
            Console.WriteLine(composites.Except(Goldbach).First());
        }
    }
}