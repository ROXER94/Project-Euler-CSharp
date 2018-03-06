using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Dictionary used to memoize the Happy numbers
        /// </summary>
        static IDictionary<int, bool> happyDict = new Dictionary<int, bool>();

        /// <summary>
        /// Determines if n is a happy number via memoization
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>True if n is a happy number</returns>
        public static bool isHappy(int n)
        {
            if (!happyDict.ContainsKey(n))
                happyDict[n] = isHappyUncached(n);
            return happyDict[n];
        }

        /// <summary>
        /// Determines if n is a happy number via recursion
        /// </summary>
        /// <param name="n">Int</param>
        /// <returns>True if n is a happy number</returns>
        public static bool isHappyUncached(int n)
        {
            int s = (from c in n.ToString() select (int)Math.Pow(Char.GetNumericValue(c), 2)).Sum();
            if (s == 1) return true;
            else if (s == 89) return false;
            else return isHappy(s);
        }

        /// <summary>
        /// Calculates the number of unhappy numbers below 10,000,000
        /// </summary>
        static void P092()
        {
            Console.WriteLine((from i in Enumerable.Range(1, 10000000) where !isHappy(i) select 1).Count());
        }
    }
}