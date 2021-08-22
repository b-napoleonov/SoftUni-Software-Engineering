using System;
using System.Text.RegularExpressions;

namespace _03._SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+(?:[.]\d+)?)\$";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            double totalIncome = 0;

            while (input != "end of shift")
            {
                if (regex.IsMatch(input))
                {
                    var validOrder = regex.Match(input);

                    string name = validOrder.Groups["name"].Value;
                    string product = validOrder.Groups["product"].Value;
                    int.TryParse(validOrder.Groups["count"].Value, out int count);
                    double.TryParse(validOrder.Groups["price"].Value, out double price);

                    double income = count * price;
                    totalIncome += income;

                    Console.WriteLine($"{name}: {product} - {income:F2}");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
