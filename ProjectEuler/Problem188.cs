using System;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the last 8 digits of 1777↑↑1855
        /// </summary>
        static void P188()
        {
            BigInteger ans = 0;
            BigInteger a = 1777;
            BigInteger b = 1855;
            for (int i = 0; i < b; i++)
                ans = BigInteger.ModPow(a, ans, BigInteger.Pow(10, 8));
            Console.WriteLine(ans);
        }
    }
}