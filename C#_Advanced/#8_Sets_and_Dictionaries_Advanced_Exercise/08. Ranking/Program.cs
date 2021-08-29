using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();
            string input;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];

                if (contests.ContainsKey(contest) == false)
                {
                    contests.Add(contest, password);
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contests.ContainsKey(contest) == false ||
                    contests[contest] != password)
                {
                    continue;
                }
                else
                {
                    if (users.ContainsKey(username) == false)
                    {
                        users.Add(username, new Dictionary<string, int>());
                    }

                    if (users[username].ContainsKey(contest) == false)
                    {
                        users[username].Add(contest, 0);
                    }


                    if (users[username][contest] < points)
                    {
                        users[username][contest] = points;
                    }
                }
            }

            int maxPoints = 0;
            string maxUser = string.Empty;

            foreach (var (key, value) in users)
            {
                int current = 0;

                foreach (var item in value)
                {
                    current += item.Value;
                }

                if (maxPoints < current)
                {
                    maxPoints = current;
                    maxUser = key;
                }

            }

            Console.WriteLine($"Best candidate is {maxUser} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var (key, value) in users)
            {
                Console.WriteLine($"{key}");

                foreach (var item in value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
