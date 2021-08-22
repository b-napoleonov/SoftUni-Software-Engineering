using System;
using System.Text.RegularExpressions;

namespace _01._MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\w+";

            Regex regex = new Regex(pattern);
            var validNames = regex.Matches(names);

            Console.WriteLine(string.Join(' ', validNames));
        }
    }
}
