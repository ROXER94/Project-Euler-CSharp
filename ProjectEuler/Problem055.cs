using ProjectEuler.Common;
using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the sum of a number and its reverse number
        /// </summary>
        /// <param name="n">BigInteger</param>
        /// <returns>The sum of n and the reverse of n</returns>
        static BigInteger getLychrel(BigInteger n)
        {
            return n + BigInteger.Parse(new String(n.ToString().ToCharArray().Reverse().ToArray()));
        }

        /// <summary>
        ///  Calculates the number of Lychrel numbers below 10,000
        /// </summary>
        static void P055()
        {
            int ans = 0;
            for (BigInteger i = 1; i < 10000; i++)
            {
                bool isLychrel = true;
                BigInteger currentNumber = i;
                int iterationCount = 0;
                while (iterationCount < 50)
                {
                    currentNumber = getLychrel(currentNumber);
                    if (Functions.isPalindrome(currentNumber.ToString()))
                    {
                        isLychrel = false;
                        break;
                    }
                    iterationCount++;
                }
                if (isLychrel)
                    ans++;
            }
            Console.WriteLine(ans);
        }
    }
}
