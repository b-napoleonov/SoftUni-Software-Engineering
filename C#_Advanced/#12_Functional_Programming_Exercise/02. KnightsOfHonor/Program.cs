using System;
using System.Linq;

namespace _02._KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> name = name => Console.WriteLine($"Sir {name}");

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(t => name(t));
        }
    }
}
