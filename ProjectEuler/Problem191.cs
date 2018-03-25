using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Dictionary used to memoize the prize strings
        /// </summary>
        static IDictionary<Tuple<bool, int, int>, int> prizeStringDict = new Dictionary<Tuple<bool, int, int>, int>();

        /// <summary>
        /// Gets the number of prize strings that exist over a 30-day period via recursion
        /// </summary>
        /// <param name="s">String</param>
        /// <param name="late">Bool</param>
        /// <param name="absenses">Int</param>
        /// <param name="day">Int</param>
        /// <returns></returns>
        static int getPrizeStringCount(StringBuilder s, bool late, int absenses, int day)
        {
            if (day == 30) return 1;
            if (late)
            {
                if (absenses == 2)
                {
                    Tuple<bool, int, int> T1 = Tuple.Create(late, absenses, day);
                    if (!prizeStringDict.ContainsKey(T1))
                        prizeStringDict[T1] = getPrizeStringCount(s.Append("O"), late, 0, day + 1);
                    return prizeStringDict[T1];
                }
                else
                {
                    Tuple<bool, int, int> T1 = Tuple.Create(late, 0, day + 1);
                    if (!prizeStringDict.ContainsKey(T1))
                        prizeStringDict[T1] = getPrizeStringCount(s.Append("O"), late, 0, day + 1);
                    Tuple<bool, int, int> T2 = Tuple.Create(late, absenses + 1, day + 1);
                    if (!prizeStringDict.ContainsKey(T2))
                        prizeStringDict[T2] = getPrizeStringCount(s.Append("A"), late, absenses + 1, day + 1);
                    return prizeStringDict[T1] + prizeStringDict[T2];
                }
            }
            else
            {
                if (absenses == 2)
                {
                    Tuple<bool, int, int> T1 = Tuple.Create(late, 0, day + 1);
                    if (!prizeStringDict.ContainsKey(T1))
                        prizeStringDict[T1] = getPrizeStringCount(s.Append("O"), late, 0, day + 1);
                    Tuple<bool, int, int> T2 = Tuple.Create(!late, 0, day + 1);
                    if (!prizeStringDict.ContainsKey(T2))
                        prizeStringDict[T2] = getPrizeStringCount(s.Append("A"), !late, 0, day + 1);
                    return prizeStringDict[T1] + prizeStringDict[T2];
                }
                else
                {
                    Tuple<bool, int, int> T1 = Tuple.Create(late, 0, day + 1);
                    if (!prizeStringDict.ContainsKey(T1))
                        prizeStringDict[T1] = getPrizeStringCount(s.Append("O"), late, 0, day + 1);
                    Tuple<bool, int, int> T2 = Tuple.Create(late, absenses + 1, day + 1);
                    if (!prizeStringDict.ContainsKey(T2))
                        prizeStringDict[T2] = getPrizeStringCount(s.Append("O"), late, absenses + 1, day + 1);
                    Tuple<bool, int, int> T3 = Tuple.Create(!late, 0, day + 1);
                    if (!prizeStringDict.ContainsKey(T3))
                        prizeStringDict[T3] = getPrizeStringCount(s.Append("O"), !late, 0, day + 1);
                    return prizeStringDict[T1] + prizeStringDict[T2] + prizeStringDict[T3];
                }
            }
        }

        /// <summary>
        /// Calculates the number of prize strings that exist over a 30-day period
        /// </summary>
        static void P191()
        {
            Console.WriteLine(getPrizeStringCount(new StringBuilder(), false, 0, 0));
        }
    }
}