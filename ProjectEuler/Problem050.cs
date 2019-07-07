using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the prime below 1,000,000 that can be written as the sum of the most consecutive primes
        /// </summary>
        static void P050()
        {
            int ans = 0;
            List<int> primes = new List<int> { 2 };
            int n = 3;
            while (primes.Sum() < 1000000)
            {
                if (Functions.isPrime(n))
                    primes.Add(n);
                n += 2;
            }
            primes.RemoveAt(primes.Count - 1);
            int index = 0;
            int maximumCount = 0;
            while (index != primes.Count)
            {
                int sum = 0;
                List<int> accumulated = (primes.GetRange(index, primes.Count - index)).Select(w => sum += w).ToList();
                var newPrimes = from j in
                                    (from i in accumulated
                                     where i % 2 != 0 && i % 5 != 0
                                     select i)
                                where Functions.isPrime(j)
                                select j;
                int currentCount = accumulated.IndexOf(newPrimes.Last()) + 1;
                if (currentCount > maximumCount)
                {
                    maximumCount = currentCount;
                    ans = newPrimes.Last();
                }
                index++;
            }
            Console.WriteLine(ans);
        }
    }
}