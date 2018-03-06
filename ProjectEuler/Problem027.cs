using ProjectEuler.Common;
using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the product of the coefficients, a and b, for the quadratic expression n^2 + a*n+b that produces the maximum number of primes for consecutive values of n, starting with n = 0
        /// </summary>
        static void P027()
        {
            int ans = 0;
            int consecutiveCount = 0;
            List<long> primes = Functions.getPrimesList(1000);
            for (int a = 1; a < 1000; a++)
            {
                foreach (int b in primes)
                {
                    int n = 0;
                    int currentCount = 0;
                    while (Functions.isPrime(n * n + a * n + b))
                    {
                        currentCount++;
                        if (currentCount > consecutiveCount)
                        {
                            consecutiveCount = currentCount;
                            ans = a * b;
                        }
                        n++;
                    }
                    n = 0;
                    currentCount = 0;
                    while (Functions.isPrime(n * n - a * n + b))
                    {
                        currentCount++;
                        if (currentCount > consecutiveCount)
                        {
                            consecutiveCount = currentCount;
                            ans = -a * b;
                        }
                        n++;
                    }
                    n = 0;
                    currentCount = 0;
                    while (Functions.isPrime(n * n + a * n - b))
                    {
                        currentCount++;
                        if (currentCount > consecutiveCount)
                        {
                            consecutiveCount = currentCount;
                            ans = a * -b;
                        }
                        n++;
                    }
                    n = 0;
                    currentCount = 0;
                    while (Functions.isPrime(n * n - a * n - b))
                    {
                        currentCount++;
                        if (currentCount > consecutiveCount)
                        {
                            consecutiveCount = currentCount;
                            ans = -a * -b;
                        }
                        n++;
                    }
                }
            }
            Console.WriteLine(ans);
        }
    }
}