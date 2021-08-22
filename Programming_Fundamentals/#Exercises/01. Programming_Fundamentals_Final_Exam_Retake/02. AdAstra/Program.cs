using System;
using System.Text.RegularExpressions;

namespace _02._AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"([|#])(?<itemName>[A-Za-z ]+)\1(?<expDate>[\d]{2}/[\d]{2}/[\d]{2})\1(?<calories>\d+)\1";

            MatchCollection food = Regex.Matches(text, pattern);

            int calories = 0;

            foreach (Match item in food)
            {
                calories += int.Parse(item.Groups["calories"].Value);
            }

            Console.WriteLine($"You have food to last you for: {calories / 2000} days!");

            foreach (Match item in food)
            {
                string foodName = item.Groups["itemName"].Value;
                string expDate = item.Groups["expDate"].Value;
                calories = int.Parse(item.Groups["calories"].Value);

                Console.WriteLine($"Item: {foodName}, Best before: {expDate}, Nutrition: {calories}");
            }
        }
    }
}
