using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the first 25 composite values of n for which GCD(n, 10) = 1 and n − 1 is divisible by A(n)
        /// </summary>
        static void P130()
        {
            int ans = 0;
            int count = 0;
            int n = 91;
            IDictionary<long, bool> primesDict = Functions.getPrimesDict(15000);
            while (count < 25)
            {
                if (Functions.getGCD(n, 10) == 1 && Functions.getGCD(n, 3) == 1)
                {
                    int k = 1;
                    while (BigInteger.ModPow(10, k, n) != 1) k++;
                    if ((n - 1) % k == 0 && !primesDict.ContainsKey(n) && BigInteger.Parse(String.Join("", Enumerable.Repeat("1", k))) % n == 0)
                    {
                        ans += n;
                        count++;
                    }
                }
                n += 2;
            }
            Console.WriteLine(ans);
        }
    }
}