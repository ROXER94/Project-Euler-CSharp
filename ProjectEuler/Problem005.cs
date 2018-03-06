using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the smallest positive number that is evenly divisible by all numbers from 1 to 20
        /// </summary>
        static void P005()
        {
            Console.WriteLine((new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }).Aggregate((a, b) => Functions.getLCM(a, b)));
        }
    }
}