using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of the perimeters of all almost equilateral triangles with integral side lengths and area and whose perimeters do not exceed 1,000,000,000
        /// </summary>
        static void P094()
        {
            int ans = 0;
            int s = 5;
            int t = -1;
            int previous = 1;
            while (s < 333333334)
            {
                ans += 3 * s - t;
                int p = s;
                s = 4 * s - previous + 2 * t;
                t *= -1;
                previous = p;
            }
            Console.WriteLine(ans);
        }
    }
}