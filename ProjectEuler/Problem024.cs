using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8, and 9
        /// </summary>
        static void P024()
        {
            Console.WriteLine(String.Join("", Functions.getPermutations(Enumerable.Range(0, 10), 10).ToArray()[999999]));
        }
    }
}