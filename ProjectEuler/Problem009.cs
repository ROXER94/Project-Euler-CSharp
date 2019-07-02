using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the product of a Pythagorean triplet that sums to 1000
        /// </summary>
        static void P009()
        {
            for (int a = 1; a < 500; a++)
                for (int b = a + 1; b < 500; b++)
                    if (a + b + Math.Sqrt(a * a + b * b) == 1000)
                        Console.WriteLine(a * b * Math.Sqrt(a * a + b * b));
        }
    }
}