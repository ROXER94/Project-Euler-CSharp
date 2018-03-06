using ProjectEuler.Common;
using System;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        ///  Calculates the sum of numbers under 1,000,000 that are palindromes in both decimal and binary
        /// </summary>
        static void P036()
        {
            Console.WriteLine((from l in 
                                   (from k in 
                                        (from j in 
                                             (from i in Enumerable.Range(1, 999999)
                                              where Functions.isPalindrome(i.ToString()) select i)
                                         select Convert.ToString(j, 2))
                                    where Functions.isPalindrome(k) select k)
                               select Convert.ToInt32(l, 2)).Sum());
        }
    }
}