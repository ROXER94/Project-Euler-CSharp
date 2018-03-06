using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates a 12-digit number that is formed by concatenating the three terms in a unique sequence
        /// </summary>
        static void P049()
        {
            var primes = from i in Functions.getPrimesList(10000) where i >= 1000 select i;
            foreach (int p in primes)
            {
                if (primes.Contains(p + 3330) && primes.Contains(p + 6660) && p != 1487)
                {
                    bool b = true;
                    foreach (char c in p.ToString())
                    {
                        if (!(p + 3330).ToString().Contains(c.ToString()) || !(p + 6660).ToString().Contains(c.ToString()))
                        {
                            b = false;
                            break;
                        }
                    }
                    if (b)
                    {
                        Console.WriteLine(p.ToString() + (p + 3330).ToString() + (p + 6660).ToString());
                        break;
                    }
                }
            }
        }
    }
}