using System;
using System.Collections.Generic;

namespace _03._HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> names = new List<string>(numberOfCommands);

            for (int i = 0; i < numberOfCommands; i++)
            {
                string input = Console.ReadLine();
                string name = input.Split()[0];
                string command = input.Split()[2];

                switch (command)
                {
                    case "going!":
                        if (!names.Contains(name))
                        {
                            names.Add(name);
                        }
                        else
                        {
                            Console.WriteLine($"{name} is already in the list!");
                        }
                        break;
                    case "not":
                        if (names.Contains(name))
                        {
                            names.Remove(name);
                        }
                        else
                        {
                            Console.WriteLine($"{name} is not in the list!");
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join("\n", names));
        }
    }
}