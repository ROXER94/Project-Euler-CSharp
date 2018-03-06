using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of squarefree numbers below 2^50
        /// </summary>
        static void P193()
        {
            int[] M = Functions.getMoebius((int)Math.Pow(2, 25));
            Console.WriteLine((from i in Enumerable.Range(1, (int)Math.Pow(2, 25)) select (long)(M[i] * Math.Pow(2, 50) / (1.0 * i * i))).Sum());
        }
    }
}