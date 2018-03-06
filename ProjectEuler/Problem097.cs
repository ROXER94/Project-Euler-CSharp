using System;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the last ten digits of 28433 * 2^7830457 + 1
        /// </summary>
        static void P097()
        {
            Console.WriteLine((28433 * BigInteger.ModPow(2, 7830457, 10000000000) + 1) % 10000000000);
        }
    }
}