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
        /// Gets Lehmer's speed-up for use in Størmer's theorem
        /// </summary>
        /// <param name="n">BigInteger</param>
        /// <returns>Lehmer's speed-up for n</returns>
        static Tuple<bool, BigInteger> getLehmerSpeedUp(BigInteger n)
        {
            BigInteger x = (n - 1) / 2;
            BigInteger y = (n + 1) / 2;
            if (Functions.isSmooth(x, 47) && Functions.isSmooth(y, 47))
                return Tuple.Create(true, x);
            return Tuple.Create(false, BigInteger.Zero);
        }

        /// <summary>
        /// Gets the next set of solutions of Pell's equation: x^2 - D * y^2 = 1
        /// </summary>
        /// <param name="x0">BigInteger</param>
        /// <param name="y0">BigInteger</param>
        /// <param name="D">Long</param>
        /// <param name="count">Int</param>
        /// <returns>The next set of solutions of a given Pell's equation</returns>
        static IEnumerable<Tuple<BigInteger, BigInteger>> getNextPellSolutions(BigInteger x0, BigInteger y0, long D, int count)
        {
            BigInteger xCurrent = x0;
            BigInteger yCurrent = y0;
            for (int i = 0; i < count; i++)
            {
                yield return Tuple.Create(xCurrent, yCurrent);
                BigInteger xNext = x0 * xCurrent + D * y0 * yCurrent;
                BigInteger yNext = y0 * xCurrent + x0 * yCurrent;
                xCurrent = xNext;
                yCurrent = yNext;
            }
        }

        /// <summary>
        /// Calculates the sum of indices n such that T(n) is 47-smooth
        /// </summary>
        static void P581()
        {
            BigInteger ans = 0;
            List<long> primes = Functions.getPrimesList(48);
            List<long> squarefrees = Functions.getSquarefrees(1, 0, primes).OrderBy(i => i).ToList();
            squarefrees.Remove(2);
            foreach (long sqfree in squarefrees)
            {
                Tuple<BigInteger, BigInteger> fundamentalSolution = Functions.getPellSolution(2 * sqfree);
                if (getLehmerSpeedUp(fundamentalSolution.Item1).Item1)
                    foreach (Tuple<BigInteger, BigInteger> i in getNextPellSolutions(fundamentalSolution.Item1, fundamentalSolution.Item2, 2 * sqfree, (int)Math.Max(3, (primes.Last() + 1) / 2)))
                    {
                        Tuple<bool, BigInteger> Lehmer = getLehmerSpeedUp(i.Item1);
                        if (Lehmer.Item1)
                            ans += Lehmer.Item2;
                    }
            }
            Console.WriteLine(ans);
        }
    }
}