using ProjectEuler.Common;
using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the largest value of a less than n such that a^2 ≡ a (mod n) for 1 ≤ n ≤ 10,000,000
        /// </summary>
        static void P407()
        {
            long ans = 0;
            int n = 10000000;
            int[] array = new int[n + 1];
            HashSet<long> primes = Functions.ToHashSet(Functions.getPrimesList(n));
            for (int i = 2; i <= n; i++)
                if (primes.Contains(i))
                    for (int j = i; j <= n; j += i)
                        array[j] = i;
            HashSet<long> seen = new HashSet<long>() { 1, 2, 4 };
            foreach (int p in primes)
                for (int e = 1; e <= (int)Math.Log(n, 3); e++)
                {
                    long value = (long)Math.Pow(p, e);
                    if (value <= n)
                    {
                        seen.Add(value);
                        ans++;
                    }
                    else break;
                }
            for (int i = 3; i <= n; i++)
                if (!seen.Contains(i))
                    for (long j = i - array[i]; j >= 0; j -= array[i])
                        if ((j + 1) * (j + 1) % i == j + 1)
                        {
                            ans += j + 1;
                            break;
                        }
                        else if (j * j % i == j)
                        {
                            ans += j;
                            break;
                        }
            Console.WriteLine(ans);
        }
    }
}