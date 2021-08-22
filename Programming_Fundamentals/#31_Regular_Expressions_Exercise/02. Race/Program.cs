using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();

            List<string> list = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var name in list)
            {
                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, 0);
                }
            }

            Regex regex = new Regex(@"\w");
            string input = Console.ReadLine();

            while (input != "end of race")
            {
                var matchedchars = regex.Matches(input);

                StringBuilder personName = new StringBuilder();
                double distance = 0;

                foreach (Match item in matchedchars)
                {
                    if (char.IsLetter(item.Value[0]))
                    {
                        personName.Append(item.Value);
                    }
                    else if (char.IsDigit(item.Value[0]))
                    {
                        distance += double.Parse(item.Value);
                    }
                }

                if (dict.ContainsKey(personName.ToString()))
                {
                    dict[personName.ToString()] += distance;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"1st place: {dict.OrderByDescending(x => x.Value).ElementAt(0).Key}");
            Console.WriteLine($"2nd place: {dict.OrderByDescending(x => x.Value).ElementAt(1).Key}");
            Console.WriteLine($"3rd place: {dict.OrderByDescending(x => x.Value).ElementAt(2).Key}");
        }
    }
}
