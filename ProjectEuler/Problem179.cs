using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of pairs of consecutive integers which have the same number of divisors
        /// </summary>
        static void P179()
        {
            int ans = 0;
            int n = 10000000;
            int[] divisors = new int[n];
            for (int i = 2; i < n; i++) divisors[i] = 1;
            for (int i = 2; i < n; i++)
            {
                for (int j = 2 * i; j < n; j += i)
                    divisors[j]++;
                if (divisors[i] == divisors[i - 1])
                    ans++;
            }
            Console.WriteLine(ans);
        }
    }
}