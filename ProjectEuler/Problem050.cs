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
            long ans = 0;
            List<long> primes = Functions.getPrimesList(1000000);
            long primesSum = 0;
            primes = primes.TakeWhile(p => (primesSum += p) <= 1000000).ToList();
            int index = 0;
            int maximumCount = 0;
            while (index != primes.Count)
            {
                long currentSum = 0;
                List<long> accumulated = (primes.GetRange(index, primes.Count - index)).Select(p => currentSum += p).ToList();
                var newPrimes = from j in
                                    (from i in accumulated
                                     where i % 2 != 0 && i % 5 != 0
                                     select i)
                                where Functions.isPrime((int)j)
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