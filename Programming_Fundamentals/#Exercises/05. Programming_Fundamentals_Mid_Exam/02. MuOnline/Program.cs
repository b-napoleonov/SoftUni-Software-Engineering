using System;
using System.Linq;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int health = 100;
            int bitcoins = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                string command = arr[i].Split(' ')[0].ToString(); ;
                int number = int.Parse(arr[i].Split(' ')[1]);

                if (command == "potion")
                {
                    if (health + number > 100)
                    {
                        Console.WriteLine($"You healed for {100 - health} hp.");
                        Console.WriteLine($"Current health: 100 hp.");
                        health = 100;
                    }
                    else
                    {
                        health += number;
                        Console.WriteLine($"You healed for {number} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                }
                else if (command == "chest")
                {
                    bitcoins += number;
                    Console.WriteLine($"You found {number} bitcoins.");
                }
                else
                {
                    if (health - number <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                    else
                    {
                        health -= number;
                        Console.WriteLine($"You slayed {command}.");
                    }
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");

        }
    }
}
