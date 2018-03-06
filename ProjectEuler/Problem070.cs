using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number under 10,000,000 for which the value of the number/phi(number) is minimized and phi(number) is a permutation of the number
        /// </summary>
        static void P070()
        {
            int ans = 0;
            double minimumValue = 1.5;
            for (int i = 2; i < 10000000; i++)
            {
                int totient = Functions.getPhi(i);
                double currentValue = (double)i / totient;
                if (i.ToString().Length == totient.ToString().Length &&
                    String.Concat(i.ToString().OrderBy(c => c)) == String.Concat(totient.ToString().OrderBy(c => c)) &&
                    currentValue < minimumValue)
                {
                    minimumValue = currentValue;
                    ans = i;
                }
            }
            Console.WriteLine(ans);
        }
    }
}