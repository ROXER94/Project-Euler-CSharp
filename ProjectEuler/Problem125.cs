using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the sum of all the numbers less than 100,000,000 that are both palindromic and can be written as the sum of consecutive squares
        /// </summary>
        static void P125()
        {
            var squares = from i in Enumerable.Range(1, 7074) select i * i;
            var squarePalindromes = from i in squares where Functions.isPalindrome(i.ToString()) select i;
            HashSet<long> palindromes = new HashSet<long>();
            int index = 0;
            while (index != squares.Count())
            {
                int currentValue = 0;
                foreach (int i in squares.Skip(index))
                {
                    if (currentValue + i < 100000000)
                    {
                        currentValue += i;
                        if (currentValue.ToString() == new String(currentValue.ToString().ToCharArray().Reverse().ToArray()))
                            palindromes.Add(currentValue);
                    }
                }
                index++;
            }
            Console.WriteLine(palindromes.Sum() - squarePalindromes.Sum());
        }
    }
}