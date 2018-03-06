using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the base of a trapezoid
        /// </summary>
        /// <param name="n">Double</param>
        /// <returns>The base of a trapezoid</returns>
        static double getTrapezoidBase(double n)
        {
            return 1 - Math.Pow(1 - n * n, .5);
        }

        /// <summary>
        /// Gets the solution to the general quadratic equation
        /// </summary>
        /// <param name="a">Int</param>
        /// <param name="b">Int</param>
        /// <param name="c">Int</param>
        /// <returns>The solution to the quadratic equation: a * x^2 + b * x + c = 0</returns>
        static double getQuadraticSolution(int a, int b, int c)
        {
            return Math.Round((-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a), 8);
        }

        /// <summary>
        /// Calculates the least value of n for which the concave triangle occupies less than 0.1% of the L-section
        /// </summary>
        static void P587()
        {
            int ans = 0;
            double blue = 1 - Math.PI / 4;
            while (true)
            {
                double y = getQuadraticSolution(ans * ans + 1, -(2 * ans + 2), 1);
                double x = y * ans;
                double dx = (1 - x) / 50;
                double area = (from i in Enumerable.Range(1, (int)((1 - x) / dx)) select dx * (getTrapezoidBase((i - 1) * dx) + getTrapezoidBase(i * dx)) / 2).Sum();
                if ((area + x * y / 2) / blue < .001) break;
                ans++;
            }
            Console.WriteLine(ans);
        }
    }
}