using System;
using System.IO;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the area of a triangle 
        /// </summary>
        /// <param name="x1">Int</param>
        /// <param name="y1">Int</param>
        /// <param name="x2">Int</param>
        /// <param name="y2">Int</param>
        /// <param name="x3">Int</param>
        /// <param name="y3">Int</param>
        /// <returns>The area of a triangle located at points (x1,y1), (x2,y2), and (x3,y3)</returns>
        static double getTriangleArea(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            return .5 * (-y2 * x3 + y1 * (-x2 + x3) + x1 * (y2 - y3) + x2 * y3);
        }

        /// <summary>
        /// Gets the first barycentric coordinate of a triangle
        /// </summary>
        /// <param name="x1">Int</param>
        /// <param name="y1">Int</param>
        /// <param name="x2">Int</param>
        /// <param name="y2">Int</param>
        /// <param name="x3">Int</param>
        /// <param name="y3">Int</param>
        /// <returns>The first barycentric coordinate of a triangle located at points (x1,y1), (x2,y2), and (x3,y3)</returns>
        static double getBarycentricCoordinate1(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            return 1 / (2 * getTriangleArea(x1, y1, x2, y2, x3, y3)) * (y1 * x3 - x1 * y3);
        }

        /// <summary>
        /// Gets the second barycentric coordinate of a triangle
        /// </summary>
        /// <param name="x1">Int</param>
        /// <param name="y1">Int</param>
        /// <param name="x2">Int</param>
        /// <param name="y2">Int</param>
        /// <param name="x3">Int</param>
        /// <param name="y3">Int</param>
        /// <returns>The second barycentric coordinate of a triangle located at points (x1,y1), (x2,y2), and (x3,y3)</returns>
        static double getBarycentricCoordinate2(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            return 1 / (2 * getTriangleArea(x1, y1, x2, y2, x3, y3)) * (x1 * y2 - y1 * x2);
        }

        /// <summary>
        /// Calculates the number of triangles in the text file for which the interior contains the origin
        /// </summary>
        static void P102()
        {
            int ans = 0;
            foreach (string line in File.ReadAllText(@"...\...\Resources\p102_triangles.txt").Split('\n'))
            {
                int x1 = Int32.Parse(line.Split(',')[0]);
                int y1 = Int32.Parse(line.Split(',')[1]);
                int x2 = Int32.Parse(line.Split(',')[2]);
                int y2 = Int32.Parse(line.Split(',')[3]);
                int x3 = Int32.Parse(line.Split(',')[4]);
                int y3 = Int32.Parse(line.Split(',')[5]);
                double bCoordinate1 = getBarycentricCoordinate1(x1, y1, x2, y2, x3, y3);
                double bCoordinate2 = getBarycentricCoordinate2(x1, y1, x2, y2, x3, y3);
                if (bCoordinate1 > 0 && bCoordinate2 > 0 && 1 - bCoordinate1 - bCoordinate2 > 0) ans++;
            }
            Console.WriteLine(ans);
        }
    }
}