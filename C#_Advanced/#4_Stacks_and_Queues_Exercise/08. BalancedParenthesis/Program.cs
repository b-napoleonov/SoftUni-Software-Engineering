using System;
using System.Collections.Generic;

namespace _08._BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> parentheses = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                switch (current)
                {
                    case '(':

                        parentheses.Push(current);

                        break;

                    case '[':

                        parentheses.Push(current);

                        break;

                    case '{':

                        parentheses.Push(current);

                        break;

                    case ')':

                        if (parentheses.Count == 0)
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        else
                        {
                            if (parentheses.Peek() == '(')
                            {
                                parentheses.Pop();
                            }
                            else
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                        }

                        break;

                    case ']':

                        if (parentheses.Count == 0)
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        else
                        {
                            if (parentheses.Peek() == '[')
                            {
                                parentheses.Pop();
                            }
                            else
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                        }

                        break;

                    case '}':

                        if (parentheses.Count == 0)
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        else
                        {
                            if (parentheses.Peek() == '{')
                            {
                                parentheses.Pop();
                            }
                            else
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                        }

                        break;
                }
            }

            if (parentheses.Count != 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
