using System;
using System.Globalization;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of Sundays that fell on the first of the month between January 1st, 1901 and December 31st, 2000
        /// </summary>
        static void P019()
        {
            int ans = 0;
            Calendar calendar = CultureInfo.InvariantCulture.Calendar;
            for (int y = 1901; y <= 2000; y++)
                for (int m = 1; m <= 12; m++)
                    if (calendar.GetDayOfWeek(new DateTime(y, m, 1)) == DayOfWeek.Sunday)
                        ans++;
            Console.WriteLine(ans);
        }
    }
}