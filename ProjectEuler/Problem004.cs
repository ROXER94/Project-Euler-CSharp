using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Determines if a number is the product of two 3-digit numbers
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>True if n is the product of two 3-digit numbers</returns>
        private static bool isThreeDigitProduct(int n)
        {
            for (int i = 100; i <= 999; i++)
                if (n % i == 0 && (n / i).ToString().Length == 3)
                    return true;
            return false;
        }

        /// <summary>
        /// Calculates the largest palindrome made from the product of two 3-digit numbers
        /// </summary>
        static void P004()
        {
            for (int ans = 999 * 999; ans >= 100 * 100; ans--)
                if (Functions.isPalindrome(ans.ToString()) && isThreeDigitProduct(ans))
                {
                    Console.WriteLine(ans);
                    break;
                }
        }
    }
}