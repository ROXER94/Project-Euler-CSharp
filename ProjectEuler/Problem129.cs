using ProjectEuler.Common;
using System;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the least value of n for which A(n) first exceeds 1,000,000
        /// </summary>
        static void P129()
        {
            int ans = 1000013;
            while (true)
            {
                if (Functions.getGCD(ans, 10) == 1)
                {
                    int k = 666681;
                    while (BigInteger.ModPow(10, k, ans) != 1)
                        k++;
                    if (k > 1000000) break;
                }
                ans += 2;
            }
            Console.WriteLine(ans);
        }
    }
}