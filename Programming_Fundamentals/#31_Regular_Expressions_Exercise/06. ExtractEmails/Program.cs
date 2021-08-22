using System;
using System.Text.RegularExpressions;

namespace _06._ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<=\s)([A-Za-z0-9]+[.\-_]*[A-Za-z0-9]+)@([A-Za-z]+(([-.])*[A-Za-z]+)*\.[a-z]{2,})";

            MatchCollection validEmails = Regex.Matches(input, pattern);

            foreach (Match email in validEmails)
            {
                Console.WriteLine(email.Value);
            }
        }
    }
}
