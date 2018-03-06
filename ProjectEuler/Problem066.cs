using ProjectEuler.Common;
using System;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the value of D ≤ 1000 in minimal solutions of x for which the largest value of x is obtained
        /// </summary>
        static void P066()
        {
            long ans = 0;
            BigInteger minimumSolutions = 0;
            for (long i = 1; i <= 1000; i++)
                if (!Functions.isSquare(i))
                {
                    BigInteger currentSolutions = Functions.getPellSolution(i).Item1;
                    if (currentSolutions > minimumSolutions)
                    {
                        minimumSolutions = currentSolutions;
                        ans = i;
                    }
                }
            Console.WriteLine(ans);
        }
    }
}