using System;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of fractions that contain a numerator with more digits than denominator in the first 1000 expansions of the continued fraction of √2
        /// </summary>
        static void P057()
        {
            int ans = 0;
            BigInteger n = 3;
            BigInteger d = 2;
            int currentIteration = 0;
            while (currentIteration != 1000)
            {
                if (n.ToString().Length > d.ToString().Length)
                    ans++;
                BigInteger n2 = 2 * d + n;
                BigInteger d2 = n + d;
                n = n2;
                d = d2;
                currentIteration++;
            }
            Console.WriteLine(ans);
        }
    }
}