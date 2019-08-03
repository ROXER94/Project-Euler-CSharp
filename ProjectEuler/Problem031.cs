using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of different ways £2 can be made using 1p, 2p, 5p, 10p, 20p, 50p, £1 and £2
        /// </summary>
        static void P031()
        {
            int[] coins = { 1, 2, 5, 10, 20, 50, 100, 200 };
            int n = 200;
            int[] ways = new int[n + 1];
            ways[0] = 1;
            for (int i = 0; i < coins.Length; i++)
                for (int j = coins[i]; j <= n; j++)
                    ways[j] += ways[j - coins[i]];
            Console.WriteLine(ways[n]);
        }
    }
}