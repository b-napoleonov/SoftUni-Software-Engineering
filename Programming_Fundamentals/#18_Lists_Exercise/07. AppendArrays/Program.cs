using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToList();

            List<string> final = new List<string>(list.Count);

            foreach (var item in list)
            {
                final.AddRange(item.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList());
            }

            Console.WriteLine(string.Join(' ', final));
        }
    }
}
