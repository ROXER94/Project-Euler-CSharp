using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the result of the Reverse Polish Notation expression
        /// </summary>
        /// <param name="expression">String[]</param>
        /// <returns>The result of the Reverse Polish Notation expression</returns>
        static double getReversePolishNotation(string[] expression)
        {
            Stack<double> stack = new Stack<double>();
            foreach (string i in expression)
            {
                if (i == "+" || i == "-" || i == "*" || i == "/")
                {
                    if (i == "+")
                    {
                        double a = stack.Pop();
                        double b = stack.Pop();
                        stack.Push(b + a);
                    }
                    else if (i == "-")
                    {
                        double a = stack.Pop();
                        double b = stack.Pop();
                        stack.Push(b - a);
                    }
                    else if (i == "*")
                    {
                        double a = stack.Pop();
                        double b = stack.Pop();
                        stack.Push(b * a);
                    }
                    else if (i == "/")
                    {
                        double a = stack.Pop();
                        double b = stack.Pop();
                        stack.Push(b / a);
                    }
                }
                else stack.Push(Convert.ToDouble(i));
            }
            if (double.IsInfinity(stack.Peek()) || double.IsNaN(stack.Peek()))
                throw new System.ArgumentException("Division by constant zero");
            return stack.Peek();
        }

        /// <summary>
        /// Calculates the set of four distinct digits for which the longest set of consecutive positive integers from 1 to n can be obtained using arithmetic operators
        /// </summary>
        static void P093()
        {
            int ans = 0;
            int limit = 10;
            int consecutiveCount = 0;
            for (int a = 1; a < limit; a++)
                for (int b = a + 1; b < limit; b++)
                    for (int c = b + 1; c < limit; c++)
                        for (int d = c + 1; d < limit; d++)
                        {
                            SortedSet<double> RPN = new SortedSet<double>();
                            foreach (string op1 in new string[] { "+", "-", "*", "/" })
                                foreach (string op2 in new string[] { "+", "-", "*", "/" })
                                    foreach (string op3 in new string[] { "+", "-", "*", "/" })
                                        foreach (var i in Functions.getPermutations(new string[] { a.ToString(), b.ToString(), c.ToString(), d.ToString() }, 4))
                                        {
                                            try { RPN.Add(getReversePolishNotation(new string[] { i.ElementAt(0), i.ElementAt(1), op1, i.ElementAt(2), op2, i.ElementAt(3), op3 })); }
                                            catch { }
                                            try { RPN.Add(getReversePolishNotation(new string[] { i.ElementAt(0), i.ElementAt(1), i.ElementAt(2), op1, op2, i.ElementAt(3), op3 })); }
                                            catch { }
                                            try { RPN.Add(getReversePolishNotation(new string[] { i.ElementAt(0), i.ElementAt(1), op1, i.ElementAt(2), i.ElementAt(3), op2, op3 })); }
                                            catch { }
                                        }
                            RPN.RemoveWhere(n => n <= 0 || n % 1 != 0);
                            double[] rpn = RPN.ToArray();
                            int currentCount = 0;
                            for (int i = 0; i < RPN.Count - 1; i++)
                            {
                                if (rpn[i] + 1 == rpn[i + 1]) currentCount++;
                                else break;
                            }
                            if (currentCount > consecutiveCount)
                            {
                                consecutiveCount = currentCount;
                                ans = 1000 * a + 100 * b + 10 * c + d;
                            }
                        }
            Console.WriteLine(ans);
        }
    }
}