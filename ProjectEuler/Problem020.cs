using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the digits in 100!
        /// </summary>
        static void P020()
        {
            Console.WriteLine((from number in (Functions.getFactorial(100)).ToString() select (int)Char.GetNumericValue(number)).Sum());
        }
    }
}