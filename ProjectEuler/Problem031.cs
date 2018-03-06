using System;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of different ways £2 can be made using 1p, 2p, 5p, 10p, 20p, 50p, £1 and £2
        /// </summary>
        static void P031()
        {
            int ans = 1;
            for (int pound = 0; pound <= 2; pound++)
            {
                for (int pence50 = 0; pence50 <= 4; pence50++)
                {
                    if (100 * pound + 50 * pence50 > 200) break;
                    for (int pence20 = 0; pence20 <= 10; pence20++)
                    {
                        if (100 * pound + 50 * pence50 + 20 * pence20 > 200) break;
                        for (int pence10 = 0; pence10 <= 20; pence10++)
                        {
                            if (100 * pound + 50 * pence50 + 20 * pence20 + 10 * pence10 > 200) break;
                            for (int pence5 = 0; pence5 <= 40; pence5++)
                            {
                                if (100 * pound + 50 * pence50 + 20 * pence20 + 10 * pence10 + 5 * pence5 > 200) break;
                                for (int pence2 = 0; pence2 <= 100; pence2++)
                                {
                                    if (100 * pound + 50 * pence50 + 20 * pence20 + 10 * pence10 + 5 * pence5 + 2 * pence2 > 200) break;
                                    for (int pence = 0; pence <= 200;)
                                    {
                                        if (100 * pound + 50 * pence50 + 20 * pence20 + 10 * pence10 + 5 * pence5 + 2 * pence2 + pence > 200) break;
                                        ans++;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(ans);
        }
    }
}