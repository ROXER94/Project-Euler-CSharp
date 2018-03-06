using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the sum of 10-digit pandigital numbers with a unique property
        /// </summary>
        static void P043()
        {
            Console.WriteLine((from i in Functions.getPermutations(Enumerable.Range(0, 10), 10)
                               where
                               Convert.ToInt32(String.Join("", i.ToArray()).Substring(1, 3)) % 2 == 0 &&
                               Convert.ToInt32(String.Join("", i.ToArray()).Substring(2, 3)) % 3 == 0 &&
                               Convert.ToInt32(String.Join("", i.ToArray()).Substring(3, 3)) % 5 == 0 &&
                               Convert.ToInt32(String.Join("", i.ToArray()).Substring(4, 3)) % 7 == 0 &&
                               Convert.ToInt32(String.Join("", i.ToArray()).Substring(5, 3)) % 11 == 0 &&
                               Convert.ToInt32(String.Join("", i.ToArray()).Substring(6, 3)) % 13 == 0 &&
                               Convert.ToInt32(String.Join("", i.ToArray()).Substring(7, 3)) % 17 == 0
                               select Convert.ToInt64(String.Join("", i.ToArray()))).Sum());
        }
    }
}