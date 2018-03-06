using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the previous number in the modified Collatz sequence when the previous number is divisble by 3
        /// </summary>
        /// <param name="n">Double</param>
        /// <returns>The previous number in the modified Collatz sequence</returns>
        static double getModifiedCollatzDown(double n)
        {
            return 3 * n;
        }

        /// <summary>
        /// Gets the previous number in the modified Collatz sequence when the previous number is divisble by 3 and gives remainder 1
        /// </summary>
        /// <param name="n">Double</param>
        /// <returns>The previous number in the modified Collatz sequence</returns>
        static double getModifiedCollatzUp(double n)
        {
            return (3 * n - 2) / 4;
        }

        /// <summary>
        /// Gets the previous number in the modified Collatz sequence when the previous number is divisble by 3 and gives remainder 2
        /// </summary>
        /// <param name="n">Double</param>
        /// <returns>The previous number in the modified Collatz sequence</returns>
        static double getModifiedCollatzdown(double n)
        {
            return (3 * n + 1) / 2;
        }

        /// <summary>
        /// Calculates the smallest number greater than 10^15 that has a specific modified Collatz sequence
        /// </summary>
        static void P277()
        {
            double ans = 1;
            string s = new String("UDDDUdddDDUDDddDdDddDDUDDdUUDd".ToCharArray().Reverse().ToArray());
            while (true)
            {
                double original = ans;
                foreach (char c in s)
                {
                    if (c == 'D')
                    {
                        ans = getModifiedCollatzDown(ans);
                        if (ans % 1 != 0) break;
                    }
                    else if (c == 'U')
                    {
                        ans = getModifiedCollatzUp(ans);
                        if (ans % 1 != 0) break;
                    }
                    else
                    {
                        ans = getModifiedCollatzdown(ans);
                        if (ans % 1 != 0) break;
                    }
                }
                if (ans % 1 == 0 && ans > Math.Pow(10, 15)) break;
                ans = original + 69;
            }
            Console.WriteLine((long)ans);
        }
    }
}