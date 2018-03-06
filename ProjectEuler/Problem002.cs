using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the even terms of the Fibonacci sequence under 4,000,000
        /// </summary>
        static void P002()
        {
            int ans = 0;
            int a = 1;
            int b = 2;
            while (b < 4000000)
            {
                int temp = b;
                b = a + b;
                a = temp;
                if (a % 2 == 0)
                    ans += a;
            }
            Console.WriteLine(ans);
        }
    }
}