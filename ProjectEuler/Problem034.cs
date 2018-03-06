using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the sum of factorions greater than two
        /// </summary>
        static void P034()
        {
            Console.WriteLine((from i in Enumerable.Range(10, 50000) where i == (from c in i.ToString() select (int)Functions.getFactorial((int)Char.GetNumericValue(c))).Sum() select i).Sum());
        }
    }
}