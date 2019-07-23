using ProjectEuler.Common;
using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of c less than 120,000 for abc-hits 
        /// </summary>
        static void P127()
        {
            int ans = 0;
            int N = 120000;
            long[] rad = new long[N];
            for (int i = 1; i < N; i++) rad[i] = 1;
            for (int i = 2; i < N; i++)
                if (rad[i] == 1)
                    for (int j = i; j < N; j += i)
                        rad[j] *= i;
            for (int c = 2; c < N; c++)
            {
                if (rad[c - 1] * rad[c] < c) ans += c;
                if (6 * rad[c] < c)
                    for (int a = 2; a < c / 2; a++)
                        if (rad[a] * rad[c] < c && Functions.getGCD(a, c) == 1 && rad[a] * rad[c - a] * rad[c] < c)
                            ans += c;
            }
            Console.WriteLine(ans);
        }
    }
}