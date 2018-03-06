using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of all positive numbers n below 64,000,000 such that σ2(n) is a perfect square
        /// </summary>
        static void P211()
        {
            long ans = 0;
            int n = 64000000;
            long[] o2 = new long[n];
            for (int i = 0; i < n; i++) o2[i] = 1;
            for (long i = 2; i < n; i++)
            {
                for (long j = i; j < n; j += i)
                    o2[j] += i * i;
                if (Functions.isSquare(o2[i])) ans += i;
            }
            Console.WriteLine(ans + 1);
        }
    }
}