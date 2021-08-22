using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> languageSubmissions = new SortedDictionary<string, int>();
            SortedDictionary<string, int> usernamePoints = new SortedDictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] arr = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string username = arr[0];
                string language = arr[1];

                if (language != "banned")
                {
                    int points = int.Parse(arr[2]);

                    if (!languageSubmissions.ContainsKey(language))
                    {
                        languageSubmissions.Add(language, 0);
                    }

                    languageSubmissions[language]++;

                    if (!usernamePoints.ContainsKey(username))
                    {
                        usernamePoints.Add(username, 0);
                    }

                    usernamePoints[username] = usernamePoints[username] < points ? points : usernamePoints[username];
                }
                else
                {
                    if (usernamePoints.ContainsKey(username))
                    {
                        usernamePoints.Remove(username);
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Results:");

            foreach (var (key, value) in usernamePoints
                .OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{key} | {value}");
            }

            Console.WriteLine($"Submissions:");

            foreach (var (key, value) in languageSubmissions
                .OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{key} - {value}");
            }
        }
    }
}
