using ProjectEuler.Common;
using System;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the square root expansion of a number
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>The square root expansion of n</returns>
        static BigInteger getSquareRootExpansion(int n)
        {
            BigInteger a = 5 * n;
            BigInteger b = 5;
            while (b.ToString().Length <= 101)
            {
                if (a >= b)
                {
                    a -= b;
                    b += 10;
                }
                else
                {
                    a *= 100;
                    b = 10 * b - 45;
                }
            }
            return b;
        }

        /// <summary>
        ///  Calculates the total of the digital sums of the first one hundred decimal digits for all irrational square roots
        /// </summary>
        static void P080()
        {
            int ans = 0;
            for (int i = 1; i <= 100; i++)
                if (!Functions.isSquare(i))
                    foreach (char c in getSquareRootExpansion(i).ToString().Substring(0, 100))
                        ans += (int)Char.GetNumericValue(c);
            Console.WriteLine(ans);
        }
    }
}