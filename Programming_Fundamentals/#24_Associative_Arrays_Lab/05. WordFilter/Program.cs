using System;
using System.Linq;

namespace _05._WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.Length % 2 == 0)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
