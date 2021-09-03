using System;
using System.Linq;

namespace _03._CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isUpprer = l => char.IsUpper(l[0]);

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(l => isUpprer(l))
                .ToList()
                .ForEach(l => Console.WriteLine(l));
        }
    }
}
