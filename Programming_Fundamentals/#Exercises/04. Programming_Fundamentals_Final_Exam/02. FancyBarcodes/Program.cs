using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._FancyBarco
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"^@#+([A-Z][A-Za-z0-9]{4,}[A-Z])@#+$";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match barcode = Regex.Match(input, pattern);

                if (!barcode.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                StringBuilder numbers = new StringBuilder();

                for (int j = 0; j < barcode.Length; j++)
                {
                    if (char.IsDigit(barcode.Value[j]))
                    {
                        numbers.Append(barcode.Value[j]);
                    }
                }

                if (numbers.Length > 0)
                {
                    Console.WriteLine($"Product group: {numbers}");
                }
                else
                {
                    Console.WriteLine("Product group: 00");
                }
            }
        }
    }
}
