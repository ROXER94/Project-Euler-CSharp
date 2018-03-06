using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the 1 to 9 pandigital concatenated product of a number
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>The pandigital concatenated product of n</returns>
        static int getPandigitalProduct(int n)
        {
            String s = "";
            int i = 1;
            while (s.Length < 10)
            {
                s += (n * i).ToString();
                i++;
            }
            s = s.Substring(0, 9);
            if (s.ToCharArray().Distinct().ToArray().Length == 9 && !s.ToCharArray().Distinct().ToArray().Contains('0'))
                return Int32.Parse(s);
            return 0;
        }

        /// <summary>
        ///  Calculates the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an integer with (1,2,...,n) where n > 1
        /// </summary>
        static void P038()
        {
            int ans = 0;
            for (int i = 9999; i >= 9000; i--)
                ans = Math.Max(ans, getPandigitalProduct(i));
            Console.WriteLine(ans);
        }
    }
}