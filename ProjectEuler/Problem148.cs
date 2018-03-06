using ProjectEuler.Common;
using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the base 7 representation of a number
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>The base 7 representation of n</returns>
        static long getBase7(int n)
        {
            if (n == 0) return 0;
            List<int> digits = new List<int>();
            while (n != 0)
            {
                digits.Add(n % 7);
                n /= 7;
            }
            digits.Reverse();
            return Int64.Parse(String.Join("", digits));
        }

        /// <summary>
        /// Gets the number of entries which are not divisible by 7 in the first n rows of Pascal's triangle
        /// </summary>
        /// <param name="n">Long</param>
        /// <param name="b">Bool</param>
        /// <returns>The number of entries which are not divisible by 7 in the first n rows of Pascal's triangle</returns>
        static long getExplorePascal(long n, bool b = false)
        {
            if (n < 7) return Functions.getTriangle((int)n);
            long b7 = n;
            if (b) b7 = getBase7((int)n);
            int n1 = (int)Char.GetNumericValue(b7.ToString()[0]);
            long n2 = Int64.Parse(b7.ToString().Substring(1));
            return n1 * (n1 + 1) / 2 * (long)Math.Pow(28, b7.ToString().Length - 1) + (n1 + 1) * getExplorePascal(n2);
        }

        /// <summary>
        /// Calculates the number of entries which are not divisible by 7 in the first 1,000,000,000 rows of Pascal's triangle
        /// </summary>
        static void P148()
        {
            Console.WriteLine(getExplorePascal(1000000000, true));
        }
    }
}