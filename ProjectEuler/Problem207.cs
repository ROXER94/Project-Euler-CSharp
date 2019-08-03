using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the smallest m for which P(m) is less than 1/12345
        /// </summary>
        static void P207()
        {
            double ans = 1;
            while (true)
            {
                if ((int)(Math.Log(ans + 1, 2)) / ans < 1.0 / 12345) break;
                ans++;
            }
            ans *= ans + 1;
            Console.WriteLine(ans);
        }
    }
}