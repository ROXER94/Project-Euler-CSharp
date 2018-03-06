using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number under 1,000,000 for which the value of the number/phi(number) is maximized
        /// </summary>
        static void P069()
        {
            int ans = 0;
            double maximumValue = 0;
            for (int i = 1; i <= 1000000; i++)
            {
                double currentValue = (double)i / Functions.getPhi(i);
                if (currentValue > maximumValue)
                {
                    maximumValue = currentValue;
                    ans = i;
                }
            }
            Console.WriteLine(ans);
        }
    }
}