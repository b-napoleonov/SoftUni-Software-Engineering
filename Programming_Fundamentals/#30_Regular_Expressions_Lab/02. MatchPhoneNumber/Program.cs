using System;
using System.Text.RegularExpressions;

namespace _02._MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string phones = Console.ReadLine();
            string pattern = @"\+359( |-)2\1\d{3}\1\d{4}\b";

            Regex regex = new Regex(pattern);
            var matchedPhones = regex.Matches(phones);

            Console.WriteLine(string.Join(", ", matchedPhones));

        }
    }
}
