using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the number of rectangles that can be found in a rectangular grid
        /// </summary>
        /// <param name="l">Int</param>
        /// <param name="w">Int</param>
        /// <returns>The number of rectangles contained in a l x w grid</returns>
        static int getRectangleCount(int l, int w)
        {
            return l * w * (l + 1) * (w + 1) / 4;
        }

        /// <summary>
        ///  Calculates the area of the grid that contains nearly 2,000,000 rectangles
        /// </summary>
        static void P085()
        {
            int ans = 0;
            int currentDifference = 100;
            for (int l = 1; l < 1000; l++)
                for (int w = 1; w < 1000; w++)
                {
                    int rectangleCount = getRectangleCount(l, w);
                    if (Math.Abs(2000000 - rectangleCount) < currentDifference)
                    {
                        currentDifference = Math.Abs(2000000 - rectangleCount);
                        ans = l * w;
                    }
                }
            Console.WriteLine(ans);
        }
    }
}