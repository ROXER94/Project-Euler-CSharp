using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital
        /// </summary>
        static void P032()
        {
            HashSet<int> ans = new HashSet<int>();
            foreach (var i in Functions.getPermutations(Enumerable.Range(1, 9), 9))
                if (i.ElementAt(0) * Convert.ToInt32(String.Join("", i.ToArray()).Substring(1, 4)) == Convert.ToInt32(String.Join("", i.ToArray()).Substring(5, 4)) ||
                    Convert.ToInt32(String.Join("", i.ToArray()).Substring(0, 2)) * Convert.ToInt32(String.Join("", i.ToArray()).Substring(2, 3)) == Convert.ToInt32(String.Join("", i.ToArray()).Substring(5, 4)))
                    ans.Add(Convert.ToInt32(String.Join("", i.ToArray()).Substring(5, 4)));
            Console.WriteLine(ans.Sum());
        }
    }
}