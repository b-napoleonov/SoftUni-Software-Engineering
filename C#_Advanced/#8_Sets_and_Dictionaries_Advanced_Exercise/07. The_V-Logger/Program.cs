using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vLogger =
                new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            string input;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string vloggerName = tokens[0];
                string command = tokens[1];

                switch (command)
                {
                    case "joined":

                        if (vLogger.ContainsKey(vloggerName) == false)
                        {
                            vLogger.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                            vLogger[vloggerName].Add("following", new SortedSet<string>());
                            vLogger[vloggerName].Add("followers", new SortedSet<string>());
                        }

                        break;

                    case "followed":

                        string followName = tokens[2];

                        if (!vLogger.ContainsKey(vloggerName) ||
                            !vLogger.ContainsKey(followName) ||
                            vloggerName == followName ||
                            vLogger[vloggerName]["following"].Any(x => x == followName))
                        {
                            continue;
                        }

                        vLogger[vloggerName]["following"].Add(followName);
                        vLogger[followName]["followers"].Add(vloggerName);

                        break;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vLogger.Count} vloggers in its logs.");

            int counter = 1;

            foreach (var vloggers in vLogger.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
            {
                if (vloggers.Value["followers"].Count != 0 && counter == 1)
                {
                    Console.WriteLine($"{counter}. {vloggers.Key} : {vloggers.Value["followers"].Count} followers, {vloggers.Value["following"].Count} following");

                    foreach (var item in vloggers.Value["followers"])
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }
                else
                {
                    Console.WriteLine($"{counter}. {vloggers.Key} : {vloggers.Value["followers"].Count} followers, {vloggers.Value["following"].Count} following");
                }
                counter++;
            }
        }
    }
}
