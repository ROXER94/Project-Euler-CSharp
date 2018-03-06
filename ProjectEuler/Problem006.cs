using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the difference between the sum of the squares of the first one hundred numbers and the square of the sum
        /// </summary>
        static void P006()
        {
            Console.WriteLine(Math.Pow((from n in Enumerable.Range(1, 100) select n).Sum(), 2) - (from n in Enumerable.Range(1, 100) select n * n).Sum());
        }
    }
}