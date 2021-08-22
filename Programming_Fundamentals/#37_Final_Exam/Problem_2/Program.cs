using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counter = 0;
            string pattern = @"U\$(?<username>[A-Z][a-z]{2,})U\$P@\$(?<password>[A-Za-z]{5,}[0-9]{1,})P@\$";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    Console.WriteLine("Registration was successful");

                    Console.WriteLine($"Username: {match.Groups["username"].Value}, Password: {match.Groups["password"].Value}");

                    counter++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {counter}");
        }
    }
}
