using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the maximum number of lattice points in an axis-aligned N×N square that the graph of a single strictly convex increasing function can pass through for N = 10^18
        /// </summary>
        static void P604()
        {
            long ans = 0;
            long n = (long)Math.Pow(10, 18);
            int k = (int)Math.Pow(n * Math.Pow(Math.PI, 2), 1.0 / 3);
            int[] phi = Functions.getTotients(k);
            for (long i = 1; i < k; i++)
            {
                n -= i * phi[i] / 2;
                ans += phi[i];
            }
            ans += 2 * n / k;
            Console.WriteLine(ans);
        }
    }
}