using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Determines if a number is a circular prime
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>True if n is a circular prime</returns>
        static bool isCircularPrime(int n)
        {
            String s = n.ToString();
            if (s.Length == 1 ||
                s.Length == 2 && Functions.isPrime(Int32.Parse(s.Substring(1) + s.Substring(0,1))) ||
                s.Length == 3 && Functions.isPrime(Int32.Parse(s.Substring(1) + s.Substring(0, 1))) && Functions.isPrime(Int32.Parse(s.Substring(2) + s.Substring(0, 2))) ||
                s.Length == 4 && Functions.isPrime(Int32.Parse(s.Substring(1) + s.Substring(0, 1))) && Functions.isPrime(Int32.Parse(s.Substring(2) + s.Substring(0, 2))) && Functions.isPrime(Int32.Parse(s.Substring(3) + s.Substring(0, 3))) ||
                s.Length == 5 && Functions.isPrime(Int32.Parse(s.Substring(1) + s.Substring(0, 1))) && Functions.isPrime(Int32.Parse(s.Substring(2) + s.Substring(0, 2))) && Functions.isPrime(Int32.Parse(s.Substring(3) + s.Substring(0, 3))) && Functions.isPrime(Int32.Parse(s.Substring(4) + s.Substring(0, 4))) ||
                s.Length == 6 && Functions.isPrime(Int32.Parse(s.Substring(1) + s.Substring(0, 1))) && Functions.isPrime(Int32.Parse(s.Substring(2) + s.Substring(0, 2))) && Functions.isPrime(Int32.Parse(s.Substring(3) + s.Substring(0, 3))) && Functions.isPrime(Int32.Parse(s.Substring(4) + s.Substring(0, 4))) && Functions.isPrime(Int32.Parse(s.Substring(5) + s.Substring(0, 5))))
                return true;
            return false;
        }

        /// <summary>
        ///  Calculates the number of circular primes below 1,000,000
        /// </summary>
        static void P035()
        {
            Console.WriteLine((from i in (from p in Functions.getPrimesList(1000000) where !p.ToString().Contains('2') && !p.ToString().Contains('5') select (int)p) where isCircularPrime(i) select i).ToArray().Length + 2);
        }
    }
}