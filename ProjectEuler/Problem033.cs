using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the simplified denominator of the product of all two-digit digit-cancelled fractions
        /// </summary>
        static void P033()
        {
            double ans = 1;
            foreach (int N in from i in Enumerable.Range(10, 89) select i)
                foreach (int D in from i in Enumerable.Range(N + 1, 100 - N - 1) select i)
                {
                    string n = N.ToString();
                    string d = D.ToString();
                    if (d.ToString()[1] != '0')
                        if (n.ToString()[0] == d[0] && (double)Char.GetNumericValue(n[1]) / Char.GetNumericValue(d[1]) == (double)N / D ||
                            n.ToString()[0] == d[1] && (double)Char.GetNumericValue(n[1]) / Char.GetNumericValue(d[0]) == (double)N / D ||
                            n.ToString()[1] == d[0] && (double)Char.GetNumericValue(n[0]) / Char.GetNumericValue(d[1]) == (double)N / D ||
                            n.ToString()[1] == d[1] && (double)Char.GetNumericValue(n[0]) / Char.GetNumericValue(d[0]) == (double)N / D)
                            ans *= (double)D / N;
                }
            Console.WriteLine(ans);
        }
    }
}