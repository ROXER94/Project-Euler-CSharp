using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Determines if a number has permuted multiples
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>True if n has permuted multiples</returns>
        static bool isPermutedMultiple(int n)
        {
            if ((2 * n).ToString().Length == (3 * n).ToString().Length &&
                (3 * n).ToString().Length == (4 * n).ToString().Length &&
                (4 * n).ToString().Length == (5 * n).ToString().Length &&
                (5 * n).ToString().Length == (6 * n).ToString().Length &&
                Functions.isAnagram((2 * n).ToString(), (3 * n).ToString()) &&
                Functions.isAnagram((3 * n).ToString(), (4 * n).ToString()) &&
                Functions.isAnagram((4 * n).ToString(), (5 * n).ToString()) &&
                Functions.isAnagram((5 * n).ToString(), (6 * n).ToString()))
                    return true;
            return false;
        }

        /// <summary>
        ///  Calculates the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits
        /// </summary>
        static void P052()
        {
            int ans = 1;
            while (true)
            {
                if (isPermutedMultiple(ans)) break;
                ans++;
            }
            Console.WriteLine(ans);
        }
    }
}