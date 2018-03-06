using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the admissable numbers
        /// </summary>
        /// <param name="index">Int</param>
        /// <param name="product">Long</param>
        /// <param name="limit">Int</param>
        /// <param name="primes">List</param>
        /// <returns>The even positive integers if it is a power of 2 or its distinct prime factors are consecutive primes</returns>
        static IEnumerable<int> getAdmissable(int index, long product, int limit, List<long> primes)
        {
            if (index == primes.Count) yield break;
            while (product <= limit)
            {
                product *= primes[index];
                if (product < limit)
                    yield return (int)product;
                foreach (int i in getAdmissable(index + 1, product, limit, primes))
                    yield return i;
            }
        }

        /// <summary>
        /// Calculates the sum of all distinct pseudo-Fortunate numbers for admissible numbers less than 10^9
        /// </summary>
        static void P293()
        {
            HashSet<int> ans = new HashSet<int>();
            var admissable = getAdmissable(0, 1, 1000000000, Functions.getPrimesList(24));
            foreach (int i in admissable)
            {
                int j = 3;
                while (true)
                {
                    if (Functions.isPrime(i + j)) break;
                    j += 2;
                }
                ans.Add(j);
            }
            Console.WriteLine(ans.Sum());
        }
    }
}