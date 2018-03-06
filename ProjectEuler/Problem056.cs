using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the maximum digital sum of natural numbers of the form a^b for a,b < 100
        /// </summary>
        static void P056()
        {
            int ans = 0;
            for (int a = 1; a < 100; a++)
                for (int b = 1; b < 100; b++)
                    ans = Math.Max(ans, (from c in BigInteger.Pow(a, b).ToString() select (int)Char.GetNumericValue(c)).Sum());
            Console.WriteLine(ans);
        }
    }
}