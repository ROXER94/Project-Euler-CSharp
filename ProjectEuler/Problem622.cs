using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of all values of n that satisfy s(n)=60
        /// </summary>
        static void P622()
        {
            Console.WriteLine((from n in Functions.getFactors((long)Math.Pow(2, 60) - 1) where Functions.getMultiplicativeOrder(2, (int)n) == 60 select n + 1).Sum());
        }
    }
}