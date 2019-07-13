using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Evaluates the value of a given card
        /// </summary>
        /// <param name="c">Char</param>
        /// <returns>The value of a card (Two = 2, ..., Ace = 14)</returns>
        static int getEvaluateCard(char c)
        {
            if (Char.IsDigit(c)) return (int)Char.GetNumericValue(c);
            return new List<char> { 'T', 'J', 'Q', 'K', 'A' }.IndexOf(c) + 10;

        }

        /// <summary>
        /// Evaluates the Poker hand
        /// </summary>
        /// <param name="line">String</param>
        /// <returns>The category of the Poker hand</returns>
        static Tuple<int, int> getEvaluateHand(string line)
        {
            List<char> RoyalFlush = new List<char> { 'T', 'J', 'Q', 'K', 'A' };
            int[] numbers = new int[] { getEvaluateCard(line[0]), getEvaluateCard(line[3]), getEvaluateCard(line[6]), getEvaluateCard(line[9]), getEvaluateCard(line[12]) };
            Array.Sort(numbers);
            // Same Suit
            if (line[1] == line[4] && line[4] == line[7] && line[7] == line[10] && line[10] == line[13])
            {
                // Royal Flush
                if (RoyalFlush.Contains(line[0]) && RoyalFlush.Contains(line[3]) && RoyalFlush.Contains(line[6]) && RoyalFlush.Contains(line[9]) && RoyalFlush.Contains(line[12]))
                    return Tuple.Create(10, 10);
                // Straight Flush
                if (numbers[0] + 4 == numbers[1] + 3 && numbers[1] + 3 == numbers[2] + 2 && numbers[2] + 2 == numbers[3] + 1 && numbers[3] + 1 == numbers[4])
                    return Tuple.Create(9, numbers.Last());
                // Flush
                else
                    return Tuple.Create(6, numbers.Last());
            }
            if (numbers.Distinct().Count() == 2)
                // Full House
                if (numbers.Where(x => x.Equals(numbers[0])).Count() == 2 || numbers.Where(x => x.Equals(numbers[0])).Count() == 3)
                    return Tuple.Create(7, numbers[2]);
                // Four of a Kind
                else
                    return Tuple.Create(8, numbers[2]);
            // Straight
            if (numbers[0] + 4 == numbers[1] + 3 && numbers[1] + 3 == numbers[2] + 2 && numbers[2] + 2 == numbers[3] + 1 && numbers[3] + 1 == numbers[4])
                return Tuple.Create(5, numbers.Last());
            if (numbers.Distinct().Count() == 3)
            {
                // Three of a Kind
                if (numbers.Where(x => x.Equals(numbers[0])).Count() == 3 ||
                    numbers.Where(x => x.Equals(numbers[2])).Count() == 3 ||
                    numbers.Where(x => x.Equals(numbers[4])).Count() == 3)
                    return Tuple.Create(4, numbers[2]);
                // Two Pairs
                else
                    return Tuple.Create(3, Math.Max(numbers[1], numbers[3]));
            }
            // One Pair
            if (numbers.Distinct().Count() == 4)
                return Tuple.Create(2, numbers.GroupBy(item => item).OrderByDescending(g => g.Count()).Select(g => g.Key).First());
            // High Card
            else
                return Tuple.Create(1, numbers[4]);
        }


        /// <summary>
        ///  Calculates the number of Poker hands that Player 1 wins
        /// </summary>
        static void P054()
        {
            int ans = 0;
            foreach (string line in (from i in File.ReadAllText(@"...\...\Resources\p054_poker.txt").Split('\n') select i))
            {
                Tuple<int, int> hand1 = getEvaluateHand(line.Substring(0, 14));
                Tuple<int, int> hand2 = getEvaluateHand(line.Substring(15, 14));
                if (hand1.Item1 > hand2.Item1 || hand1.Item1 == hand2.Item1 && hand1.Item2 > hand2.Item2)
                    ans++;
            }
            Console.WriteLine(ans);
        }
    }
}