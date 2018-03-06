using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the smallest prime in an eight prime value family
        /// </summary>
        static void P051()
        {
            List<long> primesList = Functions.getPrimesList(1000000);
            List<long> primes = primesList.GetRange(9592, primesList.Count - 9592);
            IDictionary<long, bool> primesDict = Functions.getPrimesDict(1000000);
            foreach (int ans in primes)
            {
                int count = 0;
                long i = ans;
                char r = ans.ToString().GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
                i = Int32.Parse(i.ToString().Replace(r, '0'));
                if (primesDict.ContainsKey(i) && i.ToString().Length == 6) count++;
                i = ans;
                i = Int32.Parse(i.ToString().Replace(r, '1'));
                if (primesDict.ContainsKey(i)) count++;
                i = ans;
                i = Int32.Parse(i.ToString().Replace(r, '2'));
                if (primesDict.ContainsKey(i)) count++;
                i = ans;
                i = Int32.Parse(i.ToString().Replace(r, '3'));
                if (primesDict.ContainsKey(i)) count++;
                i = ans;
                i = Int32.Parse(i.ToString().Replace(r, '4'));
                if (primesDict.ContainsKey(i)) count++;
                i = ans;
                i = Int32.Parse(i.ToString().Replace(r, '5'));
                if (primesDict.ContainsKey(i)) count++;
                i = ans;
                i = Int32.Parse(i.ToString().Replace(r, '6'));
                if (primesDict.ContainsKey(i)) count++;
                i = ans;
                i = Int32.Parse(i.ToString().Replace(r, '7'));
                if (primesDict.ContainsKey(i)) count++;
                i = ans;
                i = Int32.Parse(i.ToString().Replace(r, '8'));
                if (primesDict.ContainsKey(i)) count++;
                i = ans;
                i = Int32.Parse(i.ToString().Replace(r, '9'));
                if (primesDict.ContainsKey(i)) count++;
                if (count == 8)
                {
                    Console.WriteLine(ans);
                    break;
                }
            }
        }
    }
}