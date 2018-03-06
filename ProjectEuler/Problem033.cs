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
            foreach (double n in from i in Enumerable.Range(11, 89) select i)
                foreach (double d in from i in Enumerable.Range(12, 89) select i)
                    if (n < d && d.ToString()[1] != '0')
                        if (n.ToString()[0] == d.ToString()[0] && (double)Char.GetNumericValue(n.ToString()[1]) / (double)Char.GetNumericValue(d.ToString()[1]) == n / d ||
                            n.ToString()[0] == d.ToString()[1] && (double)Char.GetNumericValue(n.ToString()[1]) / (double)Char.GetNumericValue(d.ToString()[0]) == n / d ||
                            n.ToString()[1] == d.ToString()[0] && (double)Char.GetNumericValue(n.ToString()[0]) / (double)Char.GetNumericValue(d.ToString()[1]) == n / d ||
                            n.ToString()[1] == d.ToString()[1] && (double)Char.GetNumericValue(n.ToString()[0]) / (double)Char.GetNumericValue(d.ToString()[0]) == n / d)
                            ans *= d / n;
            Console.WriteLine(ans);
        }
    }
}