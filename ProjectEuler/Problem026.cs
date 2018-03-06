using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number below 1000 which contains the longest recurring cycle in its decimal fraction part
        /// </summary>
        static void P026()
        {
            List<long> primes = Functions.getPrimesList(1000);
            primes.Reverse();
            foreach (int ans in primes)
            {
                int t = 1;
                while (BigInteger.ModPow(10, t, ans) != 1)
                    t++;
                if (t == ans - 1)
                {
                    Console.WriteLine(ans);
                    break;
                }
            } 
        }
    }
}