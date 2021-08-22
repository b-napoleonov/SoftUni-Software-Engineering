using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d+(\.\d+)?)!(?<quantity>\d+)";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            List<string> list = new List<string>();
            double totalMoney = 0;

            while (input != "Purchase")
            {
                MatchCollection validInput = regex.Matches(input);

                if (validInput.Count > 0)
                {

                    foreach (Match item in validInput)
                    {
                        string name = item.Groups["name"].Value;
                        double price = double.Parse(item.Groups["price"].Value);
                        int quantity = int.Parse(item.Groups["quantity"].Value);

                        list.Add(name);

                        totalMoney += price * quantity;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");

            if (list.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, list));
            }

            Console.WriteLine($"Total money spend: {totalMoney:F2}");
        }
    }
}
