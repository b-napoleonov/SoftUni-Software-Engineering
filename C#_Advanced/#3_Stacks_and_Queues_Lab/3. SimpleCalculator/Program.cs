using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> numbers = new Stack<string>(Console.ReadLine().Split().Reverse());

            while (numbers.Count > 1)
            {
                int num1 = int.Parse(numbers.Pop());
                char symbol = char.Parse(numbers.Pop());
                int num2 = int.Parse(numbers.Pop());

                switch (symbol)
                {
                    case '+':

                        numbers.Push((num1 + num2).ToString());

                        break;

                    case '-':

                        numbers.Push((num1 - num2).ToString());

                        break; 
                }
            }

            Console.WriteLine(numbers.Pop());
        }
    }
}
