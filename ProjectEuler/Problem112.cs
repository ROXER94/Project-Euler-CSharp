using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Determines if a number is increasing
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>True if n is increasing</returns>
        static bool isIncreasing(int n)
        {
            string s = n.ToString();
            for (int i = 0; i < s.Length - 1; i++)
                if ((int)Char.GetNumericValue(s[i]) > (int)Char.GetNumericValue(s[i + 1]))
                    return false;
            return true;
        }

        /// <summary>
        /// Determines if a number is decreasing
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>True if n is decreasing</returns>
        static bool isDecreasing(int n)
        {
            string s = n.ToString();
            for (int i = 0; i < s.Length - 1; i++)
                if ((int)Char.GetNumericValue(s[i]) < (int)Char.GetNumericValue(s[i + 1]))
                    return false;
            return true;
        }

        /// <summary>
        /// Determines if a number is bouncy
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>True if n is bouncy</returns>
        static bool isBouncy(int n)
        {
            return !isIncreasing(n) && !isDecreasing(n);
        }

        /// <summary>
        /// Calculates the least number for which the proportion of bouncy numbers is exactly 99%
        /// </summary>
        static void P112()
        {
            int ans = 1000;
            double bouncyCount = 525;
            while (bouncyCount / ans != .99)
            {
                ans++;
                if (isBouncy(ans)) bouncyCount++;
            }
            Console.WriteLine(ans);
        }
    }
}