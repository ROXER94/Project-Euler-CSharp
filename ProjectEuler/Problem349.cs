using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Calculates the number of squares that are black after 10^18 moves of Langton's Ant
        /// </summary>
        static void P349()
        {
            int n = 9984;
            Tuple<int, int> coordinate = Tuple.Create(0, 0);
            string direction = "up";
            IDictionary<Tuple<int, int>, int> d = new Dictionary<Tuple<int, int>, int>();
            for (int i = 0; i < n; i++)
            {
                try
                {
                    if (d[coordinate] == 0)
                    {
                        d[coordinate] = 1;
                        if (direction == "up")
                        {
                            direction = "right";
                            coordinate = Tuple.Create(coordinate.Item1 + 1, coordinate.Item2);
                        }
                        else if (direction == "right")
                        {
                            direction = "down";
                            coordinate = Tuple.Create(coordinate.Item1, coordinate.Item2 - 1);
                        }
                        else if (direction == "down")
                        {
                            direction = "left";
                            coordinate = Tuple.Create(coordinate.Item1 - 1, coordinate.Item2);
                        }
                        else
                        {
                            direction = "up";
                            coordinate = Tuple.Create(coordinate.Item1, coordinate.Item2 + 1);
                        }
                    }
                    else
                    {
                        d[coordinate] = 0;
                        if (direction == "up")
                        {
                            direction = "left";
                            coordinate = Tuple.Create(coordinate.Item1 - 1, coordinate.Item2);
                        }
                        else if (direction == "right")
                        {
                            direction = "up";
                            coordinate = Tuple.Create(coordinate.Item1, coordinate.Item2 + 1);
                        }
                        else if (direction == "down")
                        {
                            direction = "right";
                            coordinate = Tuple.Create(coordinate.Item1 + 1, coordinate.Item2);
                        }
                        else
                        {
                            direction = "down";
                            coordinate = Tuple.Create(coordinate.Item1, coordinate.Item2 - 1);
                        }
                    }
                }
                catch
                {
                    d[coordinate] = 1;
                    if (direction == "up")
                    {
                        direction = "right";
                        coordinate = Tuple.Create(coordinate.Item1 + 1, coordinate.Item2);
                    }
                    else if (direction == "right")
                    {
                        direction = "down";
                        coordinate = Tuple.Create(coordinate.Item1, coordinate.Item2 - 1);
                    }
                    else if (direction == "down")
                    {
                        direction = "left";
                        coordinate = Tuple.Create(coordinate.Item1 - 1, coordinate.Item2);
                    }
                    else
                    {
                        direction = "up";
                        coordinate = Tuple.Create(coordinate.Item1, coordinate.Item2 + 1);
                    }
                }
            }
            Console.WriteLine((long)(d.Values.Sum() + (Math.Pow(10, 18) - n) / 104 * 12) - 8);
        }
    }
}