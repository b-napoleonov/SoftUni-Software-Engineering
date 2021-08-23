using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> brackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    brackets.Push(i);
                }
                else if (input[i] == ')')
                {
                    int start = brackets.Pop();
                    string sub = input.Substring(start, i - start + 1);
                    Console.WriteLine(sub);
                }
            }
        }
    }
}
