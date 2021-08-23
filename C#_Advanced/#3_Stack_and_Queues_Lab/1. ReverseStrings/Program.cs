using System;
using System.Collections.Generic;

namespace _1._ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> symbols = new Stack<char>(input);
            char symbol;

            while (symbols.TryPop(out symbol))
            {
                Console.Write(symbol);
            }
        }
    }
}
