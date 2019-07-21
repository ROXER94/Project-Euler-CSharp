using ProjectEuler.Common;
using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Determines if three pairs of coordinates produce a right triangle
        /// </summary>
        /// <param name="x1">Int</param>
        /// <param name="y1">Int</param>
        /// <param name="x2">Int</param>
        /// <param name="y2">Int</param>
        /// <param name="x3">Int</param>
        /// <param name="y3">Int</param>
        /// <returns>True if the triangle formed from (0,0), (x1,y1), and (x2,y2) is a right triangle</returns>
        static bool isRightTriangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            double s1 = Functions.getDistance(x1, y1, x2, y2);
            double s2 = Functions.getDistance(x2, y2, x3, y3);
            double s3 = Functions.getDistance(x1, y1, x3, y3);
            double[] sides = new double[] { s1, s2, s3 };
            Array.Sort(sides);
            return Math.Round(sides[0] * sides[0] + sides[1] * sides[1]) == Math.Round(sides[2] * sides[2]);
        }

        /// <summary>
        /// Calculates the number of right triangles that can be formed with integer coordinates in a given range and joined at the origin
        /// </summary>
        static void P091()
        {
            int ans = 0;
            int limit = 50;
            HashSet<Tuple<Tuple<int, int>, Tuple<int, int>>> rightTriangles = new HashSet<Tuple<Tuple<int, int>, Tuple<int, int>>>();
            for (int x1 = 1; x1 <= limit; x1++)
                for (int y1 = 0; y1 <= limit; y1++)
                    for (int x2 = 0; x2 <= limit; x2++)
                        for (int y2 = 1; y2 <= limit; y2++)
                            if (isRightTriangle(0, 0, x1, y1, x2, y2) &&
                                !rightTriangles.Contains(Tuple.Create(Tuple.Create(x1, y1), Tuple.Create(x2, y2))) &&
                                !rightTriangles.Contains(Tuple.Create(Tuple.Create(x2, y2), Tuple.Create(x1, y1))))
                            {
                                rightTriangles.Add(Tuple.Create(Tuple.Create(x1, y1), Tuple.Create(x2, y2)));
                                ans++;
                            }
            ans -= limit * limit;
            Console.WriteLine(ans);
        }
    }
}