using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._PlantDis
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> plantRarity = new Dictionary<string, double>();
            Dictionary<string, List<double>> plantRating = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] information = Console.ReadLine().Split("<->");
                string plant = information[0];
                double rarity = double.Parse(information[1]);

                if (!plantRarity.ContainsKey(plant))
                {
                    plantRarity.Add(plant, 0);
                    plantRating.Add(plant, new List<double>());

                    plantRarity[plant] = rarity;
                }
            }

            string input = Console.ReadLine();

            while (input != "Exhibition")
            {
                string[] commands = input.Split(": ");
                string command = commands[0];

                switch (command)
                {
                    case "Rate":

                        string[] splitted = commands[1].Split(" - ");
                        string plant = splitted[0];
                        double rating = double.Parse(splitted[1]);

                        if (plantRating.ContainsKey(plant))
                        {
                            plantRating[plant].Add(rating);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }

                        break;

                    case "Update":

                        string[] split = commands[1].Split(" - ");
                        string pl = split[0];
                        double rarity = double.Parse(split[1]);

                        if (plantRarity.ContainsKey(pl))
                        {
                            plantRarity[pl] = rarity;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }

                        break;

                    case "Reset":

                        string p = commands[1];

                        if (plantRating.ContainsKey(p))
                        {
                            plantRating[p].Clear();
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Plants for the exhibition:");

            foreach (var (key, value) in plantRarity.OrderByDescending(x => x.Value))
            {
                double average = plantRating[key].Count > 0 ? plantRating[key].Average() : 0;

                Console.WriteLine($"- {key}; Rarity: {plantRarity[key]}; Rating: {average:F2}");
            }
        }
    }
}
