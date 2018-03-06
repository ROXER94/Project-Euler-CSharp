using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the 10,001st prime number
        /// </summary>
        static void P007()
        {
            Console.WriteLine(Functions.getPrimesList(120000)[10000]);
        }
    }
}