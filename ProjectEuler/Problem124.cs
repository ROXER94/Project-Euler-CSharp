using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the value of n in the 10,000th row of the sorted column of the radical of n for 1 ≤ n ≤ 100,000
        /// </summary>
        static void P124()
        {
            int N = 100000;
            int[] rad = new int[N];
            for (int i = 1; i < N; i++) rad[i] = 1;
            for (int i = 2; i < N; i++)
                if (rad[i] == 1)
                    for (int j = i; j < N; j += i)
                        rad[j] *= i;
            Tuple<int, int>[] sortedRadicals = new Tuple<int, int>[N];
            for (int i = 0; i < N; i++)
                sortedRadicals[i] = Tuple.Create(rad[i], i);
            Array.Sort(sortedRadicals);
            Console.WriteLine(sortedRadicals[9999].Item2);
        }
    }
}