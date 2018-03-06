using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of all amicable numbers under 10000
        /// </summary>
        static void P021()
        {
            int ans = 0;
            for (int i = 1; i < 10000; i++)
            {
                int s = (int)Functions.getFactors(i).Sum() - i;
                int d = (int)Functions.getFactors(s).Sum() - s;
                if (i == d && s != d)
                    ans += i;
            }
            Console.WriteLine(ans);
        }
    }
}