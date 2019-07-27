using ProjectEuler.Common;
using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of largest positive number m smaller than n-1 such that the modular inverse of m modulo n equals m itself for 3 ≤ n ≤ 20,000,000
        /// </summary>
        static void P451()
        {
            long ans = 1;
            int n = 20000000;
            int[] array = new int[n + 1];
            HashSet<long> primes = Functions.ToHashSet(Functions.getPrimesList(n));
            for (int i = 2; i <= n; i++)
                if (primes.Contains(i))
                    for (int j = i; j <= n; j += i)
                        array[j] = i;
            primes.Remove(2);
            HashSet<long> seen = new HashSet<long>() { 1, 2, 4 };
            for (int e = 3; e <= (int)Math.Log(n, 2); e++)
            {
                long value = (long)Math.Pow(2, e);
                seen.Add(value);
                ans += value / 2 + 1;
            }
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
                    if (2 * value <= n)
                    {
                        seen.Add(2 * value);
                        ans++;
                    }
                }
            for (int i = 3; i <= n; i++)
                if (!seen.Contains(i))
                    for (long j = i - array[i]; j >= 0; j -= array[i])
                        if ((j + 1) * (j + 1) % i == 1)
                        {
                            ans += j + 1;
                            break;
                        }
                        else if ((j - 1) * (j - 1) % i == 1)
                        {
                            ans += j - 1;
                            break;
                        }
            Console.WriteLine(ans);
        }
    }
}