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
            foreach (int n in from i in Enumerable.Range(10, 89) select i)
                foreach (int d in from i in Enumerable.Range(n + 1, 100 - n - 1) select i)
                    if (d.ToString()[1] != '0')
                        if (n.ToString()[0] == d.ToString()[0] && (double)Char.GetNumericValue(n.ToString()[1]) / Char.GetNumericValue(d.ToString()[1]) == (double)n / d ||
                            n.ToString()[0] == d.ToString()[1] && (double)Char.GetNumericValue(n.ToString()[1]) / Char.GetNumericValue(d.ToString()[0]) == (double)n / d ||
                            n.ToString()[1] == d.ToString()[0] && (double)Char.GetNumericValue(n.ToString()[0]) / Char.GetNumericValue(d.ToString()[1]) == (double)n / d ||
                            n.ToString()[1] == d.ToString()[1] && (double)Char.GetNumericValue(n.ToString()[0]) / Char.GetNumericValue(d.ToString()[0]) == (double)n / d)
                            ans *= (double)d / n;
            Console.WriteLine(ans);
        }
    }
}