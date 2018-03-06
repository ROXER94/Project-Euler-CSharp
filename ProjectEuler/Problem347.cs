using ProjectEuler.Common;
using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the largest possible integer divisible by two primes under a limit
        /// </summary>
        /// <param name="p">Long</param>
        /// <param name="q">Long</param>
        /// <param name="N">Int</param>
        /// <returns>The largest possible integer divisible by p and q ≤ N</returns>
        static long getM347(long p, long q, int N)
        {
            long result = 0;
            for (int i = 1; i <= (int)Math.Log(N / q, p) + 1; i++)
                for (int j = 1; j <= (int)Math.Log(N / p, q) + 1; j++)
                {
                    long currentValue = (long)(Math.Pow(p, i) * Math.Pow(q, j));
                    if (currentValue <= N && currentValue > result)
                        result = currentValue;
                }
            return result;
        }

        /// <summary>
        /// Calculates the sum of M(p,q,10,000,000) for all distinct primes p and q
        /// </summary>
        static void P347()
        {
            long ans = 0;
            int N = 10000000;
            List<long> primes = Functions.getPrimesList(N / 2);
            foreach (long p in primes)
                foreach (long q in primes.GetRange(primes.IndexOf(p) + 1, primes.Count - primes.IndexOf(p) - 1))
                {
                    if (p * q > N) break;
                    ans += getM347(p, q, N);
                }
            Console.WriteLine(ans);
        }
    }
}