using System;
using System.Collections.Generic;

namespace _05._SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> dict = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];
                string name = input[1];

                switch (command)
                {
                    case "register":

                        string plateNumber = input[2];

                        if (dict.ContainsKey(name))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {dict[name]}");
                        }
                        else
                        {
                            dict.Add(name, plateNumber);
                            Console.WriteLine($"{name} registered {plateNumber} successfully");
                        }
                        break;

                    case "unregister":

                        if (!dict.ContainsKey(name))
                        {
                            Console.WriteLine($"ERROR: user {name} not found");
                        }
                        else
                        {
                            dict.Remove(name);
                            Console.WriteLine($"{name} unregistered successfully");
                        }
                        break;
                }
            }

            foreach (var (key, value) in dict)
            {
                Console.WriteLine($"{key} => {value}");
            }
        }
    }
}
