using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of blue discs in the arrangement for which the probability of taking two blue discs is 1/2 and the arrangement contains over 1,000,000,000,000 discs in total
        /// </summary>
        static void P100()
        {
            long n = 15;
            long d = 21;
            while (d < 1000000000000)
            {
                long a = 3 * n + 2 * d - 2;
                long b = 4 * n + 3 * d - 3;
                n = a;
                d = b;
            }
            Console.WriteLine(n);
        }
    }
}