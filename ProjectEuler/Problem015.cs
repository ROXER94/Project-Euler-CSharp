using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of down-and-right paths through a 20 x 20 grid
        /// </summary>
        static void P015()
        {
            Console.WriteLine(Functions.getnCk(40,20));
        }
    }
}