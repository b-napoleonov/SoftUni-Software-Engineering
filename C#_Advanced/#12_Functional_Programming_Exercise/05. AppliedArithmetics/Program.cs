using System;
using System.Linq;

namespace _05._AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int> add = n => n + 1;
            Func<int, int> multiply = n => n * 2;
            Func<int, int> subtract = n => n - 1;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":

                        numbers = numbers.Select(n => add(n)).ToArray();

                        break;

                    case "multiply":

                        numbers = numbers.Select(n => multiply(n)).ToArray();

                        break;

                    case "subtract":

                        numbers = numbers.Select(n => subtract(n)).ToArray();

                        break;

                    case "print":

                        Console.WriteLine(string.Join(' ', numbers));

                        break;
                }
            }
        }
    }
}
