using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the digits in the numerator of the 100th convergent of the continued fraction for e
        /// </summary>
        static void P065()
        {
            BigInteger ans = 0;
            int k = 0;
            BigInteger n1 = 2;
            BigInteger n2 = 3;
            for (int i = 3; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    k += 2;
                    ans = k * n2 + n1;
                }
                else ans = n2 + n1;
                n1 = n2;
                n2 = ans;
            }
            Console.WriteLine(ans.ToString().Select(c => (int)Char.GetNumericValue(c)).Sum());
        }
    }
}