using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Determines if a number is abundant
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>True if abundant</returns>
        static bool isAbundant(int n)
        {
            List<int> factors = new List<int>();
            for (int i = 1; i <= n / 2; i++)
                if (n % i == 0)
                    factors.Add(i);
            if (factors.Sum() > n) return true;
            return false;
        }

        /// <summary>
        /// Calculates the sum of all the positive integers which cannot be written as the sum of two abundant numbers
        /// </summary>
        static void P023()
        {
            HashSet<int> abundantList = Functions.ToHashSet(from n in Enumerable.Range(1, 28123) where isAbundant(n) select n);
            HashSet<int> sums = new HashSet<int>();
            foreach (int i in abundantList)
                foreach (int j in abundantList)
                    if (j >= i)
                        sums.Add(i + j);
            Console.WriteLine((from n in Enumerable.Range(1, 28123) where !sums.Contains(n) select n).Sum());
        }
    }
}