using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> cities = new Dictionary<string, List<int>>();

            string input = Console.ReadLine();

            while (input != "Sail")
            {
                string[] data = input.Split("||");

                string cityName = data[0];
                int population = int.Parse(data[1]);
                int gold = int.Parse(data[2]);

                if (!cities.ContainsKey(cityName))
                {
                    cities.Add(cityName, new List<int> { population, gold });
                }
                else
                {
                    cities[cityName][0] += population;
                    cities[cityName][1] += gold;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                string[] events = input.Split("=>");
                string command = events[0];

                switch (command)
                {
                    case "Plunder":

                        string plTown = events[1];
                        int people = int.Parse(events[2]);
                        int plGold = int.Parse(events[3]);

                        cities[plTown][0] -= people;
                        cities[plTown][1] -= plGold;

                        Console.WriteLine($"{plTown} plundered! {plGold} gold stolen, {people} citizens killed.");

                        if (cities[plTown][0] <= 0 || cities[plTown][1] <= 0)
                        {
                            cities.Remove(plTown);
                            Console.WriteLine($"{plTown} has been wiped off the map!");
                        }

                        break;

                    case "Prosper":

                        string prTown = events[1];
                        int prGold = int.Parse(events[2]);

                        if (prGold < 0)
                        {
                            Console.WriteLine($"Gold added cannot be a negative number!");
                            input = Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            cities[prTown][1] += prGold;

                            Console.WriteLine($"{prGold} gold added to the city treasury. {prTown} now has {cities[prTown][1]} gold.");
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (var city in cities.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value[0]} citizens, Gold: {city.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
