using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the expected number of distinct colors in 20 randomly picked balls
        /// </summary>
        static void P493()
        {
            Console.WriteLine(Math.Round(7 * (1 - (double)Functions.getnCk(60, 20) / (double)Functions.getnCk(70, 20)), 10));
        }
    }
}
