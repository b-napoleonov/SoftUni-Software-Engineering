using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                string delimer = input.Contains('|') ? " | " : " -> ";

                string[] arr = input.Split(delimer, StringSplitOptions.RemoveEmptyEntries);

                switch (delimer)
                {
                    case " | ":

                        string forceSide = arr[0];
                        string forceUser = arr[1];

                        if (!dict.ContainsKey(forceSide))
                        {
                            dict.Add(forceSide, new List<string>());
                        }

                        if (!dict[forceSide].Contains(forceUser) &&
                            !dict.Values.Any(x => x.Contains(forceUser)))
                        {
                            dict[forceSide].Add(forceUser);
                        }

                        break;

                    case " -> ":

                        string user = arr[0];
                        string side = arr[1];

                        foreach (var team in dict)
                        {
                            foreach (var currentUser in team.Value)
                            {
                                if (currentUser == user)
                                {
                                    team.Value.Remove(user);
                                    break;
                                }
                            }
                        }

                        if (!dict.ContainsKey(side))
                        {
                            dict.Add(side, new List<string>());
                        }

                        dict[side].Add(user);

                        Console.WriteLine($"{user} joins the {side} side!");

                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var item in dict
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");

                foreach (var user in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
