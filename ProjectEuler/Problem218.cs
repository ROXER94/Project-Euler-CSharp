using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the count of the perfect right-angled triangles with side c less than a limit that are not super-perfect
        /// </summary>
        /// <param name="triangle">Decimal[][]</param>
        /// <param name="limit">Int</param>
        /// <returns>The count of the perfect right-angled triangles with side c less than a limit that are not super-perfect</returns>
        static int getPerfectPrimitives(decimal[][] triangle, int limit)
        {
            if (triangle[2][0] > limit) return 0;
            decimal[][] a = getMatrixMultiplication(new decimal[][] { new decimal[] { 1, -2, 2 }, new decimal[] { 2, -1, 2 }, new decimal[] { 2, -2, 3 } }, triangle);
            decimal[][] b = getMatrixMultiplication(new decimal[][] { new decimal[] { 1, 2, 2 }, new decimal[] { 2, 1, 2 }, new decimal[] { 2, 2, 3 } }, triangle);
            decimal[][] c = getMatrixMultiplication(new decimal[][] { new decimal[] { -1, 2, 2 }, new decimal[] { -2, 1, 2 }, new decimal[] { -2, 2, 3 } }, triangle);
            decimal area = triangle[0][0] * triangle[1][0] / 2;
            if (Functions.isSquare((long)triangle[2][0]) && area % 84 != 0)
                return 1 + getPerfectPrimitives(a, limit) + getPerfectPrimitives(b, limit) + getPerfectPrimitives(c, limit);
            else
                return getPerfectPrimitives(a, limit) + getPerfectPrimitives(b, limit) + getPerfectPrimitives(c, limit);
        }

        /// <summary>
        /// Calculates the number of perfect right-angled triangles that are not super-perfect
        /// </summary>
        static void P218()
        {
            Console.WriteLine(getPerfectPrimitives(new decimal[][] { new decimal[] { 3 }, new decimal[] { 4 }, new decimal[] { 5 } }, (int)Math.Pow(Math.Pow(10, 16), (1 / 3))));
        }
    }
}