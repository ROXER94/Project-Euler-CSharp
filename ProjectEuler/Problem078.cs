using System;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the smallest value of n for which p(n) is divisible by one million
        /// </summary>
        static void P078()
        {
            int n = 60000;
            BigInteger[] ways = new BigInteger[n + 1];
            ways[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j++)
                    ways[j] = ways[j] + ways[j - i];
                if (ways[i] % 1000000 == 0)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}