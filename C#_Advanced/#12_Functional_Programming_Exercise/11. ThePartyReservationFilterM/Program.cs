using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._ThePartyReservationFilterM
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] reservations = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<string> filters = new List<string>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Print")
            {
                if (input.Contains("Add"))
                {
                    filters.Add(input.Substring(11, input.Length - 11));
                }
                else
                {
                    filters.Remove(input.Substring(14, input.Length - 14));
                }
            }

            foreach (var filter in filters)
            {
                string[] value = filter.Split(";");

                if (filter.Contains("Starts"))
                {
                    reservations = reservations.Where(r => !r.StartsWith(value[1])).ToArray();
                }
                else if (filter.Contains("Ends"))
                {
                    reservations = reservations.Where(r => !r.EndsWith(value[1])).ToArray();
                }
                else if (filter.Contains("Length"))
                {
                    reservations = reservations.Where(r => r.Length != int.Parse(value[1])).ToArray();
                }
                else if (filter.Contains("Contains"))
                {
                    reservations = reservations.Where(r => !r.Contains(value[1])).ToArray();
                }
            }

            if (reservations.Any())
            {
                Console.WriteLine(string.Join(' ', reservations));
            }
        }
    }
}
