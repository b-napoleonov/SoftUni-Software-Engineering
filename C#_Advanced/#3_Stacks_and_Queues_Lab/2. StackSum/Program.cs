using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            Stack<int> numbers = new Stack<int>(inputNums.Length);

            for (int i = 0; i < inputNums.Length; i++)
            {
                numbers.Push(inputNums[i]);
            }

            while (command.ToLower() != "end")
            {
                string[] commands = command.Split();
                string opr = commands[0];

                switch (opr.ToLower())
                {
                    case "add":

                        int num1 = int.Parse(commands[1]);
                        int num2 = int.Parse(commands[2]);

                        numbers.Push(num1);
                        numbers.Push(num2);

                        break;

                    case "remove":

                        int num = int.Parse(commands[1]);

                        if (num > numbers.Count)
                        {
                            command = Console.ReadLine();
                            continue;
                        }

                        for (int i = 0; i < num; i++)
                        {
                            int buffer = 0;
                            numbers.TryPop(out buffer);
                        }

                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
