using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._DestinatiM
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"([=/])(?<city>[A-Z][A-Za-z]{2,})\1";

            MatchCollection cities = Regex.Matches(text, pattern);

            List<string> destinations = new List<string>();

            int travelPoints = 0;

            foreach (Match item in cities)
            {
                destinations.Add(item.Groups["city"].Value);

                travelPoints += item.Groups["city"].Value.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");

            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
